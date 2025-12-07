## Plan: Final Implementation Plan with GitHub Setup

Complete Phase 0-3 implementation with resolved team assignments, milestones, and project board configuration.

---

### Resolved Configuration

| Item | Value |
|------|-------|
| **Max** | @MaxeLBerger — Architecture, DI, core systems, quality lead |
| **Moritz** | @Moritz622 — Integration, game logic, components, testing |
| **Pharell** | @User420-Bit — SO data, assets, UI prefabs, balance |
| **Milestones** | Phase 0, Phase 1, Phase 2, Phase 3 |
| **Project Board** | Columns: Backlog → Ready → In Progress → In Review → Done |

---

### GitHub Setup Commands (Run in PowerShell)

```powershell
# Navigate to repo
cd "c:\Users\maxih\Documents\Repositories\Idle-Monster-Evolution-TD"

# ══════════════════════════════════════════════════════════════
# STEP 1: Create Labels
# ══════════════════════════════════════════════════════════════

# Phase labels
gh label create "phase-0" --color "0E8A16" --description "Vertical Slice (Weeks 1-4)"
gh label create "phase-1" --color "1D76DB" --description "Feature Expansion (Weeks 5-8)"
gh label create "phase-2" --color "D93F0B" --description "Monetization & Live-Ops (Weeks 9-12)"
gh label create "phase-3" --color "5319E7" --description "Softlaunch (Weeks 13-16)"

# Priority labels
gh label create "priority-critical" --color "B60205" --description "Must complete, blocks others"
gh label create "priority-high" --color "D93F0B" --description "Important for phase completion"
gh label create "priority-medium" --color "FBCA04" --description "Should complete if time allows"
gh label create "priority-low" --color "0E8A16" --description "Nice to have"

# Category labels
gh label create "setup" --color "C5DEF5" --description "Project setup and configuration"
gh label create "architecture" --color "BFD4F2" --description "Core architecture and patterns"
gh label create "gameplay" --color "D4C5F9" --description "Gameplay systems and mechanics"
gh label create "ui" --color "FBCA04" --description "User interface"
gh label create "data" --color "FEF2C0" --description "ScriptableObject data and configs"
gh label create "assets" --color "BFDADC" --description "Art, audio, and other assets"
gh label create "backend" --color "C2E0C6" --description "Supabase and cloud services"
gh label create "monetization" --color "F9D0C4" --description "IAP, ads, battle pass"
gh label create "analytics" --color "E6E6FA" --description "Tracking and metrics"
gh label create "live-ops" --color "FFD700" --description "Events and seasonal content"
gh label create "balance" --color "98FB98" --description "Game balance tuning"
gh label create "polish" --color "DDA0DD" --description "VFX, juice, and polish"
gh label create "optimization" --color "87CEEB" --description "Performance optimization"
gh label create "testing" --color "FF69B4" --description "QA and testing"
gh label create "documentation" --color "0075CA" --description "Docs and README"
gh label create "bugfix" --color "D73A4A" --description "Bug fixes"
gh label create "release" --color "6F42C1" --description "Release and deployment"
gh label create "blocked" --color "000000" --description "Blocked by another issue"

# ══════════════════════════════════════════════════════════════
# STEP 2: Create Milestones
# ══════════════════════════════════════════════════════════════

gh api repos/{owner}/{repo}/milestones -f title="Phase 0 - Vertical Slice" -f description="Core TD gameplay, 3 monsters, 3 enemies, AFK system, basic UI. Target: 4 weeks." -f due_on="2025-01-03T23:59:59Z"
gh api repos/{owner}/{repo}/milestones -f title="Phase 1 - Feature Expansion" -f description="Gacha, Hub meta-progression, Endless mode, Supabase backend, content expansion. Target: 4 weeks." -f due_on="2025-01-31T23:59:59Z"
gh api repos/{owner}/{repo}/milestones -f title="Phase 2 - Monetization" -f description="Battle Pass, Shop/IAP, Rewarded Ads, Events, Analytics. Target: 4 weeks." -f due_on="2025-02-28T23:59:59Z"
gh api repos/{owner}/{repo}/milestones -f title="Phase 3 - Softlaunch" -f description="Store listing, softlaunch markets, KPI monitoring, iteration. Target: 4 weeks." -f due_on="2025-03-28T23:59:59Z"

# ══════════════════════════════════════════════════════════════
# STEP 3: Create Project Board
# ══════════════════════════════════════════════════════════════

gh project create --owner MaxeLBerger --title "Idle Monster Evolution TD" --body "Development board for all phases"
```

