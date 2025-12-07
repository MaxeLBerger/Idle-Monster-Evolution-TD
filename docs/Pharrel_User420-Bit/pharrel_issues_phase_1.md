## Phase 1 Issues for Pharell (@User420-Bit)

This file contains all Phase 1 issues assigned to Pharell, copied 1:1 from `pharrel_issues.md` but scoped to Feature Expansion work.

---

### Issue #54: [Gacha] Create 5 new monsters

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `data`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion  
**Blocked by:** Phase 0 complete, MonsterConfigSO exists

---

#### 🎯 Goal
Design and create 5 new monsters for the Gacha system with increasing rarity and unique abilities.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Monster Configs**

Navigate to: `Assets/_Project/ScriptableObjects/Monsters/`

Create these 5 new monsters:

---

**Monster 4: Stone Golem** (Rare - Defensive)
```
Filename: StoneGolem_Config.asset

Display Name:     Stone Golem
Rarity:           Rare
Evolution Stage:  Normal

═══ STATS ═══
ATK:              15
Range:            2.0  (very short range)
Attack Speed:     0.4  (slow but powerful)

═══ TARGETING ═══
Targeting Priority: Strongest

═══ SPECIAL ═══
Ability: "Earthquake" - Every 4th attack stuns enemies for 0.5s
Stun Duration: 0.5 seconds

═══ DESCRIPTION ═══
"An ancient stone guardian. Slow attacks but can stun enemies with powerful ground pounds!"

═══ PLACEHOLDER VISUAL ═══
Shape: Cube (large)
Color: Gray (150, 150, 150)
Scale: (1.3, 1.3, 1.3)
```

---

**Monster 5: Wind Sprite** (Rare - Long Range)
```
Filename: WindSprite_Config.asset

Display Name:     Wind Sprite
Rarity:           Rare
Evolution Stage:  Normal

═══ STATS ═══
ATK:              12
Range:            7.0  (longest range in game!)
Attack Speed:     1.0

═══ TARGETING ═══
Targeting Priority: First

═══ SPECIAL ═══
Ability: "Gust" - Pushes enemies back slightly on hit
Pushback Distance: 0.3 units

═══ DESCRIPTION ═══
"A swift spirit of the wind. Incredible range and can push enemies backward!"

═══ PLACEHOLDER VISUAL ═══
Shape: Small Sphere with trail
Color: White/Light Cyan (220, 255, 255)
Scale: (0.5, 0.5, 0.5)
```

---

**Monster 6: Shadow Panther** (Epic - Multi-Hit)
```
Filename: ShadowPanther_Config.asset

Display Name:     Shadow Panther
Rarity:           Epic
Evolution Stage:  Normal

═══ STATS ═══
ATK:              8  (per hit)
Range:            3.5
Attack Speed:     2.5  (very fast!)

═══ TARGETING ═══
Targeting Priority: Fastest

═══ SPECIAL ═══
Ability: "Shadow Strike" - Each attack hits 3 times rapidly
Hits Per Attack: 3
(Effective DPS: 8 × 3 × 2.5 = 60!)

═══ DESCRIPTION ═══
"A deadly predator from the shadow realm. Strikes multiple times in the blink of an eye!"

═══ PLACEHOLDER VISUAL ═══
Shape: Stretched capsule (cat-like)
Color: Dark Purple (40, 20, 60)
Scale: (0.6, 0.5, 1.0)
```

---

**Monster 7: Phoenix** (Epic - AoE + DoT)
```
Filename: Phoenix_Config.asset

Display Name:     Phoenix
Rarity:           Epic
Evolution Stage:  Normal

═══ STATS ═══
ATK:              20
Range:            4.0
Attack Speed:     0.7

═══ TARGETING ═══
Targeting Priority: Nearest

═══ SPECIAL ═══
Ability: "Flame Burst" - Attacks hit in AoE and apply burn
AoE Radius: 1.5 units
Burn Damage: 5 per second
Burn Duration: 3 seconds

═══ DESCRIPTION ═══
"A legendary bird of fire. Burns everything in its path with explosive flame attacks!"

═══ PLACEHOLDER VISUAL ═══
Shape: Sphere with wing-like attachments
Color: Orange-Red (255, 100, 30)
Scale: (0.9, 0.9, 0.9)
Add: Emission for glowing effect
```

