
# Moritz – Phase 0 Issues (Weeks 1–4)

Moritz, this file is your personal Phase 0 playbook. You own the **integration and gameplay glue** between Max’s architecture/services and Pharrel’s assets/ScriptableObjects: enemy components, monster combat logic, the wave & game state services, HUD wiring, AFK popup logic, and Hub→Battle scene flow.

You are **strong in Java** and **mid-experienced in Unity**, so this doc leans into:
- Explaining **MonoBehaviour lifecycle** and where to put logic (`Awake`, `OnEnable`, `Update`).
- How to work with **prefabs, scenes, and ScriptableObjects** in Unity.
- How to use our **dependency injection (VContainer)** instead of `FindObjectOfType` or static singletons.

Always read the **Definition of Done** and test each feature in play mode. If a pre-requisite is not ready yet, you can still stub parts of the logic and come back later.

---

## Week 2 – Gameplay Systems (Issues #24–#27)

### Issue #24 – [Enemy] Implement EnemyMovement component

**Assignee:** @Moritz622  |  **Labels:** phase-0, gameplay, priority-high  
**GitHub Issue Body (source):** "Create EnemyMovement : MonoBehaviour. Inject Waypoint[] path. Move along path using speed from EnemyConfigSO. Trigger base damage when reaching end. Use IPoolable for reset on spawn."

#### Goal

Make every enemy **follow the S-shaped path** from spawn to the base at the speed defined in its `EnemyConfigSO`. When an enemy reaches the last waypoint, it should **damage the base** (reduce `BaseHP`) and then **despawn via the pool** instead of being destroyed.

#### Pre-requisites

