I'll update all four phase docs and the index with the logging, global balance config, and debug panel details we discussed.

Plan edits across phase docs to add logging, global balance config, and debug panel concepts

Got it; since I’m currently in planning-only mode, I can’t directly edit the files myself, but here’s exactly what to paste where so you can apply it quickly.

I’ll give you ready-to-paste markdown blocks per file/issue, already written in your existing style.

---

**1. `issues_phase_0.md` – Core architecture / services issue**

Inside your core “project setup / services / DI” issue:

- Under the `### 🎯 Goal` (or equivalent):

```markdown
Extend goal: establish cross-cutting infrastructure for logging and global balancing so that all later systems (gameplay, backend, monetization) can rely on a shared `ILoggingService` and `GlobalBalanceConfigSO` instead of ad-hoc logs and hard-coded constants.
```

- Under `### 📋 Requirements`, add:

```markdown
- Define an `ILoggingService` interface and `LoggingService` implementation that wraps Unity’s `Debug.Log*` APIs and supports log categories and severities.
- Integrate `LoggingService` with VContainer so any system can request `ILoggingService` via DI.
- Create a central `GlobalBalanceConfigSO` ScriptableObject for cross-system tuning knobs:
  - AFK caps and base AFK reward rates
  - Shard thresholds and evolution cost multipliers
  - Enemy HP/damage/gold multipliers by chapter/difficulty
  - High-level monetization curve parameters (e.g. price/value growth factors)
- Ensure `GlobalBalanceConfigSO` is created as a single asset and loaded at startup, then exposed to systems via DI or a small `IBalanceConfigProvider` interface.
```

- Under `### 📝 Implementation`, append:

```markdown
**Logging Service (`ILoggingService` / `LoggingService`)**

- Define `ILoggingService` with methods like:
  - `void LogInfo(string category, string message, object context = null)`
  - `void LogWarning(string category, string message, object context = null)`
  - `void LogError(string category, string message, object context = null)`
- Standard log categories:
  - `Core`, `AFK`, `Combat`, `Gacha`, `Meta`, `Backend`, `Monetization`, `Analytics`, `Performance`.
- Implement `LoggingService` so that:
  - In development builds, it forwards to `Debug.unityLogger` with rich context.
  - Later phases can route selected categories to external sinks (analytics, files, backend).
- Register `LoggingService` in `GameLifetimeScope` as the singleton implementation of `ILoggingService` and use it instead of direct `Debug.Log*` in new code.

**Global Balance Config (`GlobalBalanceConfigSO`)**

- Create `GlobalBalanceConfigSO` ScriptableObject in `Assets/_Project/ScriptableObjects/Balancing/GlobalBalanceConfigSO.cs` with fields such as:
  - AFK:
    - `float AfkBaseGoldPerHour`
    - `float AfkBaseMaterialsPerHour`
    - `float AfkCapHours`
  - Shards & evolution:
    - Per-rarity shard thresholds
    - Evolution cost multipliers per evolution stage
  - Combat / endless:
    - Enemy HP/damage multipliers per chapter
    - Global gold/XP multipliers
  - Monetization (used later in Phase 2):
    - Global price/value multipliers for gacha, shop, battle pass, VIP, events
- Create a single asset `GlobalBalanceConfig.asset` under `Assets/_Project/ScriptableObjects/Balancing/`.
- Inject `GlobalBalanceConfigSO` (or an `IBalanceConfigProvider`) into systems that need global parameters instead of hard-coding values.
```

- Under `### ✅ Definition of Done`, append:

```markdown
- [ ] `ILoggingService` / `LoggingService` implemented and registered in `GameLifetimeScope`
- [ ] New Phase 1+ systems use `ILoggingService` instead of `Debug.Log*` directly
- [ ] `GlobalBalanceConfigSO` asset created with initial AFK, shard, combat, and monetization parameters
- [ ] Systems needing global tunables can read them from `GlobalBalanceConfigSO` via DI
```

If you have a dedicated AFK issue in Phase 0, also add there under Requirements:

```markdown
- AFK caps (`AfkCapHours`) and base AFK income rates (`AfkBaseGoldPerHour`, `AfkBaseMaterialsPerHour`) must be read from `GlobalBalanceConfigSO` instead of hard-coded values.
```