---

**Monster 8: Dragon Lord** (Legendary - Ultimate AoE)
```
Filename: DragonLord_Config.asset

Display Name:     Dragon Lord
Rarity:           Legendary
Evolution Stage:  Normal

═══ STATS ═══
ATK:              35
Range:            5.0
Attack Speed:     0.5

═══ TARGETING ═══
Targeting Priority: Strongest

═══ SPECIAL ═══
Ability: "Dragon Breath" - Massive cone attack hitting all enemies in front
Cone Angle: 45 degrees
Cone Range: 5.0 units

═══ DESCRIPTION ═══
"The mightiest of all monsters. Its dragon breath devastates everything before it!"

═══ PLACEHOLDER VISUAL ═══
Shape: Large cube with sphere head
Color: Deep Red (150, 30, 30)
Scale: (1.5, 1.2, 1.8)
Add: Bright emission, particle effect
```

---

**Step 2: Create Placeholder Visuals**

For each new monster:
1. Create the prefab as described in visual section
2. Save to `Assets/_Project/Prefabs/Monsters/`
3. Link prefab to the config

**Step 3: Create Placeholder Materials**

| Material Name | Color | Emission |
|---------------|-------|----------|
| `Mat_StoneGolem` | Gray (150, 150, 150) | None |
| `Mat_WindSprite` | Cyan (220, 255, 255) | Light cyan |
| `Mat_ShadowPanther` | Dark Purple (40, 20, 60) | Purple |
| `Mat_Phoenix` | Orange (255, 100, 30) | Bright orange |
| `Mat_DragonLord` | Deep Red (150, 30, 30) | Red glow |

---

#### 🎮 Monster Role Summary

| Monster | Rarity | Role | Best Against |
|---------|--------|------|--------------|
| Stone Golem | Rare | Tank/Stun | Grouped enemies |
| Wind Sprite | Rare | Long Range/Pushback | All (safe distance) |
| Shadow Panther | Epic | DPS/Fast | Fast enemies |
| Phoenix | Epic | AoE/Burn | Groups |
| Dragon Lord | Legendary | Ultimate AoE | Everything! |

---

#### ✅ Definition of Done
- [ ] 5 MonsterConfigSO assets created with all stats
- [ ] 5 placeholder prefabs created
- [ ] 5 materials created
- [ ] Configs linked to prefabs
- [ ] Rarity distribution: 2 Rare, 2 Epic, 1 Legendary

---

---

### Issue #55: [UI] Create Summon screen UI

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `ui`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create the Gacha/Summon screen where players spend diamonds to get new monsters.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Panel**
1. In HubScene, right-click Canvas → UI → Panel
2. Name: `SummonScreen`
3. Full screen, dark themed background

**Step 2: Create Layout**

```
┌────────────────────────────────────────────────────────────┐
│  [←]                    SUMMON                         [?] │
├────────────────────────────────────────────────────────────┤
│                                                            │
│          ╔══════════════════════════════════╗              │
│          ║                                  ║              │
│          ║        🎴 BANNER IMAGE 🎴        ║              │
│          ║                                  ║              │
│          ║    "Flame Festival Banner"       ║              │
│          ║                                  ║              │
│          ╚══════════════════════════════════╝              │
│                                                            │
│                   Featured: Phoenix 🔥                     │
│                                                            │
├────────────────────────────────────────────────────────────┤
│                                                            │
│         ┌─────────────────┐  ┌─────────────────┐          │
│         │                 │  │                 │          │
│         │   SUMMON x1     │  │   SUMMON x10    │          │
│         │                 │  │                 │          │
│         │   💎 100        │  │   💎 900        │          │
│         │                 │  │   (10% off!)    │          │
│         └─────────────────┘  └─────────────────┘          │
│                                                            │
├────────────────────────────────────────────────────────────┤
│  Pity Counter: 67/90  ████████████████░░░░░  Guaranteed!   │
│                                                            │
│  [View Drop Rates]                                         │
└────────────────────────────────────────────────────────────┘
```