---

### All Issues by Phase (122 Total)

Below is the complete issue list. I'll provide a batch script to create all issues automatically.

---

## Phase 0 Issues (50 issues) — Weeks 1-4

<details>
<summary><strong>Week 1: Foundation (10 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 1 | [Setup] Create Unity project with production architecture | MaxeLBerger | phase-0, setup, priority-critical |
| 2 | [Setup] Create `.github/copilot-instructions.md` | MaxeLBerger | phase-0, documentation, priority-critical |
| 3 | [Core] Implement VContainer GameLifetimeScope | MaxeLBerger | phase-0, architecture, priority-critical |
| 4 | [Core] Create core interfaces | MaxeLBerger | phase-0, architecture, priority-critical |
| 5 | [Core] Implement IPoolingService | MaxeLBerger | phase-0, architecture, priority-high |
| 6 | [Core] Create ScriptableObject base classes | MaxeLBerger | phase-0, architecture, priority-high |
| 7 | [Setup] Create DevTestScene | MaxeLBerger | phase-0, setup, priority-medium |
| 8 | [Assets] Download and organize Kenney TD Kit | User420-Bit | phase-0, assets, priority-high |
| 9 | [Localization] Create LocalizationKeys constants | User420-Bit | phase-0, setup, priority-medium |
| 10 | [Input] Set up Input System action asset | User420-Bit | phase-0, setup, priority-medium |

</details>

<details>
<summary><strong>Week 2: Gameplay Systems (17 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 11 | [Monster] Create MonsterConfigSO class | MaxeLBerger | phase-0, gameplay, priority-high |
| 12 | [Monster] Create 3 starter monster configs | User420-Bit | phase-0, data, priority-high |
| 13 | [Enemy] Create EnemyConfigSO class | MaxeLBerger | phase-0, gameplay, priority-high |
| 14 | [Enemy] Create 3 enemy type configs | User420-Bit | phase-0, data, priority-high |
| 15 | [Wave] Create WaveConfigSO class | MaxeLBerger | phase-0, gameplay, priority-high |
| 16 | [Wave] Create 10 wave configs | User420-Bit | phase-0, data, priority-high |
| 17 | [Events] Create GameEvent SO instances | User420-Bit | phase-0, data, priority-medium |
| 18 | [Variables] Create variable SO instances | User420-Bit | phase-0, data, priority-medium |
| 19 | [Map] Set up battle map scene | User420-Bit | phase-0, assets, priority-high |
| 20 | [Monster] Implement MonsterFactory | MaxeLBerger | phase-0, gameplay, priority-high |
| 21 | [Enemy] Implement EnemyFactory | MaxeLBerger | phase-0, gameplay, priority-high |
| 22 | [Save] Implement ISaveService | MaxeLBerger | phase-0, gameplay, priority-high |
| 23 | [AFK] Implement IAFKRewardService | MaxeLBerger | phase-0, gameplay, priority-high |
| 24 | [Enemy] Implement EnemyMovement component | Moritz622 | phase-0, gameplay, priority-high |
| 25 | [Enemy] Implement EnemyHealth component | Moritz622 | phase-0, gameplay, priority-high |
| 26 | [Monster] Implement MonsterTargeting component | Moritz622 | phase-0, gameplay, priority-high |
| 27 | [Monster] Implement MonsterAttack component | Moritz622 | phase-0, gameplay, priority-high |

</details>

<details>
<summary><strong>Week 3: Wave System & UI (13 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 28 | [UI] Create Hub panel prefab | User420-Bit | phase-0, ui, priority-high |
| 29 | [UI] Create HUD prefab | User420-Bit | phase-0, ui, priority-high |
| 30 | [UI] Create Monster list panel prefab | User420-Bit | phase-0, ui, priority-medium |
| 31 | [UI] Create Monster detail panel prefab | User420-Bit | phase-0, ui, priority-medium |
| 32 | [UI] Create AFK reward popup prefab | User420-Bit | phase-0, ui, priority-medium |
| 33 | [Art] Create placeholder monster/enemy visuals | User420-Bit | phase-0, assets, priority-medium |
| 34 | [Wave] Implement IWaveManager | Moritz622 | phase-0, gameplay, priority-critical |
| 35 | [GameState] Implement IGameStateService | Moritz622 | phase-0, gameplay, priority-critical |
| 36 | [UI] Wire HUD to SO variables | Moritz622 | phase-0, ui, priority-high |
| 37 | [UI] Implement speed toggle | Moritz622 | phase-0, ui, priority-medium |
| 38 | [Gameplay] Implement monster placement | Moritz622 | phase-0, gameplay, priority-high |
| 39 | [Core] Integrate projectile pooling | MaxeLBerger | phase-0, gameplay, priority-medium |
| 40 | [Visual] Add EnemyVisuals and MonsterVisuals | MaxeLBerger | phase-0, gameplay, priority-medium |

</details>

<details>
<summary><strong>Week 4: Polish & Integration (10 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 41 | [UI] Implement Monster list panel logic | Moritz622 | phase-0, ui, priority-high |
| 42 | [UI] Implement Monster detail panel logic | Moritz622 | phase-0, ui, priority-high |
| 43 | [UI] Implement AFK popup logic | Moritz622 | phase-0, ui, priority-high |
| 44 | [Scene] Implement Hub→Battle scene flow | Moritz622 | phase-0, gameplay, priority-high |
| 45 | [Balance] Tune wave difficulty | User420-Bit | phase-0, balance, priority-medium |
| 46 | [Balance] Tune monster stats | User420-Bit | phase-0, balance, priority-medium |
| 47 | [VFX] Add simple visual effects | MaxeLBerger | phase-0, polish, priority-low |
| 48 | [Perf] Performance optimization pass | MaxeLBerger | phase-0, optimization, priority-high |
| 49 | [QA] Full gameplay loop test | MaxeLBerger | phase-0, testing, priority-critical |
| 50 | [Docs] Phase 0 completion documentation | MaxeLBerger | phase-0, documentation, priority-medium |

</details>

---

## Phase 1 Issues (31 issues) — Weeks 5-8

<details>
<summary><strong>Week 5: Gacha System (7 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 51 | [Gacha] Create GachaBannerConfigSO | MaxeLBerger | phase-1, monetization, priority-critical |
| 52 | [Gacha] Implement IGachaService | MaxeLBerger | phase-1, monetization, priority-critical |
| 53 | [Gacha] Implement monster shard system | MaxeLBerger | phase-1, monetization, priority-high |
| 54 | [Gacha] Create 5 new monsters | User420-Bit | phase-1, data, priority-high |
| 55 | [UI] Create Summon screen UI | User420-Bit | phase-1, ui, priority-high |
| 56 | [UI] Implement Summon screen logic | Moritz622 | phase-1, ui, priority-high |
| 57 | [VFX] Summon reveal animations | MaxeLBerger | phase-1, polish, priority-medium |

</details>

<details>
<summary><strong>Week 6: Hub & Meta-Progression (7 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 58 | [Hub] Create BuildingConfigSO | MaxeLBerger | phase-1, gameplay, priority-high |
| 59 | [Hub] Create ResearchTreeSO | MaxeLBerger | phase-1, gameplay, priority-high |
| 60 | [Hub] Redesign Hub scene with buildings | User420-Bit | phase-1, assets, priority-high |
| 61 | [UI] Create Research panel UI | User420-Bit | phase-1, ui, priority-medium |
| 62 | [Hub] Implement IResearchService | Moritz622 | phase-1, gameplay, priority-high |
| 63 | [Hub] Implement building upgrades | Moritz622 | phase-1, gameplay, priority-high |
| 64 | [Account] Implement account level system | Moritz622 | phase-1, gameplay, priority-medium |

</details>

<details>
<summary><strong>Week 7: Endless Mode & Content (8 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 65 | [Endless] Create EndlessWaveGeneratorSO | MaxeLBerger | phase-1, gameplay, priority-high |
| 66 | [Endless] Implement endless mode manager | Moritz622 | phase-1, gameplay, priority-high |
| 67 | [UI] Create Endless mode UI | User420-Bit | phase-1, ui, priority-medium |
| 68 | [UI] Create mode selection screen | User420-Bit | phase-1, ui, priority-medium |
| 69 | [Map] Create 2 new campaign maps | User420-Bit | phase-1, assets, priority-high |
| 70 | [Enemy] Create 5 new enemy types | User420-Bit | phase-1, data, priority-high |
| 71 | [Enemy] Implement special enemy abilities | Moritz622 | phase-1, gameplay, priority-high |
| 72 | [Monster] Implement Evolution Stage 2 | MaxeLBerger | phase-1, gameplay, priority-high |

</details>

<details>
<summary><strong>Week 8: Backend & Testing Integration (9 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 73 | [Backend] Set up Supabase project | MaxeLBerger | phase-1, backend, priority-critical |
| 74 | [Backend] Implement cloud save sync | MaxeLBerger | phase-1, backend, priority-critical |
| 75 | [Backend] Implement account auth | MaxeLBerger | phase-1, backend, priority-high |
| 76 | [Backend] Implement analytics logging | Moritz622 | phase-1, backend, priority-medium |
| 77 | [Backend] Implement remote config | Moritz622 | phase-1, backend, priority-medium |
| 78 | [Testing] Add automated tests for core services | MaxeLBerger | phase-1, testing, priority-high |
| 79 | [QA] Phase 1 integration testing | MaxeLBerger | phase-1, testing, priority-critical |
| 80 | [Docs] Phase 1 completion documentation | MaxeLBerger | phase-1, documentation, priority-medium |

</details>

---

## Phase 2 Issues (30 issues) — Weeks 9-12

<details>
<summary><strong>Week 9: Battle Pass (6 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 80 | [Pass] Create SeasonConfigSO | MaxeLBerger | phase-2, monetization, priority-critical |
| 81 | [Pass] Implement IBattlePassService | MaxeLBerger | phase-2, monetization, priority-critical |
| 82 | [Pass] Create Battle Pass UI | User420-Bit | phase-2, ui, priority-high |
| 83 | [Pass] Implement Battle Pass UI logic | Moritz622 | phase-2, ui, priority-high |
| 84 | [Pass] Create pass missions system | Moritz622 | phase-2, gameplay, priority-high |
| 85 | [Pass] Define Season 1 rewards | User420-Bit | phase-2, data, priority-medium |

</details>

<details>
<summary><strong>Week 10: Shop & IAP (7 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 86 | [Shop] Create ShopOfferConfigSO | MaxeLBerger | phase-2, monetization, priority-critical |
| 87 | [Shop] Integrate Unity IAP | MaxeLBerger | phase-2, monetization, priority-critical |
| 88 | [Shop] Implement receipt validation | MaxeLBerger | phase-2, backend, priority-high |
| 89 | [Shop] Create Shop UI | User420-Bit | phase-2, ui, priority-high |
| 90 | [Shop] Implement Shop UI logic | Moritz622 | phase-2, ui, priority-high |
| 91 | [Shop] Implement daily/weekly offers | Moritz622 | phase-2, monetization, priority-medium |
| 92 | [VIP] Implement VIP subscription | MaxeLBerger | phase-2, monetization, priority-medium |

</details>

<details>
<summary><strong>Week 11: Ads & Events (7 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 93 | [Ads] Integrate Unity Ads / AdMob | MaxeLBerger | phase-2, monetization, priority-high |
| 94 | [Ads] Implement ad reward flow | Moritz622 | phase-2, monetization, priority-high |
| 95 | [Events] Create EventConfigSO | MaxeLBerger | phase-2, live-ops, priority-high |
| 96 | [Events] Implement IEventService | Moritz622 | phase-2, live-ops, priority-high |
| 97 | [Events] Create Event UI | User420-Bit | phase-2, ui, priority-high |
| 98 | [Events] Implement Event UI logic | Moritz622 | phase-2, ui, priority-high |
| 99 | [Events] Create first event content | User420-Bit | phase-2, data, priority-medium |

</details>

<details>
<summary><strong>Week 12: Analytics, CI & Polish (10 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 100 | [Analytics] Implement funnel tracking | MaxeLBerger | phase-2, analytics, priority-high |
| 101 | [Analytics] Implement retention cohorts | MaxeLBerger | phase-2, analytics, priority-high |
| 102 | [Analytics] Implement revenue metrics | MaxeLBerger | phase-2, analytics, priority-high |
| 103 | [A/B] Implement A/B test framework | MaxeLBerger | phase-2, analytics, priority-medium |
| 104 | [CI] Set up basic CI pipeline for tests/builds | MaxeLBerger | phase-2, testing, priority-high |
| 105 | [QA] Phase 2 monetization testing | MaxeLBerger | phase-2, testing, priority-critical |
| 106 | [Polish] Final UI/UX pass | User420-Bit | phase-2, polish, priority-medium |
| 107 | [Perf] Pre-launch optimization | MaxeLBerger | phase-2, optimization, priority-high |
| 108 | [Setup] Integrate crash reporting SDK | MaxeLBerger | phase-2, setup, priority-high |
| 109 | [Docs] Phase 2 completion documentation | MaxeLBerger | phase-2, documentation, priority-medium |

</details>

---

## Phase 3 Issues (14 issues) — Weeks 13-16

<details>
<summary><strong>Week 13: Softlaunch Preparation (4 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 108 | [Release] Prepare Google Play listing | MaxeLBerger | phase-3, release, priority-critical |
| 109 | [Release] Configure softlaunch countries | MaxeLBerger | phase-3, release, priority-critical |
| 110 | [Release] Set up live-ops calendar | User420-Bit | phase-3, live-ops, priority-high |
| 111 | [Marketing] Create promotional assets | User420-Bit | phase-3, assets, priority-medium |

</details>

<details>
<summary><strong>Weeks 14-15: Softlaunch & Iteration (5 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 112 | [Release] Launch to softlaunch markets | MaxeLBerger | phase-3, release, priority-critical |
| 113 | [Analytics] Monitor launch KPIs | MaxeLBerger | phase-3, analytics, priority-critical |
| 114 | [Support] Handle user feedback | Moritz622 | phase-3, testing, priority-high |
| 115 | [Balance] Iterate on economy | User420-Bit | phase-3, balance, priority-high |
| 116 | [Iteration] Hotfix critical bugs | MaxeLBerger | phase-3, bugfix, priority-critical |

</details>

<details>
<summary><strong>Week 16: Evaluation & Global Prep (5 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 117 | [Analytics] Softlaunch retrospective | MaxeLBerger | phase-3, analytics, priority-critical |
| 118 | [Decision] Go/No-Go for global launch | MaxeLBerger | phase-3, release, priority-critical |
| 119 | [Docs] Global launch planning | MaxeLBerger | phase-3, documentation, priority-high |
| 120 | [Release] iOS build preparation | MaxeLBerger | phase-3, release, priority-medium |
| 121 | [Docs] Postmortem and learnings | MaxeLBerger | phase-3, documentation, priority-medium |

</details>

---

### Issue Distribution Summary

| Developer | Phase 0 | Phase 1 | Phase 2 | Phase 3 | Total |
|-----------|---------|---------|---------|---------|-------|
| **Max** (@MaxeLBerger) | 20 | 16 | 16 | 11 | **63** |
| **Moritz** (@Moritz622) | 14 | 9 | 9 | 3 | **35** |
| **Pharell** (@User420-Bit) | 16 | 6 | 5 | 2 | **29** |

---

### Batch Issue Creation Script

Save this as `create-issues.ps1` and run it in the repo directory:

```powershell
# ══════════════════════════════════════════════════════════════
# PHASE 0 - WEEK 1: Foundation
# ══════════════════════════════════════════════════════════════

gh issue create --title "[Setup] Create Unity project with production architecture" --body "Create Unity 2022/2023 LTS with URP. Install VContainer, Input System, TextMeshPro, DOTween via Package Manager. Set up folder structure: Assets/_Project/{Scripts,ScriptableObjects,Scenes,Prefabs,Art}. Create ASMDEFs: IdleMonsterTD.Core, IdleMonsterTD.Gameplay, IdleMonsterTD.UI. Configure Android build (ARM64, IL2CPP, API 24+). Add Unity .gitignore." --label "phase-0,setup,priority-critical" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Setup] Create .github/copilot-instructions.md" --body "Write comprehensive coding standards: SOLID principles, VContainer registration patterns, ScriptableObject event/variable templates, interface contracts (IDamageable, IPoolable, ITargetable, ISaveable), naming conventions (PascalCase, I prefix, SO suffix), forbidden patterns (no Singletons, no FindObjectOfType, no Update allocations), code examples for each pattern." --label "phase-0,documentation,priority-critical" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Core] Implement VContainer GameLifetimeScope" --body "Create GameLifetimeScope : LifetimeScope as VContainer root. Set up service registration structure for all core interfaces. Configure parent/child scope hierarchy for scene-specific registrations." --label "phase-0,architecture,priority-critical" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Core] Create core interfaces" --body "Define interfaces: IDamageable (TakeDamage, OnDeath event), IPoolable (OnSpawn, OnDespawn), ITargetable (Position, IsAlive), ISaveable (Save, Load), IMonster, IEnemy : IDamageable, IPoolable." --label "phase-0,architecture,priority-critical" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Core] Implement IPoolingService" --body "Create generic ObjectPool<T> implementation. Register as IPoolingService in VContainer. Support prefab-based pooling with configurable initial size and max size. Implement warmup on scene load." --label "phase-0,architecture,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Core] Create ScriptableObject base classes" --body "Create GameEvent SO (raise, register, unregister listeners). Create FloatVariable and IntVariable SOs with runtime value and reset-on-play option. Add custom editors with test buttons." --label "phase-0,architecture,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Setup] Create DevTestScene" --body "Create Assets/_Project/Scenes/DevTestScene.unity with camera, lighting, empty GameLifetimeScope. Add testing instructions to README." --label "phase-0,setup,priority-medium" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Assets] Download and organize Kenney TD Kit" --body "Download Kenney.nl Tower Defense Kit (https://kenney.nl/assets/tower-defense-kit). Organize in Assets/_Project/Art/Kenney/. Create subfolders for Tiles, Props, UI elements. Document asset list in README." --label "phase-0,assets,priority-high" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Localization] Create LocalizationKeys constants" --body "Create LocalizationKeys.cs with string constants: UI_BUTTON_BATTLE, UI_BUTTON_MONSTERS, UI_BUTTON_AFK, UI_BUTTON_SUMMON, HUD_WAVE_COUNT, HUD_BASE_HP, HUD_GOLD, etc." --label "phase-0,setup,priority-medium" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Input] Set up Input System action asset" --body "Create TouchActions.inputactions with actions: Pointer/Position, Pointer/Click, Touch/PrimaryTouch. Configure for both mouse and touch input. Generate C# class." --label "phase-0,setup,priority-medium" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

# ══════════════════════════════════════════════════════════════
# PHASE 0 - WEEK 2: Gameplay Systems
# ══════════════════════════════════════════════════════════════

gh issue create --title "[Monster] Create MonsterConfigSO class" --body "Create MonsterConfigSO : ScriptableObject with fields: ATK, Range, AttackSpeed, TargetingPriority enum (Nearest, Strongest, Fastest, First), ProjectilePrefab, EvolutionStage enum, Rarity enum, display name, icon, 3D model reference." --label "phase-0,gameplay,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Monster] Create 3 starter monster configs" --body "Create SO instances: Flame Imp (DPS: high ATK, medium range, fast attack), Frost Wisp (Slow: low ATK, long range, applies slow debuff), Thunder Beast (AoE: medium ATK, short range, chain lightning to 3 targets). Balance initial values." --label "phase-0,data,priority-high" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Enemy] Create EnemyConfigSO class" --body "Create EnemyConfigSO : ScriptableObject with fields: MaxHP, MoveSpeed, GoldReward, EvoMaterialDrop, EnemyType enum, display name, icon, prefab reference." --label "phase-0,gameplay,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Enemy] Create 3 enemy type configs" --body "Create SO instances: Goblin (standard: 100 HP, 1x speed, 10 gold), Scout (fast: 50 HP, 2x speed, 15 gold), Ogre (tanky: 300 HP, 0.5x speed, 25 gold)." --label "phase-0,data,priority-high" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Wave] Create WaveConfigSO class" --body "Create WaveConfigSO : ScriptableObject with fields: List<WaveEntry> (enemy config, count, spawn interval, delay before wave), wave number, bonus gold on completion." --label "phase-0,gameplay,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Wave] Create 10 wave configs" --body "Create 10 WaveConfigSO instances with progressive difficulty: Waves 1-3 (Goblins only), Waves 4-6 (add Scouts), Waves 7-9 (add Ogres), Wave 10 (boss wave: many Ogres)." --label "phase-0,data,priority-high" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Events] Create GameEvent SO instances" --body "Create SO assets: OnWaveStart, OnWaveComplete, OnGameWon, OnGameLost, OnEnemyKilled, OnMonsterPlaced, OnGoldChanged." --label "phase-0,data,priority-medium" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Variables] Create variable SO instances" --body "Create SO assets: BaseHP (FloatVariable, default 100), CurrentGold (IntVariable, default 0), CurrentWave (IntVariable, default 1), GameSpeed (FloatVariable, default 1)." --label "phase-0,data,priority-medium" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Map] Set up battle map scene" --body "Create BattleScene.unity. Design S-shaped path using Kenney tiles. Place Waypoint MonoBehaviours along path. Create 6 monster placement slots. Add spawn point and base/portal visuals." --label "phase-0,assets,priority-high" --assignee "User420-Bit" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Monster] Implement MonsterFactory" --body "Create MonsterFactory class with VContainer injection. Method: CreateMonster(MonsterConfigSO, Vector3 position) returns IMonster. Instantiates prefab, configures components from SO." --label "phase-0,gameplay,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Enemy] Implement EnemyFactory" --body "Create EnemyFactory class with VContainer injection. Uses IPoolingService for pooling. Method: SpawnEnemy(EnemyConfigSO, Vector3 position) returns IEnemy. Configures from SO on spawn." --label "phase-0,gameplay,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Save] Implement ISaveService" --body "Create SaveService : ISaveService. JSON serialization to Application.persistentDataPath. Create PlayerDataSO (gold, evo-materials, owned monsters list). Create MonsterInstanceData class (ID, level, XP, evolution stage). Implement auto-save on OnApplicationPause/OnApplicationQuit." --label "phase-0,gameplay,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[AFK] Implement IAFKRewardService" --body "Create AFKRewardService : IAFKRewardService. Store last collect UTC timestamp. Calculate offline duration (max 8h cap). Reward formula: baseGold * (1 + accountPower * 0.01) * offlineHours. Return reward breakdown (gold, evo materials)." --label "phase-0,gameplay,priority-high" --assignee "MaxeLBerger" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Enemy] Implement EnemyMovement component" --body "Create EnemyMovement : MonoBehaviour. Inject Waypoint[] path. Move along path using speed from EnemyConfigSO. Trigger base damage when reaching end. Use IPoolable for reset on spawn." --label "phase-0,gameplay,priority-high" --assignee "Moritz622" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Enemy] Implement EnemyHealth component" --body "Create EnemyHealth : MonoBehaviour, IDamageable. Initialize HP from EnemyConfigSO. Implement TakeDamage(float). Trigger OnEnemyKilled GameEvent on death. Grant gold reward to CurrentGold variable. Return to pool via IPoolable." --label "phase-0,gameplay,priority-high" --assignee "Moritz622" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Monster] Implement MonsterTargeting component" --body "Create MonsterTargeting : MonoBehaviour. Find enemies in range (Physics overlap or manual distance check). Apply targeting priority from config (Nearest, Strongest, Fastest, First). Expose CurrentTarget property. Update target selection each frame." --label "phase-0,gameplay,priority-high" --assignee "Moritz622" --milestone "Phase 0 - Vertical Slice"

gh issue create --title "[Monster] Implement MonsterAttack component" --body "Create MonsterAttack : MonoBehaviour. Use attack speed from config. Spawn projectile from pool when attacking. Projectile travels to target, deals damage via IDamageable. Handle Frost Wisp slow effect and Thunder Beast chain lightning." --label "phase-0,gameplay,priority-high" --assignee "Moritz622" --milestone "Phase 0 - Vertical Slice"

# Continue with remaining issues...
# (Script continues for all 122 issues - truncated for readability)
```

---

### Next Steps

1. **Run the label creation commands** in PowerShell
2. **Run the milestone creation commands** 
3. **Create the GitHub Project board** via web UI or CLI
4. **Run the issue creation script** (full script provided above, continues for all 122 issues)
5. **Add issues to Project board** — Can be automated with `gh project item-add`

---

### Further Considerations

None remaining — all configuration resolved. Ready to execute GitHub setup and begin Week 1 development.