- Max:
	- `EnemyConfigSO` exists with at least a `MoveSpeed` field (issue #13).
	- Core interfaces like `IPoolable`, `IEnemy` and the pooling pattern are implemented (issues #4, #5).
- Pharrel:
	- Battle map scene (`BattleScene.unity`) is set up with a **path of Waypoints** from spawn to base (issue #19).
	- `BaseHP` `FloatVariable` ScriptableObject and related GameEvent(s) exist (issues #17, #18).
- Status:
	- **Blocked until** `EnemyConfigSO`, waypoints in the battle scene, and the pooling API exist. You can still sketch the component and TODO comments before everything is wired.

#### Implementation Notes

- Create a script `EnemyMovement` in `Assets/_Project/Scripts/Gameplay/Enemy/`.
- Make it `public sealed class EnemyMovement : MonoBehaviour` and keep it **data-driven**:
	- A serialized reference or injected reference to `EnemyConfigSO` for movement speed.
	- A serialized `Waypoint[]` or similar list of `Transform`s representing the path.
- Movement loop:
	- Store an integer `currentWaypointIndex`.
	- In `Update()`, move `transform.position` towards the current waypoint using `Time.deltaTime * moveSpeed`.
	- When close enough (e.g. distance < small threshold), increment `currentWaypointIndex` to target the next waypoint.
- When you pass the **last waypoint**:
	- Reduce `BaseHP` via the `FloatVariable` SO or raise a "base hit" GameEvent that a service listens to.
	- Call into the enemy’s pooling hook (e.g. `IPoolable.OnDespawn()` or via `IPoolingService`) so the object returns to the pool.
- Lifecycle / pooling:
	- On spawn (`OnEnable` or a custom `OnSpawn` method) reset `currentWaypointIndex` to 0 and snap the enemy to the first waypoint / spawn point.
	- Do **not** use `Destroy(gameObject)` – always go through the pool.
- Performance / style:
	- Avoid `new` allocations or LINQ inside `Update()`.
	- Use fields cached at `Awake()` time rather than calling `GetComponent` every frame.

#### Definition of Done

- [ ] Dropping an enemy prefab with `EnemyMovement` into `BattleScene` makes it follow the full S-path correctly.
- [ ] Movement speed clearly changes when you edit the `MoveSpeed` value in its `EnemyConfigSO`.
- [ ] When an enemy reaches the base, `BaseHP` goes down by the configured amount **once per enemy**.
- [ ] After reaching the base, the enemy despawns via pooling (no `Destroy`, no memory leaks) and can be reused.
- [ ] No console errors or warnings when many enemies move at once.

---

### Issue #25 – [Enemy] Implement EnemyHealth component

**Assignee:** @Moritz622  |  **Labels:** phase-0, gameplay, priority-high  
**GitHub Issue Body (source):** "Create EnemyHealth : MonoBehaviour, IDamageable. Initialize HP from EnemyConfigSO. Implement TakeDamage(float). Trigger OnEnemyKilled GameEvent on death. Grant gold reward to CurrentGold variable. Return to pool via IPoolable."

#### Goal

Give enemies **hit points and death logic**: they should take damage from projectiles, die when HP reaches zero, **reward gold** to the player, fire an `OnEnemyKilled` event for other systems, and then **return to the pool** instead of being destroyed.

#### Pre-requisites

- Max:
	- `EnemyConfigSO` defines `MaxHP` and `GoldReward` (issue #13).
	- Interfaces `IDamageable` and `IPoolable` exist in the core assembly (issue #4).
	- ScriptableObject variable base classes like `IntVariable`/`FloatVariable` exist (issue #6).
- Pharrel:
	- `OnEnemyKilled` `GameEvent` instance is created (issue #17).
	- `CurrentGold` `IntVariable` ScriptableObject exists (issue #18).
- Status:
	- **Blocked until** the config SO and variable/event assets exist. You can still implement the `IDamageable` logic and keep TODO placeholders for the SO references.

#### Implementation Notes

- Create a script `EnemyHealth` in `Assets/_Project/Scripts/Gameplay/Enemy/`.
- Implement it as `public sealed class EnemyHealth : MonoBehaviour, IDamageable`.
- Fields:
	- A reference to `EnemyConfigSO` to read `MaxHP` and `GoldReward`.
	- A reference to `IntVariable` for `CurrentGold`.
	- A reference to `GameEvent` for `OnEnemyKilled`.
	- A private float `currentHp`.
- Initialization:
	- In `OnEnable()` or a public `Initialize()` method, set `currentHp = enemyConfig.MaxHP`.
	- Make sure this also happens when objects are reused from the pool.
- `TakeDamage(float amount)`:
	- Subtract `amount` from `currentHp`.
	- Clamp at 0 to avoid negative values.
	- If `currentHp <= 0` and the enemy is not already dead:
		- Increase `CurrentGold.Value` by `enemyConfig.GoldReward`.
		- Raise the `OnEnemyKilled` `GameEvent`.
		- Trigger despawn via pooling (same pattern as in `EnemyMovement`).
- Optional: expose a simple `OnHealthChanged` C# event for VFX or UI hooks later.

#### Definition of Done

- [ ] Enemy prefabs with `EnemyHealth` and `EnemyConfigSO` take damage correctly when projectiles hit them.
- [ ] When HP reaches 0, each enemy dies exactly once, even if multiple hits land on the same frame.
- [ ] Killing an enemy increases `CurrentGold` by the `GoldReward` from its config.
- [ ] The `OnEnemyKilled` GameEvent fires on each kill and can be seen by a simple test listener.
- [ ] Dead enemies are despawned via pooling and can be respawned with full health.

---

### Issue #26 – [Monster] Implement MonsterTargeting component

**Assignee:** @Moritz622  |  **Labels:** phase-0, gameplay, priority-high  
**GitHub Issue Body (source):** "Create MonsterTargeting : MonoBehaviour. Find enemies in range (Physics overlap or manual distance check). Apply targeting priority from config (Nearest, Strongest, Fastest, First). Expose CurrentTarget property. Update target selection each frame."

#### Goal

Let each monster **find and track the best enemy target** in its range based on the targeting rules from its `MonsterConfigSO` (e.g. Nearest, Strongest, Fastest, First). Other components, especially `MonsterAttack`, will read a `CurrentTarget` property from here.

#### Pre-requisites

- Max:
	- `MonsterConfigSO` exists with fields like `Range` and a `TargetingPriority` enum (issue #11).
	- A shared interface such as `IEnemy` / `ITargetable` is defined so you can identify enemies (issue #4).
- Pharrel:
	- Enemy prefabs and configs are created and spawn properly in the battle scene (issues #14, #19).
- Status:
	- **Soft-blocked:** you can prototype targeting logic using a simple list of active enemies even before the final enemy registry / layers are finalized.

#### Implementation Notes

- Create `MonsterTargeting` in `Assets/_Project/Scripts/Gameplay/Monster/`.
- This should be a `MonoBehaviour` sitting on the monster prefab (same GameObject that will also host `MonsterAttack`).
- Data / configuration:
	- Reference to the `MonsterConfigSO` to get `Range` and `TargetingPriority`.
	- Possibly a reference to a central **EnemyRegistry** or rely on physics queries with a dedicated enemy layer.
- Target search strategies:
	- Decide whether to use `Physics.OverlapSphere` (3D) / `OverlapCircle` (2D) or iterate through a cached list of active enemies.
	- For each candidate enemy, compute:
		- Distance from the monster.
		- Other attributes from its config (HP, speed) as needed for "Strongest" / "Fastest".
	- Apply the priority rule to choose the best target.
- Performance considerations:
	- Do **not** run heavy logic every frame. Consider checking for a new target every X seconds or when the current target dies/leaves range.
	- Avoid allocations by reusing the same list/array for physics results.
- API surface:
	- Expose a `public Transform CurrentTarget { get; }` or similar.
	- Optionally expose an event like `OnTargetChanged` if needed for VFX.

#### Definition of Done

- [ ] Monsters with `MonsterTargeting` acquire an enemy in range shortly after spawn.
- [ ] When using different priority modes (Nearest/Strongest/Fastest/First), you can observe different enemies being chosen as expected.
- [ ] If the current target dies or leaves range, the monster eventually switches to a new valid target.
- [ ] There are no noticeable frame drops or GC allocations from the targeting logic, even with many monsters.

---

### Issue #27 – [Monster] Implement MonsterAttack component

**Assignee:** @Moritz622  |  **Labels:** phase-0, gameplay, priority-high  
**GitHub Issue Body (source):** "Create MonsterAttack : MonoBehaviour. Use attack speed from config. Spawn projectile from pool when attacking. Projectile travels to target, deals damage via IDamageable. Handle Frost Wisp slow effect and Thunder Beast chain lightning."

#### Goal

Make monsters **actually attack** the target from `MonsterTargeting`: fire projectiles at the correct interval based on their `AttackSpeed`, deal damage using `IDamageable`, and support the three starter behaviours:
- Flame Imp: single-target DPS.
- Frost Wisp: applies a **slow** debuff to enemies.
- Thunder Beast: uses **chain lightning** to hit multiple enemies.

#### Pre-requisites

- Max:
	- `MonsterConfigSO` includes `AttackSpeed`, projectile prefab reference, and any stats needed for slow/chain behaviour (issue #11).
	- `IPoolingService` is implemented, and projectile pooling/integration exists or is planned (`ObjectPool`, issue #5, #39).
- Pharrel:
	- Starter monster configs: Flame Imp, Frost Wisp, Thunder Beast (issue #12) wired to appropriate projectile prefabs.
	- Basic projectile / VFX prefabs available (issues #33, #40).
- Moritz:
	- `MonsterTargeting` (#26) returns a valid `CurrentTarget`.
	- `EnemyHealth` (#25) implements `IDamageable`.
- Status:
	- **Blocked until** there is at least a basic projectile prefab and the pool API; you can still define the attack timer and API in advance.

#### Implementation Notes

- Create `MonsterAttack` in `Assets/_Project/Scripts/Gameplay/Monster/` and place it on the same prefab as `MonsterTargeting`.
- Data / fields:
	- Reference to `MonsterConfigSO` for `AttackSpeed` and behaviour type.
	- Reference to `MonsterTargeting` to read `CurrentTarget`.
	- A float timer to track time since last attack.
- Attack loop:
	- In `Update()`, if `CurrentTarget` is not null and the game is in a battle state, increment the timer.
	- When `timer >= 1f / AttackSpeed`, reset timer and perform an attack.
- Projectile creation:
	- Request a projectile instance from the pooling service rather than instantiating directly.
	- Position the projectile at the monster’s fire point, aim it towards `CurrentTarget.position`.
	- Configure the projectile with damage amount and any special behaviour needed.
- Special behaviours:
	- Flame Imp: projectile simply calls `TakeDamage(damage)` on the hit enemy.
	- Frost Wisp: in addition to damage, modifies the enemy’s movement speed for a duration (e.g. via a debuff component or modifier in `EnemyMovement`).
	- Thunder Beast: on hit, find nearby enemies and apply damage to up to N additional targets.
- Make sure everything is **pool-safe**: projectiles reset when reused.

#### Definition of Done

- [ ] All three starter monsters fire projectiles at a visible, config-driven rate when enemies are in range.
- [ ] Enemies hit by Flame Imp projectiles lose HP correctly.
- [ ] Enemies hit by Frost Wisp are noticeably slowed according to config values.
- [ ] Thunder Beast attacks chain to multiple nearby enemies based on config.
- [ ] No projectiles use `Destroy()`; they despawn via the pooling system without spamming the GC.

---

## Week 3 – Wave System & HUD (Issues #34–#38)

### Issue #34 – [Wave] Implement IWaveManager

**Assignee:** @Moritz622  |  **Labels:** phase-0, gameplay, priority-critical  
**GitHub Issue Body (source):** "Wave system service handling wave progression, spawning enemies per wave."

#### Goal

Create a central **wave manager service** that controls which wave is currently active, spawns enemies according to the `WaveConfigSO` data, and knows when a wave (and the entire run) is complete. Other systems (HUD, game state) will subscribe to its events and variables.

#### Pre-requisites

- Max:
	- `IWaveManager` interface and `WaveConfigSO` class exist (issues #4, #15).
	- `EnemyFactory` is implemented for spawning enemies (issue #21).
	- VContainer `GameLifetimeScope` is set up so services can be registered (issue #3).
- Pharrel:
	- 10 `WaveConfigSO` instances created with increasing difficulty (issue #16).
	- `OnWaveStart` / `OnWaveComplete` GameEvents and `CurrentWave` variable (issues #17, #18).
- Moritz:
	- Enemy movement and health components (#24, #25) are working so spawned enemies actually walk and die.
- Status:
	- **Blocked until** at least `WaveConfigSO` and `EnemyFactory` exist. You can still scaffold the class with TODOs and interfaces.

#### Implementation Notes

- Implement `WaveManager : IWaveManager` as a **pure C# service** (not a MonoBehaviour) in `Assets/_Project/Scripts/Core/Gameplay/`.
- Register it in `GameLifetimeScope` so other systems can get `IWaveManager` injected.
- Responsibilities:
	- Keep a reference to the **list of wave configs** for the current run (e.g. from a `LevelConfigSO`).
	- Maintain an integer `currentWaveIndex` and expose `CurrentWaveIndex`.
	- Provide methods like `StartFirstWave()`, `StartNextWave()`, and `StopAllWaves()`.
- Spawning logic:
	- For the current `WaveConfigSO`, read its entries (enemy type, count, spawn interval, delay).
	- Use a coroutine or an injected `ITickService` / timer to spawn enemies over time via `EnemyFactory`.
	- Update `CurrentWave` variable and raise `OnWaveStart` when a wave begins.
	- Track when all enemies in a wave have been spawned and then killed; on completion, raise `OnWaveComplete`.
- Unity / DI bridge:
	- Use a small MonoBehaviour (e.g. `WaveRunner`) in the battle scene that receives `IWaveManager` via injection and runs coroutines on its behalf.

#### Definition of Done

- [ ] Starting a battle triggers `IWaveManager` to spawn wave 1 according to its `WaveConfigSO`.
- [ ] All configured enemies for a wave spawn at the right times and walk along the path.
- [ ] `CurrentWave` variable and `OnWaveStart` / `OnWaveComplete` events update correctly for each wave.
- [ ] When the last wave is complete and all enemies are dead, the manager signals completion so `IGameStateService` can declare victory.

---

### Issue #35 – [GameState] Implement IGameStateService

**Assignee:** @Moritz622  |  **Labels:** phase-0, gameplay, priority-critical  
**GitHub Issue Body (source):** "Implement central game state service (menu vs battle, win/lose states, etc.), probably raising events and managing transitions."

#### Goal

Create a **single source of truth** for the game’s high-level state: Hub, Battle, Victory, Defeat, maybe Loading. This service also coordinates scene transitions (Hub → Battle → Hub) and exposes events for UI to react to.

#### Pre-requisites

- Max:
	- Interface `IGameStateService` and an enum of states (issue #4).
	- Scenes (`Boot`, `Hub`, `Battle`) are created and in build settings (issues #1, #7).
	- VContainer `GameLifetimeScope` is set up and survives scene loads (issue #3).
- Pharrel:
	- GameEvents for win/lose and maybe state changes exist (issue #17).
	- Scriptable variables like `BaseHP` that determine defeat conditions exist (issue #18).
- Moritz:
	- `IWaveManager` (#34) and enemy/base logic feed into win/lose conditions.
- Status:
	- **Soft-blocked:** you can implement the service interface and dummy scene loading before all events are wired.

#### Implementation Notes

- Implement `GameStateService : IGameStateService` as a service in `Assets/_Project/Scripts/Core/Services/`.
- Internal state:
	- A `GameState` enum property (e.g. `Hub`, `Battle`, `Victory`, `Defeat`, `Loading`).
	- Events or observables for `OnStateChanged`.
- Public API examples:
	- `void StartBattle()` – set state to Loading → Battle, then request battle scene load.
	- `void ReturnToHub()` – set state to Loading → Hub, then request hub scene load.
	- `void OnBaseHpReachedZero()` – transition to `Defeat`.
	- `void OnAllWavesCompleted()` – transition to `Victory`.
- Scene loading:
	- Use Unity’s `SceneManager.LoadSceneAsync` wrapped in a small helper that the service can call.
	- Make sure the DI root stays alive between scenes (e.g. Boot scene + `DontDestroyOnLoad`).
- Integration:
	- WaveManager should notify `GameStateService` when a run is finished.
	- Enemy/base logic should notify on defeat.

#### Definition of Done

- [ ] You can query `IGameStateService.State` from anywhere and get a correct value (Hub/Battle/Victory/Defeat).
- [ ] Changing state triggers a clear `OnStateChanged` callback that UI and systems can subscribe to.
- [ ] Starting a battle from the hub uses `StartBattle()` and loads the battle scene.
- [ ] Finishing a run or losing the base triggers a transition back to the hub with the correct state.

---

### Issue #36 – [UI] Wire HUD to SO variables

**Assignee:** @Moritz622  |  **Labels:** phase-0, ui, priority-high  
**GitHub Issue Body (source):** "Connect HUD UI elements to ScriptableObject variables (wave counter, base HP, gold, game speed)."

#### Goal

Make the in-battle **HUD automatically reflect the current game state**: base HP, gold, current wave number, and game speed should all update in real time from shared ScriptableObject variables without direct coupling to gameplay scripts.

#### Pre-requisites

- Pharrel:
	- HUD prefab is created with placeholders for base HP, gold, wave, speed text/icons (issue #29).
	- ScriptableObject variables exist: `BaseHP`, `CurrentGold`, `CurrentWave`, `GameSpeed` (issue #18).
- Max:
	- SO variable base classes support value changes and (ideally) change notifications (issue #6).
- Moritz:
	- `EnemyHealth` updates `CurrentGold` (#25).
	- `IWaveManager` updates `CurrentWave` (#34) and maybe raises events.
	- `GameStateService` or a related system updates `BaseHP` on damage.
- Status:
	- **Soft-blocked:** you can bind HUD elements to dummy variables early and update references later.

#### Implementation Notes

- Create scripts like `HudBaseHpView`, `HudGoldView`, `HudWaveView`, `HudSpeedView` in `Assets/_Project/Scripts/UI/HUD/`.
- Each script should:
	- Have serialized references to the relevant variable SO (e.g. `FloatVariable baseHpVar`).
	- Have serialized references to the UI components (e.g. `TextMeshProUGUI`, sliders, icons).
	- In `OnEnable()`, subscribe to a variable-changed event if available, or simply refresh once per `Update()` for a simpler first version.
- Display logic examples:
	- `HudBaseHpView`: show `BaseHP.Value` as an integer or with one decimal.
	- `HudGoldView`: show `CurrentGold.Value` with thousands formatting.
	- `HudWaveView`: show `Wave X / 10` using `CurrentWave.Value`.
	- `HudSpeedView`: show `1x` or `2x` based on `GameSpeed.Value`.
- Keep code **one-way**: UI reads from variables but does not directly change game state (except via dedicated buttons like speed toggle).

#### Definition of Done

- [ ] In play mode, base HP, gold, wave, and speed all display sensible numbers on the HUD.
- [ ] Changing values in the inspected ScriptableObject assets during play instantly updates the HUD.
- [ ] No gameplay script directly manipulates UI components; everything goes through SO variables and events.

---

### Issue #37 – [UI] Implement speed toggle

**Assignee:** @Moritz622  |  **Labels:** phase-0, ui, priority-medium  
**GitHub Issue Body (source):** "Implement UI for 1x/2x speed, probably by updating a GameSpeed variable SO and/or directly controlling Time.timeScale."

#### Goal

Add a **speed toggle button** to the HUD that lets the player switch between at least **1x and 2x** game speed. The current speed should be clearly visible, and all gameplay (movement, attacks, waves) should react consistently.

#### Pre-requisites

- Pharrel:
	- HUD prefab includes a speed toggle button and maybe a label/icon (issue #29).
	- `GameSpeed` `FloatVariable` and localization keys like `HUD_SPEED_1X`, `HUD_SPEED_2X` exist (issues #9, #18).
- Max:
	- Decision on how to apply game speed: using `Time.timeScale` or a custom multiplier used by movement/attack logic.
- Moritz:
	- Basic HUD binding for speed text is in place (`HudSpeedView`, issue #36).
- Status:
	- **Soft-blocked:** the exact application of speed may need Max’s decision, but you can still implement the button and variable changes.

#### Implementation Notes

- Create a `HudSpeedToggle` script in `Assets/_Project/Scripts/UI/HUD/`.
- Attach it to the speed button in the HUD prefab.
- Fields:
	- Reference to `GameSpeed` `FloatVariable`.
	- Reference to a `TextMeshProUGUI` or icon for current speed.
- Behaviour:
	- On button click, toggle between `GameSpeed.Value = 1f` and `GameSpeed.Value = 2f` (you can add extra states later if needed).
	- Update the label/icon to show `1x` / `2x` using localization keys.
	- Optionally apply `Time.timeScale = GameSpeed.Value` if that’s the agreed approach.
- Make sure to reset speed to `1x` when returning to the hub or starting a new battle.

#### Definition of Done

- [ ] Clicking the speed button in battle toggles between 1x and 2x speed.
- [ ] The HUD speed label or icon clearly reflects the current speed.
- [ ] Movement, wave timings, and attack rates all feel consistently faster/slower when changing speed.
- [ ] Speed resets to 1x when a new battle starts.

---

### Issue #38 – [Gameplay] Implement monster placement

**Assignee:** @Moritz622  |  **Labels:** phase-0, gameplay, priority-high  
**GitHub Issue Body (source):** "Let player place monsters into map slots using Input System; spawn via MonsterFactory."

#### Goal

Allow the player to **place monsters on the map** by tapping/clicking on valid placement slots in the battle scene, using the new **Unity Input System**. When a slot is selected, `MonsterFactory` should spawn the currently selected monster there.

#### Pre-requisites

- Pharrel:
	- `GameInputActions` asset with pointer/touch actions is set up (issue #10).
	- Battle map (`BattleScene`) has **monster slot objects** (colliders or custom `MonsterSlot` components) defined (issue #19).
- Max:
	- `MonsterFactory` implemented with a clear API, e.g. `CreateMonster(MonsterConfigSO, Vector3 position)` (issue #20).
	- `PlayerDataSO` or similar stores the list of owned monsters (issue #22).
- Moritz:
	- Monster list/detail logic (#41, #42) or at least a simple "currently selected monster" reference.
- Status:
	- **Blocked until** the input actions and map slots are present. You can still build the controller logic against placeholder slots.

#### Implementation Notes

- Create `MonsterPlacementController` in `Assets/_Project/Scripts/Gameplay/Monster/` and place it in the battle scene.
- Input:
	- Use the generated `GameInputActions` C# class to read pointer position and clicks/taps.
	- On click/tap, convert screen position to a ray and raycast into the world.
- Slot detection:
	- Hit test against colliders or a `MonsterSlot` component on placement tiles.
	- Check if the slot is free before spawning.
- Spawning:
	- Ask some `SelectedMonsterProvider` (e.g. from the monster list panel) which `MonsterConfigSO` is currently selected.
	- Call `MonsterFactory.CreateMonster(selectedConfig, slotPosition)` and parent the monster appropriately.
- Bookkeeping:
	- Mark the slot as occupied and store a reference to the spawned monster.
	- Optionally support selling/removing monsters later, but not required in Phase 0.

#### Definition of Done

- [ ] In battle, you can click/tap on a free monster slot and spawn the selected monster there.
- [ ] Attempting to place a monster on an occupied slot is ignored or gives feedback (no double placement bugs).
- [ ] Spawned monsters immediately begin targeting and attacking enemies using your other components.
- [ ] No null reference exceptions when placing or reloading the battle scene.

---

## Week 4 – UI Logic & Scene Flow (Issues #41–#44)

### Issue #41 – [UI] Implement Monster list panel logic

**Assignee:** @Moritz622  |  **Labels:** phase-0, ui, priority-high  
**GitHub Issue Body (source):** "Implement logic backing the monster list UI: show owned monsters, select one for details/placement."

#### Goal

Back the **Monster List panel** with real data so it displays the player’s owned monsters (from `PlayerDataSO`) and lets the player select which monster is currently "active" for viewing details and for placement into battle slots.

#### Pre-requisites

- Pharrel:
	- Monster list panel prefab exists with a scroll area and an item template (issue #30).
- Max:
	- `PlayerDataSO` and `MonsterInstanceData` types exist and track owned monsters (issue #22).
- Moritz:
	- Basic understanding of `MonsterConfigSO` and starter monsters (#11, #12).
- Status:
	- **Soft-blocked:** you can stub the list with dummy data until final `PlayerDataSO` is ready.

#### Implementation Notes

- Create a `MonsterListPanel` script in `Assets/_Project/Scripts/UI/Monsters/`.
- References:
	- `PlayerDataSO` for owned monster instances.
	- A `RectTransform` for the list content area.
	- A prefab for a single list item (monster row/card) with a Button and labels/icons.
- On panel open or `Start()`:
	- Clear existing children under the content transform.
	- Loop over owned monsters in `PlayerDataSO` and instantiate one list item per monster.
	- Bind name, rarity, level, and icon from `MonsterConfigSO` and instance data.
- Selection:
	- When the user clicks a list item, set a `SelectedMonster` in some shared place (e.g. `SelectedMonsterModel` service or static reference for now) and open the Monster Detail panel.
	- Visually highlight the selected item.

#### Definition of Done

- [ ] Opening the Monster List panel shows all currently owned monsters with correct names/icons/levels.
- [ ] Clicking a monster row changes the active selection and highlights it.
- [ ] The selected monster can be read by other systems (detail panel, placement controller).

---

### Issue #42 – [UI] Implement Monster detail panel logic

**Assignee:** @Moritz622  |  **Labels:** phase-0, ui, priority-high  
**GitHub Issue Body (source):** "Show stats and upgrade button for a selected monster; handle level-up."

#### Goal

Make the **Monster Detail panel** show detailed information about the currently selected monster (stats, level, evolution stage) and allow the player to **level it up** by spending gold, updating both the data and the UI.

#### Pre-requisites

- Pharrel:
	- Monster detail panel prefab is ready with labels/bars and a Level Up button (issue #31).
- Max:
	- `PlayerDataSO`/`MonsterInstanceData` contain level and stat fields (issue #22).
	- A level-up cost formula and stat-scaling rules exist (likely in a balance config SO).
- Moritz:
	- Monster selection is available from the Monster List panel (#41).
	- `CurrentGold` variable exists and is updated by gameplay (#25, #18).
- Status:
	- **Blocked until** level-up rules are defined; you can still wire the UI and mock the calculation.

#### Implementation Notes

- Create `MonsterDetailPanel` script in `Assets/_Project/Scripts/UI/Monsters/`.
- References:
	- UI: labels for name, level, ATK, Range, AttackSpeed; optional bars and icons.
	- Level Up button.
	- `PlayerDataSO` and the currently selected `MonsterInstanceData`.
	- `CurrentGold` `IntVariable`.
- On show/open:
	- Read the selected monster from the shared selection model.
	- Fill out all text fields and bars from the instance and its `MonsterConfigSO`.
	- Compute the cost for the next level and show it.
- Level up flow:
	- On button click, check if `CurrentGold.Value >= cost`.
	- If not, disable button or show a "Not enough gold" hint.
	- If yes, deduct gold, increment level, recompute stats and refresh UI.
	- Ensure data is persisted via `ISaveService` or flagged for save later.

#### Definition of Done

- [ ] Opening the detail panel shows correct stats for the currently selected monster.
- [ ] Pressing Level Up increases the level and updates stats if there is enough gold.
- [ ] Level Up is blocked when there is not enough gold, with clear feedback.
- [ ] Changes persist across scene reloads via the save system.

---

### Issue #43 – [UI] Implement AFK popup logic

**Assignee:** @Moritz622  |  **Labels:** phase-0, ui, priority-high  
**GitHub Issue Body (source):** "Wire AFK reward popup UI to IAFKRewardService and player currency."

#### Goal

Implement the **AFK reward popup** that appears when the player opens the AFK chest in the hub. It should show how long the player has been offline and what rewards they’ll get, and when the player taps **Claim**, it should grant those rewards and update save data.

#### Pre-requisites

- Pharrel:
	- AFK popup prefab exists with text fields for duration, gold, materials, and a Claim button (issue #32).
	- Relevant localization keys for AFK labels exist (issue #9).
- Max:
	- `IAFKRewardService` implemented and calculating rewards based on last collect time and account power (issue #23).
	- `ISaveService` and `PlayerDataSO` handle updating gold/materials and persisting them (issue #22).
- Moritz:
	- HUD / Hub has an entry point (AFK chest button) that you can hook into.
- Status:
	- **Blocked until** `IAFKRewardService` exposes a clear API. You can stub the UI flow and drive it with fake data first.

#### Implementation Notes

- Create `AfkPopupController` in `Assets/_Project/Scripts/UI/AFK/`.
- Fields:
	- References to UI text elements for duration, gold reward, material rewards.
	- Reference to the Claim button.
	- Injected `IAFKRewardService`, `ISaveService`, and `PlayerDataSO`.
- On popup open:
	- Ask `IAFKRewardService` for the current reward breakdown (duration, gold, materials).
	- Format and display the values in the UI.
- On Claim:
	- Apply rewards to `PlayerDataSO` and variable SOs (e.g. `CurrentGold`).
	- Notify `ISaveService` to persist the updated data.
	- Close the popup and reset internal state.
- Make sure the Claim button cannot be spammed (disable after one click until new rewards are available).

#### Definition of Done

- [ ] Opening the AFK popup shows a reasonable offline duration and corresponding rewards.
- [ ] Pressing Claim adds the rewards to the player’s gold/materials exactly once.
- [ ] After claiming, the popup closes and new AFK time starts accumulating (handled by service).
- [ ] No duplicate claims are possible through rapid clicks.

---

### Issue #44 – [Scene] Implement Hub→Battle scene flow

**Assignee:** @Moritz622  |  **Labels:** phase-0, gameplay, priority-high  
**GitHub Issue Body (source):** "Make the hub buttons start a battle by loading the battle scene, and handle return flow."

#### Goal

Connect the **Hub and Battle scenes** so the player can tap a **Battle** button in the hub, load into the battle scene, play a run (waves, monsters, enemies), and then be returned back to the hub with the correct state after winning or losing.

#### Pre-requisites

- Max:
	- Scenes `Boot`, `Hub`, `Battle` exist and are added to the build (issues #1, #7).
	- `IGameStateService` is implemented (#35) and can be used for scene transitions.
- Pharrel:
	- Hub panel prefab has a Battle button wired into the hub scene (issue #28).
- Moritz:
	- `IWaveManager` is functional (#34) so battles actually play waves.
	- Enemy/base logic can signal win/lose to `GameStateService`.
- Status:
	- **Soft-blocked:** you can wire up basic scenes and transitions before combat is perfectly tuned.

#### Implementation Notes

- In the Hub scene:
	- Add a script (e.g. `HubController`) that receives `IGameStateService` via injection.
	- Hook the Battle button’s `onClick` to call `gameStateService.StartBattle()`.
- In the Battle scene:
	- Add a `BattleController` MonoBehaviour that, on scene start, asks `IWaveManager` to start wave 1.
	- Subscribe to "run finished" notifications (victory/defeat) from WaveManager or GameStateService.
	- When the run ends, call `gameStateService.ReturnToHub()`.
- Make sure `GameLifetimeScope` persists between scenes so services are not recreated unexpectedly.

#### Definition of Done

- [ ] From the hub, tapping the Battle button reliably loads the battle scene.
- [ ] A full run of waves plays, and on win/lose the game transitions back to the hub.
- [ ] Services like `IWaveManager` and `IGameStateService` behave correctly across multiple Hub→Battle→Hub cycles without duplicates or stale data.

---

## Cross-Cutting Notes for Moritz

- Prefer **services with DI** (VContainer) for global systems (`IWaveManager`, `IGameStateService`, `IAFKRewardService`) and use `MonoBehaviour` only for things that live on GameObjects (movement, health, targeting, attack, UI controllers).
- Use **ScriptableObjects** for:
	- Static config data (`MonsterConfigSO`, `EnemyConfigSO`, `WaveConfigSO`).
	- Runtime variables (`BaseHP`, `CurrentGold`, `CurrentWave`, `GameSpeed`).
- Always think **pooling first**:
	- Never `Destroy` enemies or projectiles; use `IPoolable` and `IPoolingService`.
	- Reset state (`HP`, waypoint index, timers) in `OnEnable`/`OnSpawn`.
- Try to keep systems **decoupled via GameEvents and SO variables** instead of direct references between components.
- Suggested implementation order when starting Phase 0:
	- Week 2: EnemyMovement (#24) → EnemyHealth (#25) → MonsterTargeting (#26) → MonsterAttack (#27).
	- Week 3: WaveManager (#34) → GameStateService (#35) → HUD wiring (#36) → Speed toggle (#37) → Monster placement (#38).
	- Week 4: Monster list panel logic (#41) → Monster detail panel logic (#42) → AFK popup logic (#43) → Hub→Battle flow (#44).


