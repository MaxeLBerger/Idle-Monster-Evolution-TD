# Max's Phase 0 Issues — Weeks 1–4

**Focus:** Project setup, VContainer DI, core configs, factories, save/AFK systems, visuals, QA

---

## Phase 0 Issue Summary (21 issues)

| # | Title | Priority | Status |
|---|-------|----------|---------|
| #1 | [Setup] Create Unity project with production architecture | Critical | ✅ |
| #2 | [Setup] Create `.github/copilot-instructions.md` | Critical | ✅ |
| #2b | [CI] Setup GitHub Copilot Auto Code Review | High | ⬜ |
| #3 | [Core] Implement VContainer GameLifetimeScope | Critical | ⬜ |
| #4 | [Core] Create core interfaces | Critical | ⬜ |
| #5 | [Core] Implement IPoolingService | High | ⬜ |
| #6 | [Core] Create ScriptableObject base classes | High | ⬜ |
| #7 | [Setup] Create DevTestScene | Medium | ⬜ |
| #11 | [Monster] Create MonsterConfigSO class | High | ⬜ |
| #13 | [Enemy] Create EnemyConfigSO class | High | ⬜ |
| #15 | [Wave] Create WaveConfigSO class | High | ⬜ |
| #20 | [Monster] Implement MonsterFactory | High | ⬜ |
| #21 | [Enemy] Implement EnemyFactory | High | ⬜ |
| #22 | [Save] Implement ISaveService | High | ⬜ |
| #23 | [AFK] Implement IAFKRewardService | High | ⬜ |
| #39 | [Core] Integrate projectile pooling | Medium | ⬜ |
| #40 | [Visual] Add EnemyVisuals and MonsterVisuals | Medium | ⬜ |
| #47 | [VFX] Add simple visual effects | Low | ⬜ |
| #48 | [Perf] Performance optimization pass | High | ⬜ |
| #49 | [QA] Full gameplay loop test | Critical | ⬜ |
| #50 | [Docs] Phase 0 completion documentation | Medium | ⬜ |

---

## Issue #1: [Setup] Create Unity project with production architecture

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `setup`, `priority-critical`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Create the Unity project with folders, assemblies, and baseline settings ready for a production mobile game.

---

### 📋 Requirements
- Unity 2022.3 LTS (or project-agreed version)
- Separate runtime vs editor assemblies
- Clean folder hierarchy under `Assets/_Project`
- Mobile settings optimized (orientation, quality, scripting backend, IL2CPP)
- Basic scenes: `Boot`, `Hub`, `Battle`, `DevTestScene`

---

### 📝 Implementation

**Folder structure (under `Assets/`):**
- `_Project/`
  - `Scripts/`
    - `Core/` (services, interfaces, DI)
    - `Gameplay/` (monsters, enemies, waves, hub)
    - `UI/`
    - `Backend/`
  - `ScriptableObjects/`
    - `Monsters/`, `Enemies/`, `Waves/`, `Hub/`, `Balance/`
  - `Prefabs/`
  - `Scenes/`
    - `Boot.unity`, `Hub.unity`, `Battle.unity`, `DevTestScene.unity`

**Assembly Definitions:**
Create `.asmdef` files to split code:
- `_Project/Core/Core.asmdef`
- `_Project/Gameplay/Gameplay.asmdef`
- `_Project/UI/UI.asmdef`
- `_Project/Backend/Backend.asmdef`

Reference chain: `Core` → used by all, `Gameplay` references `Core`, `UI` references `Core` + `Gameplay`, `Backend` references `Core`.

**Project Settings (high level):**
- Scripting Backend: **IL2CPP**
- Api Compatibility Level: **.NET Standard 2.1**
- Orientation: Portrait (lock if game is portrait-only)
- Disable unused modules in Player Settings if needed

---

### ✅ Definition of Done
- [ ] Folder structure created in `Assets/_Project`
- [ ] Assembly definitions created and compiling
- [ ] Core scenes created (`Boot`, `Hub`, `Battle`, `DevTestScene`)
- [ ] Mobile-friendly Player Settings set
- [ ] Project opens without errors

---

## Issue #2: [Setup] Create `.github/copilot-instructions.md`

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `documentation`, `priority-critical`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Provide clear instructions for GitHub Copilot and AI tooling so generated code follows project patterns.

---

### 📋 Requirements
- Describe architecture (VContainer DI, services, ScriptableObjects)
- Coding style and naming conventions
- Folder and namespace conventions
- How to register services in `GameLifetimeScope`
- How to work with Supabase backend