**Step 3: Build Header**
1. Back button (←) - returns to Hub
2. Title: "SUMMON" (centered)
3. Info button (?) - shows help

**Step 4: Build Banner Area**
1. Create large Image: `BannerImage`
	- Size: 800 x 400
	- Placeholder: colored rectangle with "BANNER" text
2. Add banner title below: `BannerTitle`
3. Add featured monster display: `FeaturedMonster`

**Step 5: Build Summon Buttons**

Create 2 buttons side by side:

**Single Summon Button:**
```
Name: Button_SummonSingle
Size: 300 x 150
Contents:
  - "SUMMON x1"
  - Diamond icon + "100"
Color: Blue (80, 120, 200)
```

**10x Summon Button:**
```
Name: Button_SummonTen
Size: 300 x 150
Contents:
  - "SUMMON x10"
  - Diamond icon + "900"
  - Small text: "(10% off!)"
Color: Purple (150, 80, 200)
```

**Step 6: Build Pity Counter**
1. Add Slider: `PityBar`
	- Not interactable
	- Fill color: Gold
2. Add Text: `PityText`
	- Shows "67/90" or similar
3. Add Text: "Guaranteed Epic/Legendary at 90!"

**Step 7: Build Drop Rates Button**
1. Create small button: `Button_ViewRates`
2. Text: "View Drop Rates"
3. When clicked, shows popup with rates (Moritz will implement)

**Step 8: Create Prefab**
1. Drag `SummonScreen` to `Assets/_Project/Prefabs/UI/`

---

#### ✅ Definition of Done
- [ ] `SummonScreen.prefab` created
- [ ] Banner area with placeholder image
- [ ] Single summon button with cost display
- [ ] 10x summon button with cost display
- [ ] Pity counter bar and text
- [ ] Drop rates button
- [ ] Back button to Hub

---

---

### Issue #60: [Hub] Redesign Hub scene with buildings

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `assets`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Transform the Hub from simple buttons into a visual base with clickable buildings.

---

#### 📝 Step-by-Step Instructions

**Step 1: Open HubScene**
1. Open: `Assets/_Project/Scenes/HubScene.unity`
2. Keep the Canvas but we'll modify the content

**Step 2: Create Hub Layout**

