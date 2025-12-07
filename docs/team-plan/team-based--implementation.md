Research phase documents fully

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/planning_Phase_0.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/planning_Phase_1.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/planning_Phase_3.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/PRD_IdleMonsterEvolutionTD.md)

## Plan: Team-Based Implementation for 3 Developers

A 4-week Phase 0 implementation plan assigning tasks based on skill levels: **Developer A** (new vibe coder), **Developer B** (experienced quality vibe coder), and **Developer C** (traditional coder with AI suggestions). Work is parallelized where possible with clear handoff points.

---

### Team Roles & Strengths

| Developer | Profile | Assigned Focus |
|-----------|---------|----------------|
| **A** | New to coding, vibe coder | ScriptableObject data, assets, simple UI prefabs, configuration |
| **B** | Experienced, quality vibe coder | Architecture, DI infrastructure, core systems, interfaces, patterns |
| **C** | Traditional + AI suggestions | Integration work, game logic components, testing, cross-system wiring |

---

### Week 1 — Foundation (Developer B leads)

| Task | Owner | Dependencies |
|------|-------|--------------|
| Create Unity project (URP, packages: VContainer, Input System, TextMeshPro, DOTween), folder structure, ASMDEFs, Android config, `.gitignore` | **B** | None |
| Write `.github/copilot-instructions.md` with SOLID rules, VContainer patterns, interface contracts, naming conventions, forbidden patterns | **B** | None |
| Implement `GameLifetimeScope` (VContainer root), service registration structure | **B** | Project setup |
| Create core interfaces: `IDamageable`, `IPoolable`, `ITargetable`, `ISaveable`, `IMonster`, `IEnemy` | **B** | Project setup |
| Implement `IPoolingService` (generic `ObjectPool<T>`) | **B** | Core interfaces |
| Create ScriptableObject base classes: `GameEvent`, `FloatVariable`, `IntVariable` with custom editors | **B** | Project setup |
| Download [Kenney.nl TD Kit](https://kenney.nl/assets/tower-defense-kit), organize in `Assets/_Project/Art/` | **A** | None |
| Create `LocalizationKeys.cs` constants file (`"UI_BUTTON_BATTLE"`, `"HUD_WAVE_COUNT"`, etc.) | **A** | None |
| Set up Input System action asset (`TouchActions.inputactions`) with Pointer/Touch bindings | **A** | Packages installed |

**Week 1 Handoff**: B provides A with ScriptableObject base classes → A starts creating SO instances in Week 2.

---

### Week 2 — Gameplay Systems (Parallel Work)

| Task | Owner | Dependencies |
|------|-------|--------------|
| Create `MonsterConfigSO` class, then 3 instances: Flame Imp (DPS), Frost Wisp (Slow), Thunder Beast (AoE) — fill stats: ATK, Range, AttackSpeed, TargetingPriority | **A** | SO base classes (B) |
| Create `EnemyConfigSO` class, then 3 instances: Goblin (standard), Scout (2x speed, 0.5x HP), Ogre (0.5x speed, 3x HP) | **A** | SO base classes (B) |
| Create `WaveConfigSO` class, then 10 wave instances with enemy counts/spawn intervals | **A** | SO base classes (B) |
| Set up map scene: S-path with `Waypoint` MonoBehaviours, monster placement slots, base/portal visuals using Kenney assets | **A** | Assets organized |
| Create `GameEvent` SO instances: `OnWaveStart`, `OnWaveComplete`, `OnGameWon`, `OnGameLost`, `OnEnemyKilled` | **A** | SO base classes (B) |
| Create variable SO instances: `BaseHP` (FloatVariable), `CurrentGold` (IntVariable), `CurrentWave` (IntVariable) | **A** | SO base classes (B) |
| Implement `MonsterFactory` with VContainer injection, returns configured `IMonster` instances | **B** | `IPoolingService`, interfaces |
| Implement `EnemyFactory` with VContainer injection, returns pooled `IEnemy` instances | **B** | `IPoolingService`, interfaces |
| Implement `ISaveService` — JSON serialization, `PlayerDataSO`, `MonsterInstanceData` class, auto-save on pause/quit | **B** | Interfaces |
| Implement `IAFKRewardService` — UTC timestamp storage, offline time calculation, reward formula scaling with account power | **B** | `ISaveService` |
| Implement `EnemyMovement` component (follows `Waypoint[]` path, speed from config) | **C** | `EnemyConfigSO` (A), interfaces (B) |
| Implement `EnemyHealth` component (takes damage via `IDamageable`, triggers `OnEnemyKilled` event) | **C** | `EnemyConfigSO` (A), interfaces (B) |
| Implement `MonsterTargeting` component (finds targets in range, priority enum: Nearest/Strongest/Fastest) | **C** | `MonsterConfigSO` (A), interfaces (B) |
| Implement `MonsterAttack` component (spawns pooled projectiles, deals damage to `IDamageable` targets) | **C** | `MonsterFactory` (B), `IPoolingService` (B) |

**Week 2 Handoff**: A provides configured SOs → C uses them in components. B provides factories → C integrates with components.

---

### Week 3 — Wave System & UI (Integration Focus)

| Task | Owner | Dependencies |
|------|-------|--------------|
| Create UI prefab: Hub panel (4 buttons: Battle, Monsters, AFK-Chest, Summon) — layout only, no code | **A** | TextMeshPro |
| Create UI prefab: HUD (wave counter text, base HP bar, gold display, 1x/2x speed button) — layout only | **A** | TextMeshPro |
| Create UI prefab: Monster list panel (scrollable grid of monster cards) — layout only | **A** | None |
| Create UI prefab: Monster detail panel (stats display, level-up button, cost text, evolution preview) — layout only | **A** | None |
| Create UI prefab: AFK reward popup (time away, rewards list, claim button) — layout only | **A** | None |
| Create simple primitive placeholders for monsters/enemies (colored cubes/spheres with distinct colors) | **A** | None |
| Implement `IWaveManager` — spawns enemies via `EnemyFactory`, triggers `GameEvent` SOs, manages wave progression | **C** | `EnemyFactory` (B), `WaveConfigSO` (A), events (A) |
| Implement `IGameStateService` — coordinates game states (Hub, Playing, Paused, Won, Lost), base HP monitoring | **C** | `FloatVariable` (A), events (A) |
| Wire HUD to SO variables: wave counter reads `CurrentWave`, HP bar reads `BaseHP`, gold reads `CurrentGold` | **C** | UI prefabs (A), variable SOs (A) |
| Implement speed toggle (1x/2x via `Time.timeScale`) bound to `GameEvent` | **C** | UI prefabs (A) |
| Implement monster placement logic — touch/click on slot → assign selected monster from inventory | **C** | Input System (A), `MonsterFactory` (B) |
| Integrate projectile pooling with `IPoolingService` for all monster attacks | **B** | `MonsterAttack` (C), `IPoolingService` (B) |
| Add `EnemyVisuals` and `MonsterVisuals` components for sprite/mesh assignment from config | **B** | Placeholder art (A) |

**Week 3 Handoff**: A provides UI prefabs → C binds them to systems. Full gameplay loop should be testable end of Week 3.

---

### Week 4 — Polish, AFK Integration & Testing

| Task | Owner | Dependencies |
|------|-------|--------------|
| Implement Monster list panel logic — displays owned monsters from `PlayerDataSO`, click opens detail | **C** | UI prefabs (A), `PlayerDataSO` (B) |
| Implement Monster detail panel logic — shows stats, level-up button deducts gold, increases level | **C** | UI prefabs (A), `ISaveService` (B) |
| Implement AFK popup logic — on app open, calculate offline rewards via `IAFKRewardService`, show popup, claim adds to `PlayerDataSO` | **C** | `IAFKRewardService` (B), UI prefabs (A) |
| Implement Hub→Battle scene transition, game flow (start wave, win/lose, return to hub) | **C** | `IGameStateService` (C), scenes |
| Balance wave difficulty — adjust enemy counts/HP in `WaveConfigSO` instances based on playtesting | **A** | Gameplay loop (C) |
| Balance monster stats — adjust ATK/Range/Speed in `MonsterConfigSO` based on playtesting | **A** | Gameplay loop (C) |
| Add simple VFX: projectile trails, enemy death particles, damage numbers (TextMeshPro popup) | **B** | Pooling system |
| Performance optimization — profile on Android, ensure pooling is working, no Update allocations | **B** | All systems |
| Code review: verify all code matches `.github/copilot-instructions.md` patterns | **B** | All code |
| Playtest full loop: claim AFK rewards → upgrade monster → start battle → survive 10 waves → return to hub | **All** | All systems |
| Document Phase 1 handoff: known issues, next steps, architecture decisions | **B** | All systems |

---

### Task Summary Per Developer

| Developer | Week 1 | Week 2 | Week 3 | Week 4 |
|-----------|--------|--------|--------|--------|
| **A** (Vibe Coder) | Assets, localization keys, input setup | All SO data (monsters, enemies, waves, events, variables), map setup | UI prefabs (5 panels/popups), placeholder art | Balance tuning, playtesting |
| **B** (Quality Vibe) | Project setup, DI, interfaces, pooling, SO bases, copilot-instructions | Factories, save system, AFK service | Projectile pooling, visuals components | VFX, performance, code review, documentation |
| **C** (Traditional+AI) | — (wait for infrastructure) | Enemy/Monster components (Movement, Health, Targeting, Attack) | WaveManager, GameStateService, UI wiring, placement logic | Panel logic, scene flow, AFK integration, full integration testing |

---

### Further Considerations

1. **Daily sync recommended?** — With 3 developers, a 15-min daily standup prevents blocking. B's infrastructure work in Week 1 gates everyone else — ensure B prioritizes interfaces/bases early so A can start SO creation mid-Week 1.

2. **Code review workflow?** — B should review C's component code before integration. Use PR-based workflow where B approves gameplay components, C approves UI integration. A's SO data changes need minimal review (just validation of values).

3. **Shared test scene?** — Create a `DevTestScene` where C can test components in isolation before full integration. A can place prefabs, B can debug DI registration, C can test enemy/monster behavior without full game flow.