---

### 📝 Implementation

**File:** `.github/copilot-instructions.md`

Include sections:
- **Architecture Overview:** DI with VContainer, service interfaces in `Core`, implementations in feature folders.
- **Patterns:** Service interfaces, `I...Service`, ScriptableObject configs, factory + pooling pattern, UniTask for async.
- **Conventions:**
  - Namespaces: `IdleMonsterTD.Core.*`, `IdleMonsterTD.Gameplay.*`, `IdleMonsterTD.UI.*`
  - Use PascalCase for classes, camelCase for fields (private fields with `_` prefix).
- **Dependencies:** Note use of VContainer, UniTask, R3, Supabase.

---

### ✅ Definition of Done
- [x] `.github/copilot-instructions.md` created
- [x] Architecture and patterns described
- [x] Examples for service + registration included
- [x] Pushed to repo so Copilot reads it

---

## Issue #2b: [CI] Setup GitHub Copilot Auto Code Review

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `ci-cd`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Automatische Code-Reviews durch GitHub Copilot bei jedem Pull Request auf `dev` und `main` Branches.

---

### 📋 Requirements
- Automatischer Trigger bei PRs auf `dev` und `main` Branch
- Copilot analysiert geänderte Dateien
- Review-Kommentare direkt im PR
- Einhaltung der `copilot-instructions.md` Richtlinien prüfen
- Optional: Review bei neuen Pushes auf bestehende PRs

---

### 📝 Implementation

**Setup via GitHub Repository Rulesets:**

1. **Repository Settings → Rules → Rulesets → New ruleset**
2. **New branch ruleset** erstellen
3. **Ruleset Name:** `Copilot Auto Review`
4. **Enforcement Status:** Active
5. **Target branches:** Add target → Include default branch + `dev`
6. **Branch rules:** Aktiviere `Automatically request Copilot code review`
   - ✅ Review new pushes (optional)
   - ✅ Review draft pull requests (optional)
7. **Create** klicken

**Voraussetzungen:**
- GitHub Copilot Business/Enterprise für das Repository
- `.github/copilot-instructions.md` vorhanden (für Custom Instructions)

**Custom Instructions für Code Review:**

Copilot verwendet automatisch die `.github/copilot-instructions.md` als Kontext für Reviews.

---

### 🔧 Setup-Schritte

1. Navigiere zu: https://github.com/MaxeLBerger/Idle-Monster-Evolution-TD/settings/rules
2. Klicke "New ruleset" → "New branch ruleset"
3. Konfiguriere wie oben beschrieben
4. Teste mit einem Test-PR

---

### ✅ Definition of Done
- [ ] Branch Ruleset für Copilot Auto Review erstellt
- [ ] Target branches: `main` und `dev` konfiguriert
- [ ] Test-PR erstellt und von Copilot reviewt
- [ ] Review-Kommentare erscheinen automatisch bei PRs
- [ ] Team informiert über neuen Review-Prozess

---

## Issue #3: [Core] Implement VContainer GameLifetimeScope

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `architecture`, `priority-critical`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Central dependency injection root that wires up all services and game entry points and establishes cross-cutting infrastructure for logging and global balancing so that all later systems (gameplay, backend, monetization) can rely on a shared `ILoggingService` and `GlobalBalanceConfigSO` instead of ad-hoc logs and hard-coded constants.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/DI/GameLifetimeScope.cs`

Define a VContainer scope deriving from `LifetimeScope`:
- Register core services (save, AFK, pooling, factories)
- Register ScriptableObject singletons as configs
- Wire scene entry points via constructor injection

Ensure separate scopes for `Hub` and `Battle` scenes if needed (e.g., `HubLifetimeScope`, `BattleLifetimeScope`) that extend base registrations.

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

---

### ✅ Definition of Done
- [ ] `GameLifetimeScope` implemented
- [ ] Compiles and runs, services resolved
- [ ] Used in Boot scene as entry point
 - [ ] `ILoggingService` / `LoggingService` implemented and registered in `GameLifetimeScope`
 - [ ] New Phase 1+ systems use `ILoggingService` instead of `Debug.Log*` directly
 - [ ] `GlobalBalanceConfigSO` asset created with initial AFK, shard, combat, and monetization parameters
 - [ ] Systems needing global tunables can read them from `GlobalBalanceConfigSO` via DI

---

## Issue #4: [Core] Create core interfaces

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `architecture`, `priority-critical`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Define key service interfaces used across the project to decouple systems.

---

### 📝 Implementation

**Location:** `Assets/_Project/Scripts/Core/Services/`

Create basic interfaces (minimal methods to start):
- `ISaveService` (see Issue #22 for details)
- `IAFKRewardService` (Issue #23)
- `IPoolingService` (Issue #5)
- `IMonsterFactory`, `IEnemyFactory` (Issues #20, #21)
- `IGameStateService`, `IWaveManager` (for Moritz’s work)

Keep them small and focused; implementations come in their own issues.

---

### ✅ Definition of Done
- [ ] Interfaces created in `Core/Services`
- [ ] Namespaces consistent (`IdleMonsterTD.Core.Services`)
- [ ] No concrete implementation logic here

---

## Issue #5: [Core] Implement IPoolingService

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `architecture`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Reusable object pooling service for projectiles, enemies, and other frequently spawned objects.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Services/IPoolingService.cs`