```
┌────────────────────────────────────────────────────────────┐
│                     💎 1,250          🪙 45,000            │
│  [Settings]                                      [Profile] │
├────────────────────────────────────────────────────────────┤
│                                                            │
│      ┌─────────┐                      ┌─────────┐         │
│      │ MONSTER │                      │ SUMMON  │         │
│      │   LAB   │                      │  ARENA  │         │
│      │  Lv.3   │                      │  Lv.2   │         │
│      └─────────┘                      └─────────┘         │
│                                                            │
│                    ┌─────────┐                            │
│                    │  YOUR   │                            │
│                    │  BASE   │                            │
│                    │         │                            │
│                    └─────────┘                            │
│                                                            │
│      ┌─────────┐                      ┌─────────┐         │
│      │RESEARCH │                      │   AFK   │         │
│      │   LAB   │                      │  CHEST  │         │
│      │  Lv.1   │                      │  Ready! │         │
│      └─────────┘                      └─────────┘         │
│                                                            │
├────────────────────────────────────────────────────────────┤
│                                                            │
│   ┌──────────────────────────────────────────────────┐    │
│   │                    BATTLE!                        │    │
│   └──────────────────────────────────────────────────┘    │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

**Step 3: Create Top Bar**
1. Create Panel: `TopBar`
	- Anchor: Top stretch
	- Height: 80
2. Add diamond display (icon + count)
3. Add gold display (icon + count)
4. Add Settings button (gear icon) - left
5. Add Profile button (avatar icon) - right

**Step 4: Create Building Container**
1. Create Empty: `Buildings`
2. Position in center of screen

**Step 5: Create Building Prefab Template**

Create `BuildingNode.prefab`:
```
BuildingNode
├── Background (Image - building shape)
├── Icon (Image - building-specific icon)
├── NameText (TMP - "Monster Lab")
├── LevelText (TMP - "Lv. 3")
├── NotificationBadge (Image - for alerts, hidden by default)
└── Button (invisible, covers whole area)
```

**Step 6: Place 4 Buildings**

| Building | Position | Icon Idea |
|----------|----------|-----------|
| Monster Lab | Top-Left | Monster silhouette |
| Summon Arena | Top-Right | Crystal/portal |
| Research Lab | Bottom-Left | Flask/gear |
| AFK Chest | Bottom-Right | Treasure chest |

**Step 7: Create Battle Button**
1. At bottom of screen
2. Large, prominent button
3. Text: "BATTLE!"
4. Green color, glow effect

**Step 8: Add Visual Polish**
1. Background: Gradient or subtle pattern
2. Buildings: Add subtle shadows
3. Add decorative elements (trees, clouds, etc.)

---

#### ✅ Definition of Done
- [ ] HubScene has building-based layout
- [ ] 4 buildings placed (Monster Lab, Summon Arena, Research, AFK Chest)
- [ ] Each building shows name and level
- [ ] Top bar with currency displays
- [ ] Battle button at bottom
- [ ] Buildings are clickable (have Button component)
- [ ] `BuildingNode.prefab` created for reuse

---

---

### Issue #61: [UI] Create Research panel UI

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `ui`, `priority-medium`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create the Research Lab panel showing a tech tree of upgrades.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Panel**
1. Right-click Canvas → UI → Panel
2. Name: `ResearchPanel`
3. Full screen with header

**Step 2: Create Layout**

```
┌────────────────────────────────────────────────────────────┐
│  [←]                 RESEARCH LAB                      [?] │
├────────────────────────────────────────────────────────────┤
│                                                            │
│                        COMBAT                              │
│                          │                                 │
│               ┌──────────┼──────────┐                      │
│               │          │          │                      │
│            [ATK+5%]  [ATK+10%]  [ATK+15%]                  │
│               ✓          ✓         🔒                      │
│               │          │          │                      │
│               └──────────┼──────────┘                      │
│                          │                                 │
│                        IDLE                                │
│                          │                                 │
│               ┌──────────┼──────────┐                      │
│               │          │          │                      │
│           [AFK+10%]  [AFK+20%]  [AFK+30%]                  │
│               ✓          🔒        🔒                      │
│                                                            │
│                       CAPACITY                             │
│                          │                                 │
│            [+1 Slot]  [+2 Slots] [+3 Slots]               │
│               ✓          🔒        🔒                      │
│                                                            │
├────────────────────────────────────────────────────────────┤
│  Selected: ATK +15%                                        │
│  Cost: 5,000 Gold + 50 Evo Materials                      │
│  Requires: ATK +10% unlocked                               │
│                                                            │
│  ┌──────────────────────────────────────────────────────┐  │
│  │                    RESEARCH                           │  │
│  └──────────────────────────────────────────────────────┘  │
└────────────────────────────────────────────────────────────┘
```

**Step 3: Create Research Node Prefab**

Create `ResearchNode.prefab`:
```
ResearchNode
├── Background (Image - hexagon or circle)
├── Icon (Image - research type icon)
├── ValueText (TMP - "+5%")
├── StatusIcon (Image - ✓ or 🔒)
├── ConnectionLine (Image - to next node)
└── Button (for selection)
```

Node States:
- **Unlocked**: Green border, checkmark
- **Available**: Normal border, no icon
- **Locked**: Gray, lock icon, faded

**Step 4: Create Scroll View for Tree**
1. Add Scroll View component
2. Enable vertical scrolling
3. Content will hold all research branches

**Step 5: Create Bottom Info Panel**
1. Shows selected research details
2. Cost display (gold + materials)
3. Requirements text
4. "RESEARCH" button (enabled only if affordable)

**Step 6: Create Prefab**
1. Drag `ResearchPanel` to `Assets/_Project/Prefabs/UI/`

---

#### ✅ Definition of Done
- [ ] `ResearchPanel.prefab` created
- [ ] `ResearchNode.prefab` created
- [ ] 3 research branches visible (Combat, Idle, Capacity)
- [ ] Each branch has 3 tiers
- [ ] Selection shows details at bottom
- [ ] Research button present
- [ ] Connection lines between nodes

---

---

### Issue #67: [UI] Create Endless mode UI

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `ui`, `priority-medium`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create the HUD modifications for Endless/Survival mode (infinite waves).

---

#### 📝 Step-by-Step Instructions

**Step 1: Duplicate BattleHUD**
1. Open `BattleHUD.prefab`
2. Duplicate it
3. Name new prefab: `EndlessHUD`

**Step 2: Modify Wave Counter**

Change from `Wave 1/10` to:
```
WAVE 47
High Score: 52
```

Elements needed:
- `WaveLabel` (TMP): "WAVE"
- `WaveNumber` (TMP): Large number, "47"
- `HighScoreText` (TMP): "High Score: 52"

**Step 3: Add Rewards Counter**

New element showing earnings this run:
```
┌─────────────────┐
│  This Run:      │
│  🪙 12,450      │
│  💎 3           │
└─────────────────┘
```

**Step 4: Add Quit Confirmation**

The pause/quit button should show a confirmation:
```
┌─────────────────────────────────────┐
│      End Run?                       │
│                                     │
│   Your rewards will be saved!       │
│                                     │
│   🪙 12,450 Gold                   │
│                                     │
│   [Cancel]        [End Run]         │
└─────────────────────────────────────┘
```

**Step 5: Create Milestone Celebration**

At every 10th wave, show:
```
┌─────────────────────────────────────┐
│     🎉 WAVE 50 REACHED! 🎉         │
│                                     │
│   Bonus: +500 Gold, +1 💎          │
│                                     │
└─────────────────────────────────────┘
```

**Step 6: Create Prefabs**
1. Save `EndlessHUD.prefab`
2. Create `EndlessMilestonePopup.prefab`
3. Create `EndlessQuitConfirm.prefab`

---

#### ✅ Definition of Done
- [ ] `EndlessHUD.prefab` created
- [ ] Wave counter shows current wave (no max)
- [ ] High score displayed
- [ ] Earnings this run displayed
- [ ] Quit confirmation popup created
- [ ] Milestone celebration popup created

---

---

### Issue #68: [UI] Create mode selection screen

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `ui`, `priority-medium`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create a screen to choose between Campaign and Endless modes.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Panel**
1. Right-click Canvas → UI → Panel
2. Name: `ModeSelectScreen`
3. Appears after tapping "BATTLE" in Hub

**Step 2: Create Layout**

```
┌────────────────────────────────────────────────────────────┐
│  [←]                SELECT MODE                            │
├────────────────────────────────────────────────────────────┤
│                                                            │
│   ┌──────────────────────────────────────────────────┐    │
│   │                                                  │    │
│   │            ⚔️  CAMPAIGN  ⚔️                     │    │
│   │                                                  │    │
│   │        Progress through story maps              │    │
│   │                                                  │    │
│   │           [Map 1: Grasslands ✓]                 │    │
│   │           [Map 2: Forest 🔒]                    │    │
│   │           [Map 3: Volcano 🔒]                   │    │
│   │                                                  │    │
│   │        Current: Wave 7/10 on Map 1              │    │
│   │                                                  │    │
│   └──────────────────────────────────────────────────┘    │
│                                                            │
│   ┌──────────────────────────────────────────────────┐    │
│   │                                                  │    │
│   │            ♾️  ENDLESS  ♾️                       │    │
│   │                                                  │    │
│   │        How far can you survive?                 │    │
│   │                                                  │    │
│   │           🏆 High Score: Wave 47                │    │
│   │                                                  │    │
│   │        🔒 Unlock at Account Level 10            │    │
│   │            (Current: Lv. 7)                     │    │
│   │                                                  │    │
│   └──────────────────────────────────────────────────┘    │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

