
---

## Phase 1 — Feature Expansion (after Phase 0)

### Steps

1. **Implement Gacha/Summon system** — `GachaBannerConfigSO` (drop rates per rarity, pity threshold, featured monsters), `IGachaService`, summon animation sequence, pity counter persistence, 10x summon batch, monster shard system for duplicates.

2. **Build Basis-Hub meta-progression** — Hub scene with building representations (Monster-Lab, AFK-Chest, Research, Summon-Arena), `BuildingConfigSO` (upgrade costs, unlock requirements, bonuses), `ResearchTreeSO` for global buffs (DMG%, AFK boost%, slot unlocks).

3. **Add Endless/Survival mode** — Infinite wave scaling formula in `EndlessWaveGeneratorSO`, increasing rewards per wave, high-score tracking, leaderboard data structure (local first).

4. **Integrate Supabase backend** — Account creation/login, cloud save sync with conflict resolution, analytics event logging (session start, wave complete, summon, level-up), remote config for balancing values.

5. **Expand content** — 2 additional campaign maps with different paths/biomes, 5+ new monsters across rarities, 5+ new enemy types with abilities (shields, healing), monster evolution to Stage 2 with visual/stat changes.

---

## Phase 2 — Monetization & Live-Ops (after Phase 1)

### Steps

1. **Implement Battle Pass system** — `SeasonConfigSO` (duration, free/premium reward tracks, mission definitions), `IBattlePassService`, mission progress tracking tied to `GameEvent` SOs, reward claim UI, premium unlock IAP.

2. **Build Shop and IAP** — `ShopOfferConfigSO` (price, contents, duration, display priority), Unity IAP integration, diamond bundles, starter packs, daily/weekly offers, receipt validation via Supabase Edge Function.

3. **Add Rewarded Ads** — Unity Ads / AdMob integration, ad placements (AFK boost x2, bonus summon, revival), `IAdService` interface, ad availability checks, reward granting via events.

4. **Implement Events system** — `EventConfigSO` (start/end dates, event shop, bonus stages), event-specific currency, limited-time banners, event leaderboard, remote config for event rotation.

5. **Analytics and A/B testing** — Funnel tracking (FTUE completion, first summon, first IAP), retention cohorts (D1/D7/D30), revenue metrics (ARPU, ARPPU), Firebase Remote Config for A/B test variants.

---

### Further Considerations

1. **Free placeholder assets for Phase 0?** Recommend [Kenney.nl Tower Defense Kit](https://kenney.nl/assets/tower-defense-kit) (CC0) for map/tiles, and simple colored shapes for monsters/enemies until Phase 1 sprite generation.

2. **Localization setup in Phase 0 or Phase 1?** Unity Localization package adds complexity — recommend setting up string keys from Phase 0 but deferring full localization to Phase 1.

3. **Testing strategy?** Should the plan include unit tests for services (via Unity Test Framework) in Phase 0, or defer automated testing to Phase 1?