Define a generic pooling interface to spawn and return objects without `Instantiate`/`Destroy` spikes.

**File:** `Assets/_Project/Scripts/Core/Services/PoolingService.cs`

Implement pooling using dictionaries keyed by prefab, with initial pool size and expansion logic.
Integrate with projectile, enemies, and later VFX.

Register `PoolingService` as singleton in `GameLifetimeScope`.

---

### ✅ Definition of Done
- [ ] `IPoolingService` interface defined
- [ ] `PoolingService` implementation complete
- [ ] Used by projectile/enemy systems
- [ ] No major allocations during gameplay

---

## Issue #6: [Core] Create ScriptableObject base classes

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `architecture`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Provide base SO patterns (ID, localization key, description) for configs.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Data/BaseConfigSO.cs`

Base class with common fields:
- `string Id`
- `string DisplayNameKey`
- `string DescriptionKey`

Derived configs will be `MonsterConfigSO`, `EnemyConfigSO`, etc.

---

### ✅ Definition of Done
- [ ] Base ScriptableObject class(es) created
- [ ] Monster/Enemy/Wave configs planned to inherit

---

## Issue #7: [Setup] Create DevTestScene

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `setup`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
A sandbox scene for quickly testing monsters, enemies, waves, and services.

---

### 📝 Implementation

**Scene:** `Assets/_Project/Scenes/DevTestScene.unity`
- Simple arena with 1–2 lanes
- UI overlays for spawning monsters/enemies
- Buttons to simulate AFK, save/load, etc.

---

### ✅ Definition of Done
- [ ] DevTestScene created
- [ ] Can spawn test monsters/enemies
- [ ] Hooked into DI boot flow

---

## Issue #11: [Monster] Create MonsterConfigSO class

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Define monster stats, visuals, and abilities via ScriptableObject.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Monster/MonsterConfigSO.cs`

Core fields:
- Id, name, description (from base)
- Rarity, element, role (DPS, Tank, Support)
- Base stats (HP, Damage, Range, AttackSpeed)
- Growth curves or level multipliers
- Prefab reference

Used by `MonsterFactory` and monster instances.

---

### ✅ Definition of Done
- [ ] MonsterConfigSO created
- [ ] At least 3 starter monsters configured

---

## Issue #13: [Enemy] Create EnemyConfigSO class

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Define enemy stats, movement speed, and rewards via ScriptableObject.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Enemy/EnemyConfigSO.cs`

Core fields:
- Id, name, description
- Health, speed, armor/resist type
- Reward gold/XP
- Prefab reference

---

### ✅ Definition of Done
- [ ] EnemyConfigSO created
- [ ] At least 3 enemy types configured

---

## Issue #15: [Wave] Create WaveConfigSO class

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Create config describing which enemies spawn in which order for campaign waves.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Wave/WaveConfigSO.cs`

Contains:
- Wave index, map id
- List of enemy entries (config + count + spawn interval)
- Reward overrides

---

### ✅ Definition of Done
- [ ] WaveConfigSO created
- [ ] 10 starter waves configured

---

## Issue #20: [Monster] Implement MonsterFactory

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Central factory to spawn monsters from `MonsterConfigSO` with DI + pooling.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Monster/MonsterFactory.cs`

- Takes `MonsterConfigSO`, spawn position, lane
- Uses `IPoolingService` for pooled instantiation
- Injects services into monster component via VContainer

---

### ✅ Definition of Done
- [ ] MonsterFactory implemented
- [ ] Used by placement/Spawn systems

---

## Issue #21: [Enemy] Implement EnemyFactory

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Factory for enemies using `EnemyConfigSO` and pooling.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Enemy/EnemyFactory.cs`