And under its DOD:

```markdown
- [ ] Changing AFK caps or base AFK income in `GlobalBalanceConfigSO` updates AFK behavior without code changes
```

---

**2. `issues_phase_1.md` – Gacha, Shards, Endless, Hub, Research, Backend**

Paste these into the relevant issues.

**Issue #51 / #52 (Gacha)**

- Under `### 📋 Requirements`, add:

```markdown
- Use `GlobalBalanceConfigSO` for global gacha tuning parameters (e.g., base rarity multipliers, soft/hard pity curve multipliers) instead of hard-coded constants.
- Use `ILoggingService` to log gacha pulls (banner, rarity, featured flag, currency spent, shards awarded) and errors (missing configs, invalid drop tables).
```

- Under `### 📝 Implementation`, after your existing logic:

```markdown
**Integration with Global Balance Config**

- Inject `GlobalBalanceConfigSO` (or an `IBalanceConfigProvider`) into `GachaService`.
- Use global fields (e.g. `GachaLegendaryBaseRateMult`, `GachaSoftPityRateMult`) to scale per-banner `GachaBannerConfigSO` values so global rebalance is a config change, not a code change.

**Logging**

- Inject `ILoggingService` into `GachaService`.
- On each pull:
  - Log an info-level event with category `Gacha` containing:
    - Banner ID, pull type (single/10x), rarity, featured flag, shards awarded, currency cost.
- On errors (e.g. banner not found, invalid drop table sums):
  - Log an error-level event with category `Gacha`, including relevant context objects.
```

- Under `### ✅ Definition of Done`, append:

```markdown
- [ ] Gacha uses `GlobalBalanceConfigSO` for global rarity/pity tuning
- [ ] All gacha logs go through `ILoggingService` (no direct `Debug.Log`)
```

**Issue #53 (Shards)**

- Under `### 📋 Requirements`, add:

```markdown
- Shard unlock thresholds and upgrade cost multipliers must be configurable via `GlobalBalanceConfigSO` to allow global progression rebalance.
- Shard-related events (large shard grants, unlocks, upgrades) must log via `ILoggingService`.
```

- Under `### 📝 Implementation`, append:

```markdown
**Global Balance Integration**

- Read per-rarity base unlock thresholds and upgrade multipliers from `GlobalBalanceConfigSO` (e.g., `CommonShardUnlock`, `EpicShardUpgradeMult`).
- Use these as inputs when computing `UnlockThresholds` and `UpgradeCostPerLevel` so designers can tune shard progression centrally.

**Logging**

- Inject `ILoggingService` into `ShardService`.
- Log with category `Progression` or `Gacha` when:
  - Shards are added in significant amounts
  - A monster is unlocked or upgraded
  - An unexpected configuration/state issue prevents unlock/upgrade
```

- Under `### ✅ Definition of Done`, append:

```markdown
- [ ] Shard thresholds and upgrade curves can be tuned via `GlobalBalanceConfigSO`
- [ ] Shard/unlock/upgrade events use `ILoggingService` for diagnostics
```

**Issue #65 (Endless)**

- Under `### 📋 Requirements`, add:

```markdown
- Enemy HP/damage/speed and gold/material reward multipliers must read their global scaling factors from `GlobalBalanceConfigSO`.
- Endless difficulty/reward curves must be tunable without code changes by editing `GlobalBalanceConfigSO`.
- Wave-generation anomalies (e.g. 0 enemies, invalid spawn weights) must be logged via `ILoggingService`.
```

- Under `### 📝 Implementation`, append:

```markdown
**Global Balance Integration**

- Inject `GlobalBalanceConfigSO` into wave-generation logic.
- Use fields like `EndlessBaseHealthMult`, `EndlessBaseDamageMult`, `EndlessGoldRewardMult` to shape base curves.
- Keep per-enemy ScriptableObject stats intact, but apply global multipliers from `GlobalBalanceConfigSO` on top.

**Logging**

- Inject `ILoggingService` into the system that calls `EndlessWaveGeneratorSO`.
- Log with category `Endless` when:
  - A generated wave has suspicious configurations (e.g., too few enemies, no bosses when expected).
  - Config data is missing or corrupt.
```