**Step 3: Create Mode Card Prefab**

Create `ModeCard.prefab`:
```
ModeCard
├── Background (Image)
├── Icon (Image - sword or infinity)
├── TitleText (TMP - "CAMPAIGN" or "ENDLESS")
├── DescriptionText (TMP)
├── ProgressText (TMP - current status)
├── LockOverlay (Panel - shown if locked)
│   └── LockText (TMP - unlock requirements)
└── Button (for selection)
```

**Step 4: Place Two Mode Cards**
1. Campaign card - always unlocked
2. Endless card - locked until level 10

**Step 5: Create Prefab**
1. Drag `ModeSelectScreen` to `Assets/_Project/Prefabs/UI/`

---

#### ✅ Definition of Done
- [ ] `ModeSelectScreen.prefab` created
- [ ] `ModeCard.prefab` created
- [ ] Campaign mode card with map progress
- [ ] Endless mode card with high score
- [ ] Lock overlay for Endless mode
- [ ] Back button to Hub

---

---

### Issue #69: [Map] Create 2 new campaign maps

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `assets`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create 2 additional battle maps with different layouts and themes.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Map 2 - Forest Path**

Create: `Assets/_Project/Scenes/BattleScene_Forest.unity`

**Theme:** Dense forest, winding path
**Difficulty:** Medium (more placement slots, longer path)