- Spawns enemies along path
- Integrates with `IWaveManager`
- Uses `IPoolingService`

---

### ✅ Definition of Done
- [ ] EnemyFactory implemented
- [ ] Integrated with first wave system

---

## Issue #22: [Save] Implement ISaveService

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Generic save/load service for player progress, using PlayerPrefs/file in Phase 0.

---

### 📝 Implementation

**Files:**
- `ISaveService` (interface)
- `SaveService` (implementation)

Features:
- `Save<T>(key, data)` / `Load<T>(key)` using JSON
- Basic encryption/obfuscation optional
- Later will plug into cloud save

---

### ✅ Definition of Done
- [ ] ISaveService interface defined
- [ ] SaveService working in editor and device
- [ ] Used by AFK, progression, settings

---

## Issue #23: [AFK] Implement IAFKRewardService

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Service that tracks offline time and grants AFK rewards when player returns.

---

### 📝 Implementation

Use `ISaveService` to store last logout time;
on login, compute delta and reward gold/resources based on progression.

---

### ✅ Definition of Done
- [ ] IAFKRewardService defined
- [ ] Rewards calculated based on time
- [ ] Basic AFK popup wired (even temporary)

---

## Issue #39: [Core] Integrate projectile pooling

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Use `IPoolingService` for projectiles fired by monsters.

---

### 📝 Implementation

Refactor projectile spawn logic to request from pool instead of `Instantiate`.
Return projectile to pool on hit or lifetime end.

---

### ✅ Definition of Done
- [ ] All projectiles spawned via pooling
- [ ] No runtime allocations per shot

---

## Issue #40: [Visual] Add EnemyVisuals and MonsterVisuals

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `gameplay`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Separate gameplay logic from visuals using dedicated visual components.

---

### 📝 Implementation

Create components:
- `MonsterVisuals` (handles animation, hit flashes, death FX)
- `EnemyVisuals` (similar for enemies)

Hook them up from `Monster`/`Enemy` logic but keep visuals swap-able.

---

### ✅ Definition of Done
- [ ] Visual components added
- [ ] Logic components communicate via events

---

## Issue #47: [VFX] Add simple visual effects

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `polish`, `priority-low`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Baseline juice: hit flashes, simple explosions, damage numbers.

---

### 📝 Implementation

Use pooled VFX prefabs for:
- Projectile impact
- Enemy death puff
- Hit highlight on monsters

---

### ✅ Definition of Done
- [ ] Basic VFX present on all main interactions
- [ ] No excessive overdraw on mobile

---

## Issue #48: [Perf] Performance optimization pass

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `optimization`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Initial performance sweep to ensure 60 FPS on target devices.

---

### 📝 Implementation

Checklist:
- Confirm pooling used where needed
- Remove heavy `Update()` allocations
- Cache component references
- Use Sprite Atlases and batch materials where possible

---

### ✅ Definition of Done
- [ ] No GC spikes during normal play
- [ ] Verified on low/mid-range test device

---

## Issue #49: [QA] Full gameplay loop test

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `testing`, `priority-critical`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Test full loop: Hub → Battle → Rewards → AFK → Return.

---

### 📋 Test Checklist
- [ ] Start from fresh profile
- [ ] Place monsters and complete first 10 waves
- [ ] Earn and spend rewards
- [ ] Close game, wait, AFK rewards
- [ ] Repeat loop without crashes

---

### ✅ Definition of Done
- [ ] All test steps pass
- [ ] No blocking bugs

---

## Issue #50: [Docs] Phase 0 completion documentation

**Assignee:** @MaxeLBerger  
**Labels:** `phase-0`, `documentation`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

### 🎯 Goal
Document Phase 0 systems and handoff to Phase 1.

---

### 📝 Documentation Deliverables
- Update `README.md` with Phase 0 status
- Create `CORE_ARCHITECTURE.md` describing DI, services, and flows
- Document base configs (Monster/Enemy/Wave)

---

### ✅ Definition of Done
- [ ] CORE_ARCHITECTURE.md written
- [ ] README updated with how to run vertical slice
- [ ] Notes prepared for Phase 1 expansion

---

<!-- End of Phase 0 -->