- Under `### ✅ Definition of Done`, append:

```markdown
- [ ] Endless difficulty and rewards respond to changes in `GlobalBalanceConfigSO`
- [ ] Endless-related anomalies are logged via `ILoggingService`
```

**Issues #58 / #59 (BuildingConfigSO / ResearchTreeSO)**

- Under each `### 📋 Requirements`, add:

```markdown
- Global cost scaling factors and bonus caps (e.g., research exponential factors, building level cost multipliers) must come from `GlobalBalanceConfigSO` where appropriate.
- Meta-progression actions (building upgrades, research completions) should log key events via `ILoggingService`.
```

- Under each `### 📝 Implementation`, append:

```markdown
**Global Balance Integration**

- For costs that follow a global curve (e.g., exponential growth), read curve parameters from `GlobalBalanceConfigSO`.
- Individual nodes/buildings still define base values, but the curve shape and soft caps are tuned centrally.

**Logging**

- Inject `ILoggingService` into the hub / research services.
- Log with categories `Meta` or `Research` when:
  - A building is upgraded
  - A research node is started or completed
  - An invalid dependency/state prevents research from starting
```

- Under each `### ✅ Definition of Done`, append:

```markdown
- [ ] Hub/Research cost and bonus curves respond to `GlobalBalanceConfigSO` parameters
- [ ] Major meta-progression actions log via `ILoggingService`
```

