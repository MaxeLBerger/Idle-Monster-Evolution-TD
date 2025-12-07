## Plan: Implement Idle Monster Evolution TD (Phase 0 → Phase 2)

A phased implementation plan starting with Phase 0 (Vertical Slice), using VContainer DI from day one, ScriptableObject architecture, new Input System, and a comprehensive `.github/copilot-instructions.md` for senior-level clean code enforcement.

---

## Phase 0 — Vertical Slice (2–4 weeks)

### Steps

1. **Create Unity project with production-ready architecture** — Initialize Unity 2022/2023 LTS with URP, install packages (VContainer, Input System, TextMeshPro, DOTween), set up folder structure with Assembly Definitions (`IdleMonsterTD.Core.asmdef`, `IdleMonsterTD.Gameplay.asmdef`, `IdleMonsterTD.UI.asmdef`), configure Android build target (ARM64, IL2CPP), add `.gitignore` and `README.md`.

2. **Create `.github/copilot-instructions.md` with full pattern examples** — Define SOLID enforcement, VContainer registration patterns, ScriptableObject event/variable templates, interface contracts (`IDamageable`, `IPoolable`, `ITargetable`, `ISaveable`), naming conventions, pooling requirements, forbidden patterns (no Singletons, no `FindObjectOfType`, no allocations in Update), component composition rules, and code examples for each pattern.

3. **Implement core services and DI infrastructure** — Create `GameLifetimeScope` (VContainer), register core services: `IWaveManager`, `IGameStateService`, `IPoolingService`, `ISaveService`, `IAFKRewardService`. Build `GameEvent` and `FloatVariable`/`IntVariable` ScriptableObject base classes for decoupled communication.

4. **Build Tower Defense gameplay systems** — S-shaped map with `Waypoint[]` array, `WaveConfigSO` (enemy types, counts, spawn intervals per wave), `WaveManager` service, enemy spawning via `ObjectPool<Enemy>`, base HP as `FloatVariable` SO, `GameEvent` SOs for `OnWaveComplete`, `OnGameWon`, `OnGameLost`, Input System action asset for touch/pointer placement.

5. **Create Monster (Tower) system** — `MonsterConfigSO` (ATK, Range, AttackSpeed, TargetingPriority enum, ProjectilePrefab, EvolutionStage), `IMonster` interface, component split (`MonsterAttack`, `MonsterTargeting`, `MonsterVisuals`), `MonsterFactory` (VContainer-injected), projectile pooling, 3 starter monsters: Flame Imp (DPS), Frost Wisp (Slow), Thunder Beast (AoE).

6. **Create Enemy system** — `EnemyConfigSO` (MaxHP, MoveSpeed, GoldReward, EnemyType enum), `IEnemy : IDamageable, IPoolable`, components (`EnemyMovement`, `EnemyHealth`, `EnemyVisuals`), `EnemyFactory`, 3 enemy types: Goblin (Standard), Scout (Fast/Fragile), Ogre (Slow/Tanky).

7. **Implement Idle/AFK and save systems** — `AFKRewardService` with UTC timestamp calculation, `PlayerDataSO` runtime variable (gold, evo-materials, owned monsters), `MonsterInstanceData` class (level, XP, evolution stage), `SaveService` with JSON serialization to `Application.persistentDataPath`, auto-save on app pause/quit.

8. **Build UI layer** — Main hub scene with 4 buttons (Battle, Monsters, AFK-Chest, placeholder Summon), gameplay HUD bound to SO variables (wave counter, base HP bar, gold display, 1x/2x speed toggle), monster list panel, monster detail panel with level-up button, AFK reward popup with claim button.

9. **Polish and test vertical slice** — Playtest for balance, fix bugs, optimize performance, ensure clean code compliance with `.github/copilot-instructions.md`, prepare documentation for Phase 1 handoff. Use testsprite.com for testing on various Android devices. or suitable testing service.## Plan Update: Further Considerations Resolved

Based on your feedback, here are the refined decisions:

---

### Resolved Considerations

1. **Free placeholder assets for Phase 0** ✅ — Use [Kenney.nl Tower Defense Kit](https://kenney.nl/assets/tower-defense-kit) (CC0) for map/tiles, and simple colored primitive shapes (Unity sprites/3D primitives) for monsters/enemies. In Phase 1, we generate custom sprites together.

2. **Localization setup** ✅ — Set up string keys and `LocalizationKey` constants from Phase 0 (all UI text uses keys like `"UI_BUTTON_BATTLE"`, `"HUD_WAVE_COUNT"`), but defer Unity Localization package integration and actual translations to Phase 1. This ensures no hardcoded strings from the start while avoiding package complexity in the prototype.

3. **Testing strategy** ✅ — Defer automated testing to Phase 1. Use **Unity Test Framework** (built-in) for unit tests on services (`IWaveManager`, `ISaveService`, `IAFKRewardService`, `IGachaService`). 

   Regarding **TestSprite.com**: This is a web-based sprite testing tool, not suitable for Unity C# unit testing. For Unity, the proper testing stack is:
   - **Unity Test Framework** (Edit Mode tests for pure C# logic, Play Mode tests for MonoBehaviour integration)
   - **NSubstitute** or **Moq** for mocking interfaces (VContainer makes this easy since all services are interface-based)
   - Optional: **Unity Test Coverage** package for coverage reports

---