```
Path Layout (Top View):

	 [S] ══════╗
				  ║
	 ╔═════════╝
	 ║
	 ╚════╗
			║     [M] = Monster Slot
	 ╔════╝     [S] = Spawn
	 ║          [B] = Base
	 ╚══════════════╗
						 ║
	 ╔══════════════╝
	 ║
	 ╚═══════ [B]
```

**Specifications:**
- Waypoints: 18 (longer path!)
- Monster Slots: 8 (more than Map 1)
- Path style: Brown/green forest tiles
- Background: Dark green, trees around edges
- Special: Add some trees near path (visual only)

**Step 2: Create Map 3 - Volcanic Ridge**

Create: `Assets/_Project/Scenes/BattleScene_Volcano.unity`

**Theme:** Volcanic, dangerous, short path
**Difficulty:** Hard (fewer slots, shorter path)

```
Path Layout (Top View):

			[S]
			 ║
	 ╔═════╩═════╗
	 ║           ║
	 ║   [LAVA]  ║     (visual only)
	 ║           ║
	 ╚═════╦═════╝
			 ║
			[B]
```

**Specifications:**
- Waypoints: 10 (short and fast!)
- Monster Slots: 5 (fewer options)
- Path style: Dark gray/black rock
- Background: Orange/red lava pools (visual)
- Special: Add glowing lava effects

**Step 3: Create Materials for Each Map**

**Forest Materials:**
- `Mat_ForestGround` - Dark green
- `Mat_ForestPath` - Brown
- `Mat_Tree` - Green spheres/cones

**Volcano Materials:**
- `Mat_VolcanoGround` - Dark gray
- `Mat_VolcanoPath` - Black/charred
- `Mat_Lava` - Orange with emission

**Step 4: Set Up Waypoints and Slots**
For each map:
1. Create `Waypoints` parent with children
2. Create `MonsterSlots` parent with children
3. Create `SpawnPoint` and `Base`

---

#### ✅ Definition of Done
- [ ] `BattleScene_Forest.unity` created
- [ ] `BattleScene_Volcano.unity` created
- [ ] Forest: 18 waypoints, 8 slots, winding path
- [ ] Volcano: 10 waypoints, 5 slots, short path
- [ ] Each map has unique visual theme
- [ ] SpawnPoint and Base set up correctly

---

---

### Issue #70: [Enemy] Create 5 new enemy types

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `data`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create 5 new enemies with special abilities for more varied gameplay.

---

#### 📝 Step-by-Step Instructions

Navigate to: `Assets/_Project/ScriptableObjects/Enemies/`

---