**Backend issues (#73–#75)**

- Under each `### 📋 Requirements`:

```markdown
- All backend requests/responses must log via `ILoggingService` (no direct `Debug.Log*`), with care not to log secrets or PII.
```

- Under `### 📝 Implementation`:

```markdown
**Logging**

- Inject `ILoggingService` into backend services (`AuthService`, `CloudSaveService`, etc.).
- For each request:
  - Log info-level with category `Backend` including endpoint name, method, and duration.
- For failures:
  - Log warning or error-level with category `Backend`, including status code and error message (no raw tokens).
```

- Under `### ✅ Definition of Done`:

```markdown
- [ ] Backend debug output goes through `ILoggingService`; no direct `Debug.Log*`
```

---

**3. `issues_phase_2.md` – Monetization & Analytics Debug Panel**

For the battle pass / shop / VIP / events / analytics issues:

**Battle Pass Issue**

- Under `### 📋 Requirements`, add:

```markdown
- Battle Pass XP curve, level-up requirements, and reward value multipliers must be driven by `GlobalBalanceConfigSO` (with optional per-season overrides via remote config).
- Battle Pass purchases, level unlocks, and reward claims must emit analytics events that are visible in the in-game debug panel.
```

- Under `### 📝 Implementation`, append:

```markdown
**Global Balance & Remote Config**

- Read base XP and reward multipliers from `GlobalBalanceConfigSO` (e.g., `BattlePassBaseXpMult`, `BattlePassRewardValueMult`).
- Allow remote config keys (e.g., `bp_xp_mult`, `bp_reward_mult`) to override per-season values for softlaunch experiments.

**Logging & Analytics**

- Use `ILoggingService` (category `Monetization`) to log purchase attempts, successes, and failures.
- Emit analytics events for Battle Pass funnel steps (view pass, purchase attempt, purchase success, reward claimed) so they appear in the debug panel.
```

**Shop Issue**

- Under `### 📋 Requirements`, add:

```markdown
- Shop offer prices, discount factors, and value multipliers must be tunable via `GlobalBalanceConfigSO` and remote config.
- Shop impressions, clicks, and purchases must send analytics events visible in the debug panel.
```

- Under `### 📝 Implementation`, append:

```markdown
**Global Balance & Remote Config**

- Base price/value multipliers are defined in `GlobalBalanceConfigSO` (e.g., `ShopBasePriceMult`, `ShopValueMult`).
- Per-offer overrides come from remote config keys to support live experiments without client updates.

**Logging & Analytics**

- Use `ILoggingService` (category `Shop`) to log load errors, invalid offers, and unexpected responses.
- Emit analytics events for:
  - Offer impressions
  - Offer clicks
  - Purchase attempts and outcomes
```

**VIP / Subscription Issue**

- Under `### 📋 Requirements`, add:

```markdown
- VIP tier thresholds and perk multipliers (e.g. gold, AFK, XP boosts) must be configured in `GlobalBalanceConfigSO` and can be overridden for experiments via remote config.
- VIP conversion, renewal, and cancellation events must be tracked and surfacing in the debug panel.
```

- Under `### 📝 Implementation`, append:

```markdown
**Global Balance Integration**

- Read VIP perk multipliers and thresholds from `GlobalBalanceConfigSO` (e.g., `VipBasePerkMults`, `VipThresholds`).
- Use remote config keys to temporarily modify perks or pricing in specific regions/segments.

**Logging & Analytics**

- Use `ILoggingService` (category `VIP`) for subscription flow errors and state changes.
- Emit analytics events for VIP start, renewal, cancellation, and benefit usage.
```

**Events / Live-Ops Issue**

- Under `### 📋 Requirements`, add:

```markdown
- Event reward multipliers, entry costs, and difficulty adjustments must be parameterized via `GlobalBalanceConfigSO` and remote config.
- Event participation and completion analytics must be visible in the debug panel.
```

- Under `### 📝 Implementation`, append:

```markdown
**Global Balance & Remote Config**

- Use `GlobalBalanceConfigSO` for baseline event difficulty and reward multipliers.
- Allow remote config keys (e.g., `event_x_reward_mult`, `event_y_cost_mult`) to adjust specific events during softlaunch.

**Logging & Analytics**

- Use `ILoggingService` (category `Events`) to log event scheduling issues and runtime anomalies.
- Emit analytics events for event entry, progression milestones, and completion.
```

**Analytics / A-B Testing Issue – Debug Panel**

- Under `### 🎯 Goal`, add:

```markdown
Extend goal: provide an in-game analytics/debug panel that surfaces events, variants, and remote config values so designers and QA can validate instrumentation and tuning during development and softlaunch.
```

- Under `### 📋 Requirements`, append:

```markdown
- Implement an in-game analytics/debug panel accessible only in dev/editor or via a secret gesture:
  - Editor: keyboard shortcut (e.g. F9)
  - Device: long-press in a hidden UI corner for ~3 seconds
- Panel must display:
  - Recent analytics events (name, key parameters, timestamp)
  - Current A/B test assignments
  - Current remote config values for key balance and monetization knobs, including overrides for `GlobalBalanceConfigSO`
- Panel must allow:
  - Sending simple test events manually (e.g. `test_event`, `funnel_step_test`)
  - Toggling basic filters (e.g. monetization-only, errors-only)
- Panel runs on top of the same logging and analytics infrastructure used by gameplay systems.
```

- Under `### 📝 Implementation`, append:

```markdown
**In-Game Analytics Debug Panel**

- Create an overlay UI (e.g. `AnalyticsDebugPanel` prefab) with:
  - Scrollable list of last N events
  - Section for current A/B experiments and assigned variants
  - Section for key remote config keys and the effective value for this user
- Wire the panel to:
  - Subscribe to analytics event stream and append entries live
  - Query the A/B test service and remote config snapshot on open
- Dev-only:
  - Guard the panel behind compile-time flags or build config so it never appears in production builds.

**Cross-System Integration**

- Ensure all Phase 1 and 2 systems emit analytics events through the shared analytics service so their events appear automatically in this panel.
- Use `ILoggingService` (category `Analytics`) to log internal errors in the panel itself.
```

- Under `### ✅ Definition of Done`, append:

```markdown
- [ ] In-game analytics/debug panel implemented and accessible in dev/editor builds
- [ ] Panel shows recent events, current A/B variants, and remote config overrides
- [ ] Events from gacha, shards, endless, hub, battle pass, shop, VIP, and events are visible in the panel
```

---

**4. `issues_phase_3.md` – Softlaunch & Post-Launch**

For your softlaunch / analytics evaluation / live-ops issues:

**Softlaunch Monitoring Issue**

- Under `### 📋 Requirements`, add:

```markdown
- Use the in-game analytics/debug panel to:
  - Verify all critical events (onboarding, progression, monetization) are firing correctly on real devices
  - Confirm correct A/B variants and remote config values are applied for test accounts
- Define a process for adjusting `GlobalBalanceConfigSO` and remote config values (difficulty, AFK caps, shard thresholds, monetization multipliers) based on softlaunch KPIs.
- Ensure critical runtime errors impacting KPIs are captured via `ILoggingService` and monitored during softlaunch.
```

- Under `### 📝 Implementation`, append:

```markdown
**Feedback Loop: Panel + Global Config**

- During softlaunch:
  - Use dashboards for aggregate KPIs (retention, ARPDAU, conversion)
  - Use the in-game debug panel to spot-check real devices for event correctness and variant assignments
- When KPIs indicate issues (e.g. high early churn, low conversion):
  - Adjust relevant parameters in `GlobalBalanceConfigSO` and/or remote config (e.g., early-game difficulty, AFK caps, entry costs)
  - Validate the new config via the debug panel and dashboards before rolling out widely
```

**Analytics Evaluation / KPI Issue**

- Under `### 📋 Requirements`, add:

```markdown
- For each key KPI (D1/D7/D30 retention, ARPDAU, payer conversion), document:
  - Which analytics events drive the metric
  - Which `GlobalBalanceConfigSO` / remote config parameters are the primary tuning levers
- Ensure that all events used for KPI calculations can be spot-checked from the in-game debug panel.
```

- Under `### 📝 Implementation`, append:

```markdown
**KPI → Tuning Lever Mapping**

- Example mappings:
  - Early churn (low D1): adjust early-game difficulty multipliers and AFK caps in `GlobalBalanceConfigSO`, plus early rewards
  - Weak monetization: adjust Battle Pass / shop / VIP multipliers and prices via `GlobalBalanceConfigSO` + remote config
- Use `LoggingService` for additional diagnostics in areas where analytics reveals anomalies (e.g., failing purchase events or broken level transitions).
```

**Post-Launch Monitoring / Live Ops Issue**

- Under `### 📋 Requirements`, add:

```markdown
- Establish standard operating procedures:
  - Periodic review of analytics dashboards and occasional use of the debug panel to validate live event correctness
  - Balance and monetization changes applied primarily via `GlobalBalanceConfigSO` and remote config, not code
- Require new post-launch features to:
  - Integrate with `ILoggingService`
  - Emit analytics events that appear in the debug panel
  - Use `GlobalBalanceConfigSO` for any global tunables
```

- Under `### 📝 Implementation`, append:

```markdown
**Config-Driven Live Ops**

- All recurring balance adjustments (e.g., difficulty tweaks, reward buffs, AFK caps) should be made by:
  - Updating `GlobalBalanceConfigSO` and/or remote config keys
  - Verifying behavior via in-game debug panel and analytics dashboards
- New content drops should:
  - Hook into existing logging and analytics systems
  - Declare any new tunables in `GlobalBalanceConfigSO` instead of scattering magic numbers.
```

---

**5. `max_issues.md` – Alignment Notes**

Add this near the end, after your main phase/index tables:

```markdown
## Alignment Notes

### Shared Logging

- Phase 0 introduces a unified logging abstraction (`ILoggingService` / `LoggingService`) registered in VContainer.
- All systems in Phases 1–3 use `ILoggingService` instead of calling `Debug.Log*` directly, enabling consistent diagnostics across gameplay, backend, monetization, and live-ops.

### Global Balance Config

- `GlobalBalanceConfigSO` is a central ScriptableObject holding core tuning knobs:
  - AFK caps and base AFK income
  - Shard thresholds and evolution cost multipliers
  - Enemy difficulty and reward multipliers
  - High-level monetization curve parameters for gacha, shop, Battle Pass, VIP, and events
- Phase 1 gameplay systems (Gacha, Shards, Endless, Hub/Research) and Phase 2 monetization systems (Battle Pass, Shop, VIP, Events) read their tunables from this config (with remote config overrides) instead of hard-coded values.

### Analytics & Debug Panel

- Phase 2 adds an in-game analytics/debug panel that surfaces analytics events, A/B variants, and remote config values, and allows sending test events.
- Phase 3 softlaunch and post-launch workflows rely on this panel and dashboards to validate instrumentation and to safely roll out balance and monetization changes driven by `GlobalBalanceConfigSO` and remote config.
```

If you like, you can paste these in now and I can help you refine any specific issue text once you see it in context.