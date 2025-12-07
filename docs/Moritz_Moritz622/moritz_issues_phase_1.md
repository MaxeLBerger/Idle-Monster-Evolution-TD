# Moritz – Phase 1 Issues (Weeks 5–8)

Moritz, Phase 1 is where you extend the **core gameplay** from Phase 0 into a richer meta: Gacha integration, Hub research & upgrades, Endless mode, and first backend hooks (analytics + remote config). You are still the **integration and gameplay glue** between Max’s services and Pharrel’s UI/assets.

This file mirrors the style of your Phase 0 doc: every issue has a clear Goal, Pre-requisites (with blocking notes), Implementation Notes, and a Definition of Done.

---

## Week 5 – Gacha System

### Issue #56 – [UI] Implement Summon screen logic

**Assignee:** @Moritz622  |  **Labels:** phase-1, ui, priority-high  
**GitHub Issue Body (source):** "Implement Summon screen logic."

#### Goal

Make the **Summon screen** actually work: when the player presses **Single Summon** or **10x Summon**, the correct Gacha service should be called, monsters/shards should be granted, and the UI should show the results (cards, rarity shine, etc.).

#### Pre-requisites

- Max:
	- `GachaBannerConfigSO` defines available banners and their drop tables (issue #51).
	- `IGachaService` is implemented and exposes methods like `SummonOnce(banner)` / `SummonTen(banner)` (issue #52).
	- Monster shard / ownership logic is defined (issue #53).
- Pharrel:
	- Summon screen UI prefab is created with banner selector, currency display, Single/10x buttons, and results area (issue #55).
- Status:
	- **Blocked until** `IGachaService` API is stable and the Summon UI prefab exists. You can still wire buttons to placeholder methods and log actions.

#### Implementation Notes

- Create a `SummonScreenController` in `Assets/_Project/Scripts/UI/Summon/` and attach it to the Summon scene/prefab root.
- References:
	- `IGachaService` injected via VContainer.
	- `PlayerDataSO` / currency variables for premium currency balance.
	- UI: banner dropdown or tabs, Single/10x buttons, results grid, and templates for result cards.
- Flow:
	- On open, show current premium currency and currently selected banner.
	- When Single/10x is pressed:
		- Check if the player has enough premium currency; if not, show a "not enough currency" hint.
		- Call the appropriate method on `IGachaService`.
		- Animate the reveal (you may just instantly show cards for now; VFX comes from Max later).
		- Display each result (monster or shard) as a card in the results grid.
	- Update the player’s currency and ownership data based on the service’s return value.
- Keep separation of concerns:
	- Let `IGachaService` handle probabilities and data mutations.
	- Let the controller focus only on **calling the service and visualising results**.

#### Definition of Done

- [ ] Opening the Summon screen shows correct banner and current premium currency.
- [ ] Pressing Single/10x Summon calls into `IGachaService` and produces a list of results.
- [ ] Results are displayed as cards with correct monster/shard info.
- [ ] Premium currency is reduced correctly and never goes negative.
- [ ] Errors (no currency, no connection, etc.) are handled gracefully with UI feedback.

---

## Week 6 – Hub & Meta-Progression

### Issue #62 – [Hub] Implement IResearchService

**Assignee:** @Moritz622  |  **Labels:** phase-1, gameplay, priority-high  
**GitHub Issue Body (source):** "Implement IResearchService."

#### Goal

Provide a **research system backend** that unlocks and upgrades global bonuses (e.g. +damage, +gold gain). The service should read from `ResearchTreeSO`, track what the player has unlocked, and expose methods for the Research UI to buy new nodes.

#### Pre-requisites

- Max:
	- `BuildingConfigSO` and `ResearchTreeSO` ScriptableObjects describe available research nodes and their costs/effects (issues #58, #59).
	- `IResearchService` interface is defined and registered pattern for services is clear.
	- Save data has a place to store unlocked research nodes (e.g. in `PlayerDataSO`, issue #22).
- Pharrel:
	- Research panel UI prefab exists with a tree view or list of research nodes (issue #61).
- Status:
	- **Blocked until** `ResearchTreeSO` and `IResearchService` interface are defined. You can still design the data flow and stub methods.

#### Implementation Notes

- Implement `ResearchService : IResearchService` in `Assets/_Project/Scripts/Core/Meta/` and register it in `GameLifetimeScope`.
- Responsibilities:
	- Hold a reference to `ResearchTreeSO`.
	- Read/write the player’s unlocked research state from `PlayerDataSO`.
	- Provide methods like `bool CanUnlock(nodeId)`, `bool TryUnlock(nodeId)`, and `bool IsUnlocked(nodeId)`.
- Costs and effects:
	- Use the cost defined in `ResearchTreeSO` and check `CurrentGold` or other resources.
	- On unlock, apply effects by updating relevant systems or config modifiers (e.g. global damage multiplier, AFK multiplier).
- Integration with UI:
	- The Research panel will call `GetAllNodes()`, `IsUnlocked(node)`, and `CanUnlock(node)` to render state.
	- On click, it calls `TryUnlock(node)` and then refreshes UI.

#### Definition of Done

- [ ] Unlocking a research node correctly checks prerequisites and cost.
- [ ] When a node is unlocked, its effect is applied and persists via the save system.
- [ ] Research UI can query and display unlocked/locked states through the service.
- [ ] Attempts to unlock without enough resources or missing prerequisites are rejected with a clear reason.

---

### Issue #63 – [Hub] Implement building upgrades

**Assignee:** @Moritz622  |  **Labels:** phase-1, gameplay, priority-high  
**GitHub Issue Body (source):** "Implement building upgrades."

#### Goal

Give Hub buildings (AFK chest, Monster Lab, Research, Summon area, etc.) **upgrade levels** that the player can increase by spending resources, granting additional benefits (e.g. more AFK capacity, extra monster slots, increased research speed).

#### Pre-requisites

- Max:
	- `BuildingConfigSO` describes each building, its upgrade levels, and benefits (issue #58).
	- Save data structure includes building levels per account (issue #22).
- Pharrel:
	- Hub scene redesign includes visible building objects and some UI to display level and an Upgrade button (issue #60).
- Status:
	- **Soft-blocked:** final numbers and balance may change, but you can implement the general upgrade pipeline.

#### Implementation Notes

- Either extend `IResearchService` or introduce an `IBuildingService` – follow whatever Max defines.
- For each building:
	- Store current level in `PlayerDataSO`.
	- Look up level data in `BuildingConfigSO` (costs and benefits).
- Upgrade flow:
	- From Hub UI (building button or panel), call `TryUpgradeBuilding(buildingId)`.
	- Check max level and resource requirements.
	- Deduct resources and increment level if allowed.
	- Apply effects: e.g. update AFK capacity, unlock extra monster slots, etc.
- UI feedback:
	- Show current level, next level preview, cost, and whether upgrade is affordable.

#### Definition of Done

- [ ] Each building shows its current level and upgrade cost in the Hub.
- [ ] Upgrading a building correctly deducts resources and increases its level.
- [ ] Building benefits (e.g. AFK capacity) update immediately and persist across sessions.
- [ ] UI clearly shows when a building is at max level or cannot be upgraded.

---

### Issue #64 – [Account] Implement account level system

**Assignee:** @Moritz622  |  **Labels:** phase-1, gameplay, priority-medium  
**GitHub Issue Body (source):** "Implement account level system."

#### Goal

Track the player’s **overall account level** based on XP gained from battles, quests, and other actions. Account level will be used to gate features (e.g. unlocking new modes) and provide rewards.

#### Pre-requisites

- Max:
	- `PlayerDataSO` has fields for `AccountLevel` and `AccountXp` (issue #22).
	- XP gain rules are defined (how much XP per wave, per win, per quest, etc.).
	- Feature unlock mapping (which level unlocks what) is specified.
- Pharrel:
	- Any UI that displays account level (e.g. in the Hub header) exists.
- Status:
	- **Soft-blocked:** exact XP curves and unlock thresholds may not be final, but you can implement the system with placeholder numbers.

#### Implementation Notes

- Implement a simple `AccountProgressionService` or similar in `Assets/_Project/Scripts/Core/Meta/`.
- Responsibilities:
	- Expose methods like `AddXp(int amount)` and `GetCurrentLevel()`.
	- Handle leveling up when XP crosses thresholds (`XpForLevel(level)`).
	- Invoke callbacks / events when level increases so UI and other systems can react.
- Integration points:
	- Wave completion, daily quests, achievements should call `AddXp` with appropriate amounts.
	- Feature gating can query current level before enabling features/modes.
- UI:
	- A small UI script in the Hub reads `AccountLevel` and `AccountXp` to display progress.

#### Definition of Done

- [ ] Account XP increases correctly from the configured sources.
- [ ] Account levels up when XP crosses thresholds and does not skip levels or get stuck.
- [ ] Level-related UI shows current level and progress to next level.
- [ ] Other systems can safely query account level to gate features.

---

## Week 7 – Endless Mode & Content

### Issue #66 – [Endless] Implement endless mode manager

**Assignee:** @Moritz622  |  **Labels:** phase-1, gameplay, priority-high  
**GitHub Issue Body (source):** "Implement endless mode manager."

#### Goal

Create an **Endless mode manager** that uses `EndlessWaveGeneratorSO` to spawn waves that scale infinitely over time (more HP, more enemies, better rewards), separate from the fixed 10-wave campaign.

#### Pre-requisites

- Max:
	- `EndlessWaveGeneratorSO` exists with parameters for how waves scale (issue #65).
	- Decisions on whether Endless uses the same `IWaveManager` or a separate flow.
- Pharrel:
	- UI for Endless mode entry and HUD additions is created (issues #67, #68).
- Moritz:
	- `IWaveManager` from Phase 0 (#34) is working and can be reused or extended.
- Status:
	- **Soft-blocked:** exact scaling parameters may still change. You can start with a simple scaling formula.

#### Implementation Notes

- Either:
	- Extend `IWaveManager` to support an Endless mode configuration, or
	- Implement a dedicated `EndlessModeManager` that owns its own wave generation but still uses `EnemyFactory`.
- Endless logic:
	- Wave number keeps increasing without a fixed cap.
	- Use `EndlessWaveGeneratorSO` to generate `WaveConfig`-like data on the fly for each wave.
	- Scale enemy HP, count, and rewards as wave number increases.
- Integration:
	- Mode selection screen should call into this manager rather than the campaign flow.
	- HUD should show "Wave X" with no max, and maybe extra Endless-only indicators.

#### Definition of Done

- [ ] Starting Endless mode spawns waves that never stop until the player loses.
- [ ] Each new wave is harder and more rewarding based on `EndlessWaveGeneratorSO` parameters.
- [ ] There are no crashes or overflows even after many waves.

---

### Issue #71 – [Enemy] Implement special enemy abilities

**Assignee:** @Moritz622  |  **Labels:** phase-1, gameplay, priority-high  
**GitHub Issue Body (source):** "Implement special enemy abilities."

#### Goal

Give certain enemy types **special abilities** (e.g. shields, healing, speed bursts) that make them stand out from simple HP/speed differences, as defined in the Phase 1 enemy designs.

#### Pre-requisites

- Max:
	- Clear design/spec for what abilities exist and how they work.
- Pharrel:
	- New enemy type configs and prefabs are created (issues #70, maybe #33/#40).
- Moritz:
	- `EnemyMovement` and `EnemyHealth` from Phase 0 (#24, #25) are solid and can be extended.
- Status:
	- **Soft-blocked:** exact ability list may still evolve. Start with 1–2 clear abilities.

#### Implementation Notes

- Ability patterns:
	- Prefer small, reusable components like `EnemyShield`, `EnemyHealer`, `EnemySpeedBurst` that can be added to certain enemy prefabs.
	- Use events from `EnemyHealth` and movement to trigger abilities (on spawn, on hit, on death, at intervals).
- Examples:
	- Shielded enemy: has a shield HP that must be broken before true HP takes damage.
	- Healer enemy: periodically heals nearby enemies.
	- Speed burst: when HP drops below a threshold, movement speed temporarily increases.
- Configuration:
	- Store ability parameters (amounts, durations, radii) in new fields on `EnemyConfigSO` or dedicated ability ScriptableObjects.

#### Definition of Done

- [ ] At least 2–3 special enemy types behave noticeably differently in combat.
- [ ] Abilities respect design values (e.g. heal amount, shield HP) from config.
- [ ] No ability causes performance issues or infinite loops.

---

## Week 8 – Backend Integration

### Issue #76 – [Backend] Implement analytics logging

**Assignee:** @Moritz622  |  **Labels:** phase-1, backend, priority-medium  
**GitHub Issue Body (source):** "Implement analytics logging."

#### Goal

Implement a **client-side analytics logger** that sends key gameplay and monetization events (session start/end, wave reached, summon, purchase attempts, AFK claims) to the backend analytics pipeline.

#### Pre-requisites

- Max:
	- Supabase project and basic backend integration set up (issues #73, #74, #75).
	- A clear event schema / API for analytics (what endpoint, payload shape, auth token).
- Moritz:
	- Access to account/session identifiers from the auth system.
- Status:
	- **Blocked until** analytics endpoints and auth tokens are ready. You can still implement an internal event buffer and local logging.

#### Implementation Notes

- Implement an `AnalyticsService` in `Assets/_Project/Scripts/Core/Analytics/`.
- Responsibilities:
	- Provide high-level methods like `LogSessionStart`, `LogWaveReached`, `LogSummon`, `LogPurchase`, `LogAfkClaim`.
	- Queue events locally and send them in batches to the backend on a timer or when app is backgrounded.
	- Handle retries and basic offline behaviour (e.g. caching until connection returns).
- Integration points:
	- Hook into `IGameStateService` for session start/end.
	- Hook into `IWaveManager` for wave progress.
	- Hook into Gacha, Shop, AFK popup for relevant actions.

#### Definition of Done

- [ ] Analytics service can be called from gameplay code without knowing about HTTP details.
- [ ] Events are buffered and sent to backend according to the agreed schema.
- [ ] Failures are handled gracefully (e.g. local retry, not spamming requests).

---

### Issue #77 – [Backend] Implement remote config

**Assignee:** @Moritz622  |  **Labels:** phase-1, backend, priority-medium  
**GitHub Issue Body (source):** "Implement remote config."

#### Goal

Add a **remote configuration layer** that fetches server-side settings (e.g. balance tweaks, A/B flags, feature toggles) from Supabase and makes them available to the game at runtime.

#### Pre-requisites

- Max:
	- Supabase or other backend has a table for remote config and an API endpoint to fetch it (issues #73–#75).
	- Schema for config keys and types is defined (e.g. `float afkMultiplier`, `bool enableEndless`, etc.).
- Status:
	- **Blocked until** backend API and schema are defined. You can still define a local `IRemoteConfig` interface and use local defaults.

#### Implementation Notes

- Define `IRemoteConfigService` and implement `RemoteConfigService` in `Assets/_Project/Scripts/Core/Config/`.
- Responsibilities:
	- Fetch config from backend on app start and on demand.
	- Cache config in memory and optionally on disk.
	- Provide type-safe getters, e.g. `GetBool(string key, bool defaultValue)`.
- Integration:
	- Wrap common knobs so other systems don’t call remote config directly (e.g. `BalanceConfig` pulling from remote values).
	- Ensure the game has sensible defaults when offline or before first fetch.

#### Definition of Done

- [ ] Game can fetch remote config successfully and log the result.
- [ ] Systems like AFK, balance, or features can consume config via a simple API.
- [ ] Game behaves sensibly (uses defaults) when remote config is unavailable.