**Enemy 4: Slime** (Splits on Death)
```
Filename: Slime_Config.asset

Display Name:     Slime
Enemy Type:       Splitter

═══ STATS ═══
Max HP:           80
Move Speed:       0.8
Gold Reward:      20

═══ SPECIAL ═══
Ability: "Split" - On death, spawns 2 smaller slimes
Split Count: 2
Baby Slime HP: 30
Baby Slime Speed: 1.2

═══ PLACEHOLDER VISUAL ═══
Shape: Sphere, squished
Color: Bright Green (100, 255, 100)
Scale: (0.8, 0.5, 0.8)
```

---

**Enemy 5: Shielded Knight** (Front Shield)
```
Filename: ShieldedKnight_Config.asset

Display Name:     Shielded Knight
Enemy Type:       Shielded

═══ STATS ═══
Max HP:           150
Move Speed:       0.7
Gold Reward:      30

═══ SPECIAL ═══
Ability: "Shield Wall" - Takes 80% reduced damage from front
Front Damage Reduction: 0.8 (80%)
Shield Angle: 120 degrees

═══ PLACEHOLDER VISUAL ═══
Shape: Capsule with cube in front (shield)
Color: Silver (200, 200, 210)
Scale: (0.6, 1.0, 0.6)
```

---

**Enemy 6: Healer** (Heals Others)
```
Filename: Healer_Config.asset

Display Name:     Healer
Enemy Type:       Support

═══ STATS ═══
Max HP:           60
Move Speed:       1.0
Gold Reward:      35

═══ SPECIAL ═══
Ability: "Group Heal" - Heals nearby enemies periodically
Heal Amount: 10 HP
Heal Radius: 2.0 units
Heal Interval: 3 seconds

═══ PLACEHOLDER VISUAL ═══
Shape: Sphere with cross on top
Color: White/Pink (255, 200, 200)
Scale: (0.5, 0.7, 0.5)
```

---

**Enemy 7: Assassin** (Invisible)
```
Filename: Assassin_Config.asset

Display Name:     Assassin
Enemy Type:       Stealth

═══ STATS ═══
Max HP:           40
Move Speed:       1.8
Gold Reward:      40

═══ SPECIAL ═══
Ability: "Stealth" - Invisible and untargetable until hit or reaches base
Visible Time After Hit: 2 seconds

═══ PLACEHOLDER VISUAL ═══
Shape: Small capsule, semi-transparent
Color: Purple with 50% transparency
Scale: (0.4, 0.6, 0.4)
Add: Flickers when visible
```

---

**Enemy 8: Golem Boss** (Milestone Boss)
```
Filename: GolemBoss_Config.asset

Display Name:     Golem Boss
Enemy Type:       Boss

═══ STATS ═══
Max HP:           1000
Move Speed:       0.3
Gold Reward:      200

═══ SPECIAL ═══
Ability: "Stomp" - Every 5 seconds, stuns nearby monsters for 1 second
Stomp Radius: 3.0 units
Stun Duration: 1 second

═══ PLACEHOLDER VISUAL ═══
Shape: Large cube stack (3 cubes)
Color: Dark Brown (80, 60, 40)
Scale: (2.0, 2.5, 2.0)
Add: Shake animation when stomping
```

---

**Step 2: Create Placeholder Prefabs**

For each enemy:
1. Build the visual in scene
2. Create prefab in `Assets/_Project/Prefabs/Enemies/`
3. Link to config

**Step 3: Create Materials**

| Material | Color |
|----------|-------|
| `Mat_Slime` | Bright Green (100, 255, 100) |
| `Mat_ShieldedKnight` | Silver (200, 200, 210) |
| `Mat_Healer` | Pink (255, 200, 200) |
| `Mat_Assassin` | Purple transparent |
| `Mat_GolemBoss` | Dark Brown (80, 60, 40) |

---

#### ✅ Definition of Done
- [ ] 5 EnemyConfigSO assets created
- [ ] 5 enemy prefabs created
- [ ] 5 materials created
- [ ] Each enemy has unique ability defined
- [ ] Slime (splitter), Knight (shield), Healer (support), Assassin (stealth), Boss

---

---
