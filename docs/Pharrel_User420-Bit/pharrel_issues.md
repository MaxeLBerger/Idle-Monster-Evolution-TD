
## Plan: Detailed Vibe-Coder-Friendly Issues for Pharell (@User420-Bit)

Below are all 29 issues assigned to Pharell with extremely detailed, step-by-step instructions written for a beginner who is new to Unity and vibe coding.

---

## Phase 0 Issues (16 issues)

---

### Issue #8: [Assets] Download and organize Kenney TD Kit

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `assets`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Download free game assets and organize them in our Unity project so the team can use them.

---

#### 📝 Step-by-Step Instructions

**Step 1: Download the Asset Pack**
1. Open your browser and go to: https://kenney.nl/assets/tower-defense-kit
2. Click the big **"Download"** button
3. Save the ZIP file to your Downloads folder
4. Extract (unzip) the file — you'll get a folder with images and files

**Step 2: Open Unity and Navigate to the Project**
1. Open Unity Hub
2. Open our project: `Idle-Monster-Evolution-TD`
3. Wait for Unity to load completely

**Step 3: Create the Folder Structure**
1. In the **Project** window (bottom of Unity), right-click on `Assets`
2. Create these folders by right-clicking → Create → Folder:
```
Assets/
  _Project/
    Art/
      Kenney/
        Tiles/
        Props/
        UI/
```

**Step 4: Import the Assets**
1. Open the extracted Kenney folder in Windows Explorer
2. Drag the image files into the correct Unity folders:
   - **Ground/Path tiles** → `Assets/_Project/Art/Kenney/Tiles/`
   - **Trees, rocks, decorations** → `Assets/_Project/Art/Kenney/Props/`
   - **Button/panel images** → `Assets/_Project/Art/Kenney/UI/`

**Step 5: Verify Everything Imported**
1. Click through each folder in Unity
2. You should see the images as little preview thumbnails
3. If they show as white squares, right-click → Reimport

---

#### ✅ Definition of Done
- [ ] Kenney TD Kit downloaded
- [ ] Folders created: `Assets/_Project/Art/Kenney/{Tiles,Props,UI}`
- [ ] All images organized in correct folders
- [ ] Assets visible in Unity Project window

---

#### 🆘 If You Get Stuck
- Can't unzip? Right-click the ZIP → "Extract All"
- Unity doesn't show images? Try restarting Unity
- Ask Max or Moritz in the daily standup!

---

---

### Issue #9: [Localization] Create LocalizationKeys constants

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `setup`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create a C# file with all the text keys we'll use in the game. This lets us easily translate the game later!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Script File**
1. In Unity, navigate to: `Assets/_Project/Scripts/Core/`
   - If this folder doesn't exist, create it!
2. Right-click → Create → C# Script
3. Name it exactly: `LocalizationKeys`
4. Wait for Unity to compile (bottom right shows a spinning icon)

**Step 2: Open the Script**
1. Double-click `LocalizationKeys.cs` to open it in your code editor
2. Delete everything inside the file

**Step 3: Copy This Code**
Replace everything with this:

```csharp
namespace IdleMonsterTD.Core
{
    /// <summary>
    /// All text keys used in the game for localization.
    /// Format: CATEGORY_SUBCATEGORY_ELEMENT
    /// </summary>
    public static class LocalizationKeys
    {
        // ══════════════════════════════════════════════════════
        // UI BUTTONS
        // ══════════════════════════════════════════════════════
        public const string UI_BUTTON_BATTLE = "UI_BUTTON_BATTLE";
        public const string UI_BUTTON_MONSTERS = "UI_BUTTON_MONSTERS";
        public const string UI_BUTTON_AFK = "UI_BUTTON_AFK";
        public const string UI_BUTTON_SUMMON = "UI_BUTTON_SUMMON";
        public const string UI_BUTTON_SHOP = "UI_BUTTON_SHOP";
        public const string UI_BUTTON_LEVELUP = "UI_BUTTON_LEVELUP";
        public const string UI_BUTTON_CLAIM = "UI_BUTTON_CLAIM";
        public const string UI_BUTTON_CLOSE = "UI_BUTTON_CLOSE";
        public const string UI_BUTTON_CONFIRM = "UI_BUTTON_CONFIRM";
        public const string UI_BUTTON_CANCEL = "UI_BUTTON_CANCEL";
        public const string UI_BUTTON_WATCH_AD = "UI_BUTTON_WATCH_AD";
        public const string UI_BUTTON_START_WAVE = "UI_BUTTON_START_WAVE";
        public const string UI_BUTTON_PAUSE = "UI_BUTTON_PAUSE";
        public const string UI_BUTTON_RESUME = "UI_BUTTON_RESUME";
        public const string UI_BUTTON_QUIT = "UI_BUTTON_QUIT";
        public const string UI_BUTTON_RETRY = "UI_BUTTON_RETRY";

        // ══════════════════════════════════════════════════════
        // HUD (Heads-Up Display during battle)
        // ══════════════════════════════════════════════════════
        public const string HUD_WAVE_COUNT = "HUD_WAVE_COUNT";           // "Wave {0}/{1}"
        public const string HUD_WAVE_CURRENT = "HUD_WAVE_CURRENT";       // "Wave {0}"
        public const string HUD_BASE_HP = "HUD_BASE_HP";                 // "HP: {0}/{1}"
        public const string HUD_GOLD = "HUD_GOLD";                       // "{0}"
        public const string HUD_SPEED_1X = "HUD_SPEED_1X";               // "1x"
        public const string HUD_SPEED_2X = "HUD_SPEED_2X";               // "2x"
        public const string HUD_SPEED_4X = "HUD_SPEED_4X";               // "4x"

        // ══════════════════════════════════════════════════════
        // MONSTER PANEL
        // ══════════════════════════════════════════════════════
        public const string MONSTER_LEVEL = "MONSTER_LEVEL";             // "Level {0}"
        public const string MONSTER_ATK = "MONSTER_ATK";                 // "ATK: {0}"
        public const string MONSTER_RANGE = "MONSTER_RANGE";             // "Range: {0}"
        public const string MONSTER_SPEED = "MONSTER_SPEED";             // "Speed: {0}"
        public const string MONSTER_RARITY_COMMON = "MONSTER_RARITY_COMMON";
        public const string MONSTER_RARITY_RARE = "MONSTER_RARITY_RARE";
        public const string MONSTER_RARITY_EPIC = "MONSTER_RARITY_EPIC";
        public const string MONSTER_RARITY_LEGENDARY = "MONSTER_RARITY_LEGENDARY";
        public const string MONSTER_EVOLUTION_NORMAL = "MONSTER_EVOLUTION_NORMAL";
        public const string MONSTER_EVOLUTION_ADVANCED = "MONSTER_EVOLUTION_ADVANCED";
        public const string MONSTER_EVOLUTION_ULTIMATE = "MONSTER_EVOLUTION_ULTIMATE";
        public const string MONSTER_UPGRADE_COST = "MONSTER_UPGRADE_COST"; // "Cost: {0} Gold"

        // ══════════════════════════════════════════════════════
        // AFK / IDLE SYSTEM
        // ══════════════════════════════════════════════════════
        public const string AFK_TITLE = "AFK_TITLE";                     // "Idle Rewards"
        public const string AFK_WELCOME_BACK = "AFK_WELCOME_BACK";       // "Welcome Back!"
        public const string AFK_OFFLINE_TIME = "AFK_OFFLINE_TIME";       // "You were offline for {0}"
        public const string AFK_GOLD_REWARD = "AFK_GOLD_REWARD";         // "+{0} Gold"
        public const string AFK_MATERIAL_REWARD = "AFK_MATERIAL_REWARD"; // "+{0} Evo Materials"
        public const string AFK_DOUBLE_REWARD = "AFK_DOUBLE_REWARD";     // "Watch ad for 2x rewards!"

        // ══════════════════════════════════════════════════════
        // GAME STATES
        // ══════════════════════════════════════════════════════
        public const string GAME_WON = "GAME_WON";                       // "Victory!"
        public const string GAME_LOST = "GAME_LOST";                     // "Defeat..."
        public const string WAVE_COMPLETE = "WAVE_COMPLETE";             // "Wave Complete!"
        public const string WAVE_INCOMING = "WAVE_INCOMING";             // "Wave Incoming!"

        // ══════════════════════════════════════════════════════
        // MONSTER NAMES (for our 3 starter monsters)
        // ══════════════════════════════════════════════════════
        public const string MONSTER_NAME_FLAME_IMP = "MONSTER_NAME_FLAME_IMP";
        public const string MONSTER_NAME_FROST_WISP = "MONSTER_NAME_FROST_WISP";
        public const string MONSTER_NAME_THUNDER_BEAST = "MONSTER_NAME_THUNDER_BEAST";

        // ══════════════════════════════════════════════════════
        // ENEMY NAMES
        // ══════════════════════════════════════════════════════
        public const string ENEMY_NAME_GOBLIN = "ENEMY_NAME_GOBLIN";
        public const string ENEMY_NAME_SCOUT = "ENEMY_NAME_SCOUT";
        public const string ENEMY_NAME_OGRE = "ENEMY_NAME_OGRE";

        // ══════════════════════════════════════════════════════
        // TUTORIAL / TOOLTIPS
        // ══════════════════════════════════════════════════════
        public const string TUTORIAL_PLACE_MONSTER = "TUTORIAL_PLACE_MONSTER";
        public const string TUTORIAL_START_WAVE = "TUTORIAL_START_WAVE";
        public const string TUTORIAL_UPGRADE_MONSTER = "TUTORIAL_UPGRADE_MONSTER";
        public const string TOOLTIP_MONSTER_SLOT = "TOOLTIP_MONSTER_SLOT";

        // ══════════════════════════════════════════════════════
        // TIME FORMATTING
        // ══════════════════════════════════════════════════════
        public const string TIME_HOURS = "TIME_HOURS";                   // "{0}h"
        public const string TIME_MINUTES = "TIME_MINUTES";               // "{0}m"
        public const string TIME_SECONDS = "TIME_SECONDS";               // "{0}s"
        public const string TIME_HOURS_MINUTES = "TIME_HOURS_MINUTES";   // "{0}h {1}m"
    }
}
```

**Step 4: Save the File**
1. Press `Ctrl + S` to save
2. Go back to Unity
3. Wait for Unity to compile (no errors in Console!)

---

#### ✅ Definition of Done
- [ ] `LocalizationKeys.cs` file created in `Assets/_Project/Scripts/Core/`
- [ ] All keys from the template are included
- [ ] No red errors in Unity Console
- [ ] File saved and committed to Git

---

#### 💡 Tips
- The `{0}` and `{1}` are placeholders for numbers (like "Wave 5/10")
- Later, we'll make actual translations that use these keys
- If you need to add a new key, follow the pattern: `CATEGORY_ELEMENT`

---

---

### Issue #10: [Input] Set up Input System action asset

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `setup`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create the input configuration so our game can detect mouse clicks AND touch input on phones.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Input Folder**
1. In Unity Project window, navigate to `Assets/_Project/`
2. Create folder: `Input`

**Step 2: Create the Input Actions Asset**
1. Right-click on the `Input` folder
2. Click: Create → Input Actions
3. Name it exactly: `GameInputActions`
4. Double-click it to open the Input Actions Editor

**Step 3: Create the "Gameplay" Action Map**
1. In the left panel, click the **"+"** button next to "Action Maps"
2. Name it: `Gameplay`

**Step 4: Add the "Point" Action**
1. With Gameplay selected, click **"+"** next to "Actions"
2. Name the action: `Point`
3. In the right panel, set **Action Type** to: `Value`
4. Set **Control Type** to: `Vector2`
5. Click **"+"** next to the Point action → Add Binding
6. Click the new binding, then in the right panel click **Path** dropdown
7. Search for and select: `Pointer/Position`

**Step 5: Add the "Click" Action**
1. Click **"+"** next to "Actions" again
2. Name the action: `Click`
3. In the right panel, set **Action Type** to: `Button`
4. Click **"+"** next to Click → Add Binding
5. Click **Path** → search and select: `Mouse/leftButton`
6. Click **"+"** next to Click → Add Binding (again for touch)
7. Click **Path** → search and select: `Touchscreen/primaryTouch/tap`

**Step 6: Add the "TouchPosition" Action (for mobile)**
1. Click **"+"** next to "Actions"
2. Name: `TouchPosition`
3. Set **Action Type** to: `Value`
4. Set **Control Type** to: `Vector2`
5. Add Binding → Path: `Touchscreen/primaryTouch/position`

**Step 7: Save and Generate C# Class**
1. Click **"Save Asset"** button (top of window)
2. Close the Input Actions window
3. In the Project window, click on `GameInputActions`
4. In the Inspector (right panel), check ✅ **"Generate C# Class"**
5. Click **Apply**
6. Unity will create `GameInputActions.cs` automatically!

---

#### ✅ Definition of Done
- [ ] `GameInputActions.inputactions` created in `Assets/_Project/Input/`
- [ ] Action Map "Gameplay" exists
- [ ] Actions created: Point, Click, TouchPosition
- [ ] "Generate C# Class" enabled
- [ ] `GameInputActions.cs` auto-generated
- [ ] No errors in Console

---

#### 🖼️ What It Should Look Like
```
Action Maps:         Actions:
[Gameplay]           Point         [Value, Vector2]
                       └─ Pointer/Position
                     Click         [Button]
                       ├─ Mouse/leftButton
                       └─ Touchscreen/primaryTouch/tap
                     TouchPosition [Value, Vector2]
                       └─ Touchscreen/primaryTouch/position
```

---

---

### Issue #12: [Monster] Create 3 starter monster configs

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #11 (Max creates MonsterConfigSO class first)

---

#### 🎯 Goal
Create the data files for our 3 starter monsters: **Flame Imp**, **Frost Wisp**, and **Thunder Beast**.

---

#### ⏳ Wait For
Max needs to finish Issue #11 first (creating the MonsterConfigSO class). Once he's done, he'll let you know!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Monsters Folder**
1. In Unity, navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Monsters`

**Step 2: Create Flame Imp Config**
1. Right-click in `Monsters` folder
2. Click: Create → IdleMonsterTD → Monster Config (or similar menu Max created)
3. Name it: `FlameImp_Config`
4. Click on it and fill in the Inspector:

```
Display Name:     Flame Imp
Rarity:           Common
Evolution Stage:  Normal

═══ STATS ═══
ATK:              25
Range:            3.0
Attack Speed:     1.5  (attacks per second)

═══ TARGETING ═══
Targeting Priority: Nearest

═══ DESCRIPTION ═══
Description: "A fiery little imp that shoots rapid fireballs. Great for consistent damage!"

═══ VISUALS (leave empty for now) ═══
Icon:             (none yet)
Prefab:           (none yet)
Projectile:       (none yet)
```

**Step 3: Create Frost Wisp Config**
1. Right-click in `Monsters` folder → Create → Monster Config
2. Name it: `FrostWisp_Config`
3. Fill in the Inspector:

```
Display Name:     Frost Wisp
Rarity:           Common
Evolution Stage:  Normal

═══ STATS ═══
ATK:              10
Range:            5.0  (long range!)
Attack Speed:     0.8

═══ TARGETING ═══
Targeting Priority: First

═══ SPECIAL ═══
Slow Percentage:  30   (slows enemies by 30%)
Slow Duration:    2.0  (seconds)

═══ DESCRIPTION ═══
Description: "A chilly spirit that freezes enemies, slowing their movement. Perfect for crowd control!"
```

**Step 4: Create Thunder Beast Config**
1. Right-click in `Monsters` folder → Create → Monster Config
2. Name it: `ThunderBeast_Config`
3. Fill in the Inspector:

```
Display Name:     Thunder Beast
Rarity:           Rare
Evolution Stage:  Normal

═══ STATS ═══
ATK:              18
Range:            2.5  (short range)
Attack Speed:     0.6

═══ TARGETING ═══
Targeting Priority: Strongest

═══ SPECIAL ═══
Chain Targets:    3    (lightning jumps to 3 enemies)
Chain Damage Falloff: 0.7  (each jump deals 70% of previous)

═══ DESCRIPTION ═══
Description: "A mighty beast that unleashes chain lightning, hitting multiple enemies at once!"
```

---

#### 🎮 Why These Stats?

| Monster | Role | Why These Stats |
|---------|------|-----------------|
| **Flame Imp** | DPS | High attack speed (1.5) means lots of hits. Medium range (3.0) is safe. Good against all enemy types. |
| **Frost Wisp** | Support | Low damage but LONG range (5.0) and slows enemies! Helps other monsters kill them. |
| **Thunder Beast** | AoE | Hits 3 enemies at once! Lower attack speed but great when enemies group up. |

---

#### ✅ Definition of Done
- [ ] `FlameImp_Config.asset` created with correct stats
- [ ] `FrostWisp_Config.asset` created with correct stats
- [ ] `ThunderBeast_Config.asset` created with correct stats
- [ ] All 3 configs are in `Assets/_Project/ScriptableObjects/Monsters/`
- [ ] Rarity colors: Flame Imp & Frost Wisp = Common, Thunder Beast = Rare

---

---

### Issue #14: [Enemy] Create 3 enemy type configs

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #13 (Max creates EnemyConfigSO class first)

---

#### 🎯 Goal
Create the data files for our 3 enemy types: **Goblin**, **Scout**, and **Ogre**.

---

#### ⏳ Wait For
Max needs to finish Issue #13 first (creating the EnemyConfigSO class).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Enemies Folder**
1. Navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Enemies`

**Step 2: Create Goblin Config**
1. Right-click in `Enemies` folder
2. Click: Create → IdleMonsterTD → Enemy Config
3. Name it: `Goblin_Config`
4. Fill in the Inspector:

```
Display Name:     Goblin
Enemy Type:       Standard

═══ STATS ═══
Max HP:           100
Move Speed:       1.0  (normal speed, this is the baseline)
Gold Reward:      10
Evo Material Drop: 0   (common enemies don't drop materials)

═══ DESCRIPTION ═══
Description: "A standard goblin raider. Nothing special, but they come in numbers!"
```

**Step 3: Create Scout Config**
1. Create new Enemy Config, name: `Scout_Config`
2. Fill in:

```
Display Name:     Scout
Enemy Type:       Fast

═══ STATS ═══
Max HP:           50   (half of Goblin - fragile!)
Move Speed:       2.0  (TWICE as fast!)
Gold Reward:      15   (worth more because harder to hit)
Evo Material Drop: 0

═══ DESCRIPTION ═══
Description: "A nimble scout that zips through your defenses. Fast but fragile!"
```

**Step 4: Create Ogre Config**
1. Create new Enemy Config, name: `Ogre_Config`
2. Fill in:

```
Display Name:     Ogre
Enemy Type:       Tanky

═══ STATS ═══
Max HP:           300  (THREE times the Goblin!)
Move Speed:       0.5  (half speed - slow and steady)
Gold Reward:      25   (worth the most)
Evo Material Drop: 1   (rare chance for evo materials!)

═══ DESCRIPTION ═══
Description: "A massive ogre that soaks up damage. Slow but nearly unstoppable!"
```

---

#### 🎮 Enemy Type Strategy

| Enemy | HP | Speed | Counter Strategy |
|-------|-----|-------|-----------------|
| **Goblin** | 100 | 1.0x | Standard target. Any monster works! |
| **Scout** | 50 | 2.0x | Use Frost Wisp to slow them down first! |
| **Ogre** | 300 | 0.5x | Focus fire with Flame Imp's fast attacks! |

---

#### ✅ Definition of Done
- [ ] `Goblin_Config.asset` created (100 HP, 1.0 speed, 10 gold)
- [ ] `Scout_Config.asset` created (50 HP, 2.0 speed, 15 gold)
- [ ] `Ogre_Config.asset` created (300 HP, 0.5 speed, 25 gold)
- [ ] All 3 configs are in `Assets/_Project/ScriptableObjects/Enemies/`

---

---

### Issue #16: [Wave] Create 10 wave configs

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #15 (Max creates WaveConfigSO class first)

---

#### 🎯 Goal
Create 10 wave configurations that define what enemies spawn in each wave. The difficulty should gradually increase!

---

#### ⏳ Wait For
Max needs to finish Issue #15 first (creating the WaveConfigSO class).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Waves Folder**
1. Navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Waves`

**Step 2: Create All 10 Wave Configs**

Create each wave config and fill in these values:

---

**Wave 1 - Tutorial Wave**
```
Filename: Wave_01.asset
Wave Number: 1
Delay Before Wave: 3.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 5
    Spawn Interval: 2.0 seconds

Bonus Gold: 20
```

---

**Wave 2 - Getting Started**
```
Filename: Wave_02.asset
Wave Number: 2
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 8
    Spawn Interval: 1.5 seconds

Bonus Gold: 30
```

---

**Wave 3 - More Goblins**
```
Filename: Wave_03.asset
Wave Number: 3
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 12
    Spawn Interval: 1.2 seconds

Bonus Gold: 40
```

---

**Wave 4 - Introducing Scouts**
```
Filename: Wave_04.asset
Wave Number: 4
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 8
    Spawn Interval: 1.5 seconds
  - Enemy: Scout_Config
    Count: 4
    Spawn Interval: 2.0 seconds

Bonus Gold: 50
```

---

**Wave 5 - Speed Challenge**
```
Filename: Wave_05.asset
Wave Number: 5
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 6
    Spawn Interval: 1.5 seconds
  - Enemy: Scout_Config
    Count: 8
    Spawn Interval: 1.0 seconds

Bonus Gold: 60
```

---

**Wave 6 - Scout Rush**
```
Filename: Wave_06.asset
Wave Number: 6
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Scout_Config
    Count: 15
    Spawn Interval: 0.8 seconds

Bonus Gold: 75
```

---

**Wave 7 - Here Comes the Ogre**
```
Filename: Wave_07.asset
Wave Number: 7
Delay Before Wave: 6.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 10
    Spawn Interval: 1.0 seconds
  - Enemy: Scout_Config
    Count: 5
    Spawn Interval: 1.5 seconds
  - Enemy: Ogre_Config
    Count: 2
    Spawn Interval: 4.0 seconds

Bonus Gold: 100
```

---

**Wave 8 - Mixed Assault**
```
Filename: Wave_08.asset
Wave Number: 8
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 12
    Spawn Interval: 0.8 seconds
  - Enemy: Scout_Config
    Count: 8
    Spawn Interval: 1.0 seconds
  - Enemy: Ogre_Config
    Count: 3
    Spawn Interval: 3.0 seconds

Bonus Gold: 120
```

---

**Wave 9 - Pre-Boss Chaos**
```
Filename: Wave_09.asset
Wave Number: 9
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 15
    Spawn Interval: 0.6 seconds
  - Enemy: Scout_Config
    Count: 10
    Spawn Interval: 0.8 seconds
  - Enemy: Ogre_Config
    Count: 4
    Spawn Interval: 2.5 seconds

Bonus Gold: 150
```

---

**Wave 10 - BOSS WAVE** 🔥
```
Filename: Wave_10.asset
Wave Number: 10
Delay Before Wave: 8.0 seconds

Enemies:
  - Enemy: Ogre_Config
    Count: 8
    Spawn Interval: 2.0 seconds
  - Enemy: Scout_Config
    Count: 10
    Spawn Interval: 1.0 seconds
  - Enemy: Goblin_Config
    Count: 10
    Spawn Interval: 0.8 seconds

Bonus Gold: 250
```

---

#### 📊 Wave Difficulty Summary

| Wave | Goblins | Scouts | Ogres | Total Enemies | Difficulty |
|------|---------|--------|-------|---------------|------------|
| 1 | 5 | 0 | 0 | 5 | ⭐ |
| 2 | 8 | 0 | 0 | 8 | ⭐ |
| 3 | 12 | 0 | 0 | 12 | ⭐⭐ |
| 4 | 8 | 4 | 0 | 12 | ⭐⭐ |
| 5 | 6 | 8 | 0 | 14 | ⭐⭐ |
| 6 | 0 | 15 | 0 | 15 | ⭐⭐⭐ |
| 7 | 10 | 5 | 2 | 17 | ⭐⭐⭐ |
| 8 | 12 | 8 | 3 | 23 | ⭐⭐⭐⭐ |
| 9 | 15 | 10 | 4 | 29 | ⭐⭐⭐⭐ |
| 10 | 10 | 10 | 8 | 28 | ⭐⭐⭐⭐⭐ |

---

#### ✅ Definition of Done
- [ ] All 10 wave configs created (`Wave_01.asset` through `Wave_10.asset`)
- [ ] Each wave references the correct enemy configs
- [ ] Enemy counts and spawn intervals match the table
- [ ] Bonus gold increases with wave difficulty
- [ ] All files in `Assets/_Project/ScriptableObjects/Waves/`

---

---

### Issue #17: [Events] Create GameEvent SO instances

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #6 (Max creates GameEvent base class first)

---

#### 🎯 Goal
Create the event ScriptableObjects that let different parts of the game communicate without being directly connected.

---

#### ⏳ Wait For
Max needs to finish Issue #6 first (creating the GameEvent base class).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Events Folder**
1. Navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Events`

**Step 2: Create Each Event**

For each event below:
1. Right-click in `Events` folder → Create → IdleMonsterTD → Game Event
2. Name it exactly as shown

**Events to Create:**

| Filename | Purpose |
|----------|---------|
| `OnWaveStart.asset` | Fires when a new wave begins |
| `OnWaveComplete.asset` | Fires when all enemies in a wave are dead |
| `OnGameWon.asset` | Fires when player completes all 10 waves |
| `OnGameLost.asset` | Fires when base HP reaches 0 |
| `OnEnemyKilled.asset` | Fires each time an enemy dies |
| `OnEnemyReachedBase.asset` | Fires when an enemy reaches the base |
| `OnMonsterPlaced.asset` | Fires when player places a monster |
| `OnMonsterLevelUp.asset` | Fires when a monster levels up |
| `OnGoldChanged.asset` | Fires when gold amount changes |
| `OnGamePaused.asset` | Fires when game is paused |
| `OnGameResumed.asset` | Fires when game is resumed |
| `OnSpeedChanged.asset` | Fires when game speed changes (1x/2x) |

---

#### 🤔 What Are GameEvents?

Think of them like a **radio broadcast**:
- Some code **raises** the event (broadcasts)
- Other code **listens** for the event
- They don't need to know about each other!

**Example:**
- When an enemy dies, `EnemyHealth` raises `OnEnemyKilled`
- The `GoldController` listens and adds gold
- The `WaveManager` listens and checks if wave is complete
- The `ScoreTracker` listens and updates kill count

---

#### ✅ Definition of Done
- [ ] All 12 GameEvent assets created
- [ ] All files are in `Assets/_Project/ScriptableObjects/Events/`
- [ ] Files are named exactly as shown (no typos!)

---

---

### Issue #18: [Variables] Create variable SO instances

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #6 (Max creates FloatVariable/IntVariable base classes first)

---

#### 🎯 Goal
Create the variable ScriptableObjects that store game data (like gold, HP, wave number) and let the UI automatically update when they change.

---

#### ⏳ Wait For
Max needs to finish Issue #6 first (creating the variable base classes).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Variables Folder**
1. Navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Variables`

**Step 2: Create Float Variables**

Right-click → Create → IdleMonsterTD → Float Variable

| Filename | Initial Value | Description |
|----------|---------------|-------------|
| `BaseHP.asset` | 100 | The player's base health |
| `BaseMaxHP.asset` | 100 | Maximum base health |
| `GameSpeed.asset` | 1.0 | Current game speed (1.0 or 2.0) |

**Step 3: Create Int Variables**

Right-click → Create → IdleMonsterTD → Int Variable

| Filename | Initial Value | Description |
|----------|---------------|-------------|
| `CurrentGold.asset` | 0 | Player's current gold |
| `CurrentWave.asset` | 1 | Current wave number |
| `MaxWaves.asset` | 10 | Total number of waves |
| `EnemiesAlive.asset` | 0 | Enemies currently on the map |
| `TotalKills.asset` | 0 | Enemies killed this run |

---

#### 🤔 What Are Variable SOs?

They're like **shared containers** for data:
- The game logic writes to them: `CurrentGold.Value = 150;`
- The UI reads from them and updates automatically
- No need to find objects or call methods!

**Example Flow:**
1. Enemy dies → EnemyHealth adds gold: `CurrentGold.Value += 10;`
2. CurrentGold raises its "OnChanged" event
3. The HUD's gold display is listening and updates the text

---

#### ✅ Definition of Done
- [ ] 3 Float Variables created: `BaseHP`, `BaseMaxHP`, `GameSpeed`
- [ ] 5 Int Variables created: `CurrentGold`, `CurrentWave`, `MaxWaves`, `EnemiesAlive`, `TotalKills`
- [ ] Initial values set correctly
- [ ] All files in `Assets/_Project/ScriptableObjects/Variables/`

---

---

### Issue #19: [Map] Set up battle map scene

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `assets`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #8 (Assets organized first)

---

#### 🎯 Goal
Create the battle scene with an S-shaped path, waypoints for enemies to follow, and slots where players can place monsters.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Scene**
1. In Unity, go to: File → New Scene → Basic (Built-in)
2. Save it: File → Save As
3. Save to: `Assets/_Project/Scenes/BattleScene.unity`

**Step 2: Set Up the Camera**
1. Select the **Main Camera** in Hierarchy
2. In Inspector, set:
   - Position: `X: 0, Y: 10, Z: -8`
   - Rotation: `X: 50, Y: 0, Z: 0`
   - Projection: `Orthographic`
   - Size: `8`

**Step 3: Create the Ground**
1. Right-click in Hierarchy → 3D Object → Plane
2. Name it: `Ground`
3. Set Position: `X: 0, Y: 0, Z: 0`
4. Set Scale: `X: 2, Y: 1, Z: 2` (makes it 20x20 units)
5. Create a green material: Assets → Create → Material → name it `GroundMaterial`
6. Set the color to grass green, drag onto the Ground

**Step 4: Create the S-Shaped Path**

We'll use cubes to visualize the path. Later we can replace with Kenney tiles!

1. Create an empty: Hierarchy → Create Empty → name it `Path`
2. Create a cube: 3D Object → Cube, name it `PathTile`
3. Set Scale: `X: 1, Y: 0.1, Z: 1`
4. Create brown material, apply it
5. Duplicate the cube (Ctrl+D) and arrange in an S-shape:

```
  Path Layout (Top View):
  
  START ─────────┐
  [Spawn]        │
                 │
  ┌──────────────┘
  │
  │
  └──────────────┐
                 │
                 │  
  ┌──────────────┘
  │
  │ [BASE]
  END ──────────
```

Place path tiles approximately at these positions:
```
(0, 0, 8)   → Start / Spawn Point
(0, 0, 6)
(2, 0, 6)
(4, 0, 6)
(4, 0, 4)
(4, 0, 2)
(2, 0, 2)
(0, 0, 2)
(-2, 0, 2)
(-2, 0, 0)
(-2, 0, -2)
(0, 0, -2)
(2, 0, -2)
(2, 0, -4)
(0, 0, -4)  → End / Base
```

**Step 5: Create Waypoints**

Waypoints are invisible markers that tell enemies where to go.

1. Create an empty: `Waypoints` (parent object)
2. Create child empties, name them `Waypoint_01` through `Waypoint_14`
3. Position them at the CENTER of each path tile (use positions from Step 4)
4. Add a small Gizmo so we can see them in editor:
   - Select a waypoint
   - Click the cube icon in Inspector (top left) → choose a color

**Step 6: Create Monster Placement Slots**

1. Create an empty: `MonsterSlots` (parent object)
2. Create 6 child objects: `Slot_01` through `Slot_06`
3. Position them NEXT TO the path (not on it!):
```
Slot_01: (2, 0, 4)    ← top right corner
Slot_02: (-2, 0, 4)   ← top left  
Slot_03: (2, 0, 0)    ← middle right
Slot_04: (-4, 0, 0)   ← middle left
Slot_05: (4, 0, -2)   ← bottom right
Slot_06: (0, 0, -6)   ← near the base
```
4. Add a visual indicator: Create a transparent circle sprite or a small platform for each slot

**Step 7: Create Spawn Point and Base**

1. Create an empty at path start: `SpawnPoint` at position `(0, 0, 8)`
2. Create an empty at path end: `Base` at position `(0, 0, -4)`
3. Add visuals:
   - For SpawnPoint: Add a portal-like effect or colored sphere
   - For Base: Add a castle/tower model or colored cube

**Step 8: Add Lighting**
1. Hierarchy → Light → Directional Light (if not already there)
2. Set Rotation: `X: 50, Y: -30, Z: 0`
3. Set Color to warm white
4. Set Intensity: `1`

---

#### 🗺️ Final Scene Structure

```
BattleScene
├── Main Camera
├── Directional Light
├── Ground
├── Path
│   ├── PathTile (x14)
│   └── ...
├── Waypoints
│   ├── Waypoint_01
│   ├── Waypoint_02
│   └── ... (through 14)
├── MonsterSlots
│   ├── Slot_01
│   ├── Slot_02
│   └── ... (through 06)
├── SpawnPoint
└── Base
```

---

#### ✅ Definition of Done
- [ ] `BattleScene.unity` created and saved
- [ ] Camera positioned for top-down view
- [ ] S-shaped path visible (14 tiles)
- [ ] 14 waypoints positioned along path
- [ ] 6 monster placement slots created
- [ ] SpawnPoint and Base objects created
- [ ] Scene runs without errors

---

---

### Issue #28: [UI] Create Hub panel prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create the main menu UI with 4 big buttons: Battle, Monsters, AFK-Chest, and Summon.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the UI Folder**
1. Navigate to: `Assets/_Project/Prefabs/`
2. Create folder: `UI`

**Step 2: Create a UI Scene for Testing**
1. File → New Scene → Basic (Built-in)
2. Save as: `Assets/_Project/Scenes/HubScene.unity`

**Step 3: Create Canvas**
1. Hierarchy → UI → Canvas
2. Select the Canvas, in Inspector:
   - Canvas Scaler → UI Scale Mode: `Scale With Screen Size`
   - Reference Resolution: `1080 x 1920` (portrait mobile)
   - Match Width Or Height: `0.5`

**Step 4: Create the Hub Panel**
1. Right-click Canvas → UI → Panel
2. Name it: `HubPanel`
3. Set color to semi-transparent dark: `(0, 0, 0, 200)`

**Step 5: Create the Button Layout**
1. Right-click HubPanel → UI → Vertical Layout Group (add as component)
2. Settings:
   - Padding: `50` all sides
   - Spacing: `30`
   - Child Alignment: `Middle Center`
   - Child Force Expand: Width ✓, Height ✗

**Step 6: Create the Battle Button**
1. Right-click HubPanel → UI → Button - TextMeshPro
2. Name it: `Button_Battle`
3. Set the button size: Width `600`, Height `120`
4. Select the child text object (TMP)
5. Set text: `Battle`
6. Set font size: `48`
7. Set font style: `Bold`
8. Set color: `White`

**Step 7: Style the Battle Button**
1. Select `Button_Battle`
2. Image component → Color: `(80, 180, 80, 255)` (green)
3. Or use a Kenney button sprite from your assets!

**Step 8: Duplicate for Other Buttons**

Duplicate `Button_Battle` three times (Ctrl+D) and modify:

| Button Name | Text | Color (RGB) |
|-------------|------|-------------|
| `Button_Battle` | Battle | Green (80, 180, 80) |
| `Button_Monsters` | Monsters | Blue (80, 120, 200) |
| `Button_AFK` | AFK Rewards | Orange (220, 160, 60) |
| `Button_Summon` | Summon | Purple (150, 80, 180) |

**Step 9: Add a Title**
1. Right-click HubPanel → UI → Text - TextMeshPro
2. Name it: `Title`
3. Set text: `Idle Monster TD`
4. Font size: `64`
5. Alignment: Center
6. Drag it ABOVE the buttons in the hierarchy (so it appears at top)

**Step 10: Create the Prefab**
1. Drag `HubPanel` from Hierarchy to `Assets/_Project/Prefabs/UI/`
2. This creates the prefab!
3. You'll see it turn blue in the Hierarchy

---

#### 🖼️ What It Should Look Like

```
┌─────────────────────────────┐
│                             │
│      IDLE MONSTER TD        │
│                             │
│   ┌───────────────────┐     │
│   │      BATTLE       │     │
│   └───────────────────┘     │
│                             │
│   ┌───────────────────┐     │
│   │     MONSTERS      │     │
│   └───────────────────┘     │
│                             │
│   ┌───────────────────┐     │
│   │    AFK REWARDS    │     │
│   └───────────────────┘     │
│                             │
│   ┌───────────────────┐     │
│   │      SUMMON       │     │
│   └───────────────────┘     │
│                             │
└─────────────────────────────┘
```

---

#### ✅ Definition of Done
- [ ] `HubPanel.prefab` created in `Assets/_Project/Prefabs/UI/`
- [ ] Canvas configured for mobile (1080x1920)
- [ ] 4 buttons with correct names and colors
- [ ] Title text "Idle Monster TD"
- [ ] Buttons are properly spaced and sized
- [ ] No code attached (layout only!)

---

---

### Issue #29: [UI] Create HUD prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create the in-game battle HUD showing: wave counter, base HP bar, gold display, and speed toggle.

---

#### 📝 Step-by-Step Instructions

**Step 1: Open BattleScene**
1. Open: `Assets/_Project/Scenes/BattleScene.unity`
2. Add a Canvas if there isn't one: Hierarchy → UI → Canvas
3. Configure Canvas Scaler for mobile (same as Issue #28)

**Step 2: Create the HUD Container**
1. Right-click Canvas → UI → Panel
2. Name it: `BattleHUD`
3. Anchor to top: Anchor Presets (hold Alt) → top-stretch
4. Set Height: `150`
5. Set Color: semi-transparent black `(0, 0, 0, 180)`

**Step 3: Create Wave Counter (Top Left)**
1. Right-click BattleHUD → UI → Text - TextMeshPro
2. Name: `WaveCounter`
3. Anchor: Top-Left
4. Position: `X: 20, Y: -20` from anchor
5. Size: `200 x 60`
6. Text: `Wave 1/10`
7. Font Size: `36`
8. Alignment: Left

**Step 4: Create Gold Display (Top Right)**
1. Create horizontal layout: Right-click BattleHUD → Create Empty
2. Name: `GoldDisplay`
3. Anchor: Top-Right
4. Position: `X: -20, Y: -20` from anchor
5. Add component: Horizontal Layout Group
6. Add child Image (for gold coin icon): `GoldIcon`
   - Size: 40x40
   - Use a coin sprite from Kenney or a yellow circle
7. Add child TextMeshPro: `GoldText`
   - Text: `0`
   - Font Size: `36`
   - Alignment: Right

**Step 5: Create HP Bar (Top Center)**
1. Right-click BattleHUD → UI → Slider
2. Name: `HPBar`
3. Anchor: Top-Center
4. Position: `X: 0, Y: -60`
5. Size: `400 x 40`
6. Delete the "Handle Slide Area" child (we don't need it)
7. Configure:
   - Background: Dark red `(100, 30, 30)`
   - Fill: Bright red `(220, 50, 50)`
   - Interactable: ✗ (uncheck - player can't drag it)
8. Add HP text on top:
   - Create TextMeshPro child
   - Name: `HPText`
   - Text: `100 / 100`
   - Font Size: `24`
   - Center over the bar

**Step 6: Create Speed Toggle (Top Right, below gold)**
1. Right-click BattleHUD → UI → Button - TextMeshPro
2. Name: `SpeedToggle`
3. Anchor: Top-Right
4. Position: `X: -20, Y: -80`
5. Size: `80 x 50`
6. Text: `1x`
7. Font Size: `28`
8. Color: Light blue background

**Step 7: Create Prefab**
1. Drag `BattleHUD` to `Assets/_Project/Prefabs/UI/`

---

#### 🖼️ What It Should Look Like

```
┌────────────────────────────────────────────────────┐
│ Wave 1/10        [████████████] 100/100    🪙 150 │
│                      HP Bar               [1x]    │
└────────────────────────────────────────────────────┘
```

---

#### ✅ Definition of Done
- [ ] `BattleHUD.prefab` created in `Assets/_Project/Prefabs/UI/`
- [ ] Wave counter (top left)
- [ ] HP bar (top center) with HP text
- [ ] Gold display with icon (top right)
- [ ] Speed toggle button (top right)
- [ ] All anchored correctly for mobile
- [ ] No code attached (layout only!)

---

---

### Issue #30: [UI] Create Monster list panel prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create a scrollable panel that shows all the player's monsters as cards.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Panel**
1. In HubScene, right-click Canvas → UI → Panel
2. Name: `MonsterListPanel`
3. Stretch to fill most of screen (leave room for close button)
4. Color: Dark semi-transparent background

**Step 2: Create Header**
1. Add TextMeshPro at top: "Your Monsters"
2. Font size: 48
3. Add Close button (X) in top-right corner

**Step 3: Create Scroll View**
1. Right-click MonsterListPanel → UI → Scroll View
2. Name: `MonsterScrollView`
3. Anchor/stretch below header
4. Only enable Vertical scrolling

**Step 4: Set Up Grid Layout**
1. Find the `Content` child inside Scroll View
2. Add component: Grid Layout Group
3. Settings:
   - Cell Size: `200 x 260`
   - Spacing: `20, 20`
   - Start Axis: Horizontal
   - Constraint: Fixed Column Count
   - Constraint Count: `4` (or 3 for phone)
4. Add component: Content Size Fitter
   - Vertical Fit: Preferred Size

**Step 5: Create Monster Card Prefab**
1. Right-click Content → UI → Image
2. Name: `MonsterCard`
3. Size: 200 x 260
4. Add children:
   - `CardBackground` (Image) - full size, colored by rarity
   - `MonsterIcon` (Image) - 140x140, centered upper portion
   - `MonsterName` (TextMeshPro) - below icon, font 20
   - `LevelText` (TextMeshPro) - below name, font 16, "Lv. 1"
   - `RarityBorder` (Image) - outline, colored by rarity
5. Drag MonsterCard to prefabs: `Assets/_Project/Prefabs/UI/MonsterCard.prefab`

**Step 6: Create the Panel Prefab**
1. Drag `MonsterListPanel` to `Assets/_Project/Prefabs/UI/`

---

#### 🖼️ Monster Card Layout

```
┌──────────────────┐
│ ┌──────────────┐ │
│ │              │ │
│ │   [ICON]     │ │
│ │              │ │
│ └──────────────┘ │
│                  │
│   Flame Imp      │
│     Lv. 5        │
│                  │
└──────────────────┘
  (colored border)
```

---

#### ✅ Definition of Done
- [ ] `MonsterListPanel.prefab` created
- [ ] `MonsterCard.prefab` created
- [ ] Scroll view works correctly
- [ ] Grid layout shows cards in rows
- [ ] Close button in header

---

---

### Issue #31: [UI] Create Monster detail panel prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create a detail view that shows when you tap a monster card - displays stats, level-up button, and evolution info.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Panel**
1. Right-click Canvas → UI → Panel
2. Name: `MonsterDetailPanel`
3. Make it slightly smaller than full screen (like a popup)
4. Add dark overlay behind it (separate panel, nearly transparent)

**Step 2: Create Layout**

```
┌────────────────────────────────────────────────────┐
│ ┌────┐                                        [X] │
│ │    │     FLAME IMP                              │
│ │ICON│     ⭐ Common                              │
│ │    │                                            │
│ └────┘                                            │
├────────────────────────────────────────────────────┤
│                                                    │
│  ATK:    25      ████████████░░░                  │
│  Range:  3.0     ████████░░░░░░░                  │
│  Speed:  1.5     ██████████████░                  │
│                                                    │
├────────────────────────────────────────────────────┤
│  Level: 5                                          │
│  ┌─────────────────────────────────┐              │
│  │      LEVEL UP (100 Gold)        │              │
│  └─────────────────────────────────┘              │
│                                                    │
├────────────────────────────────────────────────────┤
│  Evolution: Normal → Advanced                      │
│  Requirements: Level 20, 50 Evo Materials          │
└────────────────────────────────────────────────────┘
```

**Step 3: Build the Elements**

1. **Header Section:**
   - Monster Icon (150x150)
   - Monster Name (TextMeshPro, size 36)
   - Rarity indicator (stars or text)
   - Close button

2. **Stats Section:**
   - For each stat (ATK, Range, Speed):
     - Label (TextMeshPro)
     - Value (TextMeshPro)
     - Progress bar (Slider or filled Image)

3. **Level-Up Section:**
   - Current level display
   - Level-Up button with cost text
   - Gold icon next to cost

4. **Evolution Section:**
   - Current → Next evolution preview
   - Requirements text
   - (Evolve button for later)

**Step 4: Create Prefab**
1. Drag `MonsterDetailPanel` to `Assets/_Project/Prefabs/UI/`

---

#### ✅ Definition of Done
- [ ] `MonsterDetailPanel.prefab` created
- [ ] Monster icon, name, rarity display
- [ ] Stat bars for ATK, Range, Speed
- [ ] Level display and Level-Up button
- [ ] Evolution preview section
- [ ] Close button works

---

---

### Issue #32: [UI] Create AFK reward popup prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create the popup that appears when you open the game showing how much you earned while away!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Popup**
1. Right-click Canvas → UI → Panel
2. Name: `AFKRewardPopup`
3. Make it a centered popup (about 800x600)
4. Add dark overlay behind (full screen, semi-transparent)

**Step 2: Create Layout**

```
┌────────────────────────────────────────────────┐
│                                                │
│            🌙 WELCOME BACK! 🌙                │
│                                                │
│         You were offline for                   │
│              4h 32m                            │
│                                                │
│  ┌──────────────────────────────────────────┐  │
│  │  🪙  +1,250 Gold                         │  │
│  │  💎  +15 Evo Materials                   │  │
│  └──────────────────────────────────────────┘  │
│                                                │
│  ┌──────────────────────────────────────────┐  │
│  │              CLAIM                        │  │
│  └──────────────────────────────────────────┘  │
│                                                │
│  ┌──────────────────────────────────────────┐  │
│  │      📺 Watch Ad for 2x (optional)       │  │
│  └──────────────────────────────────────────┘  │
│                                                │
└────────────────────────────────────────────────┘
```

**Step 3: Build the Elements**

1. **Title:** "Welcome Back!" with moon emojis or decorative icons
2. **Offline Time:** "You were offline for {time}"
3. **Rewards Box:**
   - Vertical layout with reward rows
   - Each row: Icon + Amount text
   - Gold row, Evo Materials row
4. **Claim Button:**
   - Big, green, prominent
   - Text: "CLAIM"
5. **Watch Ad Button (optional):**
   - Smaller, secondary style
   - Text: "Watch Ad for 2x"
   - (Can be hidden initially)

**Step 4: Create Prefab**
1. Drag `AFKRewardPopup` to `Assets/_Project/Prefabs/UI/`

---

#### ✅ Definition of Done
- [ ] `AFKRewardPopup.prefab` created
- [ ] Title and welcome message
- [ ] Offline time display
- [ ] Reward list with icons
- [ ] Claim button (big and green)
- [ ] Optional Watch Ad button
- [ ] Centered popup with overlay

---

## Plan: Continuing Pharell's Detailed Issues (Issue #33 onwards)

Continuing from Issue #33 where we left off, then completing all remaining issues through Phase 3.

---

### Issue #33: [Art] Create placeholder monster/enemy visuals (CONTINUED)

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `assets`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 📝 Step-by-Step Instructions (Continued from Step 4)

**Step 4: Create Monster Prefabs (Continued)**

**Flame Imp:**
1. Create Sphere (GameObject → 3D Object → Sphere)
2. Scale: `(0.8, 0.8, 0.8)`
3. Apply `Mat_FlameImp` material
4. Add a small cone on top for "horns": 3D Object → Cone, scale tiny, rotate
5. Name the parent: `Monster_FlameImp`
6. Drag to `Assets/_Project/Prefabs/Monsters/`

**Frost Wisp:**
1. Create Sphere
2. Scale: `(0.6, 0.9, 0.6)` (taller, thinner - wispy!)
3. Apply `Mat_FrostWisp` material
4. Add a small trail renderer for ghost effect (optional)
5. Name: `Monster_FrostWisp`
6. Drag to Prefabs/Monsters/

**Thunder Beast:**
1. Create Cube (not sphere - beasts are blocky!)
2. Scale: `(1.0, 0.8, 1.2)` (wide and sturdy)
3. Apply `Mat_ThunderBeast` material
4. Add 2 small cubes on top for "ears"
5. Name: `Monster_ThunderBeast`
6. Drag to Prefabs/Monsters/

**Step 5: Create Enemy Prefabs**

Navigate to: `Assets/_Project/Prefabs/Enemies/`

**Goblin:**
1. Create Capsule (3D Object → Capsule)
2. Scale: `(0.5, 0.7, 0.5)` (small humanoid)
3. Apply `Mat_Goblin` material
4. Name: `Enemy_Goblin`
5. Drag to Prefabs/Enemies/

**Scout:**
1. Create Capsule
2. Scale: `(0.4, 0.5, 0.4)` (smaller, faster-looking)
3. Apply `Mat_Scout` material
4. Rotate slightly forward (like running)
5. Name: `Enemy_Scout`
6. Drag to Prefabs/Enemies/

**Ogre:**
1. Create Cube
2. Scale: `(1.2, 1.5, 1.0)` (big and chunky!)
3. Apply `Mat_Ogre` material
4. Add sphere on top for head
5. Name: `Enemy_Ogre`
6. Drag to Prefabs/Enemies/

**Step 6: Create Projectile Prefabs**

Navigate to: `Assets/_Project/Prefabs/Projectiles/`

| Projectile | Shape | Scale | Material Color |
|------------|-------|-------|----------------|
| `Projectile_Fireball` | Sphere | (0.2, 0.2, 0.2) | Orange with emission |
| `Projectile_IceShard` | Cube (rotated 45°) | (0.15, 0.3, 0.15) | Light blue |
| `Projectile_Lightning` | Stretched Capsule | (0.1, 0.4, 0.1) | Yellow with bright emission |

---

#### ✅ Definition of Done
- [ ] 6 materials created (3 monster, 3 enemy)
- [ ] 3 monster prefabs created with distinct shapes
- [ ] 3 enemy prefabs created with distinct shapes
- [ ] 3 projectile prefabs created
- [ ] All prefabs in correct folders
- [ ] Materials have appropriate colors

---

#### 💡 Visual Guide

```
MONSTERS:                    ENEMIES:
                            
🔴 Flame Imp (sphere)       🟢 Goblin (capsule)
   Red, small horns             Green, medium
                            
🔵 Frost Wisp (tall sphere) 🟢 Scout (small capsule)
   Blue, ethereal               Light green, tiny
                            
🟡 Thunder Beast (cube)     🟢 Ogre (big cube)
   Yellow, blocky               Dark green, huge
```

---

---

### Issue #45: [Balance] Tune wave difficulty

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `balance`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Depends on:** Gameplay loop working (Week 3 complete)

---

#### 🎯 Goal
Playtest the game and adjust wave configs so the difficulty feels right - not too easy, not too hard!

---

#### 📝 Step-by-Step Instructions

**Step 1: Set Up for Playtesting**
1. Open `BattleScene.unity`
2. Press Play
3. Place all 3 monsters on slots
4. Let waves run and observe

**Step 2: What to Look For**

For each wave, note:
- ⏱️ How long did the wave take?
- ❤️ How much base HP did you lose?
- 💀 Did any enemies reach the base?
- 😴 Was it boring (too easy)?
- 😤 Was it frustrating (too hard)?

**Step 3: Use This Difficulty Guide**

| Wave | Target Difficulty | HP Loss Target | Feel |
|------|-------------------|----------------|------|
| 1-3 | Very Easy | 0 HP lost | "I can do this!" |
| 4-6 | Easy-Medium | 0-10 HP lost | "Getting interesting" |
| 7-8 | Medium-Hard | 10-30 HP lost | "Need to focus" |
| 9 | Hard | 20-40 HP lost | "This is tough!" |
| 10 | Very Hard | 30-50 HP lost | "Just barely made it!" |

**Step 4: How to Adjust**

Open the Wave configs in `Assets/_Project/ScriptableObjects/Waves/`

**If wave is TOO EASY:**
- Increase enemy count (+2 to +5)
- Decrease spawn interval (-0.2 seconds)
- Add stronger enemy types earlier

**If wave is TOO HARD:**
- Decrease enemy count (-2 to -5)
- Increase spawn interval (+0.3 seconds)
- Delay introduction of harder enemies

**Step 5: Record Your Changes**

Create a simple note in the issue comments:
```
Wave 1: Was too easy, increased Goblins from 5 to 7
Wave 6: Scout rush was impossible, reduced from 15 to 12
Wave 10: Perfect difficulty, kept as-is
```

**Step 6: Test Again After Changes**
1. Save the modified configs
2. Play again
3. Repeat until it feels right

---

#### 📊 Balance Checklist

| Wave | Original | Adjusted | Notes |
|------|----------|----------|-------|
| 1 | 5 Goblins | ___ | |
| 2 | 8 Goblins | ___ | |
| 3 | 12 Goblins | ___ | |
| 4 | 8G + 4S | ___ | |
| 5 | 6G + 8S | ___ | |
| 6 | 15 Scouts | ___ | |
| 7 | 10G + 5S + 2O | ___ | |
| 8 | 12G + 8S + 3O | ___ | |
| 9 | 15G + 10S + 4O | ___ | |
| 10 | 10G + 10S + 8O | ___ | |

---

#### ✅ Definition of Done
- [ ] Played through all 10 waves at least 3 times
- [ ] Adjusted wave configs based on observations
- [ ] Waves 1-3 feel like a tutorial (easy)
- [ ] Waves 4-6 provide moderate challenge
- [ ] Waves 7-9 are challenging but fair
- [ ] Wave 10 is hard but beatable
- [ ] Documented changes in issue comments

---

---

### Issue #46: [Balance] Tune monster stats

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `balance`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Depends on:** Gameplay loop working (Week 3 complete)

---

#### 🎯 Goal
Adjust monster stats so all 3 monsters feel useful and fun to use.

---

#### 📝 Step-by-Step Instructions

**Step 1: Test Each Monster Alone**

Play waves 1-5 using ONLY one monster type at a time:
1. Only Flame Imps → Note performance
2. Only Frost Wisps → Note performance
3. Only Thunder Beasts → Note performance

**Step 2: What Each Monster Should Feel Like**

| Monster | Should Be Good At | Should Struggle With |
|---------|-------------------|---------------------|
| **Flame Imp** | Killing everything consistently | Large groups (single target) |
| **Frost Wisp** | Slowing fast enemies, supporting | Killing anything by itself |
| **Thunder Beast** | Groups of enemies | Single strong enemies |

**Step 3: Balance Indicators**

**Flame Imp (DPS) - Check these:**
- [ ] Kills a Goblin in 4-5 hits? (not too fast, not too slow)
- [ ] Attack speed feels "rapid fire"?
- [ ] Range lets it hit enemies for a good duration?

**Frost Wisp (Slow) - Check these:**
- [ ] Slow effect is noticeable on Scouts?
- [ ] Doesn't kill things too fast (support, not DPS)?
- [ ] Long range lets it slow enemies early?

**Thunder Beast (AoE) - Check these:**
- [ ] Chain lightning visibly jumps between enemies?
- [ ] Effective when 3+ enemies are grouped?
- [ ] Struggles against single Ogre (as intended)?

**Step 4: How to Adjust Stats**

Open Monster configs in `Assets/_Project/ScriptableObjects/Monsters/`

| If... | Then Adjust... |
|-------|----------------|
| Monster kills too fast | Reduce ATK |
| Monster kills too slow | Increase ATK |
| Monster hits too rarely | Increase Attack Speed |
| Monster hits too often | Decrease Attack Speed |
| Can't hit anything | Increase Range |
| Hits from too far | Decrease Range |
| Slow effect too weak | Increase Slow Percentage |
| Slow effect too strong | Decrease Slow Percentage |

**Step 5: Test Combinations**

After individual tuning, test combinations:
1. All 3 monster types together
2. 2x Flame Imp + 1 Frost Wisp
3. 2x Thunder Beast + 1 Frost Wisp

All combos should feel viable!

---

#### 📊 Stat Adjustment Tracker

| Monster | Original ATK | New ATK | Original Speed | New Speed | Notes |
|---------|--------------|---------|----------------|-----------|-------|
| Flame Imp | 25 | ___ | 1.5 | ___ | |
| Frost Wisp | 10 | ___ | 0.8 | ___ | |
| Thunder Beast | 18 | ___ | 0.6 | ___ | |

---

#### ✅ Definition of Done
- [ ] Each monster tested individually
- [ ] Stats adjusted so each monster has a clear role
- [ ] Flame Imp = consistent DPS
- [ ] Frost Wisp = crowd control support
- [ ] Thunder Beast = AoE damage
- [ ] All 3 monsters feel useful
- [ ] No monster feels "useless" or "overpowered"

---

---

## Phase 1 Issues (8 issues)

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

## Phase 2 Issues (5 issues)

---

### Issue #82: [Pass] Create Battle Pass UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the Battle Pass/Season Pass screen showing tiers and rewards.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Layout**

```
┌────────────────────────────────────────────────────────────────────┐
│  [←]              SEASON PASS - Season 1                    ⏱️ 14d │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  Level 15                    ████████████░░░░░░  3,450/5,000 XP   │
│                                                                    │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  ← ════════════════════════════════════════════════════════════ → │
│                                                                    │
│     [13]    [14]    [15]    [16]    [17]    [18]    [19]         │
│      ✓       ✓      NOW      🔒      🔒      🔒      🔒          │
│                                                                    │
│     FREE REWARDS:                                                  │
│    ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐       │
│    │🪙  │  │🪙  │  │💎  │  │🪙  │  │📦  │  │🪙  │  │⭐  │       │
│    │500 │  │500 │  │ 10 │  │750 │  │Shard│  │1k  │  │Rare│       │
│    └────┘  └────┘  └────┘  └────┘  └────┘  └────┘  └────┘       │
│       ✓       ✓     Claim     -       -       -       -          │
│                                                                    │
│     ┌─────────────────────────────────────────────────────────┐   │
│     │  🔒 PREMIUM REWARDS - Unlock for $9.99                   │   │
│     └─────────────────────────────────────────────────────────┘   │
│    ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐       │
│    │💎  │  │💎  │  │🎨  │  │💎  │  │⭐  │  │💎  │  │🌟  │       │
│    │ 50 │  │ 50 │  │Frame│  │100 │  │Epic│  │150 │  │Leg │       │
│    └────┘  └────┘  └────┘  └────┘  └────┘  └────┘  └────┘       │
│                                                                    │
├────────────────────────────────────────────────────────────────────┤
│  MISSIONS:                                                         │
│  ├─ Complete 10 waves      ████████░░  8/10     (+100 XP)         │
│  ├─ Level up 5 monsters    ██████████  5/5  ✓   [CLAIM]           │
│  └─ Perform 3 summons      ████░░░░░░  2/3      (+150 XP)         │
└────────────────────────────────────────────────────────────────────┘
```

**Step 2: Build Components**

1. **Header:**
   - Back button
   - Season title
   - Timer countdown

2. **Progress Bar:**
   - Current level
   - XP bar with numbers

3. **Tier Scroll View:**
   - Horizontal scroll
   - Tier nodes with numbers
   - Current tier highlighted

4. **Reward Rows:**
   - Free reward row (always visible)
   - Premium reward row (locked overlay if not purchased)

5. **Reward Item Prefab:**
   ```
   RewardItem
   ├── Background
   ├── Icon
   ├── AmountText
   ├── ClaimedOverlay (checkmark)
   └── ClaimButton (if available)
   ```

6. **Missions Section:**
   - List of active missions
   - Progress bar per mission
   - Claim button when complete

**Step 3: Create Prefabs**
- `BattlePassScreen.prefab`
- `PassTierNode.prefab`
- `PassRewardItem.prefab`
- `PassMissionRow.prefab`

---

#### ✅ Definition of Done
- [ ] `BattlePassScreen.prefab` created
- [ ] Tier scroll view with 40 tiers
- [ ] Free and Premium reward tracks
- [ ] Mission list at bottom
- [ ] XP progress bar
- [ ] Timer display
- [ ] Premium unlock button

---

---

### Issue #85: [Pass] Define Season 1 rewards

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `data`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Design all 40 tiers of rewards for both free and premium tracks.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Reward Spreadsheet**

Use this template (you can create it in a doc or spreadsheet):

| Tier | Free Reward | Premium Reward |
|------|-------------|----------------|
| 1 | 500 Gold | 50 Diamonds |
| 2 | 500 Gold | 50 Diamonds |
| 3 | 10 Diamonds | Profile Frame |
| 4 | 750 Gold | 75 Diamonds |
| 5 | 10 Evo Materials | Monster Shard (Rare) |
| ... | ... | ... |
| 40 | Legendary Shard (1) | EXCLUSIVE: Dragon Lord Skin |

**Step 2: Follow These Guidelines**

**Free Track Rewards:**
- Mostly Gold (every 1-2 tiers)
- Some Diamonds (every 5 tiers, small amounts: 5-15)
- Evo Materials (every 4-5 tiers)
- Common/Rare Monster Shards (tiers 10, 20, 30)
- One Legendary Shard at tier 40

**Premium Track Rewards:**
- More Diamonds (50-200 per tier)
- Epic Monster Shards (every 10 tiers)
- Exclusive Cosmetics (profile frames, chat badges)
- Legendary Shard at tier 35
- EXCLUSIVE item at tier 40 (skin or unique cosmetic)

**Step 3: Create the Full Reward List**

```
SEASON 1: "Flame Festival"

Tier 1:  FREE: 500 Gold        PREMIUM: 50 Diamonds
Tier 2:  FREE: 500 Gold        PREMIUM: 50 Diamonds
Tier 3:  FREE: 10 Diamonds     PREMIUM: "Flame Frame" (profile)
Tier 4:  FREE: 750 Gold        PREMIUM: 75 Diamonds
Tier 5:  FREE: 10 Evo Mats     PREMIUM: 100 Diamonds
Tier 6:  FREE: 500 Gold        PREMIUM: 50 Diamonds
Tier 7:  FREE: 500 Gold        PREMIUM: 75 Diamonds
Tier 8:  FREE: 750 Gold        PREMIUM: 100 Diamonds
Tier 9:  FREE: 15 Diamonds     PREMIUM: 10 Evo Mats
Tier 10: FREE: Rare Shard x5   PREMIUM: Epic Shard x3

Tier 11: FREE: 1000 Gold       PREMIUM: 100 Diamonds
Tier 12: FREE: 500 Gold        PREMIUM: 50 Diamonds
Tier 13: FREE: 15 Evo Mats     PREMIUM: 75 Diamonds
Tier 14: FREE: 750 Gold        PREMIUM: 100 Diamonds
Tier 15: FREE: 20 Diamonds     PREMIUM: "Fire Badge" (chat)
Tier 16: FREE: 1000 Gold       PREMIUM: 100 Diamonds
Tier 17: FREE: 500 Gold        PREMIUM: 75 Diamonds
Tier 18: FREE: 750 Gold        PREMIUM: 100 Diamonds
Tier 19: FREE: 20 Evo Mats     PREMIUM: 150 Diamonds
Tier 20: FREE: Rare Shard x10  PREMIUM: Epic Shard x5

Tier 21: FREE: 1500 Gold       PREMIUM: 150 Diamonds
Tier 22: FREE: 750 Gold        PREMIUM: 75 Diamonds
Tier 23: FREE: 25 Diamonds     PREMIUM: 100 Diamonds
Tier 24: FREE: 1000 Gold       PREMIUM: 125 Diamonds
Tier 25: FREE: 25 Evo Mats     PREMIUM: "Inferno Frame" (profile)
Tier 26: FREE: 1000 Gold       PREMIUM: 100 Diamonds
Tier 27: FREE: 750 Gold        PREMIUM: 100 Diamonds
Tier 28: FREE: 1500 Gold       PREMIUM: 150 Diamonds
Tier 29: FREE: 30 Evo Mats     PREMIUM: 175 Diamonds
Tier 30: FREE: Epic Shard x3   PREMIUM: Epic Shard x10

Tier 31: FREE: 2000 Gold       PREMIUM: 200 Diamonds
Tier 32: FREE: 1000 Gold       PREMIUM: 100 Diamonds
Tier 33: FREE: 30 Diamonds     PREMIUM: 150 Diamonds
Tier 34: FREE: 1500 Gold       PREMIUM: 175 Diamonds
Tier 35: FREE: 35 Evo Mats     PREMIUM: Legendary Shard x1
Tier 36: FREE: 1500 Gold       PREMIUM: 150 Diamonds
Tier 37: FREE: 1000 Gold       PREMIUM: 150 Diamonds
Tier 38: FREE: 2000 Gold       PREMIUM: 200 Diamonds
Tier 39: FREE: 40 Evo Mats     PREMIUM: 250 Diamonds
Tier 40: FREE: Legendary Shard x1  PREMIUM: "Phoenix Flame Skin" (EXCLUSIVE)
```

**Step 4: Document XP Requirements**

| Tiers | XP Per Tier |
|-------|-------------|
| 1-10 | 1,000 XP each |
| 11-20 | 2,000 XP each |
| 21-30 | 3,000 XP each |
| 31-40 | 4,000 XP each |

Total XP needed: 100,000 XP

**Step 5: Document Missions (XP Sources)**

| Mission | XP Reward | Refresh |
|---------|-----------|---------|
| Complete 10 waves | 100 XP | Daily |
| Level up 5 monsters | 150 XP | Daily |
| Perform 3 summons | 150 XP | Daily |
| Win 3 battles | 200 XP | Daily |
| Reach wave 50 in Endless | 500 XP | Weekly |
| Collect AFK rewards 7 times | 300 XP | Weekly |

---

#### ✅ Definition of Done
- [ ] All 40 tiers defined with Free rewards
- [ ] All 40 tiers defined with Premium rewards
- [ ] Rewards follow progression guidelines
- [ ] XP requirements documented
- [ ] Missions defined with XP values
- [ ] Season theme ("Flame Festival") defined

---

---

### Issue #89: [Shop] Create Shop UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the in-game shop for purchasing diamonds, bundles, and special offers.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Layout**

```
┌────────────────────────────────────────────────────────────────────┐
│  [←]                        SHOP                                   │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  [💎 Diamonds]  [📦 Bundles]  [🎁 Daily Deals]  [👑 VIP]          │
│  ═══════════════                                                   │
│                                                                    │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  ┌────────────┐  ┌────────────┐  ┌────────────┐  ┌────────────┐  │
│  │    💎      │  │    💎💎    │  │   💎💎💎   │  │  💎💎💎💎  │  │
│  │    100     │  │    550     │  │   1,200    │  │   2,500    │  │
│  │            │  │  +10% BONUS│  │ +20% BONUS │  │ +30% BONUS │  │
│  │   $0.99    │  │   $4.99    │  │   $9.99    │  │   $19.99   │  │
│  └────────────┘  └────────────┘  └────────────┘  └────────────┘  │
│                                                                    │
│  ┌────────────┐  ┌────────────────────────────────────────────┐   │
│  │ 💎💎💎💎💎 │  │         ⭐ BEST VALUE ⭐                   │   │
│  │   6,500    │  │              💎 15,000                      │   │
│  │+50% BONUS  │  │           +100% BONUS!                      │   │
│  │  $49.99    │  │              $99.99                         │   │
│  └────────────┘  └────────────────────────────────────────────┘   │
│                                                                    │
└────────────────────────────────────────────────────────────────────┘
```

**Step 2: Create Tab System**
1. Create horizontal tab bar at top
2. Tabs: Diamonds, Bundles, Daily Deals, VIP
3. Selected tab is highlighted

**Step 3: Create Diamond Pack Card**

`DiamondPackCard.prefab`:
```
DiamondPackCard
├── Background (Image)
├── DiamondIcon (Image - scales with amount)
├── AmountText (TMP - "1,200")
├── BonusTag (Panel - "+20% BONUS", hidden if no bonus)
├── PriceButton (Button with price text "$9.99")
└── BestValueBadge (Image - only on biggest pack)
```

**Step 4: Create Bundles Tab**

```
STARTER BUNDLE (One-time purchase!)
┌──────────────────────────────────────────────────────────────┐
│  🌟 STARTER PACKSTARTER BUNDLE (One-time purchase!)
┌──────────────────────────────────────────────────────────────┐
│  🌟 STARTER PACK
MaxeLBerger: what do I have to do, to implement #file:PRD_IdleMonsterEvolutionTD.md 

GitHub Copilot: I'll analyze the PRD and create a comprehensive implementation plan for you. 

Research codebase structure

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD)

Searched for files matching `**/.github/**`, no matches

Searched for files matching `**/Assets/**`, no matches

Searched for files matching `**/ProjectSettings/**`, no matches

Searched for files matching `**/Packages/**`, no matches

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/planning_Phase_0.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/planning_Phase_1.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/planning_Phase_3.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/PRD_IdleMonsterEvolutionTD.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/Idle-Monster-Evolution-TD.code-workspace)

## Plan: Implement Idle Monster Evolution TD (Full Production Path)

Complete implementation roadmap from empty repository to production-ready F2P mobile game, following the PRD's phased approach with VContainer DI, ScriptableObject architecture, and clean code standards.

---

### Steps

1. **Set up Unity project foundation** — Create Unity 2022/2023 LTS project with URP, install packages via Package Manager (VContainer, Input System, TextMeshPro, DOTween Pro/free), configure folder structure (`Assets/_Project/{Scripts,ScriptableObjects,Scenes,Prefabs,Art}`), create Assembly Definitions (`Core.asmdef`, `Gameplay.asmdef`, `UI.asmdef`), set Android build target (ARM64, IL2CPP, API 24+), add Unity `.gitignore`.

2. **Create `.github/copilot-instructions.md` with architecture enforcement** — Document SOLID principles, VContainer service registration patterns, ScriptableObject event/variable templates, interface contracts (`IDamageable`, `IPoolable`, `ITargetable`, `ISaveable`, `IMonster`, `IEnemy`), naming conventions (PascalCase, `I` prefix for interfaces, `SO` suffix for ScriptableObjects), pooling mandates, forbidden patterns (Singletons, `FindObjectOfType`, Update allocations), component composition over inheritance.

3. **Implement core DI infrastructure and services** — Create `GameLifetimeScope` MonoBehaviour, register services: `IWaveManager`, `IGameStateService`, `IPoolingService`, `ISaveService`, `IAFKRewardService`. Build `GameEvent` and typed variable (`FloatVariable`, `IntVariable`) ScriptableObject base classes for decoupled pub-sub communication.

4. **Build Phase 0 Tower Defense gameplay** — S-shaped map with `Waypoint` MonoBehaviour array, `WaveConfigSO` defining 10 waves (enemy types, counts, spawn intervals), `WaveManager` implementation with `ObjectPool<Enemy>` spawning, base HP as `FloatVariable` SO, `GameEvent` SOs (`OnWaveComplete`, `OnGameWon`, `OnGameLost`), Input System action asset for touch placement.

5. **Implement Monster (Tower) system** — Create `MonsterConfigSO` (stats, `EvolutionStage` enum, projectile prefab), `IMonster` interface, component-based design (`MonsterAttack`, `MonsterTargeting`, `MonsterVisuals`), `MonsterFactory` with VContainer injection, projectile pooling, implement 3 starters: Flame Imp (single-target DPS), Frost Wisp (slow effect), Thunder Beast (chain AoE).

6. **Implement Enemy system** — Create `EnemyConfigSO` (MaxHP, MoveSpeed, GoldReward, `EnemyType` enum), `IEnemy : IDamageable, IPoolable`, component split (`EnemyMovement`, `EnemyHealth`, `EnemyVisuals`), `EnemyFactory`, implement 3 types: Goblin (standard), Scout (2x speed, 0.5x HP), Ogre (0.5x speed, 3x HP).

7. **Build Idle/AFK and persistence systems** — `AFKRewardService` calculating offline time via UTC timestamps, `PlayerDataSO` runtime container (gold, evo-materials, monster collection), `MonsterInstanceData` serializable class (level, XP, evolution stage), `SaveService` with JSON to `Application.persistentDataPath`, auto-save on `OnApplicationPause`/`OnApplicationQuit`.

8. **Create UI layer with ScriptableObject binding** — Main hub scene (Battle, Monsters, AFK-Chest, Summon buttons), in-game HUD bound to SOs (wave `IntVariable`, base HP `FloatVariable`, gold display, 1x/2x speed toggle via `GameEvent`), monster list panel with sorting, monster detail panel (stats, level-up button, cost display), AFK reward popup with claim interaction.

9. **Integrate free placeholder assets (Phase 0)** — Download [Kenney.nl Tower Defense Kit](https://kenney.nl/assets/tower-defense-kit) (CC0 license) for map tiles/UI, use Unity primitives (cubes, spheres with colored materials) for monsters/enemies, implement simple sprite-based projectiles, set up TextMeshPro font for all UI text.

10. **Implement Phase 1 Gacha/Summon system** — Create `GachaConfigSO` (drop rates per rarity, pity thresholds), `IGachaService` with `SummonSingle()`/`SummonTen()` methods, `MonsterShardSO` system (100 shards = 1 monster), banner system with rate-up events, summon UI with drop rate display, VFX for reveal animations.

11. **Build Phase 1 Meta-Progression (Basis-Hub)** — Create Hub scene with building nodes (Monster-Lab, Research, AFK-Chest room, Summon-Arena), `BuildingConfigSO` for upgrade costs/effects, `IResearchService` for global buffs (ATK%, Idle%, Max offline time), building upgrade UI panels, account level system with XP from battles.

12. **Implement Endless/Survival mode (Phase 1)** — Create `EndlessModeManager` with infinite wave scaling (+10% HP/DMG per wave, exponential gold rewards), milestone rewards every 10 waves, optional "prestige points" currency for future meta-progression, high-score leaderboard preparation (local only, backend Phase 2).

13. **Integrate Supabase backend (Phase 2)** — Install Supabase Unity SDK, create tables (`accounts`, `player_progress`, `purchases`, `events`), implement `ICloudSaveService` for sync on app start/pause, add conflict resolution (server timestamp wins), implement basic analytics events (`session_start`, `wave_complete`, `iap_purchase`), create Edge Function for server-side pity validation.

14. **Build Battle Pass system (Phase 2)** — Create `BattlePassSO` (40 tiers, free/premium rewards), `IBattlePassService` tracking XP from missions (`CompleteWaves`, `UpgradeMonsters`, `SummonMonsters`), UI with two-track visualization, timer countdown for season end, reward claim flow, purchase premium pass flow with IAP.

15. **Implement IAP Shop and monetization (Phase 2)** — Unity IAP integration, create `ShopOfferSO` (currency packs, starter bundles, timed offers), `IIAPService` with receipt validation, purchase flow UI, daily deals rotation via Supabase config, VIP subscription with recurring benefits (+20% idle, daily diamonds), rewarded ad integration (AdMob/Unity Ads) for idle boost/extra attempts.

16. **Create Events system (Phase 2)** — `EventConfigSO` defining limited-time challenges (special map, modified rules, event currency drops), `IEventService` fetching active events from Supabase, event-specific enemy types, event shop with exclusive rewards (rare monsters, cosmetics), event UI with timer and leaderboard.

17. **Implement Analytics and A/B testing (Phase 2)** — Unity Analytics or custom Supabase logging for retention (D1/D7/D30), session length, wave completion rates, IAP conversion, ARPU/ARPPU, funnel drops, implement Remote Config for A/B tests (IAP prices, starter pack contents, AFK rates), dashboards in Supabase or external BI tool.

18. **Content expansion (Phase 2+)** — Add 2 new campaign maps (different path layouts, biomes), 5+ new monsters per faction with Stage 2/3 evolutions, 5+ enemy types with special mechanics (shields, healing, summoning), Daily Challenge mode with modifiers (single-faction only, double enemy speed, random buffs).

19. **Polish and optimization** — Profile on mid-range Android (3-4 year old devices), optimize draw calls (batching, atlasing), reduce memory allocations (object pooling, struct usage), implement quality settings (resolution scale, particle limits, shadow toggle), crash reporting (Unity Cloud Diagnostics or Sentry), final UI/UX polish pass.

20. **Softlaunch preparation (Phase 3)** — Create softlaunch build (Canada/Scandinavia), set up UAC (User Acquisition Campaign) tracking parameters, configure analytics funnels (install → tutorial → D1 → first IAP), implement feedback form in-game, prepare live-ops calendar (weekly events, rotating offers), KPI monitoring dashboard (CPI, LTV, retention curves), iteration plan based on metrics.

---

### Further Considerations

1. **Timeline expectations?** — Phase 0 (Vertical Slice): 2-4 weeks solo or 1-2 weeks with team. Phase 1 (Feature Expansion): +3-4 weeks. Phase 2 (Monetization/Live-Ops): +4-6 weeks. Phase 3 (Softlaunch): +2-4 weeks testing/iteration. Total: ~3-5 months from empty repo to softlaunch-ready.

2. **Solo developer or team?** — Steps can be parallelized with a team (one dev on monsters/enemies, one on UI, one on backend). Solo requires strict phase discipline to avoid scope creep. Recommend starting Phase 0 fully before expanding to Phase 1.

3. **Backend complexity trade-off?** — Supabase adds cloud save, analytics, and live-ops flexibility but increases complexity. Alternative: Start with local-only saves in Phase 0-1, defer Supabase to Phase 2 when monetization testing begins. This reduces early technical risk.

4. **Art asset plan after Phase 0?** — Phase 1+ requires custom art. Options: hire 2D artist for sprite work, commission asset packs (itch.io/Unity Asset Store), or use AI generation (Midjourney/DALL-E) with manual cleanup. Budget ~$500-2000 for professional sprite set (monsters, enemies, UI, VFX).

MaxeLBerger: Plan it for 3 Developers. 1 very new to coding vibe coder. 1 experienced coder that does quality vibe coding. 1 Developer that uses LLM´s but codes the Code by himself and only get suggestions from AI.



GitHub Copilot: Research phase documents fully

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

MaxeLBerger: 1. yes if this will keep us motivated and structured and productive
2. review optional. only for lowest tier developer, the vibe coder with low skills
3. yes 

GitHub Copilot: ## Plan: Updated Team Workflow with Resolved Considerations

Incorporating your decisions into the team-based implementation plan with refined workflow processes.

---

### Resolved Workflow Decisions

1. **Daily sync: Yes ✅** — 15-minute daily standups to maintain motivation, structure, and productivity. Prevents blocking issues and keeps all 3 developers aligned.

2. **Code review: Minimal, only for Developer A ✅** — B reviews A's code only (SO classes, simple scripts). B and C work autonomously without mandatory reviews—trust their experience.

3. **Shared test scene: Yes ✅** — Create `DevTestScene` for isolated component testing before full integration.

---

### Updated Workflow Structure

| Process | Details |
|---------|---------|
| **Daily Standup** | 15 min, same time daily. Format: "Yesterday / Today / Blockers". B leads Week 1, C leads Weeks 2-4 (integration focus). |
| **Code Reviews** | Only A → B reviews. B checks A's `*ConfigSO` classes and any scripts A writes. B and C skip reviews—merge directly. |
| **Test Scene** | B creates `Assets/_Project/Scenes/DevTestScene.unity` in Week 1. All devs use it for isolated testing before main scene integration. |
| **Branch Strategy** | `main` (stable), `dev` (integration). A works on `dev` directly. B and C can use feature branches or commit to `dev`. |

---

### Updated Week 1 — Add DevTestScene Setup

| Task | Owner | Dependencies |
|------|-------|--------------|
| *(All existing Week 1 tasks remain)* | | |
| **NEW:** Create `DevTestScene.unity` with basic camera, lighting, empty GameLifetimeScope for testing | **B** | Project setup |
| **NEW:** Add `DevTestScene` checklist to README: "How to test your component in isolation" | **B** | DevTestScene |

---

### Daily Standup Agenda Template

```
📅 [Date] - Daily Sync (15 min max)

👤 Developer A:
  - Yesterday: 
  - Today: 
  - Blockers: 

👤 Developer B:
  - Yesterday: 
  - Today: 
  - Blockers: 

👤 Developer C:
  - Yesterday: 
  - Today: 
  - Blockers: 

🔗 Handoffs needed today:
  - [e.g., "B → A: GameEvent base class ready"]
```

---

### DevTestScene Usage Guide (for README)

```markdown
## DevTestScene - Component Testing

Use `Assets/_Project/Scenes/DevTestScene.unity` to test your work in isolation.

### Developer A (SO Data)
1. Create your SO instance (e.g., `FlameImpConfig.asset`)
2. In DevTestScene, create empty GameObject, add a test MonoBehaviour
3. Reference your SO, enter Play Mode, verify inspector values

### Developer B (Services/Factories)
1. Add `GameLifetimeScope` to DevTestScene if testing DI
2. Create test consumer that injects your service
3. Verify service behavior via Debug.Log or Gizmos

### Developer C (Components)
1. Create test prefab with your component (e.g., Enemy with EnemyMovement)
2. Add mock waypoints in DevTestScene
3. Enter Play Mode, verify behavior before integrating into main scene
```

---

### Further Considerations

None — all decisions resolved. Ready to begin Week 1 implementation.

MaxeLBerger: Plan everything for completing Phase 0-3 and Create Issues for everything needed exactly for each developer.

1. Max :(me, qualified Vibe Coder, coding since 3 years MaxeLBerger on GitHub)
2. Moritz :(best friend, qualified Prompt Engineer, uses GPT to code but he codes the code himself)
3. Pharell:(good friend, new to coding, visits University for Informatics(has some experience but 1st semester, just told him a bit about vibecoding))


GitHub Copilot: Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/planning_Phase_1.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/planning_Phase_3.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/PRD_IdleMonsterEvolutionTD.md#200-200), lines 200 to 280

Now I have all the context needed. Let me create a comprehensive plan with GitHub issues for all phases (0-3) assigned to the three team members.

## Plan: Complete Phase 0-3 Implementation with GitHub Issues

A comprehensive implementation plan from Vertical Slice through Softlaunch, with GitHub Issues organized by phase, week, and developer assignment. Total timeline: ~12-16 weeks.

---

### Team Assignment (Updated)

| Developer | GitHub | Profile | Focus Areas |
|-----------|--------|---------|-------------|
| **Max** | @MaxeLBerger | Qualified Vibe Coder (3 years) | Architecture, DI, core systems, complex integrations, code quality |
| **Moritz** | TBD | Prompt Engineer + codes himself | Integration work, game logic, components, cross-system wiring, testing |
| **Pharell** | TBD | New coder, CS student (1st semester) | ScriptableObject data, assets, UI prefabs, configuration, balance tuning |

---

## Phase 0 — Vertical Slice (Weeks 1-4)

### Week 1: Foundation

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #1 | **[Setup] Create Unity project with production architecture** | Max | `phase-0`, `setup`, `priority-critical` | Create Unity 2022/2023 LTS with URP. Install VContainer, Input System, TextMeshPro, DOTween via Package Manager. Set up folder structure: `Assets/_Project/{Scripts,ScriptableObjects,Scenes,Prefabs,Art}`. Create ASMDEFs: `IdleMonsterTD.Core`, `IdleMonsterTD.Gameplay`, `IdleMonsterTD.UI`. Configure Android build (ARM64, IL2CPP, API 24+). Add Unity `.gitignore`. |
| #2 | **[Setup] Create `.github/copilot-instructions.md`** | Max | `phase-0`, `documentation`, `priority-critical` | Write comprehensive coding standards: SOLID principles, VContainer registration patterns, ScriptableObject event/variable templates, interface contracts (`IDamageable`, `IPoolable`, `ITargetable`, `ISaveable`), naming conventions (PascalCase, `I` prefix, `SO` suffix), forbidden patterns (no Singletons, no `FindObjectOfType`, no Update allocations), code examples for each pattern. |
| #3 | **[Core] Implement VContainer GameLifetimeScope** | Max | `phase-0`, `architecture`, `priority-critical` | Create `GameLifetimeScope : LifetimeScope` as VContainer root. Set up service registration structure for all core interfaces. Configure parent/child scope hierarchy for scene-specific registrations. |
| #4 | **[Core] Create core interfaces** | Max | `phase-0`, `architecture`, `priority-critical` | Define interfaces: `IDamageable` (TakeDamage, OnDeath event), `IPoolable` (OnSpawn, OnDespawn), `ITargetable` (Position, IsAlive), `ISaveable` (Save, Load), `IMonster`, `IEnemy : IDamageable, IPoolable`. |
| #5 | **[Core] Implement IPoolingService** | Max | `phase-0`, `architecture`, `priority-high` | Create generic `ObjectPool<T>` implementation. Register as `IPoolingService` in VContainer. Support prefab-based pooling with configurable initial size and max size. Implement warmup on scene load. |
| #6 | **[Core] Create ScriptableObject base classes** | Max | `phase-0`, `architecture`, `priority-high` | Create `GameEvent` SO (raise, register, unregister listeners). Create `FloatVariable` and `IntVariable` SOs with runtime value and reset-on-play option. Add custom editors with test buttons. |
| #7 | **[Setup] Create DevTestScene** | Max | `phase-0`, `setup`, `priority-medium` | Create `Assets/_Project/Scenes/DevTestScene.unity` with camera, lighting, empty `GameLifetimeScope`. Add testing instructions to README. |
| #8 | **[Assets] Download and organize Kenney TD Kit** | Pharell | `phase-0`, `assets`, `priority-high` | Download [Kenney.nl Tower Defense Kit](https://kenney.nl/assets/tower-defense-kit). Organize in `Assets/_Project/Art/Kenney/`. Create subfolders for Tiles, Props, UI elements. Document asset list in README. |
| #9 | **[Localization] Create LocalizationKeys constants** | Pharell | `phase-0`, `setup`, `priority-medium` | Create `LocalizationKeys.cs` with string constants: `UI_BUTTON_BATTLE`, `UI_BUTTON_MONSTERS`, `UI_BUTTON_AFK`, `UI_BUTTON_SUMMON`, `HUD_WAVE_COUNT`, `HUD_BASE_HP`, `HUD_GOLD`, etc. |
| #10 | **[Input] Set up Input System action asset** | Pharell | `phase-0`, `setup`, `priority-medium` | Create `TouchActions.inputactions` with actions: `Pointer/Position`, `Pointer/Click`, `Touch/PrimaryTouch`. Configure for both mouse and touch input. Generate C# class. |

### Week 2: Gameplay Systems

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #11 | **[Monster] Create MonsterConfigSO class** | Max | `phase-0`, `gameplay`, `priority-high` | Create `MonsterConfigSO : ScriptableObject` with fields: `ATK`, `Range`, `AttackSpeed`, `TargetingPriority` enum (Nearest, Strongest, Fastest, First), `ProjectilePrefab`, `EvolutionStage` enum, `Rarity` enum, display name, icon, 3D model reference. |
| #12 | **[Monster] Create 3 starter monster configs** | Pharell | `phase-0`, `data`, `priority-high`, `blocked-by-#11` | Create SO instances: **Flame Imp** (DPS: high ATK, medium range, fast attack), **Frost Wisp** (Slow: low ATK, long range, applies slow debuff), **Thunder Beast** (AoE: medium ATK, short range, chain lightning to 3 targets). Balance initial values. |
| #13 | **[Enemy] Create EnemyConfigSO class** | Max | `phase-0`, `gameplay`, `priority-high` | Create `EnemyConfigSO : ScriptableObject` with fields: `MaxHP`, `MoveSpeed`, `GoldReward`, `EvoMaterialDrop`, `EnemyType` enum, display name, icon, prefab reference. |
| #14 | **[Enemy] Create 3 enemy type configs** | Pharell | `phase-0`, `data`, `priority-high`, `blocked-by-#13` | Create SO instances: **Goblin** (standard: 100 HP, 1x speed, 10 gold), **Scout** (fast: 50 HP, 2x speed, 15 gold), **Ogre** (tanky: 300 HP, 0.5x speed, 25 gold). |
| #15 | **[Wave] Create WaveConfigSO class** | Max | `phase-0`, `gameplay`, `priority-high` | Create `WaveConfigSO : ScriptableObject` with fields: `List<WaveEntry>` (enemy config, count, spawn interval, delay before wave), wave number, bonus gold on completion. |
| #16 | **[Wave] Create 10 wave configs** | Pharell | `phase-0`, `data`, `priority-high`, `blocked-by-#15` | Create 10 `WaveConfigSO` instances with progressive difficulty: Waves 1-3 (Goblins only), Waves 4-6 (add Scouts), Waves 7-9 (add Ogres), Wave 10 (boss wave: many Ogres). |
| #17 | **[Events] Create GameEvent SO instances** | Pharell | `phase-0`, `data`, `priority-medium`, `blocked-by-#6` | Create SO assets: `OnWaveStart`, `OnWaveComplete`, `OnGameWon`, `OnGameLost`, `OnEnemyKilled`, `OnMonsterPlaced`, `OnGoldChanged`. |
| #18 | **[Variables] Create variable SO instances** | Pharell | `phase-0`, `data`, `priority-medium`, `blocked-by-#6` | Create SO assets: `BaseHP` (FloatVariable, default 100), `CurrentGold` (IntVariable, default 0), `CurrentWave` (IntVariable, default 1), `GameSpeed` (FloatVariable, default 1). |
| #19 | **[Map] Set up battle map scene** | Pharell | `phase-0`, `level-design`, `priority-high` | Create `BattleScene.unity`. Design S-shaped path using Kenney tiles. Place `Waypoint` MonoBehaviours along path. Create 6 monster placement slots. Add spawn point and base/portal visuals. |
| #20 | **[Monster] Implement MonsterFactory** | Max | `phase-0`, `gameplay`, `priority-high` | Create `MonsterFactory` class with VContainer injection. Method: `CreateMonster(MonsterConfigSO, Vector3 position)` returns `IMonster`. Instantiates prefab, configures components from SO. |
| #21 | **[Enemy] Implement EnemyFactory** | Max | `phase-0`, `gameplay`, `priority-high` | Create `EnemyFactory` class with VContainer injection. Uses `IPoolingService` for pooling. Method: `SpawnEnemy(EnemyConfigSO, Vector3 position)` returns `IEnemy`. Configures from SO on spawn. |
| #22 | **[Save] Implement ISaveService** | Max | `phase-0`, `persistence`, `priority-high` | Create `SaveService : ISaveService`. JSON serialization to `Application.persistentDataPath`. Create `PlayerDataSO` (gold, evo-materials, owned monsters list). Create `MonsterInstanceData` class (ID, level, XP, evolution stage). Implement auto-save on `OnApplicationPause`/`OnApplicationQuit`. |
| #23 | **[AFK] Implement IAFKRewardService** | Max | `phase-0`, `persistence`, `priority-high`, `blocked-by-#22` | Create `AFKRewardService : IAFKRewardService`. Store last collect UTC timestamp. Calculate offline duration (max 8h cap). Reward formula: `baseGold * (1 + accountPower * 0.01) * offlineHours`. Return reward breakdown (gold, evo materials). |
| #24 | **[Enemy] Implement EnemyMovement component** | Moritz | `phase-0`, `gameplay`, `priority-high` | Create `EnemyMovement : MonoBehaviour`. Inject `Waypoint[]` path. Move along path using speed from `EnemyConfigSO`. Trigger base damage when reaching end. Use `IPoolable` for reset on spawn. |
| #25 | **[Enemy] Implement EnemyHealth component** | Moritz | `phase-0`, `gameplay`, `priority-high` | Create `EnemyHealth : MonoBehaviour, IDamageable`. Initialize HP from `EnemyConfigSO`. Implement `TakeDamage(float)`. Trigger `OnEnemyKilled` GameEvent on death. Grant gold reward to `CurrentGold` variable. Return to pool via `IPoolable`. |
| #26 | **[Monster] Implement MonsterTargeting component** | Moritz | `phase-0`, `gameplay`, `priority-high` | Create `MonsterTargeting : MonoBehaviour`. Find enemies in range (Physics overlap or manual distance check). Apply targeting priority from config (Nearest, Strongest, Fastest, First). Expose `CurrentTarget` property. Update target selection each frame. |
| #27 | **[Monster] Implement MonsterAttack component** | Moritz | `phase-0`, `gameplay`, `priority-high`, `blocked-by-#26` | Create `MonsterAttack : MonoBehaviour`. Use attack speed from config. Spawn projectile from pool when attacking. Projectile travels to target, deals damage via `IDamageable`. Handle Frost Wisp slow effect and Thunder Beast chain lightning. |

### Week 3: Wave System & UI

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #28 | **[UI] Create Hub panel prefab** | Pharell | `phase-0`, `ui`, `priority-high` | Create `HubPanel.prefab` with 4 buttons: Battle, Monsters, AFK-Chest, Summon (disabled placeholder). Use TextMeshPro. Layout only, no code. Follow mobile-friendly sizing (large touch targets). |
| #29 | **[UI] Create HUD prefab** | Pharell | `phase-0`, `ui`, `priority-high` | Create `BattleHUD.prefab` with: Wave counter text, Base HP bar (slider), Gold display with icon, Speed toggle button (1x/2x). Layout only, no code. |
| #30 | **[UI] Create Monster list panel prefab** | Pharell | `phase-0`, `ui`, `priority-medium` | Create `MonsterListPanel.prefab` with scrollable vertical grid. Create `MonsterCard.prefab` child (icon, name, level, rarity border). Layout only. |
| #31 | **[UI] Create Monster detail panel prefab** | Pharell | `phase-0`, `ui`, `priority-medium` | Create `MonsterDetailPanel.prefab` with: Large monster preview, Stats display (ATK, Range, Speed with bars), Evolution preview section, Level-up button with cost, Close button. |
| #32 | **[UI] Create AFK reward popup prefab** | Pharell | `phase-0`, `ui`, `priority-medium` | Create `AFKPopup.prefab` with: "Welcome back!" header, Time away display, Rewards list (gold icon + amount, evo-mats icon + amount), Claim button, optional "Watch Ad for 2x" button placeholder. |
| #33 | **[Art] Create placeholder monster/enemy visuals** | Pharell | `phase-0`, `assets`, `priority-medium` | Create colored primitives: Flame Imp (red sphere), Frost Wisp (blue sphere), Thunder Beast (yellow cube). Enemies: Goblin (green capsule), Scout (small green capsule), Ogre (large green cube). Add simple materials. |
| #34 | **[Wave] Implement IWaveManager** | Moritz | `phase-0`, `gameplay`, `priority-critical` | Create `WaveManager : IWaveManager`. Load `WaveConfigSO` sequence. Spawn enemies via `EnemyFactory` with configured delays. Track alive enemies. Trigger `OnWaveComplete` when all dead. Trigger `OnGameWon` after wave 10. Handle endless mode transition (future). |
| #35 | **[GameState] Implement IGameStateService** | Moritz | `phase-0`, `gameplay`, `priority-critical` | Create `GameStateService : IGameStateService`. States: `Hub`, `PreBattle`, `Playing`, `Paused`, `Won`, `Lost`. Monitor `BaseHP` variable for loss condition. Expose state change events. Control `Time.timeScale` for pause. |
| #36 | **[UI] Wire HUD to SO variables** | Moritz | `phase-0`, `ui`, `priority-high`, `blocked-by-#29` | Create `HUDController : MonoBehaviour`. Bind wave counter to `CurrentWave` IntVariable. Bind HP bar to `BaseHP` FloatVariable. Bind gold display to `CurrentGold` IntVariable. Subscribe to variable change events. |
| #37 | **[UI] Implement speed toggle** | Moritz | `phase-0`, `ui`, `priority-medium` | Create `SpeedToggleButton : MonoBehaviour`. Toggle between 1x and 2x (modify `GameSpeed` FloatVariable). Update button visual. `GameStateService` applies `Time.timeScale` from variable. |
| #38 | **[Gameplay] Implement monster placement** | Moritz | `phase-0`, `gameplay`, `priority-high` | Create `MonsterPlacementController`. Use Input System for touch/click. Detect placement slot clicks. Show monster selection UI. On select, call `MonsterFactory.CreateMonster()` at slot position. Deduct placement cost from gold. |
| #39 | **[Core] Integrate projectile pooling** | Max | `phase-0`, `gameplay`, `priority-medium`, `blocked-by-#27` | Configure `IPoolingService` for projectile prefabs. Ensure `MonsterAttack` uses pooled projectiles. Add projectile return-to-pool on hit or timeout. Verify no memory leaks with profiler. |
| #40 | **[Visual] Add EnemyVisuals and MonsterVisuals** | Max | `phase-0`, `gameplay`, `priority-medium`, `blocked-by-#33` | Create `EnemyVisuals` component (assigns mesh/sprite from `EnemyConfigSO`). Create `MonsterVisuals` component (assigns mesh/sprite from `MonsterConfigSO`, handles evolution visual changes). |

### Week 4: Polish & Integration

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #41 | **[UI] Implement Monster list panel logic** | Moritz | `phase-0`, `ui`, `priority-high` | Create `MonsterListController`. Read owned monsters from `PlayerDataSO`. Instantiate `MonsterCard` prefabs. Handle card click → open detail panel. Sort by rarity/level. |
| #42 | **[UI] Implement Monster detail panel logic** | Moritz | `phase-0`, `ui`, `priority-high` | Create `MonsterDetailController`. Display stats from `MonsterConfigSO` + `MonsterInstanceData`. Level-up button: check gold cost, deduct, increment level, trigger save. Show evolution preview if eligible. |
| #43 | **[UI] Implement AFK popup logic** | Moritz | `phase-0`, `ui`, `priority-high` | Create `AFKPopupController`. On app start, call `IAFKRewardService.CalculateRewards()`. If rewards > 0, show popup. Claim button adds rewards to `PlayerDataSO`, triggers save, closes popup. |
| #44 | **[Scene] Implement Hub→Battle scene flow** | Moritz | `phase-0`, `scene`, `priority-high` | Create `HubScene.unity`. Battle button loads `BattleScene`. On win/lose, return to Hub. Pass battle results (gold earned, waves completed). Update `PlayerDataSO` with results. |
| #45 | **[Balance] Tune wave difficulty** | Pharell | `phase-0`, `balance`, `priority-medium` | Playtest waves 1-10. Adjust enemy counts, HP values, spawn intervals in `WaveConfigSO` instances. Target: Wave 1-3 easy, Wave 4-6 medium, Wave 7-9 hard, Wave 10 challenging but beatable. |
| #46 | **[Balance] Tune monster stats** | Pharell | `phase-0`, `balance`, `priority-medium` | Playtest monster effectiveness. Adjust ATK, Range, AttackSpeed in `MonsterConfigSO`. Ensure all 3 monsters feel useful. Frost Wisp slow should matter. Thunder Beast chain should hit multiple enemies. |
| #47 | **[VFX] Add simple visual effects** | Max | `phase-0`, `polish`, `priority-low` | Add projectile trail renderers. Add enemy death particle burst. Add damage number popup (TextMeshPro, pooled, floats up and fades). Add monster attack muzzle flash. |
| #48 | **[Perf] Performance optimization pass** | Max | `phase-0`, `optimization`, `priority-high` | Profile on Android device or emulator. Verify object pooling works (no runtime instantiation during waves). Check for Update allocations. Ensure 60 FPS on mid-range device. Document performance baseline. |
| #49 | **[QA] Full gameplay loop test** | All | `phase-0`, `testing`, `priority-critical` | Test complete flow: Launch → AFK popup → Claim → Hub → Monsters → Level-up → Battle → Complete 10 waves → Win → Return to Hub → Verify gold/progress saved. Document bugs. |
| #50 | **[Docs] Phase 0 completion documentation** | Max | `phase-0`, `documentation`, `priority-medium` | Update README with setup instructions. Document architecture decisions. List known issues. Write Phase 1 handoff notes. Create changelog entry. |

---

## Phase 1 — Feature Expansion (Weeks 5-8)

### Week 5: Gacha System

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #51 | **[Gacha] Create GachaBannerConfigSO** | Max | `phase-1`, `gacha`, `priority-critical` | Create SO with: `DropRates` dictionary (Rarity → percentage), `PityThreshold` (int, e.g., 90), `FeaturedMonsters` list with rate-up multiplier, banner duration dates, cost per summon (diamonds). |
| #52 | **[Gacha] Implement IGachaService** | Max | `phase-1`, `gacha`, `priority-critical` | Create `GachaService : IGachaService`. Methods: `SummonSingle()`, `SummonTen()`. Implement weighted random with pity counter. Pity persists via `ISaveService`. Return list of `GachaResult` (monster or shards). |
| #53 | **[Gacha] Implement monster shard system** | Max | `phase-1`, `gacha`, `priority-high` | Modify `PlayerDataSO` to track shards per monster. Duplicate summons grant shards. Create `MonsterShardConfigSO` (shards needed: Common 10, Rare 30, Epic 80, Legendary 200). Auto-unlock monster when threshold reached. |
| #54 | **[Gacha] Create 5 new monsters** | Pharell | `phase-1`, `data`, `priority-high` | Create configs: **Stone Golem** (Rare, tanky melee), **Wind Sprite** (Rare, long range), **Shadow Panther** (Epic, fast multi-hit), **Phoenix** (Epic, AoE + burn DoT), **Dragon Lord** (Legendary, massive AoE). |
| #55 | **[UI] Create Summon screen UI** | Pharell | `phase-1`, `ui`, `priority-high` | Create `SummonScreen.prefab` with: Banner image area, Single summon button (cost display), 10x summon button (cost + bonus), Pity counter display, "View Rates" button, summon result reveal area. |
| #56 | **[UI] Implement Summon screen logic** | Moritz | `phase-1`, `ui`, `priority-high`, `blocked-by-#52,#55` | Create `SummonScreenController`. Display current banner from `GachaBannerConfigSO`. Handle button clicks → call `IGachaService`. Play reveal animation (sequential for 10x). Show results with rarity VFX. Update `PlayerDataSO`. |
| #57 | **[VFX] Summon reveal animations** | Max | `phase-1`, `vfx`, `priority-medium` | Create summon door/portal animation. Rarity-based reveal VFX (Common: white, Rare: blue, Epic: purple, Legendary: gold). Screen shake on legendary. Sound effect hooks (audio later). |

### Week 6: Hub & Meta-Progression

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #58 | **[Hub] Create BuildingConfigSO** | Max | `phase-1`, `meta`, `priority-high` | Create SO with: Building type enum (MonsterLab, AFKChest, Research, SummonArena), upgrade levels array (cost, unlock requirements, bonuses per level). |
| #59 | **[Hub] Create ResearchTreeSO** | Max | `phase-1`, `meta`, `priority-high` | Create SO defining research nodes: Global ATK%, Global HP%, AFK Rate%, Max AFK Time, Extra Monster Slots. Each node has cost, prerequisites, effect value. |
| #60 | **[Hub] Redesign Hub scene with buildings** | Pharell | `phase-1`, `level-design`, `priority-high` | Update `HubScene.unity` with visual building representations. Clickable areas for: Monster-Lab, AFK-Chest, Research Lab, Summon Arena. Show upgrade level indicators. |
| #61 | **[UI] Create Research panel UI** | Pharell | `phase-1`, `ui`, `priority-medium` | Create `ResearchPanel.prefab` with tree visualization. Show nodes with unlock state, cost, effect preview. Unlock button per node. |
| #62 | **[Hub] Implement IResearchService** | Moritz | `phase-1`, `meta`, `priority-high`, `blocked-by-#59` | Create `ResearchService : IResearchService`. Track unlocked research in `PlayerDataSO`. Apply bonuses globally (modify base values). Expose `GetBonus(BonusType)` method. |
| #63 | **[Hub] Implement building upgrades** | Moritz | `phase-1`, `meta`, `priority-high`, `blocked-by-#58` | Create `BuildingUpgradeController`. Display current level, next level benefits, upgrade cost. Handle upgrade purchase. Apply building bonuses (e.g., AFK-Chest level increases reward rate). |
| #64 | **[Account] Implement account level system** | Moritz | `phase-1`, `meta`, `priority-medium` | Add `AccountXP` and `AccountLevel` to `PlayerDataSO`. Grant XP on wave complete, monster level-up, summons. Level-up unlocks features (research at level 5, endless at level 10). |

### Week 7: Endless Mode & Content

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #65 | **[Endless] Create EndlessWaveGeneratorSO** | Max | `phase-1`, `gameplay`, `priority-high` | Create SO with scaling formula: HP multiplier per wave (1 + wave * 0.1), enemy count scaling, reward multiplier, boss wave interval (every 10 waves). |
| #66 | **[Endless] Implement endless mode manager** | Moritz | `phase-1`, `gameplay`, `priority-high`, `blocked-by-#65` | Create `EndlessModeManager`. Generate waves infinitely from formula. Track high score (waves survived). Increasing rewards per wave. Game over when base HP reaches 0. |
| #67 | **[UI] Create Endless mode UI** | Pharell | `phase-1`, `ui`, `priority-medium` | Create `EndlessHUD.prefab` extending battle HUD with: Current wave (no max), High score display, Rewards earned this run, Quit button (confirm dialog). |
| #68 | **[UI] Create mode selection screen** | Pharell | `phase-1`, `ui`, `priority-medium` | Create `ModeSelectScreen.prefab` with: Campaign button (shows progress), Endless button (shows high score, locked until account level 10). |
| #69 | **[Map] Create 2 new campaign maps** | Pharell | `phase-1`, `level-design`, `priority-high` | Create **Forest Path** (winding path, more placement slots) and **Volcanic Ridge** (short path, fewer slots, enemies have fire resist). Different visual themes using Kenney assets or new placeholders. |
| #70 | **[Enemy] Create 5 new enemy types** | Pharell | `phase-1`, `data`, `priority-high` | Create configs: **Slime** (splits into 2 on death), **Shielded Knight** (front shield blocks damage), **Healer** (heals nearby enemies), **Assassin** (invisible until attacked), **Golem Boss** (huge HP, slow, milestone wave boss). |
| #71 | **[Enemy] Implement special enemy abilities** | Moritz | `phase-1`, `gameplay`, `priority-high`, `blocked-by-#70` | Implement: `SlimeSplit` component, `ShieldBlock` component (directional armor), `EnemyHealer` component (AoE heal), `Invisibility` component (not targetable until hit), boss HP scaling. |
| #72 | **[Monster] Implement Evolution Stage 2** | Max | `phase-1`, `gameplay`, `priority-high` | Add evolution logic: Meet level threshold (20) + consume evo materials → evolve to Stage 2. Stage 2 has new visuals, stat multiplier (1.5x), enhanced ability. |

### Week 8: Backend Integration

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #73 | **[Backend] Set up Supabase project** | Max | `phase-1`, `backend`, `priority-critical` | Create Supabase project. Define tables: `accounts` (id, email, created_at), `player_progress` (account_id, save_data JSON, updated_at), `analytics_events` (account_id, event_type, data JSON, timestamp). Set up Row Level Security. |
| #74 | **[Backend] Implement cloud save sync** | Max | `phase-1`, `backend`, `priority-critical` | Create `CloudSaveService`. On app start: fetch cloud save, compare timestamps, use newer. On local save: queue upload. Handle offline mode gracefully. Conflict resolution: server timestamp wins. |
| #75 | **[Backend] Implement account auth** | Max | `phase-1`, `backend`, `priority-high` | Integrate Supabase Auth. Support anonymous auth (auto on first launch) + optional email link. Device ID fallback for account recovery. Store auth token securely. |
| #76 | **[Backend] Implement analytics logging** | Moritz | `phase-1`, `backend`, `priority-medium`, `blocked-by-#73` | Create `AnalyticsService`. Log events: `session_start`, `session_end`, `wave_complete`, `summon_performed`, `monster_levelup`, `iap_purchase`. Batch events, send on interval or app pause. |
| #77 | **[Backend] Implement remote config** | Moritz | `phase-1`, `backend`, `priority-medium` | Create `remote_config` table in Supabase. Fetch on app start. Override local balance values (enemy HP multipliers, reward rates). Cache locally for offline. |
| #78 | **[QA] Phase 1 integration testing** | All | `phase-1`, `testing`, `priority-critical` | Test: Gacha with pity, shard accumulation, research unlocks, endless mode scaling, cloud save sync (install on 2 devices), new maps and enemies, evolution system. Document bugs. |
| #79 | **[Docs] Phase 1 completion documentation** | Max | `phase-1`, `documentation`, `priority-medium` | Document gacha drop rates, research tree effects, endless scaling formula. Update README. Create Phase 2 handoff notes. |

---

## Phase 2 — Monetization & Live-Ops (Weeks 9-12)

### Week 9: Battle Pass

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #80 | **[Pass] Create SeasonConfigSO** | Max | `phase-2`, `monetization`, `priority-critical` | Create SO with: Season ID, start/end dates, 40 tiers, free rewards array, premium rewards array, mission definitions (complete X waves, level up X times, perform X summons). |
| #81 | **[Pass] Implement IBattlePassService** | Max | `phase-2`, `monetization`, `priority-critical` | Create `BattlePassService`. Track XP from missions. Calculate current tier. Track claimed rewards (free/premium separately). Check premium unlock status. Persist via `ISaveService`. |
| #82 | **[Pass] Create Battle Pass UI** | Pharell | `phase-2`, `ui`, `priority-high` | Create `BattlePassScreen.prefab` with: Season banner, tier track (scrollable), current XP bar, mission list, premium unlock button, reward claim buttons. |
| #83 | **[Pass] Implement Battle Pass UI logic** | Moritz | `phase-2`, `ui`, `priority-high`, `blocked-by-#81,#82` | Create `BattlePassController`. Display tier progress. Handle reward claims. Show locked/unlocked premium state. Mission progress updates. Premium purchase flow. |
| #84 | **[Pass] Create pass missions system** | Moritz | `phase-2`, `gameplay`, `priority-high` | Create `MissionTracker`. Subscribe to GameEvents (`OnWaveComplete`, `OnMonsterLevelUp`, `OnSummonPerformed`). Increment mission progress. Notify `IBattlePassService` of completion. |
| #85 | **[Pass] Define Season 1 rewards** | Pharell | `phase-2`, `data`, `priority-medium` | Design 40 tiers of rewards. Free: gold, evo materials, common shards. Premium: diamonds, epic shards, exclusive cosmetic frames, legendary shards at tier 40. |

### Week 10: Shop & IAP

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #86 | **[Shop] Create ShopOfferConfigSO** | Max | `phase-2`, `monetization`, `priority-critical` | Create SO with: Offer ID, price (real money), contents (currency/items), duration (permanent/timed), display priority, purchase limit, icon, description. |
| #87 | **[Shop] Integrate Unity IAP** | Max | `phase-2`, `monetization`, `priority-critical` | Install Unity IAP package. Configure products: Diamond packs (5 tiers), Battle Pass, Starter Bundle, Monthly VIP. Implement `IIAPService` with purchase flow. |
| #88 | **[Shop] Implement receipt validation** | Max | `phase-2`, `backend`, `priority-high`, `blocked-by-#87` | Create Supabase Edge Function for receipt validation (Google Play / App Store). Store validated purchases in `purchases` table. Prevent duplicate grants. |
| #89 | **[Shop] Create Shop UI** | Pharell | `phase-2`, `ui`, `priority-high` | Create `ShopScreen.prefab` with tabs: Diamonds, Bundles, Daily Deals. Each offer shows: contents preview, price, purchase button, "Best Value" badges. |
| #90 | **[Shop] Implement Shop UI logic** | Moritz | `phase-2`, `ui`, `priority-high`, `blocked-by-#87,#89` | Create `ShopController`. Load offers from configs. Display prices from IAP catalog. Handle purchase button → `IIAPService`. Grant rewards on success. Show purchase confirmation. |
| #91 | **[Shop] Implement daily/weekly offers** | Moritz | `phase-2`, `monetization`, `priority-medium` | Create offer rotation system. Daily deals refresh at UTC midnight. Weekly special bundles. Track purchase limits per offer. Use remote config for offer contents. |
| #92 | **[VIP] Implement VIP subscription** | Max | `phase-2`, `monetization`, `priority-medium` | Create VIP tier in IAP (auto-renewing subscription). Benefits: +20% idle rewards, daily 50 diamonds, exclusive chat frame, extra monster slots. Check subscription status on app start. |

### Week 11: Ads & Events

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #93 | **[Ads] Integrate Unity Ads / AdMob** | Max | `phase-2`, `monetization`, `priority-high` | Install ads SDK. Create `IAdService` interface. Implement rewarded ad placements: AFK 2x boost (4h), bonus summon, battle continue (revive base). |
| #94 | **[Ads] Implement ad reward flow** | Moritz | `phase-2`, `monetization`, `priority-high`, `blocked-by-#93` | Create `AdRewardController`. Check ad availability. Show "Watch Ad" buttons where applicable. Grant rewards on ad complete. Daily ad limits (5 per placement). |
| #95 | **[Events] Create EventConfigSO** | Max | `phase-2`, `live-ops`, `priority-high` | Create SO with: Event ID, type (challenge/collection/boss), start/end dates, event currency, bonus stages list, event shop rewards, leaderboard settings. |
| #96 | **[Events] Implement IEventService** | Moritz | `phase-2`, `live-ops`, `priority-high`, `blocked-by-#95` | Create `EventService`. Fetch active events from Supabase. Track event currency. Event stage completion. Event shop purchases. Leaderboard submission. |
| #97 | **[Events] Create Event UI** | Pharell | `phase-2`, `ui`, `priority-high` | Create `EventScreen.prefab` with: Event banner, timer countdown, stage list, event shop button, leaderboard button. Create `EventShopPanel.prefab`. |
| #98 | **[Events] Implement Event UI logic** | Moritz | `phase-2`, `ui`, `priority-high`, `blocked-by-#96,#97` | Create `EventController`. Display active event. Handle stage entry. Event shop purchasing. Leaderboard display. Event end handling. |
| #99 | **[Events] Create first event content** | Pharell | `phase-2`, `data`, `priority-medium` | Design "Monster Hunt" event: 5 bonus stages with increased monster shard drops, event currency from kills, event shop with exclusive Epic monster shards. |

### Week 12: Analytics & Polish

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #100 | **[Analytics] Implement funnel tracking** | Max | `phase-2`, `analytics`, `priority-high` | Track FTUE completion rate, first summon conversion, first IAP conversion, daily/weekly active users. Create Supabase views for metrics. |
| #101 | **[Analytics] Implement retention cohorts** | Max | `phase-2`, `analytics`, `priority-high` | Track D1, D7, D30 retention by install cohort. Create dashboard queries. Set up alerts for retention drops. |
| #102 | **[Analytics] Implement revenue metrics** | Max | `phase-2`, `analytics`, `priority-high` | Track ARPU, ARPPU, paying user %. Revenue by source (IAP, ads, subscription). LTV estimation. |
| #103 | **[A/B] Implement A/B test framework** | Max | `phase-2`, `analytics`, `priority-medium` | Use remote config for test variants. Assign users to buckets on first launch. Track metrics per bucket. Support: IAP pricing, starter bundle contents, AFK reward rates. |
| #104 | **[QA] Phase 2 monetization testing** | All | `phase-2`, `testing`, `priority-critical` | Test: IAP purchase flow (sandbox), receipt validation, Battle Pass tier progression, ad reward grants, event participation, VIP benefits. Verify no exploits. |
| #105 | **[Polish] Final UI/UX pass** | Pharell | `phase-2`, `polish`, `priority-medium` | Review all screens for consistency. Add loading indicators. Add confirmation dialogs for purchases. Improve touch feedback. Accessibility check (text sizes, contrast). |
| #106 | **[Perf] Pre-launch optimization** | Max | `phase-2`, `optimization`, `priority-high` | Final performance pass. Memory profiling. Reduce APK size. Enable Proguard/R8. Test on low-end devices. Crash-free rate target: 99%. |
| #107 | **[Docs] Phase 2 completion documentation** | Max | `phase-2`, `documentation`, `priority-medium` | Document monetization flow, event system, analytics dashboards. Prepare store listing assets. Write privacy policy. Create Phase 3 softlaunch plan. |

---

## Phase 3 — Softlaunch (Weeks 13-16)

### Week 13: Softlaunch Preparation

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #108 | **[Release] Prepare Google Play listing** | Max | `phase-3`, `release`, `priority-critical` | Create store listing: App name, description (short/long), screenshots (5+), feature graphic, app icon. Age rating questionnaire. Content rating. |
| #109 | **[Release] Configure softlaunch countries** | Max | `phase-3`, `release`, `priority-critical` | Set up closed/open testing track. Target countries: Canada, Australia, Scandinavia (low CPI, representative behavior). Configure geo-restrictions. |
| #110 | **[Release] Set up crash reporting** | Max | `phase-3`, `infrastructure`, `priority-high` | Integrate Unity Cloud Diagnostics or Firebase Crashlytics. Configure symbolication. Set up Slack/Discord alerts for crashes. |
| #111 | **[Release] Set up live-ops calendar** | Pharell | `phase-3`, `live-ops`, `priority-high` | Plan first 4 weeks of live content: Week 1-2 launch event, Week 3 new banner, Week 4 challenge event. Create event configs in Supabase. |
| #112 | **[Marketing] Create promotional assets** | Pharell | `phase-3`, `marketing`, `priority-medium` | Create short gameplay video (30s). Create social media assets. Prepare press kit. Design app icon variants for A/B test. |

### Week 14-15: Softlaunch & Iteration

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #113 | **[Release] Launch to softlaunch markets** | Max | `phase-3`, `release`, `priority-critical` | Push build to Google Play. Monitor rollout. Watch for critical issues. Be ready for hotfix. |
| #114 | **[Analytics] Monitor launch KPIs** | Max | `phase-3`, `analytics`, `priority-critical` | Daily monitoring: D1 retention (target: 40%+), session length, crash rate, IAP conversion, ARPU. Create daily report. |
| #115 | **[Support] Handle user feedback** | Moritz | `phase-3`, `support`, `priority-high` | Monitor Play Store reviews. Respond to user issues. Collect feature requests. Prioritize bugs by severity. |
| #116 | **[Balance] Iterate on economy** | Pharell | `phase-3`, `balance`, `priority-high` | Based on data: adjust gold rates, gacha pity, wave difficulty, IAP pricing. Use remote config for quick changes. |
| #117 | **[Iteration] Hotfix critical bugs** | All | `phase-3`, `bugfix`, `priority-critical` | Address crash-causing bugs immediately. Fix exploit vulnerabilities. Push hotfix builds as needed. |
| #118 | **[Iteration] Implement quick wins** | Moritz | `phase-3`, `improvement`, `priority-medium` | Based on feedback: QoL improvements, UI clarity fixes, tutorial improvements, balance adjustments. |

### Week 16: Evaluation & Global Prep

| Issue # | Title | Assignee | Labels | Description |
|---------|-------|----------|--------|-------------|
| #119 | **[Analytics] Softlaunch retrospective** | Max | `phase-3`, `analytics`, `priority-critical` | Compile 2-week metrics. Calculate: CPI, D7 retention, D7 LTV, LTV/CPI ratio. Identify biggest drop-off points. Write retrospective document. |
| #120 | **[Decision] Go/No-Go for global launch** | All | `phase-3`, `decision`, `priority-critical` | Review KPIs against targets. If D1 > 35%, D7 > 15%, LTV/CPI > 0.7: plan global. Otherwise: iterate further or pivot. |
| #121 | **[Docs] Global launch planning** | Max | `phase-3`, `documentation`, `priority-high` | If Go: plan global launch date, UA budget, localization priorities, iOS build timeline. Create Phase 4 roadmap (post-launch content). |
| #122 | **[Release] iOS build preparation** | Max | `phase-3`, `release`, `priority-medium` | Configure iOS build settings. TestFlight setup. App Store listing preparation. Plan iOS softlaunch or simultaneous global. |

---

## GitHub Labels to Create

```
phase-0, phase-1, phase-2, phase-3
priority-critical, priority-high, priority-medium, priority-low
setup, architecture, gameplay, ui, data, assets, documentation
backend, monetization, analytics, live-ops, balance, polish, optimization
testing, bugfix, release, marketing, support, decision
blocked
```

---

## Issue Creation Commands (GitHub CLI)

```powershell
# Create labels first
gh label create "phase-0" --color "0E8A16" --description "Vertical Slice"
gh label create "phase-1" --color "1D76DB" --description "Feature Expansion"
gh label create "phase-2" --color "D93F0B" --description "Monetization & Live-Ops"
gh label create "phase-3" --color "5319E7" --description "Softlaunch"
gh label create "priority-critical" --color "B60205"
gh label create "priority-high" --color "D93F0B"
gh label create "priority-medium" --color "FBCA04"
gh label create "priority-low" --color "0E8A16"
# ... (create remaining labels)

# Example issue creation
gh issue create --title "[Setup] Create Unity project with production architecture" --body "Create Unity 2022/2023 LTS with URP..." --label "phase-0,setup,priority-critical" --assignee "MaxeLBerger"
```

---

### Further Considerations

1. **GitHub usernames for Moritz and Pharell?** — Need their GitHub handles to create issues with correct assignees. Placeholder: use `@Moritz-TBD` and `@Pharell-TBD` until confirmed.

2. **Milestone structure?** — Recommend creating 4 milestones (Phase 0, Phase 1, Phase 2, Phase 3) to track progress per phase. Each issue assigned to its phase milestone.

3. **Project board?** — Create GitHub Project board with columns: `Backlog`, `Ready`, `In Progress`, `In Review`, `Done`. Automate card movement based on issue labels/status.

MaxeLBerger: 1. @Moritz-TBD = Moritz622  @Pharell-TBD = User420-Bit
2. yes
3. yes

GitHub Copilot: ## Plan: Final Implementation Plan with GitHub Setup

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

## Phase 1 Issues (29 issues) — Weeks 5-8

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
<summary><strong>Week 8: Backend Integration (7 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 73 | [Backend] Set up Supabase project | MaxeLBerger | phase-1, backend, priority-critical |
| 74 | [Backend] Implement cloud save sync | MaxeLBerger | phase-1, backend, priority-critical |
| 75 | [Backend] Implement account auth | MaxeLBerger | phase-1, backend, priority-high |
| 76 | [Backend] Implement analytics logging | Moritz622 | phase-1, backend, priority-medium |
| 77 | [Backend] Implement remote config | Moritz622 | phase-1, backend, priority-medium |
| 78 | [QA] Phase 1 integration testing | MaxeLBerger | phase-1, testing, priority-critical |
| 79 | [Docs] Phase 1 completion documentation | MaxeLBerger | phase-1, documentation, priority-medium |

</details>

---

## Phase 2 Issues (28 issues) — Weeks 9-12

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
<summary><strong>Week 12: Analytics & Polish (8 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 100 | [Analytics] Implement funnel tracking | MaxeLBerger | phase-2, analytics, priority-high |
| 101 | [Analytics] Implement retention cohorts | MaxeLBerger | phase-2, analytics, priority-high |
| 102 | [Analytics] Implement revenue metrics | MaxeLBerger | phase-2, analytics, priority-high |
| 103 | [A/B] Implement A/B test framework | MaxeLBerger | phase-2, analytics, priority-medium |
| 104 | [QA] Phase 2 monetization testing | MaxeLBerger | phase-2, testing, priority-critical |
| 105 | [Polish] Final UI/UX pass | User420-Bit | phase-2, polish, priority-medium |
| 106 | [Perf] Pre-launch optimization | MaxeLBerger | phase-2, optimization, priority-high |
| 107 | [Docs] Phase 2 completion documentation | MaxeLBerger | phase-2, documentation, priority-medium |

</details>

---

## Phase 3 Issues (15 issues) — Weeks 13-16

<details>
<summary><strong>Week 13: Softlaunch Preparation (5 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 108 | [Release] Prepare Google Play listing | MaxeLBerger | phase-3, release, priority-critical |
| 109 | [Release] Configure softlaunch countries | MaxeLBerger | phase-3, release, priority-critical |
| 110 | [Release] Set up crash reporting | MaxeLBerger | phase-3, setup, priority-high |
| 111 | [Release] Set up live-ops calendar | User420-Bit | phase-3, live-ops, priority-high |
| 112 | [Marketing] Create promotional assets | User420-Bit | phase-3, assets, priority-medium |

</details>

<details>
<summary><strong>Weeks 14-15: Softlaunch & Iteration (6 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 113 | [Release] Launch to softlaunch markets | MaxeLBerger | phase-3, release, priority-critical |
| 114 | [Analytics] Monitor launch KPIs | MaxeLBerger | phase-3, analytics, priority-critical |
| 115 | [Support] Handle user feedback | Moritz622 | phase-3, testing, priority-high |
| 116 | [Balance] Iterate on economy | User420-Bit | phase-3, balance, priority-high |
| 117 | [Iteration] Hotfix critical bugs | MaxeLBerger | phase-3, bugfix, priority-critical |
| 118 | [Iteration] Implement quick wins | Moritz622 | phase-3, gameplay, priority-medium |

</details>

<details>
<summary><strong>Week 16: Evaluation & Global Prep (4 issues)</strong></summary>

| # | Title | Assignee | Labels |
|---|-------|----------|--------|
| 119 | [Analytics] Softlaunch retrospective | MaxeLBerger | phase-3, analytics, priority-critical |
| 120 | [Decision] Go/No-Go for global launch | MaxeLBerger | phase-3, release, priority-critical |
| 121 | [Docs] Global launch planning | MaxeLBerger | phase-3, documentation, priority-high |
| 122 | [Release] iOS build preparation | MaxeLBerger | phase-3, release, priority-medium |

</details>

---

### Issue Distribution Summary

| Developer | Phase 0 | Phase 1 | Phase 2 | Phase 3 | Total |
|-----------|---------|---------|---------|---------|-------|
| **Max** (@MaxeLBerger) | 20 | 14 | 14 | 10 | **58** |
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

MaxeLBerger:  now fill each issues for pharell with exact instructions and vibe code friendly and easy understandable tasks

GitHub Copilot: Research Pharell's issues details

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/PRD/PRD_IdleMonsterEvolutionTD.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/Phasen/planning_Phase_0.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/Phasen/planning_Phase_1.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/team-plan/team-final-implementation#1-1), lines 1 to 300

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/Phasen/planning_Phase_3.md)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/Pharrel)

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/team-plan/team-final-implementation#300-300), lines 300 to 438

## Plan: Detailed Vibe-Coder-Friendly Issues for Pharell (@User420-Bit)

Below are all 29 issues assigned to Pharell with extremely detailed, step-by-step instructions written for a beginner who is new to Unity and vibe coding.

---

## Phase 0 Issues (16 issues)

---

### Issue #8: [Assets] Download and organize Kenney TD Kit

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `assets`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Download free game assets and organize them in our Unity project so the team can use them.

---

#### 📝 Step-by-Step Instructions

**Step 1: Download the Asset Pack**
1. Open your browser and go to: https://kenney.nl/assets/tower-defense-kit
2. Click the big **"Download"** button
3. Save the ZIP file to your Downloads folder
4. Extract (unzip) the file — you'll get a folder with images and files

**Step 2: Open Unity and Navigate to the Project**
1. Open Unity Hub
2. Open our project: `Idle-Monster-Evolution-TD`
3. Wait for Unity to load completely

**Step 3: Create the Folder Structure**
1. In the **Project** window (bottom of Unity), right-click on `Assets`
2. Create these folders by right-clicking → Create → Folder:
```
Assets/
  _Project/
    Art/
      Kenney/
        Tiles/
        Props/
        UI/
```

**Step 4: Import the Assets**
1. Open the extracted Kenney folder in Windows Explorer
2. Drag the image files into the correct Unity folders:
   - **Ground/Path tiles** → `Assets/_Project/Art/Kenney/Tiles/`
   - **Trees, rocks, decorations** → `Assets/_Project/Art/Kenney/Props/`
   - **Button/panel images** → `Assets/_Project/Art/Kenney/UI/`

**Step 5: Verify Everything Imported**
1. Click through each folder in Unity
2. You should see the images as little preview thumbnails
3. If they show as white squares, right-click → Reimport

---

#### ✅ Definition of Done
- [ ] Kenney TD Kit downloaded
- [ ] Folders created: `Assets/_Project/Art/Kenney/{Tiles,Props,UI}`
- [ ] All images organized in correct folders
- [ ] Assets visible in Unity Project window

---

#### 🆘 If You Get Stuck
- Can't unzip? Right-click the ZIP → "Extract All"
- Unity doesn't show images? Try restarting Unity
- Ask Max or Moritz in the daily standup!

---

---

### Issue #9: [Localization] Create LocalizationKeys constants

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `setup`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create a C# file with all the text keys we'll use in the game. This lets us easily translate the game later!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Script File**
1. In Unity, navigate to: `Assets/_Project/Scripts/Core/`
   - If this folder doesn't exist, create it!
2. Right-click → Create → C# Script
3. Name it exactly: `LocalizationKeys`
4. Wait for Unity to compile (bottom right shows a spinning icon)

**Step 2: Open the Script**
1. Double-click `LocalizationKeys.cs` to open it in your code editor
2. Delete everything inside the file

**Step 3: Copy This Code**
Replace everything with this:

```csharp
namespace IdleMonsterTD.Core
{
    /// <summary>
    /// All text keys used in the game for localization.
    /// Format: CATEGORY_SUBCATEGORY_ELEMENT
    /// </summary>
    public static class LocalizationKeys
    {
        // ══════════════════════════════════════════════════════
        // UI BUTTONS
        // ══════════════════════════════════════════════════════
        public const string UI_BUTTON_BATTLE = "UI_BUTTON_BATTLE";
        public const string UI_BUTTON_MONSTERS = "UI_BUTTON_MONSTERS";
        public const string UI_BUTTON_AFK = "UI_BUTTON_AFK";
        public const string UI_BUTTON_SUMMON = "UI_BUTTON_SUMMON";
        public const string UI_BUTTON_SHOP = "UI_BUTTON_SHOP";
        public const string UI_BUTTON_LEVELUP = "UI_BUTTON_LEVELUP";
        public const string UI_BUTTON_CLAIM = "UI_BUTTON_CLAIM";
        public const string UI_BUTTON_CLOSE = "UI_BUTTON_CLOSE";
        public const string UI_BUTTON_CONFIRM = "UI_BUTTON_CONFIRM";
        public const string UI_BUTTON_CANCEL = "UI_BUTTON_CANCEL";
        public const string UI_BUTTON_WATCH_AD = "UI_BUTTON_WATCH_AD";
        public const string UI_BUTTON_START_WAVE = "UI_BUTTON_START_WAVE";
        public const string UI_BUTTON_PAUSE = "UI_BUTTON_PAUSE";
        public const string UI_BUTTON_RESUME = "UI_BUTTON_RESUME";
        public const string UI_BUTTON_QUIT = "UI_BUTTON_QUIT";
        public const string UI_BUTTON_RETRY = "UI_BUTTON_RETRY";

        // ══════════════════════════════════════════════════════
        // HUD (Heads-Up Display during battle)
        // ══════════════════════════════════════════════════════
        public const string HUD_WAVE_COUNT = "HUD_WAVE_COUNT";           // "Wave {0}/{1}"
        public const string HUD_WAVE_CURRENT = "HUD_WAVE_CURRENT";       // "Wave {0}"
        public const string HUD_BASE_HP = "HUD_BASE_HP";                 // "HP: {0}/{1}"
        public const string HUD_GOLD = "HUD_GOLD";                       // "{0}"
        public const string HUD_SPEED_1X = "HUD_SPEED_1X";               // "1x"
        public const string HUD_SPEED_2X = "HUD_SPEED_2X";               // "2x"
        public const string HUD_SPEED_4X = "HUD_SPEED_4X";               // "4x"

        // ══════════════════════════════════════════════════════
        // MONSTER PANEL
        // ══════════════════════════════════════════════════════
        public const string MONSTER_LEVEL = "MONSTER_LEVEL";             // "Level {0}"
        public const string MONSTER_ATK = "MONSTER_ATK";                 // "ATK: {0}"
        public const string MONSTER_RANGE = "MONSTER_RANGE";             // "Range: {0}"
        public const string MONSTER_SPEED = "MONSTER_SPEED";             // "Speed: {0}"
        public const string MONSTER_RARITY_COMMON = "MONSTER_RARITY_COMMON";
        public const string MONSTER_RARITY_RARE = "MONSTER_RARITY_RARE";
        public const string MONSTER_RARITY_EPIC = "MONSTER_RARITY_EPIC";
        public const string MONSTER_RARITY_LEGENDARY = "MONSTER_RARITY_LEGENDARY";
        public const string MONSTER_EVOLUTION_NORMAL = "MONSTER_EVOLUTION_NORMAL";
        public const string MONSTER_EVOLUTION_ADVANCED = "MONSTER_EVOLUTION_ADVANCED";
        public const string MONSTER_EVOLUTION_ULTIMATE = "MONSTER_EVOLUTION_ULTIMATE";
        public const string MONSTER_UPGRADE_COST = "MONSTER_UPGRADE_COST"; // "Cost: {0} Gold"

        // ══════════════════════════════════════════════════════
        // AFK / IDLE SYSTEM
        // ══════════════════════════════════════════════════════
        public const string AFK_TITLE = "AFK_TITLE";                     // "Idle Rewards"
        public const string AFK_WELCOME_BACK = "AFK_WELCOME_BACK";       // "Welcome Back!"
        public const string AFK_OFFLINE_TIME = "AFK_OFFLINE_TIME";       // "You were offline for {0}"
        public const string AFK_GOLD_REWARD = "AFK_GOLD_REWARD";         // "+{0} Gold"
        public const string AFK_MATERIAL_REWARD = "AFK_MATERIAL_REWARD"; // "+{0} Evo Materials"
        public const string AFK_DOUBLE_REWARD = "AFK_DOUBLE_REWARD";     // "Watch ad for 2x rewards!"

        // ══════════════════════════════════════════════════════
        // GAME STATES
        // ══════════════════════════════════════════════════════
        public const string GAME_WON = "GAME_WON";                       // "Victory!"
        public const string GAME_LOST = "GAME_LOST";                     // "Defeat..."
        public const string WAVE_COMPLETE = "WAVE_COMPLETE";             // "Wave Complete!"
        public const string WAVE_INCOMING = "WAVE_INCOMING";             // "Wave Incoming!"

        // ══════════════════════════════════════════════════════
        // MONSTER NAMES (for our 3 starter monsters)
        // ══════════════════════════════════════════════════════
        public const string MONSTER_NAME_FLAME_IMP = "MONSTER_NAME_FLAME_IMP";
        public const string MONSTER_NAME_FROST_WISP = "MONSTER_NAME_FROST_WISP";
        public const string MONSTER_NAME_THUNDER_BEAST = "MONSTER_NAME_THUNDER_BEAST";

        // ══════════════════════════════════════════════════════
        // ENEMY NAMES
        // ══════════════════════════════════════════════════════
        public const string ENEMY_NAME_GOBLIN = "ENEMY_NAME_GOBLIN";
        public const string ENEMY_NAME_SCOUT = "ENEMY_NAME_SCOUT";
        public const string ENEMY_NAME_OGRE = "ENEMY_NAME_OGRE";

        // ══════════════════════════════════════════════════════
        // TUTORIAL / TOOLTIPS
        // ══════════════════════════════════════════════════════
        public const string TUTORIAL_PLACE_MONSTER = "TUTORIAL_PLACE_MONSTER";
        public const string TUTORIAL_START_WAVE = "TUTORIAL_START_WAVE";
        public const string TUTORIAL_UPGRADE_MONSTER = "TUTORIAL_UPGRADE_MONSTER";
        public const string TOOLTIP_MONSTER_SLOT = "TOOLTIP_MONSTER_SLOT";

        // ══════════════════════════════════════════════════════
        // TIME FORMATTING
        // ══════════════════════════════════════════════════════
        public const string TIME_HOURS = "TIME_HOURS";                   // "{0}h"
        public const string TIME_MINUTES = "TIME_MINUTES";               // "{0}m"
        public const string TIME_SECONDS = "TIME_SECONDS";               // "{0}s"
        public const string TIME_HOURS_MINUTES = "TIME_HOURS_MINUTES";   // "{0}h {1}m"
    }
}
```

**Step 4: Save the File**
1. Press `Ctrl + S` to save
2. Go back to Unity
3. Wait for Unity to compile (no errors in Console!)

---

#### ✅ Definition of Done
- [ ] `LocalizationKeys.cs` file created in `Assets/_Project/Scripts/Core/`
- [ ] All keys from the template are included
- [ ] No red errors in Unity Console
- [ ] File saved and committed to Git

---

#### 💡 Tips
- The `{0}` and `{1}` are placeholders for numbers (like "Wave 5/10")
- Later, we'll make actual translations that use these keys
- If you need to add a new key, follow the pattern: `CATEGORY_ELEMENT`

---

---

### Issue #10: [Input] Set up Input System action asset

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `setup`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create the input configuration so our game can detect mouse clicks AND touch input on phones.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Input Folder**
1. In Unity Project window, navigate to `Assets/_Project/`
2. Create folder: `Input`

**Step 2: Create the Input Actions Asset**
1. Right-click on the `Input` folder
2. Click: Create → Input Actions
3. Name it exactly: `GameInputActions`
4. Double-click it to open the Input Actions Editor

**Step 3: Create the "Gameplay" Action Map**
1. In the left panel, click the **"+"** button next to "Action Maps"
2. Name it: `Gameplay`

**Step 4: Add the "Point" Action**
1. With Gameplay selected, click **"+"** next to "Actions"
2. Name the action: `Point`
3. In the right panel, set **Action Type** to: `Value`
4. Set **Control Type** to: `Vector2`
5. Click **"+"** next to the Point action → Add Binding
6. Click the new binding, then in the right panel click **Path** dropdown
7. Search for and select: `Pointer/Position`

**Step 5: Add the "Click" Action**
1. Click **"+"** next to "Actions" again
2. Name the action: `Click`
3. In the right panel, set **Action Type** to: `Button`
4. Click **"+"** next to Click → Add Binding
5. Click **Path** → search and select: `Mouse/leftButton`
6. Click **"+"** next to Click → Add Binding (again for touch)
7. Click **Path** → search and select: `Touchscreen/primaryTouch/tap`

**Step 6: Add the "TouchPosition" Action (for mobile)**
1. Click **"+"** next to "Actions"
2. Name: `TouchPosition`
3. Set **Action Type** to: `Value`
4. Set **Control Type** to: `Vector2`
5. Add Binding → Path: `Touchscreen/primaryTouch/position`

**Step 7: Save and Generate C# Class**
1. Click **"Save Asset"** button (top of window)
2. Close the Input Actions window
3. In the Project window, click on `GameInputActions`
4. In the Inspector (right panel), check ✅ **"Generate C# Class"**
5. Click **Apply**
6. Unity will create `GameInputActions.cs` automatically!

---

#### ✅ Definition of Done
- [ ] `GameInputActions.inputactions` created in `Assets/_Project/Input/`
- [ ] Action Map "Gameplay" exists
- [ ] Actions created: Point, Click, TouchPosition
- [ ] "Generate C# Class" enabled
- [ ] `GameInputActions.cs` auto-generated
- [ ] No errors in Console

---

#### 🖼️ What It Should Look Like
```
Action Maps:         Actions:
[Gameplay]           Point         [Value, Vector2]
                       └─ Pointer/Position
                     Click         [Button]
                       ├─ Mouse/leftButton
                       └─ Touchscreen/primaryTouch/tap
                     TouchPosition [Value, Vector2]
                       └─ Touchscreen/primaryTouch/position
```

---

---

### Issue #12: [Monster] Create 3 starter monster configs

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #11 (Max creates MonsterConfigSO class first)

---

#### 🎯 Goal
Create the data files for our 3 starter monsters: **Flame Imp**, **Frost Wisp**, and **Thunder Beast**.

---

#### ⏳ Wait For
Max needs to finish Issue #11 first (creating the MonsterConfigSO class). Once he's done, he'll let you know!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Monsters Folder**
1. In Unity, navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Monsters`

**Step 2: Create Flame Imp Config**
1. Right-click in `Monsters` folder
2. Click: Create → IdleMonsterTD → Monster Config (or similar menu Max created)
3. Name it: `FlameImp_Config`
4. Click on it and fill in the Inspector:

```
Display Name:     Flame Imp
Rarity:           Common
Evolution Stage:  Normal

═══ STATS ═══
ATK:              25
Range:            3.0
Attack Speed:     1.5  (attacks per second)

═══ TARGETING ═══
Targeting Priority: Nearest

═══ DESCRIPTION ═══
Description: "A fiery little imp that shoots rapid fireballs. Great for consistent damage!"

═══ VISUALS (leave empty for now) ═══
Icon:             (none yet)
Prefab:           (none yet)
Projectile:       (none yet)
```

**Step 3: Create Frost Wisp Config**
1. Right-click in `Monsters` folder → Create → Monster Config
2. Name it: `FrostWisp_Config`
3. Fill in the Inspector:

```
Display Name:     Frost Wisp
Rarity:           Common
Evolution Stage:  Normal

═══ STATS ═══
ATK:              10
Range:            5.0  (long range!)
Attack Speed:     0.8

═══ TARGETING ═══
Targeting Priority: First

═══ SPECIAL ═══
Slow Percentage:  30   (slows enemies by 30%)
Slow Duration:    2.0  (seconds)

═══ DESCRIPTION ═══
Description: "A chilly spirit that freezes enemies, slowing their movement. Perfect for crowd control!"
```

**Step 4: Create Thunder Beast Config**
1. Right-click in `Monsters` folder → Create → Monster Config
2. Name it: `ThunderBeast_Config`
3. Fill in the Inspector:

```
Display Name:     Thunder Beast
Rarity:           Rare
Evolution Stage:  Normal

═══ STATS ═══
ATK:              18
Range:            2.5  (short range)
Attack Speed:     0.6

═══ TARGETING ═══
Targeting Priority: Strongest

═══ SPECIAL ═══
Chain Targets:    3    (lightning jumps to 3 enemies)
Chain Damage Falloff: 0.7  (each jump deals 70% of previous)

═══ DESCRIPTION ═══
Description: "A mighty beast that unleashes chain lightning, hitting multiple enemies at once!"
```

---

#### 🎮 Why These Stats?

| Monster | Role | Why These Stats |
|---------|------|-----------------|
| **Flame Imp** | DPS | High attack speed (1.5) means lots of hits. Medium range (3.0) is safe. Good against all enemy types. |
| **Frost Wisp** | Support | Low damage but LONG range (5.0) and slows enemies! Helps other monsters kill them. |
| **Thunder Beast** | AoE | Hits 3 enemies at once! Lower attack speed but great when enemies group up. |

---

#### ✅ Definition of Done
- [ ] `FlameImp_Config.asset` created with correct stats
- [ ] `FrostWisp_Config.asset` created with correct stats
- [ ] `ThunderBeast_Config.asset` created with correct stats
- [ ] All 3 configs are in `Assets/_Project/ScriptableObjects/Monsters/`
- [ ] Rarity colors: Flame Imp & Frost Wisp = Common, Thunder Beast = Rare

---

---

### Issue #14: [Enemy] Create 3 enemy type configs

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #13 (Max creates EnemyConfigSO class first)

---

#### 🎯 Goal
Create the data files for our 3 enemy types: **Goblin**, **Scout**, and **Ogre**.

---

#### ⏳ Wait For
Max needs to finish Issue #13 first (creating the EnemyConfigSO class).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Enemies Folder**
1. Navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Enemies`

**Step 2: Create Goblin Config**
1. Right-click in `Enemies` folder
2. Click: Create → IdleMonsterTD → Enemy Config
3. Name it: `Goblin_Config`
4. Fill in the Inspector:

```
Display Name:     Goblin
Enemy Type:       Standard

═══ STATS ═══
Max HP:           100
Move Speed:       1.0  (normal speed, this is the baseline)
Gold Reward:      10
Evo Material Drop: 0   (common enemies don't drop materials)

═══ DESCRIPTION ═══
Description: "A standard goblin raider. Nothing special, but they come in numbers!"
```

**Step 3: Create Scout Config**
1. Create new Enemy Config, name: `Scout_Config`
2. Fill in:

```
Display Name:     Scout
Enemy Type:       Fast

═══ STATS ═══
Max HP:           50   (half of Goblin - fragile!)
Move Speed:       2.0  (TWICE as fast!)
Gold Reward:      15   (worth more because harder to hit)
Evo Material Drop: 0

═══ DESCRIPTION ═══
Description: "A nimble scout that zips through your defenses. Fast but fragile!"
```

**Step 4: Create Ogre Config**
1. Create new Enemy Config, name: `Ogre_Config`
2. Fill in:

```
Display Name:     Ogre
Enemy Type:       Tanky

═══ STATS ═══
Max HP:           300  (THREE times the Goblin!)
Move Speed:       0.5  (half speed - slow and steady)
Gold Reward:      25   (worth the most)
Evo Material Drop: 1   (rare chance for evo materials!)

═══ DESCRIPTION ═══
Description: "A massive ogre that soaks up damage. Slow but nearly unstoppable!"
```

---

#### 🎮 Enemy Type Strategy

| Enemy | HP | Speed | Counter Strategy |
|-------|-----|-------|-----------------|
| **Goblin** | 100 | 1.0x | Standard target. Any monster works! |
| **Scout** | 50 | 2.0x | Use Frost Wisp to slow them down first! |
| **Ogre** | 300 | 0.5x | Focus fire with Flame Imp's fast attacks! |

---

#### ✅ Definition of Done
- [ ] `Goblin_Config.asset` created (100 HP, 1.0 speed, 10 gold)
- [ ] `Scout_Config.asset` created (50 HP, 2.0 speed, 15 gold)
- [ ] `Ogre_Config.asset` created (300 HP, 0.5 speed, 25 gold)
- [ ] All 3 configs are in `Assets/_Project/ScriptableObjects/Enemies/`

---

---

### Issue #16: [Wave] Create 10 wave configs

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #15 (Max creates WaveConfigSO class first)

---

#### 🎯 Goal
Create 10 wave configurations that define what enemies spawn in each wave. The difficulty should gradually increase!

---

#### ⏳ Wait For
Max needs to finish Issue #15 first (creating the WaveConfigSO class).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Waves Folder**
1. Navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Waves`

**Step 2: Create All 10 Wave Configs**

Create each wave config and fill in these values:

---

**Wave 1 - Tutorial Wave**
```
Filename: Wave_01.asset
Wave Number: 1
Delay Before Wave: 3.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 5
    Spawn Interval: 2.0 seconds

Bonus Gold: 20
```

---

**Wave 2 - Getting Started**
```
Filename: Wave_02.asset
Wave Number: 2
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 8
    Spawn Interval: 1.5 seconds

Bonus Gold: 30
```

---

**Wave 3 - More Goblins**
```
Filename: Wave_03.asset
Wave Number: 3
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 12
    Spawn Interval: 1.2 seconds

Bonus Gold: 40
```

---

**Wave 4 - Introducing Scouts**
```
Filename: Wave_04.asset
Wave Number: 4
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 8
    Spawn Interval: 1.5 seconds
  - Enemy: Scout_Config
    Count: 4
    Spawn Interval: 2.0 seconds

Bonus Gold: 50
```

---

**Wave 5 - Speed Challenge**
```
Filename: Wave_05.asset
Wave Number: 5
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 6
    Spawn Interval: 1.5 seconds
  - Enemy: Scout_Config
    Count: 8
    Spawn Interval: 1.0 seconds

Bonus Gold: 60
```

---

**Wave 6 - Scout Rush**
```
Filename: Wave_06.asset
Wave Number: 6
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Scout_Config
    Count: 15
    Spawn Interval: 0.8 seconds

Bonus Gold: 75
```

---

**Wave 7 - Here Comes the Ogre**
```
Filename: Wave_07.asset
Wave Number: 7
Delay Before Wave: 6.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 10
    Spawn Interval: 1.0 seconds
  - Enemy: Scout_Config
    Count: 5
    Spawn Interval: 1.5 seconds
  - Enemy: Ogre_Config
    Count: 2
    Spawn Interval: 4.0 seconds

Bonus Gold: 100
```

---

**Wave 8 - Mixed Assault**
```
Filename: Wave_08.asset
Wave Number: 8
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 12
    Spawn Interval: 0.8 seconds
  - Enemy: Scout_Config
    Count: 8
    Spawn Interval: 1.0 seconds
  - Enemy: Ogre_Config
    Count: 3
    Spawn Interval: 3.0 seconds

Bonus Gold: 120
```

---

**Wave 9 - Pre-Boss Chaos**
```
Filename: Wave_09.asset
Wave Number: 9
Delay Before Wave: 5.0 seconds

Enemies:
  - Enemy: Goblin_Config
    Count: 15
    Spawn Interval: 0.6 seconds
  - Enemy: Scout_Config
    Count: 10
    Spawn Interval: 0.8 seconds
  - Enemy: Ogre_Config
    Count: 4
    Spawn Interval: 2.5 seconds

Bonus Gold: 150
```

---

**Wave 10 - BOSS WAVE** 🔥
```
Filename: Wave_10.asset
Wave Number: 10
Delay Before Wave: 8.0 seconds

Enemies:
  - Enemy: Ogre_Config
    Count: 8
    Spawn Interval: 2.0 seconds
  - Enemy: Scout_Config
    Count: 10
    Spawn Interval: 1.0 seconds
  - Enemy: Goblin_Config
    Count: 10
    Spawn Interval: 0.8 seconds

Bonus Gold: 250
```

---

#### 📊 Wave Difficulty Summary

| Wave | Goblins | Scouts | Ogres | Total Enemies | Difficulty |
|------|---------|--------|-------|---------------|------------|
| 1 | 5 | 0 | 0 | 5 | ⭐ |
| 2 | 8 | 0 | 0 | 8 | ⭐ |
| 3 | 12 | 0 | 0 | 12 | ⭐⭐ |
| 4 | 8 | 4 | 0 | 12 | ⭐⭐ |
| 5 | 6 | 8 | 0 | 14 | ⭐⭐ |
| 6 | 0 | 15 | 0 | 15 | ⭐⭐⭐ |
| 7 | 10 | 5 | 2 | 17 | ⭐⭐⭐ |
| 8 | 12 | 8 | 3 | 23 | ⭐⭐⭐⭐ |
| 9 | 15 | 10 | 4 | 29 | ⭐⭐⭐⭐ |
| 10 | 10 | 10 | 8 | 28 | ⭐⭐⭐⭐⭐ |

---

#### ✅ Definition of Done
- [ ] All 10 wave configs created (`Wave_01.asset` through `Wave_10.asset`)
- [ ] Each wave references the correct enemy configs
- [ ] Enemy counts and spawn intervals match the table
- [ ] Bonus gold increases with wave difficulty
- [ ] All files in `Assets/_Project/ScriptableObjects/Waves/`

---

---

### Issue #17: [Events] Create GameEvent SO instances

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #6 (Max creates GameEvent base class first)

---

#### 🎯 Goal
Create the event ScriptableObjects that let different parts of the game communicate without being directly connected.

---

#### ⏳ Wait For
Max needs to finish Issue #6 first (creating the GameEvent base class).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Events Folder**
1. Navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Events`

**Step 2: Create Each Event**

For each event below:
1. Right-click in `Events` folder → Create → IdleMonsterTD → Game Event
2. Name it exactly as shown

**Events to Create:**

| Filename | Purpose |
|----------|---------|
| `OnWaveStart.asset` | Fires when a new wave begins |
| `OnWaveComplete.asset` | Fires when all enemies in a wave are dead |
| `OnGameWon.asset` | Fires when player completes all 10 waves |
| `OnGameLost.asset` | Fires when base HP reaches 0 |
| `OnEnemyKilled.asset` | Fires each time an enemy dies |
| `OnEnemyReachedBase.asset` | Fires when an enemy reaches the base |
| `OnMonsterPlaced.asset` | Fires when player places a monster |
| `OnMonsterLevelUp.asset` | Fires when a monster levels up |
| `OnGoldChanged.asset` | Fires when gold amount changes |
| `OnGamePaused.asset` | Fires when game is paused |
| `OnGameResumed.asset` | Fires when game is resumed |
| `OnSpeedChanged.asset` | Fires when game speed changes (1x/2x) |

---

#### 🤔 What Are GameEvents?

Think of them like a **radio broadcast**:
- Some code **raises** the event (broadcasts)
- Other code **listens** for the event
- They don't need to know about each other!

**Example:**
- When an enemy dies, `EnemyHealth` raises `OnEnemyKilled`
- The `GoldController` listens and adds gold
- The `WaveManager` listens and checks if wave is complete
- The `ScoreTracker` listens and updates kill count

---

#### ✅ Definition of Done
- [ ] All 12 GameEvent assets created
- [ ] All files are in `Assets/_Project/ScriptableObjects/Events/`
- [ ] Files are named exactly as shown (no typos!)

---

---

### Issue #18: [Variables] Create variable SO instances

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `data`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #6 (Max creates FloatVariable/IntVariable base classes first)

---

#### 🎯 Goal
Create the variable ScriptableObjects that store game data (like gold, HP, wave number) and let the UI automatically update when they change.

---

#### ⏳ Wait For
Max needs to finish Issue #6 first (creating the variable base classes).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Variables Folder**
1. Navigate to: `Assets/_Project/ScriptableObjects/`
2. Create folder: `Variables`

**Step 2: Create Float Variables**

Right-click → Create → IdleMonsterTD → Float Variable

| Filename | Initial Value | Description |
|----------|---------------|-------------|
| `BaseHP.asset` | 100 | The player's base health |
| `BaseMaxHP.asset` | 100 | Maximum base health |
| `GameSpeed.asset` | 1.0 | Current game speed (1.0 or 2.0) |

**Step 3: Create Int Variables**

Right-click → Create → IdleMonsterTD → Int Variable

| Filename | Initial Value | Description |
|----------|---------------|-------------|
| `CurrentGold.asset` | 0 | Player's current gold |
| `CurrentWave.asset` | 1 | Current wave number |
| `MaxWaves.asset` | 10 | Total number of waves |
| `EnemiesAlive.asset` | 0 | Enemies currently on the map |
| `TotalKills.asset` | 0 | Enemies killed this run |

---

#### 🤔 What Are Variable SOs?

They're like **shared containers** for data:
- The game logic writes to them: `CurrentGold.Value = 150;`
- The UI reads from them and updates automatically
- No need to find objects or call methods!

**Example Flow:**
1. Enemy dies → EnemyHealth adds gold: `CurrentGold.Value += 10;`
2. CurrentGold raises its "OnChanged" event
3. The HUD's gold display is listening and updates the text

---

#### ✅ Definition of Done
- [ ] 3 Float Variables created: `BaseHP`, `BaseMaxHP`, `GameSpeed`
- [ ] 5 Int Variables created: `CurrentGold`, `CurrentWave`, `MaxWaves`, `EnemiesAlive`, `TotalKills`
- [ ] Initial values set correctly
- [ ] All files in `Assets/_Project/ScriptableObjects/Variables/`

---

---

### Issue #19: [Map] Set up battle map scene

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `assets`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #8 (Assets organized first)

---

#### 🎯 Goal
Create the battle scene with an S-shaped path, waypoints for enemies to follow, and slots where players can place monsters.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Scene**
1. In Unity, go to: File → New Scene → Basic (Built-in)
2. Save it: File → Save As
3. Save to: `Assets/_Project/Scenes/BattleScene.unity`

**Step 2: Set Up the Camera**
1. Select the **Main Camera** in Hierarchy
2. In Inspector, set:
   - Position: `X: 0, Y: 10, Z: -8`
   - Rotation: `X: 50, Y: 0, Z: 0`
   - Projection: `Orthographic`
   - Size: `8`

**Step 3: Create the Ground**
1. Right-click in Hierarchy → 3D Object → Plane
2. Name it: `Ground`
3. Set Position: `X: 0, Y: 0, Z: 0`
4. Set Scale: `X: 2, Y: 1, Z: 2` (makes it 20x20 units)
5. Create a green material: Assets → Create → Material → name it `GroundMaterial`
6. Set the color to grass green, drag onto the Ground

**Step 4: Create the S-Shaped Path**

We'll use cubes to visualize the path. Later we can replace with Kenney tiles!

1. Create an empty: Hierarchy → Create Empty → name it `Path`
2. Create a cube: 3D Object → Cube, name it `PathTile`
3. Set Scale: `X: 1, Y: 0.1, Z: 1`
4. Create brown material, apply it
5. Duplicate the cube (Ctrl+D) and arrange in an S-shape:

```
  Path Layout (Top View):
  
  START ─────────┐
  [Spawn]        │
                 │
  ┌──────────────┘
  │
  │
  └──────────────┐
                 │
                 │  
  ┌──────────────┘
  │
  │ [BASE]
  END ──────────
```

Place path tiles approximately at these positions:
```
(0, 0, 8)   → Start / Spawn Point
(0, 0, 6)
(2, 0, 6)
(4, 0, 6)
(4, 0, 4)
(4, 0, 2)
(2, 0, 2)
(0, 0, 2)
(-2, 0, 2)
(-2, 0, 0)
(-2, 0, -2)
(0, 0, -2)
(2, 0, -2)
(2, 0, -4)
(0, 0, -4)  → End / Base
```

**Step 5: Create Waypoints**

Waypoints are invisible markers that tell enemies where to go.

1. Create an empty: `Waypoints` (parent object)
2. Create child empties, name them `Waypoint_01` through `Waypoint_14`
3. Position them at the CENTER of each path tile (use positions from Step 4)
4. Add a small Gizmo so we can see them in editor:
   - Select a waypoint
   - Click the cube icon in Inspector (top left) → choose a color

**Step 6: Create Monster Placement Slots**

1. Create an empty: `MonsterSlots` (parent object)
2. Create 6 child objects: `Slot_01` through `Slot_06`
3. Position them NEXT TO the path (not on it!):
```
Slot_01: (2, 0, 4)    ← top right corner
Slot_02: (-2, 0, 4)   ← top left  
Slot_03: (2, 0, 0)    ← middle right
Slot_04: (-4, 0, 0)   ← middle left
Slot_05: (4, 0, -2)   ← bottom right
Slot_06: (0, 0, -6)   ← near the base
```
4. Add a visual indicator: Create a transparent circle sprite or a small platform for each slot

**Step 7: Create Spawn Point and Base**

1. Create an empty at path start: `SpawnPoint` at position `(0, 0, 8)`
2. Create an empty at path end: `Base` at position `(0, 0, -4)`
3. Add visuals:
   - For SpawnPoint: Add a portal-like effect or colored sphere
   - For Base: Add a castle/tower model or colored cube

**Step 8: Add Lighting**
1. Hierarchy → Light → Directional Light (if not already there)
2. Set Rotation: `X: 50, Y: -30, Z: 0`
3. Set Color to warm white
4. Set Intensity: `1`

---

#### 🗺️ Final Scene Structure

```
BattleScene
├── Main Camera
├── Directional Light
├── Ground
├── Path
│   ├── PathTile (x14)
│   └── ...
├── Waypoints
│   ├── Waypoint_01
│   ├── Waypoint_02
│   └── ... (through 14)
├── MonsterSlots
│   ├── Slot_01
│   ├── Slot_02
│   └── ... (through 06)
├── SpawnPoint
└── Base
```

---

#### ✅ Definition of Done
- [ ] `BattleScene.unity` created and saved
- [ ] Camera positioned for top-down view
- [ ] S-shaped path visible (14 tiles)
- [ ] 14 waypoints positioned along path
- [ ] 6 monster placement slots created
- [ ] SpawnPoint and Base objects created
- [ ] Scene runs without errors

---

---

### Issue #28: [UI] Create Hub panel prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create the main menu UI with 4 big buttons: Battle, Monsters, AFK-Chest, and Summon.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the UI Folder**
1. Navigate to: `Assets/_Project/Prefabs/`
2. Create folder: `UI`

**Step 2: Create a UI Scene for Testing**
1. File → New Scene → Basic (Built-in)
2. Save as: `Assets/_Project/Scenes/HubScene.unity`

**Step 3: Create Canvas**
1. Hierarchy → UI → Canvas
2. Select the Canvas, in Inspector:
   - Canvas Scaler → UI Scale Mode: `Scale With Screen Size`
   - Reference Resolution: `1080 x 1920` (portrait mobile)
   - Match Width Or Height: `0.5`

**Step 4: Create the Hub Panel**
1. Right-click Canvas → UI → Panel
2. Name it: `HubPanel`
3. Set color to semi-transparent dark: `(0, 0, 0, 200)`

**Step 5: Create the Button Layout**
1. Right-click HubPanel → UI → Vertical Layout Group (add as component)
2. Settings:
   - Padding: `50` all sides
   - Spacing: `30`
   - Child Alignment: `Middle Center`
   - Child Force Expand: Width ✓, Height ✗

**Step 6: Create the Battle Button**
1. Right-click HubPanel → UI → Button - TextMeshPro
2. Name it: `Button_Battle`
3. Set the button size: Width `600`, Height `120`
4. Select the child text object (TMP)
5. Set text: `Battle`
6. Set font size: `48`
7. Set font style: `Bold`
8. Set color: `White`

**Step 7: Style the Battle Button**
1. Select `Button_Battle`
2. Image component → Color: `(80, 180, 80, 255)` (green)
3. Or use a Kenney button sprite from your assets!

**Step 8: Duplicate for Other Buttons**

Duplicate `Button_Battle` three times (Ctrl+D) and modify:

| Button Name | Text | Color (RGB) |
|-------------|------|-------------|
| `Button_Battle` | Battle | Green (80, 180, 80) |
| `Button_Monsters` | Monsters | Blue (80, 120, 200) |
| `Button_AFK` | AFK Rewards | Orange (220, 160, 60) |
| `Button_Summon` | Summon | Purple (150, 80, 180) |

**Step 9: Add a Title**
1. Right-click HubPanel → UI → Text - TextMeshPro
2. Name it: `Title`
3. Set text: `Idle Monster TD`
4. Font size: `64`
5. Alignment: Center
6. Drag it ABOVE the buttons in the hierarchy (so it appears at top)

**Step 10: Create the Prefab**
1. Drag `HubPanel` from Hierarchy to `Assets/_Project/Prefabs/UI/`
2. This creates the prefab!
3. You'll see it turn blue in the Hierarchy

---

#### 🖼️ What It Should Look Like

```
┌─────────────────────────────┐
│                             │
│      IDLE MONSTER TD        │
│                             │
│   ┌───────────────────┐     │
│   │      BATTLE       │     │
│   └───────────────────┘     │
│                             │
│   ┌───────────────────┐     │
│   │     MONSTERS      │     │
│   └───────────────────┘     │
│                             │
│   ┌───────────────────┐     │
│   │    AFK REWARDS    │     │
│   └───────────────────┘     │
│                             │
│   ┌───────────────────┐     │
│   │      SUMMON       │     │
│   └───────────────────┘     │
│                             │
└─────────────────────────────┘
```

---

#### ✅ Definition of Done
- [ ] `HubPanel.prefab` created in `Assets/_Project/Prefabs/UI/`
- [ ] Canvas configured for mobile (1080x1920)
- [ ] 4 buttons with correct names and colors
- [ ] Title text "Idle Monster TD"
- [ ] Buttons are properly spaced and sized
- [ ] No code attached (layout only!)

---

---

### Issue #29: [UI] Create HUD prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-high`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create the in-game battle HUD showing: wave counter, base HP bar, gold display, and speed toggle.

---

#### 📝 Step-by-Step Instructions

**Step 1: Open BattleScene**
1. Open: `Assets/_Project/Scenes/BattleScene.unity`
2. Add a Canvas if there isn't one: Hierarchy → UI → Canvas
3. Configure Canvas Scaler for mobile (same as Issue #28)

**Step 2: Create the HUD Container**
1. Right-click Canvas → UI → Panel
2. Name it: `BattleHUD`
3. Anchor to top: Anchor Presets (hold Alt) → top-stretch
4. Set Height: `150`
5. Set Color: semi-transparent black `(0, 0, 0, 180)`

**Step 3: Create Wave Counter (Top Left)**
1. Right-click BattleHUD → UI → Text - TextMeshPro
2. Name: `WaveCounter`
3. Anchor: Top-Left
4. Position: `X: 20, Y: -20` from anchor
5. Size: `200 x 60`
6. Text: `Wave 1/10`
7. Font Size: `36`
8. Alignment: Left

**Step 4: Create Gold Display (Top Right)**
1. Create horizontal layout: Right-click BattleHUD → Create Empty
2. Name: `GoldDisplay`
3. Anchor: Top-Right
4. Position: `X: -20, Y: -20` from anchor
5. Add component: Horizontal Layout Group
6. Add child Image (for gold coin icon): `GoldIcon`
   - Size: 40x40
   - Use a coin sprite from Kenney or a yellow circle
7. Add child TextMeshPro: `GoldText`
   - Text: `0`
   - Font Size: `36`
   - Alignment: Right

**Step 5: Create HP Bar (Top Center)**
1. Right-click BattleHUD → UI → Slider
2. Name: `HPBar`
3. Anchor: Top-Center
4. Position: `X: 0, Y: -60`
5. Size: `400 x 40`
6. Delete the "Handle Slide Area" child (we don't need it)
7. Configure:
   - Background: Dark red `(100, 30, 30)`
   - Fill: Bright red `(220, 50, 50)`
   - Interactable: ✗ (uncheck - player can't drag it)
8. Add HP text on top:
   - Create TextMeshPro child
   - Name: `HPText`
   - Text: `100 / 100`
   - Font Size: `24`
   - Center over the bar

**Step 6: Create Speed Toggle (Top Right, below gold)**
1. Right-click BattleHUD → UI → Button - TextMeshPro
2. Name: `SpeedToggle`
3. Anchor: Top-Right
4. Position: `X: -20, Y: -80`
5. Size: `80 x 50`
6. Text: `1x`
7. Font Size: `28`
8. Color: Light blue background

**Step 7: Create Prefab**
1. Drag `BattleHUD` to `Assets/_Project/Prefabs/UI/`

---

#### 🖼️ What It Should Look Like

```
┌────────────────────────────────────────────────────┐
│ Wave 1/10        [████████████] 100/100    🪙 150 │
│                      HP Bar               [1x]    │
└────────────────────────────────────────────────────┘
```

---

#### ✅ Definition of Done
- [ ] `BattleHUD.prefab` created in `Assets/_Project/Prefabs/UI/`
- [ ] Wave counter (top left)
- [ ] HP bar (top center) with HP text
- [ ] Gold display with icon (top right)
- [ ] Speed toggle button (top right)
- [ ] All anchored correctly for mobile
- [ ] No code attached (layout only!)

---

---

### Issue #30: [UI] Create Monster list panel prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create a scrollable panel that shows all the player's monsters as cards.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Panel**
1. In HubScene, right-click Canvas → UI → Panel
2. Name: `MonsterListPanel`
3. Stretch to fill most of screen (leave room for close button)
4. Color: Dark semi-transparent background

**Step 2: Create Header**
1. Add TextMeshPro at top: "Your Monsters"
2. Font size: 48
3. Add Close button (X) in top-right corner

**Step 3: Create Scroll View**
1. Right-click MonsterListPanel → UI → Scroll View
2. Name: `MonsterScrollView`
3. Anchor/stretch below header
4. Only enable Vertical scrolling

**Step 4: Set Up Grid Layout**
1. Find the `Content` child inside Scroll View
2. Add component: Grid Layout Group
3. Settings:
   - Cell Size: `200 x 260`
   - Spacing: `20, 20`
   - Start Axis: Horizontal
   - Constraint: Fixed Column Count
   - Constraint Count: `4` (or 3 for phone)
4. Add component: Content Size Fitter
   - Vertical Fit: Preferred Size

**Step 5: Create Monster Card Prefab**
1. Right-click Content → UI → Image
2. Name: `MonsterCard`
3. Size: 200 x 260
4. Add children:
   - `CardBackground` (Image) - full size, colored by rarity
   - `MonsterIcon` (Image) - 140x140, centered upper portion
   - `MonsterName` (TextMeshPro) - below icon, font 20
   - `LevelText` (TextMeshPro) - below name, font 16, "Lv. 1"
   - `RarityBorder` (Image) - outline, colored by rarity
5. Drag MonsterCard to prefabs: `Assets/_Project/Prefabs/UI/MonsterCard.prefab`

**Step 6: Create the Panel Prefab**
1. Drag `MonsterListPanel` to `Assets/_Project/Prefabs/UI/`

---

#### 🖼️ Monster Card Layout

```
┌──────────────────┐
│ ┌──────────────┐ │
│ │              │ │
│ │   [ICON]     │ │
│ │              │ │
│ └──────────────┘ │
│                  │
│   Flame Imp      │
│     Lv. 5        │
│                  │
└──────────────────┘
  (colored border)
```

---

#### ✅ Definition of Done
- [ ] `MonsterListPanel.prefab` created
- [ ] `MonsterCard.prefab` created
- [ ] Scroll view works correctly
- [ ] Grid layout shows cards in rows
- [ ] Close button in header

---

---

### Issue #31: [UI] Create Monster detail panel prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create a detail view that shows when you tap a monster card - displays stats, level-up button, and evolution info.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Panel**
1. Right-click Canvas → UI → Panel
2. Name: `MonsterDetailPanel`
3. Make it slightly smaller than full screen (like a popup)
4. Add dark overlay behind it (separate panel, nearly transparent)

**Step 2: Create Layout**

```
┌────────────────────────────────────────────────────┐
│ ┌────┐                                        [X] │
│ │    │     FLAME IMP                              │
│ │ICON│     ⭐ Common                              │
│ │    │                                            │
│ └────┘                                            │
├────────────────────────────────────────────────────┤
│                                                    │
│  ATK:    25      ████████████░░░                  │
│  Range:  3.0     ████████░░░░░░░                  │
│  Speed:  1.5     ██████████████░                  │
│                                                    │
├────────────────────────────────────────────────────┤
│  Level: 5                                          │
│  ┌─────────────────────────────────┐              │
│  │      LEVEL UP (100 Gold)        │              │
│  └─────────────────────────────────┘              │
│                                                    │
├────────────────────────────────────────────────────┤
│  Evolution: Normal → Advanced                      │
│  Requirements: Level 20, 50 Evo Materials          │
└────────────────────────────────────────────────────┘
```

**Step 3: Build the Elements**

1. **Header Section:**
   - Monster Icon (150x150)
   - Monster Name (TextMeshPro, size 36)
   - Rarity indicator (stars or text)
   - Close button

2. **Stats Section:**
   - For each stat (ATK, Range, Speed):
     - Label (TextMeshPro)
     - Value (TextMeshPro)
     - Progress bar (Slider or filled Image)

3. **Level-Up Section:**
   - Current level display
   - Level-Up button with cost text
   - Gold icon next to cost

4. **Evolution Section:**
   - Current → Next evolution preview
   - Requirements text
   - (Evolve button for later)

**Step 4: Create Prefab**
1. Drag `MonsterDetailPanel` to `Assets/_Project/Prefabs/UI/`

---

#### ✅ Definition of Done
- [ ] `MonsterDetailPanel.prefab` created
- [ ] Monster icon, name, rarity display
- [ ] Stat bars for ATK, Range, Speed
- [ ] Level display and Level-Up button
- [ ] Evolution preview section
- [ ] Close button works

---

---

### Issue #32: [UI] Create AFK reward popup prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `ui`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create the popup that appears when you open the game showing how much you earned while away!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Popup**
1. Right-click Canvas → UI → Panel
2. Name: `AFKRewardPopup`
3. Make it a centered popup (about 800x600)
4. Add dark overlay behind (full screen, semi-transparent)

**Step 2: Create Layout**

```
┌────────────────────────────────────────────────┐
│                                                │
│            🌙 WELCOME BACK! 🌙                │
│                                                │
│         You were offline for                   │
│              4h 32m                            │
│                                                │
│  ┌──────────────────────────────────────────┐  │
│  │  🪙  +1,250 Gold                         │  │
│  │  💎  +15 Evo Materials                   │  │
│  └──────────────────────────────────────────┘  │
│                                                │
│  ┌──────────────────────────────────────────┐  │
│  │              CLAIM                        │  │
│  └──────────────────────────────────────────┘  │
│                                                │
│  ┌──────────────────────────────────────────┐  │
│  │      📺 Watch Ad for 2x (optional)       │  │
│  └──────────────────────────────────────────┘  │
│                                                │
└────────────────────────────────────────────────┘
```

**Step 3: Build the Elements**

1. **Title:** "Welcome Back!" with moon emojis or decorative icons
2. **Offline Time:** "You were offline for {time}"
3. **Rewards Box:**
   - Vertical layout with reward rows
   - Each row: Icon + Amount text
   - Gold row, Evo Materials row
4. **Claim Button:**
   - Big, green, prominent
   - Text: "CLAIM"
5. **Watch Ad Button (optional):**
   - Smaller, secondary style
   - Text: "Watch Ad for 2x"
   - (Can be hidden initially)

**Step 4: Create Prefab**
1. Drag `AFKRewardPopup` to `Assets/_Project/Prefabs/UI/`

---

#### ✅ Definition of Done
- [ ] `AFKRewardPopup.prefab` created
- [ ] Title and welcome message
- [ ] Offline time display
- [ ] Reward list with icons
- [ ] Claim button (big and green)
- [ ] Optional Watch Ad button
- [ ] Centered popup with overlay

---

---

### Issue #33: [Art] Create placeholder monster/enemy visuals

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `assets`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 🎯 Goal
Create simple colored shapes to represent our monsters and enemies until we have real art.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Materials Folder**
1. Navigate to: `Assets/_Project/Art/`
2. Create folder: `Materials`

**Step 2: Create Monster Materials**

Create a material for each monster (Create → Material):

| Material Name | Color (RGB) | Emission |
|---------------|-------------|----------|
| `Mat_FlameImp` | Red (220, 60, 60) | Orange glow |
| `Mat_FrostWisp` | Blue (80, 180, 255) | Light blue glow |
| `Mat_ThunderBeast` | Yellow (255, 220, 50) | Yellow glow |

For emission:
1. Check "Emission"
2. Set Emission color slightly brighter than base

**Step 3: Create Enemy Materials**

| Material Name | Color (RGB) |
|---------------|-------------|
| `Mat_Goblin` | Green (60, 140, 60) |
| `Mat_Scout` | Light Green (100, 200, 100) |
| `Mat_Ogre` | Dark Green (30, 80, 30) |

**Step 4: Create Monster Prefabs**

1. Navigate to: `Assets/_Project/Prefabs/Monsters/`
2. Create each monster:

**Flame Imp:**
1. Create Sphere (GameObject → 3D Object → Sphere)
2. Scale: `(0.8, 0.8, 0.8)`
3. Apply `Mat_Flame

MaxeLBerger: continue, we stopped at issue 33 for pharrel.

GitHub Copilot: ## Plan: Pharell's Detailed Issues (Continued from #33)

Continuing with beginner-friendly, step-by-step instructions for Pharell's remaining issues.

---

## Phase 0 — Week 4: Balance

### Issue #45: [Balance] Tune wave difficulty

```markdown
## 🎯 Goal
Play the game and adjust enemy numbers to make waves feel fun and balanced.

## 📋 Prerequisites
- ✅ Game must be playable (all systems working)
- ✅ All 10 WaveConfigSO files exist
- ✅ You can start a battle and play through waves

## 📝 Step-by-Step Instructions

### Step 1: Play the game 3 times and take notes
1. **Open Unity** and press Play
2. **Start a battle** from the Hub
3. **Play all 10 waves** (or as far as you can)
4. **Write down** for each wave:
   - Was it too easy? (enemies die instantly)
   - Was it too hard? (too many enemies, base destroyed)
   - Was it boring? (waiting too long between enemies)

### Step 2: Understand what makes waves feel good
| Problem | Solution |
|---------|----------|
| Too easy | Add more enemies OR increase enemy HP |
| Too hard | Remove enemies OR decrease enemy HP |
| Too slow | Decrease spawn interval (enemies come faster) |
| Too chaotic | Increase spawn interval (more time between enemies) |

### Step 3: Adjust WaveConfigSO files
1. Go to `Assets/_Project/Sc

MaxeLBerger: continue with pharrel`s issues 

GitHub Copilot: ## Plan: Continuing Pharell's Detailed Issues (Issue #33 onwards)

Continuing from Issue #33 where we left off, then completing all remaining issues through Phase 3.

---

### Issue #33: [Art] Create placeholder monster/enemy visuals (CONTINUED)

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `assets`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice

---

#### 📝 Step-by-Step Instructions (Continued from Step 4)

**Step 4: Create Monster Prefabs (Continued)**

**Flame Imp:**
1. Create Sphere (GameObject → 3D Object → Sphere)
2. Scale: `(0.8, 0.8, 0.8)`
3. Apply `Mat_FlameImp` material
4. Add a small cone on top for "horns": 3D Object → Cone, scale tiny, rotate
5. Name the parent: `Monster_FlameImp`
6. Drag to `Assets/_Project/Prefabs/Monsters/`

**Frost Wisp:**
1. Create Sphere
2. Scale: `(0.6, 0.9, 0.6)` (taller, thinner - wispy!)
3. Apply `Mat_FrostWisp` material
4. Add a small trail renderer for ghost effect (optional)
5. Name: `Monster_FrostWisp`
6. Drag to Prefabs/Monsters/

**Thunder Beast:**
1. Create Cube (not sphere - beasts are blocky!)
2. Scale: `(1.0, 0.8, 1.2)` (wide and sturdy)
3. Apply `Mat_ThunderBeast` material
4. Add 2 small cubes on top for "ears"
5. Name: `Monster_ThunderBeast`
6. Drag to Prefabs/Monsters/

**Step 5: Create Enemy Prefabs**

Navigate to: `Assets/_Project/Prefabs/Enemies/`

**Goblin:**
1. Create Capsule (3D Object → Capsule)
2. Scale: `(0.5, 0.7, 0.5)` (small humanoid)
3. Apply `Mat_Goblin` material
4. Name: `Enemy_Goblin`
5. Drag to Prefabs/Enemies/

**Scout:**
1. Create Capsule
2. Scale: `(0.4, 0.5, 0.4)` (smaller, faster-looking)
3. Apply `Mat_Scout` material
4. Rotate slightly forward (like running)
5. Name: `Enemy_Scout`
6. Drag to Prefabs/Enemies/

**Ogre:**
1. Create Cube
2. Scale: `(1.2, 1.5, 1.0)` (big and chunky!)
3. Apply `Mat_Ogre` material
4. Add sphere on top for head
5. Name: `Enemy_Ogre`
6. Drag to Prefabs/Enemies/

**Step 6: Create Projectile Prefabs**

Navigate to: `Assets/_Project/Prefabs/Projectiles/`

| Projectile | Shape | Scale | Material Color |
|------------|-------|-------|----------------|
| `Projectile_Fireball` | Sphere | (0.2, 0.2, 0.2) | Orange with emission |
| `Projectile_IceShard` | Cube (rotated 45°) | (0.15, 0.3, 0.15) | Light blue |
| `Projectile_Lightning` | Stretched Capsule | (0.1, 0.4, 0.1) | Yellow with bright emission |

---

#### ✅ Definition of Done
- [ ] 6 materials created (3 monster, 3 enemy)
- [ ] 3 monster prefabs created with distinct shapes
- [ ] 3 enemy prefabs created with distinct shapes
- [ ] 3 projectile prefabs created
- [ ] All prefabs in correct folders
- [ ] Materials have appropriate colors

---

#### 💡 Visual Guide

```
MONSTERS:                    ENEMIES:
                            
🔴 Flame Imp (sphere)       🟢 Goblin (capsule)
   Red, small horns             Green, medium
                            
🔵 Frost Wisp (tall sphere) 🟢 Scout (small capsule)
   Blue, ethereal               Light green, tiny
                            
🟡 Thunder Beast (cube)     🟢 Ogre (big cube)
   Yellow, blocky               Dark green, huge
```

---

---

### Issue #45: [Balance] Tune wave difficulty

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `balance`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Depends on:** Gameplay loop working (Week 3 complete)

---

#### 🎯 Goal
Playtest the game and adjust wave configs so the difficulty feels right - not too easy, not too hard!

---

#### 📝 Step-by-Step Instructions

**Step 1: Set Up for Playtesting**
1. Open `BattleScene.unity`
2. Press Play
3. Place all 3 monsters on slots
4. Let waves run and observe

**Step 2: What to Look For**

For each wave, note:
- ⏱️ How long did the wave take?
- ❤️ How much base HP did you lose?
- 💀 Did any enemies reach the base?
- 😴 Was it boring (too easy)?
- 😤 Was it frustrating (too hard)?

**Step 3: Use This Difficulty Guide**

| Wave | Target Difficulty | HP Loss Target | Feel |
|------|-------------------|----------------|------|
| 1-3 | Very Easy | 0 HP lost | "I can do this!" |
| 4-6 | Easy-Medium | 0-10 HP lost | "Getting interesting" |
| 7-8 | Medium-Hard | 10-30 HP lost | "Need to focus" |
| 9 | Hard | 20-40 HP lost | "This is tough!" |
| 10 | Very Hard | 30-50 HP lost | "Just barely made it!" |

**Step 4: How to Adjust**

Open the Wave configs in `Assets/_Project/ScriptableObjects/Waves/`

**If wave is TOO EASY:**
- Increase enemy count (+2 to +5)
- Decrease spawn interval (-0.2 seconds)
- Add stronger enemy types earlier

**If wave is TOO HARD:**
- Decrease enemy count (-2 to -5)
- Increase spawn interval (+0.3 seconds)
- Delay introduction of harder enemies

**Step 5: Record Your Changes**

Create a simple note in the issue comments:
```
Wave 1: Was too easy, increased Goblins from 5 to 7
Wave 6: Scout rush was impossible, reduced from 15 to 12
Wave 10: Perfect difficulty, kept as-is
```

**Step 6: Test Again After Changes**
1. Save the modified configs
2. Play again
3. Repeat until it feels right

---

#### 📊 Balance Checklist

| Wave | Original | Adjusted | Notes |
|------|----------|----------|-------|
| 1 | 5 Goblins | ___ | |
| 2 | 8 Goblins | ___ | |
| 3 | 12 Goblins | ___ | |
| 4 | 8G + 4S | ___ | |
| 5 | 6G + 8S | ___ | |
| 6 | 15 Scouts | ___ | |
| 7 | 10G + 5S + 2O | ___ | |
| 8 | 12G + 8S + 3O | ___ | |
| 9 | 15G + 10S + 4O | ___ | |
| 10 | 10G + 10S + 8O | ___ | |

---

#### ✅ Definition of Done
- [ ] Played through all 10 waves at least 3 times
- [ ] Adjusted wave configs based on observations
- [ ] Waves 1-3 feel like a tutorial (easy)
- [ ] Waves 4-6 provide moderate challenge
- [ ] Waves 7-9 are challenging but fair
- [ ] Wave 10 is hard but beatable
- [ ] Documented changes in issue comments

---

---

### Issue #46: [Balance] Tune monster stats

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `balance`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Depends on:** Gameplay loop working (Week 3 complete)

---

#### 🎯 Goal
Adjust monster stats so all 3 monsters feel useful and fun to use.

---

#### 📝 Step-by-Step Instructions

**Step 1: Test Each Monster Alone**

Play waves 1-5 using ONLY one monster type at a time:
1. Only Flame Imps → Note performance
2. Only Frost Wisps → Note performance
3. Only Thunder Beasts → Note performance

**Step 2: What Each Monster Should Feel Like**

| Monster | Should Be Good At | Should Struggle With |
|---------|-------------------|---------------------|
| **Flame Imp** | Killing everything consistently | Large groups (single target) |
| **Frost Wisp** | Slowing fast enemies, supporting | Killing anything by itself |
| **Thunder Beast** | Groups of enemies | Single strong enemies |

**Step 3: Balance Indicators**

**Flame Imp (DPS) - Check these:**
- [ ] Kills a Goblin in 4-5 hits? (not too fast, not too slow)
- [ ] Attack speed feels "rapid fire"?
- [ ] Range lets it hit enemies for a good duration?

**Frost Wisp (Slow) - Check these:**
- [ ] Slow effect is noticeable on Scouts?
- [ ] Doesn't kill things too fast (support, not DPS)?
- [ ] Long range lets it slow enemies early?

**Thunder Beast (AoE) - Check these:**
- [ ] Chain lightning visibly jumps between enemies?
- [ ] Effective when 3+ enemies are grouped?
- [ ] Struggles against single Ogre (as intended)?

**Step 4: How to Adjust Stats**

Open Monster configs in `Assets/_Project/ScriptableObjects/Monsters/`

| If... | Then Adjust... |
|-------|----------------|
| Monster kills too fast | Reduce ATK |
| Monster kills too slow | Increase ATK |
| Monster hits too rarely | Increase Attack Speed |
| Monster hits too often | Decrease Attack Speed |
| Can't hit anything | Increase Range |
| Hits from too far | Decrease Range |
| Slow effect too weak | Increase Slow Percentage |
| Slow effect too strong | Decrease Slow Percentage |

**Step 5: Test Combinations**

After individual tuning, test combinations:
1. All 3 monster types together
2. 2x Flame Imp + 1 Frost Wisp
3. 2x Thunder Beast + 1 Frost Wisp

All combos should feel viable!

---

#### 📊 Stat Adjustment Tracker

| Monster | Original ATK | New ATK | Original Speed | New Speed | Notes |
|---------|--------------|---------|----------------|-----------|-------|
| Flame Imp | 25 | ___ | 1.5 | ___ | |
| Frost Wisp | 10 | ___ | 0.8 | ___ | |
| Thunder Beast | 18 | ___ | 0.6 | ___ | |

---

#### ✅ Definition of Done
- [ ] Each monster tested individually
- [ ] Stats adjusted so each monster has a clear role
- [ ] Flame Imp = consistent DPS
- [ ] Frost Wisp = crowd control support
- [ ] Thunder Beast = AoE damage
- [ ] All 3 monsters feel useful
- [ ] No monster feels "useless" or "overpowered"

---

---

## Phase 1 Issues (8 issues)

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

## Phase 2 Issues (5 issues)

---

### Issue #82: [Pass] Create Battle Pass UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the Battle Pass/Season Pass screen showing tiers and rewards.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Layout**

```
┌────────────────────────────────────────────────────────────────────┐
│  [←]              SEASON PASS - Season 1                    ⏱️ 14d │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  Level 15                    ████████████░░░░░░  3,450/5,000 XP   │
│                                                                    │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  ← ════════════════════════════════════════════════════════════ → │
│                                                                    │
│     [13]    [14]    [15]    [16]    [17]    [18]    [19]         │
│      ✓       ✓      NOW      🔒      🔒      🔒      🔒          │
│                                                                    │
│     FREE REWARDS:                                                  │
│    ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐       │
│    │🪙  │  │🪙  │  │💎  │  │🪙  │  │📦  │  │🪙  │  │⭐  │       │
│    │500 │  │500 │  │ 10 │  │750 │  │Shard│  │1k  │  │Rare│       │
│    └────┘  └────┘  └────┘  └────┘  └────┘  └────┘  └────┘       │
│       ✓       ✓     Claim     -       -       -       -          │
│                                                                    │
│     ┌─────────────────────────────────────────────────────────┐   │
│     │  🔒 PREMIUM REWARDS - Unlock for $9.99                   │   │
│     └─────────────────────────────────────────────────────────┘   │
│    ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐  ┌────┐       │
│    │💎  │  │💎  │  │🎨  │  │💎  │  │⭐  │  │💎  │  │🌟  │       │
│    │ 50 │  │ 50 │  │Frame│  │100 │  │Epic│  │150 │  │Leg │       │
│    └────┘  └────┘  └────┘  └────┘  └────┘  └────┘  └────┘       │
│                                                                    │
├────────────────────────────────────────────────────────────────────┤
│  MISSIONS:                                                         │
│  ├─ Complete 10 waves      ████████░░  8/10     (+100 XP)         │
│  ├─ Level up 5 monsters    ██████████  5/5  ✓   [CLAIM]           │
│  └─ Perform 3 summons      ████░░░░░░  2/3      (+150 XP)         │
└────────────────────────────────────────────────────────────────────┘
```

**Step 2: Build Components**

1. **Header:**
   - Back button
   - Season title
   - Timer countdown

2. **Progress Bar:**
   - Current level
   - XP bar with numbers

3. **Tier Scroll View:**
   - Horizontal scroll
   - Tier nodes with numbers
   - Current tier highlighted

4. **Reward Rows:**
   - Free reward row (always visible)
   - Premium reward row (locked overlay if not purchased)

5. **Reward Item Prefab:**
   ```
   RewardItem
   ├── Background
   ├── Icon
   ├── AmountText
   ├── ClaimedOverlay (checkmark)
   └── ClaimButton (if available)
   ```

6. **Missions Section:**
   - List of active missions
   - Progress bar per mission
   - Claim button when complete

**Step 3: Create Prefabs**
- `BattlePassScreen.prefab`
- `PassTierNode.prefab`
- `PassRewardItem.prefab`
- `PassMissionRow.prefab`

---

#### ✅ Definition of Done
- [ ] `BattlePassScreen.prefab` created
- [ ] Tier scroll view with 40 tiers
- [ ] Free and Premium reward tracks
- [ ] Mission list at bottom
- [ ] XP progress bar
- [ ] Timer display
- [ ] Premium unlock button

---

---

### Issue #85: [Pass] Define Season 1 rewards

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `data`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Design all 40 tiers of rewards for both free and premium tracks.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Reward Spreadsheet**

Use this template (you can create it in a doc or spreadsheet):

| Tier | Free Reward | Premium Reward |
|------|-------------|----------------|
| 1 | 500 Gold | 50 Diamonds |
| 2 | 500 Gold | 50 Diamonds |
| 3 | 10 Diamonds | Profile Frame |
| 4 | 750 Gold | 75 Diamonds |
| 5 | 10 Evo Materials | Monster Shard (Rare) |
| ... | ... | ... |
| 40 | Legendary Shard (1) | EXCLUSIVE: Dragon Lord Skin |

**Step 2: Follow These Guidelines**

**Free Track Rewards:**
- Mostly Gold (every 1-2 tiers)
- Some Diamonds (every 5 tiers, small amounts: 5-15)
- Evo Materials (every 4-5 tiers)
- Common/Rare Monster Shards (tiers 10, 20, 30)
- One Legendary Shard at tier 40

**Premium Track Rewards:**
- More Diamonds (50-200 per tier)
- Epic Monster Shards (every 10 tiers)
- Exclusive Cosmetics (profile frames, chat badges)
- Legendary Shard at tier 35
- EXCLUSIVE item at tier 40 (skin or unique cosmetic)

**Step 3: Create the Full Reward List**

```
SEASON 1: "Flame Festival"

Tier 1:  FREE: 500 Gold        PREMIUM: 50 Diamonds
Tier 2:  FREE: 500 Gold        PREMIUM: 50 Diamonds
Tier 3:  FREE: 10 Diamonds     PREMIUM: "Flame Frame" (profile)
Tier 4:  FREE: 750 Gold        PREMIUM: 75 Diamonds
Tier 5:  FREE: 10 Evo Mats     PREMIUM: 100 Diamonds
Tier 6:  FREE: 500 Gold        PREMIUM: 50 Diamonds
Tier 7:  FREE: 500 Gold        PREMIUM: 75 Diamonds
Tier 8:  FREE: 750 Gold        PREMIUM: 100 Diamonds
Tier 9:  FREE: 15 Diamonds     PREMIUM: 10 Evo Mats
Tier 10: FREE: Rare Shard x5   PREMIUM: Epic Shard x3

Tier 11: FREE: 1000 Gold       PREMIUM: 100 Diamonds
Tier 12: FREE: 500 Gold        PREMIUM: 50 Diamonds
Tier 13: FREE: 15 Evo Mats     PREMIUM: 75 Diamonds
Tier 14: FREE: 750 Gold        PREMIUM: 100 Diamonds
Tier 15: FREE: 20 Diamonds     PREMIUM: "Fire Badge" (chat)
Tier 16: FREE: 1000 Gold       PREMIUM: 100 Diamonds
Tier 17: FREE: 500 Gold        PREMIUM: 75 Diamonds
Tier 18: FREE: 750 Gold        PREMIUM: 100 Diamonds
Tier 19: FREE: 20 Evo Mats     PREMIUM: 150 Diamonds
Tier 20: FREE: Rare Shard x10  PREMIUM: Epic Shard x5

Tier 21: FREE: 1500 Gold       PREMIUM: 150 Diamonds
Tier 22: FREE: 750 Gold        PREMIUM: 75 Diamonds
Tier 23: FREE: 25 Diamonds     PREMIUM: 100 Diamonds
Tier 24: FREE: 1000 Gold       PREMIUM: 125 Diamonds
Tier 25: FREE: 25 Evo Mats     PREMIUM: "Inferno Frame" (profile)
Tier 26: FREE: 1000 Gold       PREMIUM: 100 Diamonds
Tier 27: FREE: 750 Gold        PREMIUM: 100 Diamonds
Tier 28: FREE: 1500 Gold       PREMIUM: 150 Diamonds
Tier 29: FREE: 30 Evo Mats     PREMIUM: 175 Diamonds
Tier 30: FREE: Epic Shard x3   PREMIUM: Epic Shard x10

Tier 31: FREE: 2000 Gold       PREMIUM: 200 Diamonds
Tier 32: FREE: 1000 Gold       PREMIUM: 100 Diamonds
Tier 33: FREE: 30 Diamonds     PREMIUM: 150 Diamonds
Tier 34: FREE: 1500 Gold       PREMIUM: 175 Diamonds
Tier 35: FREE: 35 Evo Mats     PREMIUM: Legendary Shard x1
Tier 36: FREE: 1500 Gold       PREMIUM: 150 Diamonds
Tier 37: FREE: 1000 Gold       PREMIUM: 150 Diamonds
Tier 38: FREE: 2000 Gold       PREMIUM: 200 Diamonds
Tier 39: FREE: 40 Evo Mats     PREMIUM: 250 Diamonds
Tier 40: FREE: Legendary Shard x1  PREMIUM: "Phoenix Flame Skin" (EXCLUSIVE)
```

**Step 4: Document XP Requirements**

| Tiers | XP Per Tier |
|-------|-------------|
| 1-10 | 1,000 XP each |
| 11-20 | 2,000 XP each |
| 21-30 | 3,000 XP each |
| 31-40 | 4,000 XP each |

Total XP needed: 100,000 XP

**Step 5: Document Missions (XP Sources)**

| Mission | XP Reward | Refresh |
|---------|-----------|---------|
| Complete 10 waves | 100 XP | Daily |
| Level up 5 monsters | 150 XP | Daily |
| Perform 3 summons | 150 XP | Daily |
| Win 3 battles | 200 XP | Daily |
| Reach wave 50 in Endless | 500 XP | Weekly |
| Collect AFK rewards 7 times | 300 XP | Weekly |

---

#### ✅ Definition of Done
- [ ] All 40 tiers defined with Free rewards
- [ ] All 40 tiers defined with Premium rewards
- [ ] Rewards follow progression guidelines
- [ ] XP requirements documented
- [ ] Missions defined with XP values
- [ ] Season theme ("Flame Festival") defined

---

---

### Issue #89: [Shop] Create Shop UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the in-game shop for purchasing diamonds, bundles, and special offers.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Layout**

```
┌────────────────────────────────────────────────────────────────────┐
│  [←]                        SHOP                                   │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  [💎 Diamonds]  [📦 Bundles]  [🎁 Daily Deals]  [👑 VIP]          │
│  ═══════════════                                                   │
│                                                                    │
├────────────────────────────────────────────────────────────────────┤
│                                                                    │
│  ┌────────────┐  ┌────────────┐  ┌────────────┐  ┌────────────┐  │
│  │    💎      │  │    💎💎    │  │   💎💎💎   │  │  💎💎💎💎  │  │
│  │    100     │  │    550     │  │   1,200    │  │   2,500    │  │
│  │            │  │  +10% BONUS│  │ +20% BONUS │  │ +30% BONUS │  │
│  │   $0.99    │  │   $4.99    │  │   $9.99    │  │   $19.99   │  │
│  └────────────┘  └────────────┘  └────────────┘  └────────────┘  │
│                                                                    │
│  ┌────────────┐  ┌────────────────────────────────────────────┐   │
│  │ 💎💎💎💎💎 │  │         ⭐ BEST VALUE ⭐                   │   │
│  │   6,500    │  │              💎 15,000                      │   │
│  │+50% BONUS  │  │           +100% BONUS!                      │   │
│  │  $49.99    │  │              $99.99                         │   │
│  └────────────┘  └────────────────────────────────────────────┘   │
│                                                                    │
└────────────────────────────────────────────────────────────────────┘
```

**Step 2: Create Tab System**
1. Create horizontal tab bar at top
2. Tabs: Diamonds, Bundles, Daily Deals, VIP
3. Selected tab is highlighted

**Step 3: Create Diamond Pack Card**

`DiamondPackCard.prefab`:
```
DiamondPackCard
├── Background (Image)
├── DiamondIcon (Image - scales with amount)
├── AmountText (TMP - "1,200")
├── BonusTag (Panel - "+20% BONUS", hidden if no bonus)
├── PriceButton (Button with price text "$9.99")
└── BestValueBadge (Image - only on biggest pack)
```

**Step 4: Create Bundles Tab**

```
STARTER BUNDLE (One-time purchase!)
┌──────────────────────────────────────────────────────────────┐
│  🌟 STARTER PACKSTARTER BUNDLE (One-time purchase!)
┌──────────────────────────────────────────────────────────────┐
│  🌟 STARTER PACK

MaxeLBerger: continue

GitHub Copilot: ## Pharell's Issues - Continuation (Issue #33 onwards)

Continuing from where we left off in Issue #33...

---

### Issue #33: [Art] Create placeholder monster/enemy visuals (CONTINUED)

**Step 4: Create Monster Prefabs (continued)**

**Flame Imp:**
1. Create Sphere (GameObject → 3D Object → Sphere)
2. Scale: `(0.8, 0.8, 0.8)`
3. Apply `Mat_FlameImp`
4. Add a small "flame" indicator: Create a smaller cone above it
   - Create Cone (or use a stretched cube rotated 45°)
   - Scale: `(0.3, 0.5, 0.3)`
   - Position above sphere
   - Make it orange
5. Parent everything under empty `FlameImp`
6. Drag to: `Assets/_Project/Prefabs/Monsters/FlameImp.prefab`

**Frost Wisp:**
1. Create Sphere
2. Scale: `(0.6, 0.6, 0.6)` (smaller, wispy)
3. Apply `Mat_FrostWisp`
4. Add "floating crystals": 3 small cubes rotating around it
   - Create 3 tiny cubes, scale `(0.15, 0.15, 0.15)`
   - Position around the sphere at different angles
   - Apply light blue material
5. Parent under empty `FrostWisp`
6. Save as prefab

**Thunder Beast:**
1. Create Cube
2. Scale: `(1.0, 1.2, 0.8)` (big and boxy)
3. Apply `Mat_ThunderBeast`
4. Add "horns": 2 stretched cubes on top
   - Scale: `(0.15, 0.4, 0.15)`
   - Position on top corners, angled outward
5. Parent under empty `ThunderBeast`
6. Save as prefab

**Step 5: Create Enemy Prefabs**

Navigate to: `Assets/_Project/Prefabs/Enemies/`

**Goblin:**
1. Create Capsule (3D Object → Capsule)
2. Scale: `(0.5, 0.5, 0.5)` (small humanoid)
3. Apply `Mat_Goblin`
4. Add "ears": 2 small spheres on sides
   - Scale: `(0.15, 0.2, 0.1)`
   - Position at head level, rotated outward
5. Save as `Goblin.prefab`

**Scout:**
1. Create Capsule
2. Scale: `(0.35, 0.35, 0.35)` (smaller than goblin!)
3. Apply `Mat_Scout`
4. Make it look "speedy": Stretch slightly forward
   - Rotation: `X: 15` (leaning forward)
5. Save as `Scout.prefab`

**Ogre:**
1. Create Cube
2. Scale: `(1.2, 1.5, 1.0)` (BIG and chunky)
3. Apply `Mat_Ogre`
4. Add "belly": Sphere in front
   - Scale: `(0.8, 0.8, 0.5)`
   - Position: slightly forward
5. Add "arms": 2 stretched cubes
   - Scale: `(0.3, 0.8, 0.3)`
   - Position on sides
6. Save as `Ogre.prefab`

**Step 6: Create Projectile Prefabs**

Navigate to: `Assets/_Project/Prefabs/Projectiles/`

| Projectile | Shape | Scale | Color | For Monster |
|------------|-------|-------|-------|-------------|
| `Fireball.prefab` | Sphere | 0.2, 0.2, 0.2 | Orange (255, 150, 50) | Flame Imp |
| `IceShard.prefab` | Cube (rotated 45°) | 0.15, 0.15, 0.3 | Cyan (100, 220, 255) | Frost Wisp |
| `LightningOrb.prefab` | Sphere | 0.25, 0.25, 0.25 | Yellow (255, 255, 100) | Thunder Beast |

---

#### 📁 Final Folder Structure

```
Assets/_Project/
├── Art/
│   └── Materials/
│       ├── Mat_FlameImp.mat
│       ├── Mat_FrostWisp.mat
│       ├── Mat_ThunderBeast.mat
│       ├── Mat_Goblin.mat
│       ├── Mat_Scout.mat
│       ├── Mat_Ogre.mat
│       ├── Mat_Fireball.mat
│       ├── Mat_IceShard.mat
│       └── Mat_LightningOrb.mat
└── Prefabs/
    ├── Monsters/
    │   ├── FlameImp.prefab
    │   ├── FrostWisp.prefab
    │   └── ThunderBeast.prefab
    ├── Enemies/
    │   ├── Goblin.prefab
    │   ├── Scout.prefab
    │   └── Ogre.prefab
    └── Projectiles/
        ├── Fireball.prefab
        ├── IceShard.prefab
        └── LightningOrb.prefab
```

---

#### ✅ Definition of Done
- [ ] 3 monster materials created with distinct colors
- [ ] 3 enemy materials created with green variants
- [ ] 3 projectile materials created
- [ ] `FlameImp.prefab` - red sphere with flame decoration
- [ ] `FrostWisp.prefab` - blue sphere with crystal decorations
- [ ] `ThunderBeast.prefab` - yellow cube with horns
- [ ] `Goblin.prefab` - green capsule with ears
- [ ] `Scout.prefab` - small green capsule, leaning forward
- [ ] `Ogre.prefab` - large green cube with belly and arms
- [ ] 3 projectile prefabs created
- [ ] All prefabs saved in correct folders

---

#### 💡 Tips
- Use emission on materials to make things "glow" and look more magical
- Keep shapes simple - we're just using these for testing!
- Make sure each monster/enemy is a different size so players can tell them apart

---

---

### Issue #45: [Balance] Tune wave difficulty

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `balance`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #49 (Gameplay must be testable first)

---

#### 🎯 Goal
Play through all 10 waves and adjust enemy counts, HP, and spawn timing to make the game challenging but fair!

---

#### ⏳ Wait For
The gameplay loop needs to be working first. Moritz will let you know when you can start testing!

---

#### 📝 Step-by-Step Instructions

**Step 1: Set Up Test Conditions**
1. Open the game in Unity (Play mode)
2. Start with your 3 starter monsters (Flame Imp, Frost Wisp, Thunder Beast)
3. Give yourself some starting gold: 500 (ask Max or Moritz how to set this)

**Step 2: Play Through Each Wave**

For EACH wave (1-10), record:

```
Wave #: ___
═══════════════════════════════════════════════
Did I win? [ ] Yes  [ ] No
Base HP remaining: ___/100
Time to complete: ___seconds
How did it FEEL?
  [ ] Too Easy (boring, no challenge)
  [ ] Just Right (exciting, close calls)
  [ ] Too Hard (impossible, frustrating)
  [ ] Unfair (couldn't do anything)
  
Notes:
_________________________________
_________________________________
```

**Step 3: Balance Guidelines**

Use these targets as a guide:

| Wave | Target HP Remaining | Target Difficulty Feel |
|------|--------------------|-----------------------|
| 1-3 | 90-100 HP | Easy, learning the game |
| 4-6 | 70-90 HP | Medium, some challenge |
| 7-9 | 50-80 HP | Hard, need to think |
| 10 | 30-60 HP | Very hard, boss fight! |

**Step 4: Make Adjustments**

If waves are **too easy**:
- Increase enemy count by 20-30%
- Decrease spawn interval (faster spawns)
- Mix in more Scouts and Ogres

If waves are **too hard**:
- Reduce enemy count by 20-30%
- Increase spawn interval (slower spawns)
- Remove some Ogres

**Step 5: Document Your Changes**

For each wave config you change, write down:
- What you changed
- Why you changed it
- The result after testing

Example:
```
Wave 6 (Scout Rush):
  BEFORE: 15 Scouts, 0.8s interval
  PROBLEM: Too overwhelming, lost 40 HP
  AFTER: 12 Scouts, 1.0s interval  
  RESULT: Lost only 15 HP, felt challenging but fair
```

**Step 6: Test Again!**

After making changes:
1. Play waves 1-10 again from the start
2. Make sure the WHOLE experience feels good
3. Repeat until satisfied!

---

#### 🎮 Balancing Tips

1. **First playthrough should be possible to WIN**
   - If you can't beat wave 10 on your first try with full upgrades, it's too hard!

2. **Scouts are tricky**
   - They move 2x speed, so fewer Scouts = less overwhelming
   - Make sure Frost Wisp can slow them effectively

3. **Ogres are scary**
   - 300 HP takes a while to kill
   - Don't spawn too many at once, or stagger their spawns

4. **Wave 10 should feel EPIC**
   - It's okay if players barely survive
   - But they should feel like they EARNED the victory!

---

#### ✅ Definition of Done
- [ ] Played through all 10 waves at least 3 times
- [ ] Waves 1-3 feel easy (learning)
- [ ] Waves 4-6 feel medium (some challenge)
- [ ] Waves 7-9 feel hard (strategic)
- [ ] Wave 10 feels epic (barely survived!)
- [ ] All changes documented in a balancing log
- [ ] Updated WaveConfigSO assets with new values

---

---

### Issue #46: [Balance] Tune monster stats

**Assignee:** @User420-Bit  
**Labels:** `phase-0`, `balance`, `priority-medium`  
**Milestone:** Phase 0 - Vertical Slice  
**Blocked by:** #49 (Gameplay must be testable first)

---

#### 🎯 Goal
Adjust monster ATK, Range, and AttackSpeed so each monster feels useful and different!

---

#### 📝 Step-by-Step Instructions

**Step 1: Test Each Monster Individually**

Create a test scenario for each monster:

1. Place ONLY that monster on the map
2. Start wave 3 (just goblins)
3. Record how it performs

**Testing Flame Imp:**
```
Question: Does it kill goblins before they reach the base?
Target: Should kill 8-10 goblins with medium upgrades
If killing too few: Increase ATK or AttackSpeed
If killing too many: Decrease ATK (it's supposed to be DPS, but not OP)
```

**Testing Frost Wisp:**
```
Question: Does the slow effect feel noticeable?
Target: Enemies should visibly slow down (30% slower)
Test: Can you SEE the difference between slowed and normal enemies?
If slow not noticeable: Increase slow percentage (try 40%)
If too strong: Decrease slow duration
```

**Testing Thunder Beast:**
```
Question: Does chain lightning hit multiple enemies?
Target: Should hit 3 enemies per attack
Test: Wait for enemies to group up - does lightning jump?
If not hitting enough: Check chain range (maybe too short)
If too powerful: Reduce chain damage falloff (each jump does less)
```

**Step 2: Test Monster Combinations**

Now test with all 3 monsters together:

```
Test Scenario: Place all 3 monsters, run wave 5
═══════════════════════════════════════════════
Questions to answer:
1. Is any monster useless compared to others? [ ]
2. Is any monster doing ALL the work? [ ]
3. Do they feel like a TEAM? [ ]
```

Each monster should contribute:
- **Flame Imp**: Consistent damage dealer (most kills)
- **Frost Wisp**: Crowd control (slows enemies for others)
- **Thunder Beast**: AoE burst (shines when enemies group up)

**Step 3: Adjust and Retest**

| If This Monster Feels... | Try This Fix |
|--------------------------|--------------|
| Flame Imp too weak | +5 ATK or +0.2 AttackSpeed |
| Flame Imp too strong | -5 ATK |
| Frost Wisp useless | +10% slow or +1 range |
| Frost Wisp too strong | -0.5 slow duration |
| Thunder Beast weak | +1 chain target or +3 ATK |
| Thunder Beast too strong | Increase chain falloff (0.7 → 0.5) |

**Step 4: Final Stat Check**

After balancing, fill in your final values:

```
FINAL MONSTER STATS
═══════════════════════════════════════════════
Flame Imp (DPS Role):
  ATK: ___
  Range: ___
  AttackSpeed: ___
  
Frost Wisp (Support Role):
  ATK: ___
  Range: ___
  AttackSpeed: ___
  Slow %: ___
  Slow Duration: ___
  
Thunder Beast (AoE Role):
  ATK: ___
  Range: ___
  AttackSpeed: ___
  Chain Targets: ___
  Chain Falloff: ___
```

---

#### ✅ Definition of Done
- [ ] Each monster tested individually
- [ ] All 3 monsters tested together
- [ ] Each monster has a clear role and feels useful
- [ ] No monster is useless or overpowered
- [ ] Final stats documented
- [ ] MonsterConfigSO assets updated with balanced values

---

---

## Phase 1 Issues (8 issues)

---

### Issue #54: [Gacha] Create 5 new monsters

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `data`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion  
**Blocked by:** #11 (MonsterConfigSO class must exist)

---

#### 🎯 Goal
Create 5 new monster configurations to add variety to the gacha system!

---

#### 📝 Step-by-Step Instructions

**Step 1: Understand the New Monsters**

We need monsters across different rarities:

| Monster | Rarity | Role | Special Ability |
|---------|--------|------|-----------------|
| Stone Golem | Rare | Tank | High HP, short range melee |
| Wind Sprite | Rare | Sniper | Very long range, low attack speed |
| Shadow Panther | Epic | Assassin | Multi-hit attacks (3 hits per attack) |
| Phoenix | Epic | AoE Burn | AoE attack + burn damage over time |
| Dragon Lord | Legendary | Ultimate AoE | Massive damage, huge range, slow attack |

**Step 2: Create Each Monster Config**

Navigate to: `Assets/_Project/ScriptableObjects/Monsters/`

---

**Stone Golem (Rare - Tank)**
```
Filename: StoneGolem_Config.asset
Display Name: Stone Golem
Rarity: Rare
Evolution Stage: Normal

═══ STATS ═══
ATK:              30
Range:            1.5  (very short - melee!)
Attack Speed:     0.4  (slow but heavy hits)

═══ TARGETING ═══
Targeting Priority: Nearest

═══ SPECIAL ═══
Armor:            20%  (takes 20% less damage if we add monster HP later)

═══ DESCRIPTION ═══
"An ancient stone guardian. Slow but incredibly tough. Its powerful fists crush anything in melee range."
```

---

**Wind Sprite (Rare - Sniper)**
```
Filename: WindSprite_Config.asset
Display Name: Wind Sprite
Rarity: Rare
Evolution Stage: Normal

═══ STATS ═══
ATK:              35
Range:            8.0  (VERY long range!)
Attack Speed:     0.5  (slow, precise shots)

═══ TARGETING ═══
Targeting Priority: Strongest

═══ DESCRIPTION ═══
"A playful wind elemental that strikes from afar. Its gusts can reach enemies others can't touch."
```

---

**Shadow Panther (Epic - Assassin)**
```
Filename: ShadowPanther_Config.asset
Display Name: Shadow Panther
Rarity: Epic
Evolution Stage: Normal

═══ STATS ═══
ATK:              12  (per hit - but hits 3 times!)
Range:            2.5
Attack Speed:     2.0  (very fast!)

═══ TARGETING ═══
Targeting Priority: Fastest

═══ SPECIAL ═══
Multi-Hit:        3    (attacks 3 times per attack cycle)
Crit Chance:      15%  (chance for double damage)

═══ DESCRIPTION ═══
"A deadly shadow predator that strikes with blinding speed. Its claws rake enemies three times in rapid succession!"
```

---

**Phoenix (Epic - AoE Burn)**
```
Filename: Phoenix_Config.asset
Display Name: Phoenix
Rarity: Epic
Evolution Stage: Normal

═══ STATS ═══
ATK:              20
Range:            4.0
Attack Speed:     0.6

═══ TARGETING ═══
Targeting Priority: First

═══ SPECIAL ═══
AoE Radius:       2.0   (hits all enemies in radius)
Burn Damage:      5     (per second)
Burn Duration:    3.0   (seconds)

═══ DESCRIPTION ═══
"A majestic firebird that rains flames upon its foes. Enemies caught in its fire continue to burn!"
```

---

**Dragon Lord (Legendary - Ultimate AoE)**
```
Filename: DragonLord_Config.asset
Display Name: Dragon Lord
Rarity: Legendary
Evolution Stage: Normal

═══ STATS ═══
ATK:              50  (HUGE damage!)
Range:            6.0  (long range)
Attack Speed:     0.3  (very slow)

═══ TARGETING ═══
Targeting Priority: Strongest

═══ SPECIAL ═══
AoE Radius:       3.5   (massive area)
Knockback:        2.0   (pushes enemies back)

═══ DESCRIPTION ═══
"The king of all monsters. Its devastating breath weapon annihilates groups of enemies. Legendary power comes at legendary rarity!"
```

---

**Step 3: Create Placeholder Prefabs**

Create simple visual placeholders like in Issue #33:

| Monster | Shape | Color | Extra |
|---------|-------|-------|-------|
| Stone Golem | Cube | Gray (128, 128, 128) | Rocky texture |
| Wind Sprite | Sphere | Light cyan (200, 255, 255) | Smaller, with swirl particles |
| Shadow Panther | Stretched cube | Dark purple (60, 30, 80) | Low, sleek shape |
| Phoenix | Sphere with cone wings | Orange-red (255, 120, 50) | Fire-colored |
| Dragon Lord | Large cube | Gold (255, 200, 50) | Crown/spikes on top |

---

#### ✅ Definition of Done
- [ ] `StoneGolem_Config.asset` created (Rare, Tank)
- [ ] `WindSprite_Config.asset` created (Rare, Sniper)
- [ ] `ShadowPanther_Config.asset` created (Epic, Assassin)
- [ ] `Phoenix_Config.asset` created (Epic, AoE Burn)
- [ ] `DragonLord_Config.asset` created (Legendary, Ultimate)
- [ ] Placeholder prefabs created for each
- [ ] Stats feel appropriate for rarity (Legendary should feel POWERFUL)

---

---

### Issue #55: [UI] Create Summon screen UI

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `ui`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create the gacha/summon screen where players spend diamonds to get new monsters!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Screen Layout**

```
┌────────────────────────────────────────────────────┐
│                                            [X]    │
│                                                    │
│            ✨ MONSTER SUMMON ✨                   │
│                                                    │
│  ┌──────────────────────────────────────────────┐  │
│  │                                              │  │
│  │           [BANNER IMAGE AREA]                │  │
│  │        "Featured: Dragon Lord!"              │  │
│  │             Rate Up: 0.5%                    │  │
│  │                                              │  │
│  └──────────────────────────────────────────────┘  │
│                                                    │
│       💎 Your Diamonds: 1,250                     │
│                                                    │
│  ┌────────────────┐    ┌────────────────────────┐  │
│  │                │    │                        │  │
│  │  SUMMON x1     │    │     SUMMON x10        │  │
│  │   💎 100       │    │     💎 900 (10% OFF)  │  │
│  │                │    │                        │  │
│  └────────────────┘    └────────────────────────┘  │
│                                                    │
│              [View Drop Rates]                     │
│                                                    │
│  Pity Counter: 75/90 - Guaranteed Epic soon!      │
│                                                    │
└────────────────────────────────────────────────────┘
```

**Step 2: Create UI Elements**

1. **Header Section:**
   - Close button (X)
   - Title: "Monster Summon" with sparkle effects

2. **Banner Area (600x300):**
   - Large image placeholder for featured monster
   - Featured monster name
   - Rate-up percentage display

3. **Diamond Display:**
   - Diamond icon
   - Current diamond count (TextMeshPro)

4. **Summon Buttons:**
   - **Single Summon (x1):**
     - Size: 300x120
     - Diamond icon + cost (100)
     - Glowing border
   - **Multi Summon (x10):**
     - Size: 400x120
     - Diamond icon + cost (900)
     - "10% OFF" badge
     - More prominent/golden style

5. **Drop Rates Button:**
   - Link/button style
   - Opens a popup with rates table

6. **Pity Counter:**
   - Progress bar showing summons until guaranteed
   - Text: "75/90 - Guaranteed Epic soon!"

**Step 3: Create Drop Rates Popup**

Create a secondary popup (`DropRatesPopup.prefab`):

```
┌────────────────────────────────────────┐
│         DROP RATES              [X]    │
├────────────────────────────────────────┤
│  Common      ⬜⬜⬜⬜⬜   60%         │
│  Rare        🟦🟦🟦      25%         │
│  Epic        🟪🟪        12%         │
│  Legendary   🟨           3%         │
├────────────────────────────────────────┤
│  Rate-Up Monsters:                     │
│  Dragon Lord (Legendary): 0.5%        │
└────────────────────────────────────────┘
```

**Step 4: Create Reveal Area (for after summoning)**

Create a placeholder area for the summon animation result:

```
┌────────────────────────────────────────┐
│                                        │
│     ✨ [MONSTER REVEAL AREA] ✨        │
│                                        │
│        (Moritz will add animation)     │
│                                        │
│          [TAP TO CONTINUE]             │
└────────────────────────────────────────┘
```

**Step 5: Create Prefabs**
1. `SummonScreen.prefab`
2. `DropRatesPopup.prefab`

---

#### ✅ Definition of Done
- [ ] `SummonScreen.prefab` created
- [ ] Banner image area with featured monster text
- [ ] Diamond display
- [ ] Single summon button (x1, 100 diamonds)
- [ ] Multi summon button (x10, 900 diamonds with discount)
- [ ] Drop rates button and popup
- [ ] Pity counter display
- [ ] Close button
- [ ] All text uses LocalizationKeys (add new keys if needed!)

---

---

### Issue #60: [Hub] Redesign Hub scene with buildings

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `assets`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Transform the Hub from simple buttons into a visual "base" with building icons that players can tap!

---

#### 📝 Step-by-Step Instructions

**Step 1: Understand the Hub Layout**

The hub should feel like a small village/base:

```
┌────────────────────────────────────────────────────┐
│                   💎 1,250    🪙 15,000            │
│                                                    │
│                    IDLE MONSTER TD                 │
│                     ⭐ Level 12 ⭐                  │
│                                                    │
│     ┌─────────┐           ┌─────────┐             │
│     │ 🏛️      │           │ 📜      │             │
│     │ SUMMON  │           │RESEARCH │             │
│     │ ARENA   │           │  LAB    │             │
│     │ (Lv.3)  │           │ (Lv.2)  │             │
│     └─────────┘           └─────────┘             │
│                                                    │
│     ┌─────────┐           ┌─────────┐             │
│     │ 🐉      │           │ 📦      │             │
│     │MONSTER  │           │  AFK    │             │
│     │  LAB    │           │ CHEST   │             │
│     │ (Lv.5)  │           │  🔔     │             │
│     └─────────┘           └─────────┘             │
│                                                    │
│              ┌─────────────────┐                  │
│              │  ⚔️  BATTLE  ⚔️  │                  │
│              └─────────────────┘                  │
│                                                    │
└────────────────────────────────────────────────────┘
```

**Step 2: Create Building Cards**

Each building is a UI card with:
- Building icon (placeholder emoji/image)
- Building name
- Current level
- Notification badge (if action available)

Create a `BuildingCard.prefab`:

```
┌─────────────────┐
│    ┌────────┐   │
│    │  🏛️   │   │   ← Icon area (Image, 80x80)
│    └────────┘   │
│                 │
│  Summon Arena   │   ← Building name (TextMeshPro)
│    Level 3      │   ← Level display
│       🔔        │   ← Notification badge (optional)
└─────────────────┘
```

**Step 3: Update HubScene**

1. Open `Assets/_Project/Scenes/HubScene.unity`
2. Remove the old button layout (or keep as reference)
3. Create new structure:

**Header Area:**
- Currency display (Diamonds + Gold) at top right
- Game title centered
- Account level below title

**Building Grid:**
- 2x2 grid in center area
- Summon Arena (top left)
- Research Lab (top right)
- Monster Lab (bottom left)
- AFK Chest (bottom right)

**Battle Button:**
- Large button at bottom
- Most prominent visual

**Step 4: Create Building Icon Placeholders**

Create colored squares for now (we'll add real art later):

| Building | Color | Emoji/Placeholder |
|----------|-------|-------------------|
| Summon Arena | Purple (150, 80, 180) | 🏛️ or portal icon |
| Research Lab | Blue (80, 120, 200) | 📜 or book icon |
| Monster Lab | Green (80, 180, 80) | 🐉 or monster icon |
| AFK Chest | Orange (220, 160, 60) | 📦 or chest icon |

**Step 5: Add Notification Badge Logic (Visual Only)**

The AFK Chest should show a notification when rewards are ready:
- Create a small red circle with "!" 
- Position at top-right corner of the building card
- (Moritz will add the logic to show/hide it)

---

#### ✅ Definition of Done
- [ ] Hub scene updated with visual building layout
- [ ] `BuildingCard.prefab` created
- [ ] 4 buildings displayed in 2x2 grid
- [ ] Currency display at top (Diamonds + Gold)
- [ ] Account level display
- [ ] Battle button at bottom (most prominent)
- [ ] AFK Chest has notification badge placeholder

---

---

### Issue #61: [UI] Create Research panel UI

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `ui`, `priority-medium`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create the research/tech tree panel where players unlock permanent bonuses!

---

#### 📝 Step-by-Step Instructions

**Step 1: Understand the Research Tree**

```
┌────────────────────────────────────────────────────┐
│           📜 RESEARCH LAB             [X]          │
│                                                    │
│                  [ATK BOOST]                       │
│                   Lv.2/10                          │
│                   +10% ATK                         │
│                      │                             │
│           ┌─────────┼─────────┐                   │
│           │                   │                   │
│      [AFK BOOST]        [RANGE BOOST]              │
│       Lv.1/10            Lv.0/10                   │
│       +5% AFK            🔒 Locked                 │
│           │                   │                   │
│           │                   │                   │
│    [AFK TIME+]          [SPEED BOOST]              │
│     Lv.0/10              Lv.0/10                   │
│     🔒 Locked            🔒 Locked                 │
│                                                    │
├────────────────────────────────────────────────────┤
│  Selected: ATK BOOST                               │
│  Current: +10% | Next Level: +15%                  │
│  Cost: 💎 500                                      │
│  ┌──────────────────────────────────────────────┐  │
│  │              UPGRADE                          │  │
│  └──────────────────────────────────────────────┘  │
└────────────────────────────────────────────────────┘
```

**Step 2: Create Research Node Prefab**

Create `ResearchNode.prefab`:

```
┌──────────────┐
│   [ICON]     │   ← Research icon (50x50)
│              │
│  ATK Boost   │   ← Name
│   Lv.2/10    │   ← Current/Max level
│   +10%       │   ← Current bonus
└──────────────┘
States:
- Locked (grayed out, lock icon)
- Available (glowing border, can upgrade)
- Maxed (gold border, "MAX" text)
```

**Step 3: Create the Tree Layout**

The research tree shows connections between nodes:
- Lines connect parent → child nodes
- Children are locked until parent reaches certain level

Create `ResearchPanel.prefab` with:
1. Header with title and close button
2. Scroll view for the tree (may need to scroll on small screens)
3. Node grid with connection lines
4. Bottom detail panel (shows selected node info)
5. Upgrade button

**Step 4: Create Research Types**

We need 5 research types for Phase 1:

| Research | Icon | Effect |
|----------|------|--------|
| ATK Boost | ⚔️ | +5% monster ATK per level |
| AFK Boost | 💤 | +10% AFK rewards per level |
| Range Boost | 🎯 | +0.5 monster range per level |
| Speed Boost | ⚡ | +5% attack speed per level |
| AFK Time+ | ⏰ | +1h max AFK time per level |

---

#### ✅ Definition of Done
- [ ] `ResearchPanel.prefab` created
- [ ] `ResearchNode.prefab` created
- [ ] Tree layout with 5 nodes
- [ ] Connection lines between nodes
- [ ] Node states: Locked, Available, Maxed
- [ ] Detail panel shows selected node info
- [ ] Upgrade button with cost display

---

---

### Issue #67: [UI] Create Endless mode UI

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `ui`, `priority-medium`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create a modified HUD for Endless/Survival mode that shows wave count (infinite), high score, and current run rewards.

---

#### 📝 Step-by-Step Instructions

**Step 1: Modify Battle HUD for Endless**

Create `EndlessHUD.prefab` (copy of BattleHUD with modifications):

```
┌────────────────────────────────────────────────────┐
│ Wave 47 🏆        [████████] 45/100    🪙 12,450  │
│ Best: 52               HP                 [2x]    │
│                                                    │
│          Current Run: 🪙 1,250  💎 50             │
└────────────────────────────────────────────────────┘
```

**Differences from normal HUD:**
1. Wave counter has NO maximum (just "Wave 47" not "Wave 47/10")
2. High score display ("Best: 52" or 🏆 trophy icon + number)
3. Current run rewards ticker (shows rewards earned this run)

**Step 2: Create Elements**

1. **Wave Counter (modified):**
   - Text: "Wave {0}" (no max)
   - Larger font for emphasis
   - Trophy icon next to it

2. **High Score Display:**
   - "Best: {highscore}"
   - Position below wave counter
   - Gold color if current wave > high score!

3. **Run Rewards Display:**
   - Horizontal layout at bottom of HUD
   - Gold icon + accumulated gold
   - Diamond icon + accumulated diamonds
   - Updates in real-time as you earn

**Step 3: Create Game Over Panel for Endless**

Create `EndlessGameOverPanel.prefab`:

```
┌────────────────────────────────────────────────────┐
│                                                    │
│               ☠️ GAME OVER ☠️                     │
│                                                    │
│              You reached Wave 47!                  │
│                                                    │
│         🏆 NEW HIGH SCORE! 🏆                      │
│            (Previous: 42)                          │
│                                                    │
│  ┌──────────────────────────────────────────────┐  │
│  │           RUN REWARDS                         │  │
│  │                                              │  │
│  │      🪙 12,450 Gold                          │  │
│  │      💎 50 Diamonds                          │  │
│  │      🔮 25 Evo Materials                     │  │
│  └──────────────────────────────────────────────┘  │
│                                                    │
│  ┌────────────────┐    ┌────────────────────────┐  │
│  │  CLAIM & EXIT  │    │    📺 WATCH AD +50%   │  │
│  └────────────────┘    └────────────────────────┘  │
│                                                    │
└────────────────────────────────────────────────────┘
```

---

#### ✅ Definition of Done
- [ ] `EndlessHUD.prefab` created
- [ ] Wave counter without maximum
- [ ] High score display
- [ ] Current run rewards display
- [ ] `EndlessGameOverPanel.prefab` created
- [ ] Shows final wave, high score comparison
- [ ] Shows all rewards earned
- [ ] Claim button and optional Ad button

---

---

### Issue #68: [UI] Create mode selection screen

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `ui`, `priority-medium`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create a screen where players choose between Campaign mode and Endless mode!

---

#### 📝 Step-by-Step Instructions

**Step 1: Design the Layout**

```
┌────────────────────────────────────────────────────┐
│           ⚔️ SELECT MODE ⚔️             [X]       │
│                                                    │
│  ┌──────────────────────────────────────────────┐  │
│  │                                              │  │
│  │          📜 CAMPAIGN                         │  │
│  │                                              │  │
│  │      Progress: Map 1 - Wave 7/10             │  │
│  │      "Defeat the goblin horde!"              │  │
│  │                                              │  │
│  │            [CONTINUE]                        │  │
│  │                                              │  │
│  └──────────────────────────────────────────────┘  │
│                                                    │
│  ┌──────────────────────────────────────────────┐  │
│  │                                              │  │
│  │          ♾️ ENDLESS MODE                     │  │
│  │                                              │  │
│  │      🏆 High Score: Wave 52                  │  │
│  │      "How far can you survive?"              │  │
│  │                                              │  │
│  │      🔒 Unlocks at Account Level 10          │  │
│  │      (Current: Level 7)                      │  │
│  │                                              │  │
│  └──────────────────────────────────────────────┘  │
│                                                    │
└────────────────────────────────────────────────────┘
```

**Step 2: Create Mode Card Prefab**

Create `ModeCard.prefab`:

```
┌──────────────────────────────────────────────────┐
│     [MODE ICON]                                  │
│                                                  │
│     MODE NAME                                    │
│                                                  │
│     Progress/HighScore info                      │
│     Description text                             │
│                                                  │
│            [PLAY BUTTON]                         │
│            or                                    │
│     🔒 Unlock requirement                        │
└──────────────────────────────────────────────────┘
```

**Step 3: Create the Screen**

1. Close button in header
2. Title: "Select Mode"
3. Two mode cards stacked vertically
4. Campaign card (always available)
5. Endless card (locked until level 10)

**Step 4: Card States**

**Campaign Card:**
- Always available
- Shows current progress (Map X, Wave Y/10)
- Play button says "Continue" if in progress, "Start" if new

**Endless Card:**
- Locked state: Gray, lock icon, shows unlock requirement
- Unlocked state: Colorful, shows high score, has Play button

---

#### ✅ Definition of Done
- [ ] `ModeSelectScreen.prefab` created
- [ ] `ModeCard.prefab` created
- [ ] Campaign mode card (always available)
- [ ] Endless mode card (can show locked state)
- [ ] Progress display for campaign
- [ ] High score display for endless
- [ ] Lock indicator with unlock requirement text

---

---

### Issue #69: [Map] Create 2 new campaign maps

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `assets`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

#### 🎯 Goal
Create 2 new battle maps with different path layouts and visual themes!

---

#### 📝 Step-by-Step Instructions

**Step 1: Map 2 - Forest Path**

```
  Forest Path (Top View):
  
            START
              │
    ┌─────────┘
    │
    │     ┌───────┐
    │     │       │
    └─────┘       │
                  │
    ┌─────────────┘
    │
    │
    ├─────────┐
    │         │
    │   END   │
```

Features:
- More winding than Map 1
- 8 monster placement slots (more than Map 1!)
- Forest/green theme
- Longer path = more time to kill enemies

**Step 2: Create Forest Path Scene**

1. File → New Scene → Save as `BattleScene_Forest.unity`
2. Copy camera and lighting setup from original BattleScene
3. Create ground with grass-green material
4. Design the winding path using tiles
5. Create 16-18 waypoints along the path
6. Create 8 monster slots at strategic positions
7. Add forest decorations (trees from Kenney kit or green cylinders)

**Step 3: Map 3 - Volcanic Ridge**

```
  Volcanic Ridge (Top View):
  
  START ────────────┐
                    │
                    │
              ┌─────┘
              │
              │
              │
              │
              │
              └───── END
```

Features:
- SHORTER path than Map 1!
- Only 4 monster placement slots (fewer options!)
- Volcanic/red-orange theme
- Enemies move faster or have fire resistance
- More challenging due to less time and fewer slots

**Step 4: Create Volcanic Ridge Scene**

1. File → New Scene → Save as `BattleScene_Volcano.unity`
2. Copy camera and lighting setup
3. Create ground with dark red/brown material
4. Add orange-tinted directional light for "hot" atmosphere
5. Design shorter, more direct path
6. Create 10-12 waypoints
7. Create only 4 monster slots (make placement crucial!)
8. Add lava pools as decoration (orange planes with emission)

**Step 5: Visual Themes**

**Forest Path Colors:**
- Ground: Dark green (40, 80, 40)
- Path: Light brown (160, 120, 80)
- Decorations: Green trees, rocks

**Volcanic Ridge Colors:**
- Ground: Dark red-brown (60, 30, 30)
- Path: Black rock (40, 40, 40)
- Decorations: Orange lava, ash particles

---

#### ✅ Definition of Done
- [ ] `BattleScene_Forest.unity` created
- [ ] Forest map has winding path with 16-18 waypoints
- [ ] Forest map has 8 monster slots
- [ ] Forest theme with green decorations
- [ ] `BattleScene_Volcano.unity` created
- [ ] Volcano map has short path with 10-12 waypoints
- [ ] Volcano map has only 4 monster slots
- [ ] Volcanic theme with red/orange decorations

---

---

### Issue #70: [Enemy] Create 5 new enemy types

**Assignee:** @User420-Bit  
**Labels:** `phase-1`, `data`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion  
**Blocked by:** #13 (EnemyConfigSO class must exist)

---

#### 🎯 Goal
Create 5 new enemy configurations with special abilities for more interesting gameplay!

---

#### 📝 Step-by-Step Instructions

**Step 1: Understand the New Enemies**

| Enemy | Special Ability | Counter Strategy |
|-------|-----------------|------------------|
| Slime | Splits into 2 smaller slimes on death | AoE attacks |
| Shielded Knight | Front shield blocks 50% damage | Attack from sides |
| Healer | Heals nearby enemies | Kill healers first! |
| Assassin | Invisible until attacked | AoE reveals them |
| Golem Boss | Huge HP, spawns on milestone waves | All-out attack |

**Step 2: Create Each Enemy Config**

Navigate to: `Assets/_Project/ScriptableObjects/Enemies/`

---

**Slime (Splitter)**
```
Filename: Slime_Config.asset
Display Name: Slime
Enemy Type: Splitter

═══ STATS ═══
Max HP:           80
Move Speed:       0.8  (slower than goblin)
Gold Reward:      12

═══ SPECIAL ═══
Splits On Death:  true
Split Count:      2     (creates 2 mini-slimes)
Mini Slime HP:    30    (each mini-slime has 30 HP)
Mini Slime Speed: 1.2   (mini-slimes are faster!)

═══ DESCRIPTION ═══
"A wobbly blob that splits into two smaller slimes when destroyed. Kill them all!"
```

---

**Shielded Knight (Armored)**
```
Filename: ShieldedKnight_Config.asset
Display Name: Shielded Knight
Enemy Type: Armored

═══ STATS ═══
Max HP:           200
Move Speed:       0.6
Gold Reward:      30

═══ SPECIAL ═══
Shield Block:     50%   (blocks 50% of frontal damage)
Shield Angle:     90    (degrees - front 90° is protected)

═══ DESCRIPTION ═══
"A heavily armored knight with a tower shield. Attack from the sides for full damage!"
```

---

**Healer (Support)**
```
Filename: Healer_Config.asset
Display Name: Healer
Enemy Type: Support

═══ STATS ═══
Max HP:           60    (fragile!)
Move Speed:       0.9
Gold Reward:      20

═══ SPECIAL ═══
Heal Amount:      10    (HP per second to nearby allies)
Heal Radius:      3.0   (affects enemies within this range)
Heal Interval:    2.0   (heals every 2 seconds)

═══ DESCRIPTION ═══
"A mystical healer that restores health to nearby enemies. Priority target!"
```

---

**Assassin (Stealth)**
```
Filename: Assassin_Config.asset
Display Name: Assassin
Enemy Type: Stealth

═══ STATS ═══
Max HP:           70
Move Speed:       1.5   (fast!)
Gold Reward:      25

═══ SPECIAL ═══
Invisible:        true
Reveal On Damage: true  (becomes visible when hit)
Stay Visible:     3.0   (stays visible for 3 seconds after hit)

═══ DESCRIPTION ═══
"A shadowy killer that's invisible to your monsters. AoE attacks can reveal them!"
```

---

**Golem Boss (Boss)**
```
Filename: GolemBoss_Config.asset
Display Name: Golem Boss
Enemy Type: Boss

═══ STATS ═══
Max HP:           1000  (MASSIVE!)
Move Speed:       0.3   (very slow)
Gold Reward:      100
Evo Material Drop: 5

═══ SPECIAL ═══
Is Boss:          true
Stomp Damage:     10    (damages base extra on arrival)
Knockback Resist: true  (immune to knockback)

═══ DESCRIPTION ═══
"An ancient stone golem of immense power. Focus all your monsters on this threat!"
```

**Step 3: Create Placeholder Prefabs**

| Enemy | Shape | Color | Extra |
|-------|-------|-------|-------|
| Slime | Sphere (squashed) | Green (100, 200, 100) | Wobbly look |
| Shielded Knight | Capsule + cube (shield) | Silver (180, 180, 180) | Shield on front |
| Healer | Tall capsule | White (230, 230, 255) | Glowing aura |
| Assassin | Low stretched cube | Dark purple (40, 20, 50) | Partially transparent |
| Golem Boss | LARGE cube | Brown (100, 80, 60) | 3x normal enemy size |

---

#### ✅ Definition of Done
- [ ] `Slime_Config.asset` created (splits on death)
- [ ] `ShieldedKnight_Config.asset` created (front shield)
- [ ] `Healer_Config.asset` created (heals allies)
- [ ] `Assassin_Config.asset` created (invisible)
- [ ] `GolemBoss_Config.asset` created (massive HP)
- [ ] Placeholder prefabs created for each
- [ ] Special ability fields defined in configs

---

---

## Phase 2 Issues (6 issues)

---

### Issue #82: [Pass] Create Battle Pass UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the Battle Pass screen showing free and premium reward tracks!

---

#### 📝 Step-by-Step Instructions

**Step 1: Understand the Layout**

```
┌────────────────────────────────────────────────────────────────┐
│                     ⭐ SEASON 1: DRAGON'S AWAKENING ⭐         │
│                         23 Days Remaining                       │
│                                                                 │
│  XP: ████████████░░░░  450/500         [BUY PREMIUM]           │
│                                                                 │
├─────────────────────────────────────────────────────────────────┤
│                                                                 │
│  PREMIUM  [🔒]   [🔒]   [🔒]   [🔒]   [🔒]   [🔒]              │
│   TRACK    💎     🐉     💎     🎨     💎     ⭐               │
│           100   Shard   200   Frame   300   Epic!              │
│                                                                 │
│  ─────── 1 ──── 2 ──── 3 ──── 4 ──── 5 ──── 6 ────► ──────     │
│                                                                 │
│   FREE    [✓]   [✓]   [!]   [ ]   [ ]   [ ]                   │
│   TRACK    🪙     🔮     🪙     🔮     🪙     💎               │
│          1000   25    2000   50    3000   50                   │
│                                                                 │
├─────────────────────────────────────────────────────────────────┤
│  MISSIONS                                              [View All]│
│  ────────────────────────────────────────────────────           │
│  ✓ Complete 5 waves     +50 XP        [CLAIMED]                 │
│  ○ Level up a monster   +30 XP        [████░░] 0/1              │
│  ○ Perform 3 summons    +100 XP       [██░░░░] 1/3              │
└─────────────────────────────────────────────────────────────────┘
```

**Step 2: Create the Main Elements**

1. **Header:**
   - Season name and icon
   - Days remaining countdown
   - XP progress bar with current/needed XP

2. **Buy Premium Button:**
   - Prominent button for upgrading to premium
   - Shows price (e.g., "$9.99")

3. **Reward Tracks (Scrollable Horizontally):**
   - Two rows: Premium (top) and Free (bottom)
   - Tier numbers in the middle
   - Each tier shows reward icon and amount

4. **Tier States:**
   - Locked: Gray, shows reward preview
   - Available: Glowing, "!" indicator
   - Claimed: Checkmark, slightly dimmed
   - Premium Locked: Lock icon overlay

5. **Missions Section:**
   - List of active missions
   - Progress bar for each
   - XP reward amount
   - Claim button when complete

**Step 3: Create Prefabs**

1. `BattlePassScreen.prefab` - Main screen
2. `BattlePassTier.prefab` - Single tier with reward
3. `BattlePassMission.prefab` - Mission row

---

#### ✅ Definition of Done
- [ ] `BattlePassScreen.prefab` created
- [ ] Season header with timer
- [ ] XP progress bar
- [ ] Dual track layout (Free + Premium)
- [ ] Horizontal scroll for tiers
- [ ] Tier states: Locked, Available, Claimed
- [ ] Buy Premium button
- [ ] Missions section with progress

---

---

### Issue #85: [Pass] Define Season 1 rewards

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `data`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Design all 40 tiers of rewards for Season 1 Battle Pass!

---

#### 📝 Step-by-Step Instructions

**Step 1: Reward Types Available**

| Type | Icon | Notes |
|------|------|-------|
| Gold | 🪙 | Soft currency |
| Diamonds | 💎 | Premium currency |
| Evo Materials | 🔮 | For evolution |
| Monster Shards | 🐉 | For gacha |
| Profile Frame | 🎨 | Cosmetic |
| Title | 📛 | Cosmetic |
| Exclusive Monster | ⭐ | Only from pass! |

**Step 2: Design Tier Rewards**

Fill out this table:

| Tier | FREE Reward | PREMIUM Reward |
|------|-------------|----------------|
| 1 | 🪙 1,000 Gold | 💎 50 Diamonds |
| 2 | 🔮 10 Evo Mats | 🐉 10 Common Shards |
| 3 | 🪙 1,500 Gold | 💎 75 Diamonds |
| 4 | 🔮 15 Evo Mats | 🐉 20 Common Shards |
| 5 | 🪙 2,000 Gold | 🎨 "Dragon Hunter" Frame |
| 6 | 💎 25 Diamonds | 🐉 5 Rare Shards |
| 7 | 🪙 2,500 Gold | 💎 100 Diamonds |
| 8 | 🔮 20 Evo Mats | 🐉 10 Rare Shards |
| 9 | 🪙 3,000 Gold | 💎 100 Diamonds |
| 10 | 💎 50 Diamonds | ⭐ Season Monster: "Ember Drake" |
| 11 | 🪙 3,500 Gold | 💎 125 Diamonds |
| 12 | 🔮 25 Evo Mats | 🐉 15 Rare Shards |
| 13 | 🪙 4,000 Gold | 💎 125 Diamonds |
| 14 | 🔮 30 Evo Mats | 🐉 20 Rare Shards |
| 15 | 💎 75 Diamonds | 🎨 "Fire Master" Frame |
| 16 | 🪙 4,500 Gold | 💎 150 Diamonds |
| 17 | 🔮 35 Evo Mats | 🐉 5 Epic Shards |
| 18 | 🪙 5,000 Gold | 💎 150 Diamonds |
| 19 | 🔮 40 Evo Mats | 🐉 10 Epic Shards |
| 20 | 💎 100 Diamonds | 📛 Title: "Dragonslayer" |
| 21-30 | (Similar escalation) | (Similar escalation) |
| 31-39 | (Peak rewards) | (Peak rewards) |
| 40 | 💎 200 Diamonds | ⭐ EXCLUSIVE: "Dragon Lord" (Legendary!) |

**Step 3: Reward Balance Guidelines**

- **Free Track Total Value:** ~50,000 Gold equivalent
- **Premium Track Total Value:** ~150,000 Gold equivalent (3x free!)
- **Premium Price:** $9.99 (should feel like great value)

**Step 4: Create Season Config Document**

Write out all 40 tiers in a spreadsheet or markdown table that Max can use to create the `SeasonConfigSO`.

---

#### ✅ Definition of Done
- [ ] All 40 tiers designed for both tracks
- [ ] Rewards escalate appropriately
- [ ] Milestone rewards at tiers 10, 20, 30, 40
- [ ] Exclusive cosmetics for premium
- [ ] Season-exclusive monster at tier 10 and 40
- [ ] Document ready for Max to implement

---

---

### Issue #89: [Shop] Create Shop UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the in-game shop for buying diamonds, bundles, and special offers!

---

#### 📝 Step-by-Step Instructions

**Step 1: Design the Layout**

```
┌────────────────────────────────────────────────────────────────┐
│           💎 SHOP 💎                                    [X]    │
│                                                                 │
│  ┌─────────┐ ┌─────────┐ ┌─────────┐                          │
│  │DIAMONDS │ │ BUNDLES │ │  DAILY  │   ← Tab buttons          │
│  └─────────┘ └─────────┘ └─────────┘                          │
│                                                                 │
├─────────────────────────────────────────────────────────────────┤
│                    💎 DIAMOND PACKS                             │
│                                                                 │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐  ┌──────────┐       │
│  │   💎60   │  │  💎330   │  │  💎720   │  │ 💎1500   │       │
│  │          │  │ +30 BONUS│  │+120 BONUS│  │+350 BONUS│       │
│  │  $0.99   │  │   $4.99  │  │   $9.99  │  │  $19.99  │       │
│  │          │  │  POPULAR │  │BEST VALUE│  │          │       │
│  └──────────┘  └──────────┘  └──────────┘  └──────────┘       │
│                                                                 │
│  ┌──────────────────────────────────────────────────────────┐  │
│  │    💎 4000 (+1000 BONUS)                                 │  │
│  │    $49.99                              [MEGA PACK]       │  │
│  └──────────────────────────────────────────────────────────┘  │
│                                                                 │
└─────────────────────────────────────────────────────────────────┘
```

**Step 2: Create Tab System**

Three tabs:
1. **Diamonds** - Currency packs
2. **Bundles** - Starter packs, value bundles
3. **Daily** - Rotating daily deals

**Step 3: Create Shop Item Card**

`ShopItemCard.prefab`:

```
┌──────────────────┐
│   💎 330         │  ← Main content (icon + amount)
│   +30 BONUS      │  ← Bonus text (if any)
│                  │
│    $4.99         │  ← Price
│                  │
│   [POPULAR]      │  ← Badge (optional)
└──────────────────┘
```

**Step 4: Create Badge Types**

| Badge | Color | Usage |
|-------|-------|-------|
| POPULAR | Blue | Most bought item |
| BEST VALUE | Gold | Best diamonds/$ ratio |
| LIMITED | Red | Time-limited offer |
| NEW | Green | New item |
| x2 VALUE | Purple | First-time purchase bonus |

**Step 5: Bundles Tab Design**

```
┌────────────────────────────────────────────────────────────────┐
│                      🎁 SPECIAL BUNDLES                        │
│                                                                 │
│  ┌──────────────────────────────────────────────────────────┐  │
│  │  🌟 STARTER BUNDLE (One-time purchase!)                  │  │
│  │                                                          │  │
│  │  💎 500 Diamonds                                         │  │
│  │  🐉 50 Rare Shards                                       │  │
│  │  🪙 10,000 Gold                                ┌────────────────────────────────────────────────────────────────┐
│                      🎁 SPECIAL BUNDLES                        │
│                                                                 │
│  ┌──────────────────────────────────────────────────────────┐  │
│  │  🌟 STARTER BUNDLE (One-time purchase!)                  │  │
│  │                                                          │  │
│  │  💎 500 Diamonds                                         │  │
│  │  🐉 50 Rare Shards                                       │  │
│  │  🪙 10,000 Gold                                

MaxeLBerger: continue

GitHub Copilot: ## Continuing Pharell's Issues (Issue #33 onwards)

---

### Issue #33: [Art] Create placeholder monster/enemy visuals (CONTINUED)

**Step 4: Create Monster Prefabs (continued)**

**Flame Imp:**
1. Create Sphere (GameObject → 3D Object → Sphere)
2. Scale: `(0.8, 0.8, 0.8)`
3. 
Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/Pharrel/pharrel_issues.md#1-1), lines 1 to 200

Searched for text `### Issue #` (`**/pharrel_issues.md`), 20 results

Searched for text `### Issue #` (`**/pharrel_issues.md`), 50 results

Read [](file:///c%3A/Users/maxih/Documents/Repositories/Idle-Monster-Evolution-TD/docs/Pharrel/pharrel_issues.md#9300-9300), lines 9300 to 9418

Now I can see what's in the file. Let me check the end of the file and find which issues are actually missing: 

Searched for regex `Issue #(97|99|105|111|112|116)` (`**/pharrel_issues.md`), no results

Now I know which issues are missing. Based on the original plan, Pharell has 29 issues. From the search, I can see the file contains issues:
- Phase 0: #8, #9, #10, #12, #14, #16, #17, #18, #19, #28, #29, #30, #31, #32, #33, #45, #46 (17 issues)
- Phase 1: #54, #55, #60, #61, #67, #68, #69, #70 (8 issues)
- Phase 2: #82, #85, #89 (3 issues - but #89 appears cut off)

**Missing Issues:**
- Phase 2: #97 (Create Event UI), #99 (Create first event content), #105 (Final UI/UX pass)
- Phase 3: #111 (Set up live-ops calendar), #112 (Create promotional assets), #116 (Iterate on economy)

## Plan: Complete Missing Pharell Issues (6 remaining)

Here are the detailed, vibe-coder-friendly instructions for Pharell's remaining 6 issues:

---

### Issue #97: [Events] Create Event UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the limited-time event UI that shows special challenges, event currency, and an event shop!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create the Event Screen Layout**

```
┌────────────────────────────────────────────────────────────────┐
│  🎃 MONSTER HUNT EVENT 🎃                               [X]   │
│                                                                │
│  ⏰ Time Remaining: 3d 14h 22m                                │
│  🎫 Event Tokens: 1,250                                       │
│                                                                │
├────────────────────────────────────────────────────────────────┤
│                                                                │
│  ┌────────┐ ┌────────┐ ┌────────┐                            │
│  │ STAGES │ │  SHOP  │ │ RANKS  │   ← Tab buttons            │
│  └────────┘ └────────┘ └────────┘                            │
│                                                                │
├────────────────────────────────────────────────────────────────┤
│                    EVENT STAGES                                │
│                                                                │
│  ┌──────────────────────────────────────────────────────────┐ │
│  │ Stage 1: Goblin Invasion           ⭐⭐⭐ CLEARED        │ │
│  │ Rewards: 50 Tokens, 500 Gold                      [PLAY] │ │
│  └──────────────────────────────────────────────────────────┘ │
│                                                                │
│  ┌──────────────────────────────────────────────────────────┐ │
│  │ Stage 2: Scout Swarm               ⭐⭐☆ 2/3 Stars      │ │
│  │ Rewards: 100 Tokens, 1000 Gold                    [PLAY] │ │
│  └──────────────────────────────────────────────────────────┘ │
│                                                                │
│  ┌──────────────────────────────────────────────────────────┐ │
│  │ Stage 3: Ogre Assault              🔒 LOCKED            │ │
│  │ Complete Stage 2 with 3 Stars to unlock                  │ │
│  └──────────────────────────────────────────────────────────┘ │
│                                                                │
└────────────────────────────────────────────────────────────────┘
```

**Step 2: Create Event Stage Card Prefab**

1. Create folder: `Assets/_Project/Prefabs/UI/Event/`
2. Create `EventStageCard.prefab`:

| Element | Description |
|---------|-------------|
| `StageName` | TextMeshPro - "Stage 1: Goblin Invasion" |
| `StarsDisplay` | 3 star images (filled/empty) |
| `StatusText` | "CLEARED" or "2/3 Stars" or "LOCKED" |
| `RewardPreview` | Icons + amounts for rewards |
| `PlayButton` | Button to start the stage |
| `LockOverlay` | Dark overlay shown when locked |

**Step 3: Create Event Shop Tab**

```
┌────────────────────────────────────────────────────────────────┐
│                    🛒 EVENT SHOP                               │
│                                                                │
│  Your Tokens: 🎫 1,250                                        │
│                                                                │
│  ┌───────────┐  ┌───────────┐  ┌───────────┐  ┌───────────┐  │
│  │   🐉      │  │   💎      │  │   🪙      │  │   ⭐      │  │
│  │  Shadow   │  │   100     │  │  5,000    │  │   Epic    │  │
│  │  Panther  │  │ Diamonds  │  │   Gold    │  │  Shards   │  │
│  │  Shards   │  │           │  │           │  │   x10     │  │
│  │   x50     │  │           │  │           │  │           │  │
│  │           │  │           │  │           │  │           │  │
│  │ 🎫 500   │  │  🎫 200   │  │  🎫 100   │  │  🎫 300   │  │
│  │  [BUY]   │  │   [BUY]   │  │   [BUY]   │  │   [BUY]   │  │
│  │  0/5     │  │   0/10    │  │   0/∞     │  │   0/3     │  │
│  └───────────┘  └───────────┘  └───────────┘  └───────────┘  │
│                                                                │
└────────────────────────────────────────────────────────────────┘
```

**Step 4: Create Event Shop Item Prefab**

1. Create `EventShopItem.prefab`:

| Element | Description |
|---------|-------------|
| `ItemIcon` | Image - the reward icon |
| `ItemName` | TextMeshPro - "Shadow Panther Shards" |
| `ItemAmount` | TextMeshPro - "x50" |
| `TokenCost` | Token icon + amount |
| `BuyButton` | Button |
| `PurchaseLimit` | TextMeshPro - "0/5" (bought/max) |
| `SoldOutOverlay` | Shown when limit reached |

**Step 5: Create Leaderboard Tab**

```
┌────────────────────────────────────────────────────────────────┐
│                    🏆 EVENT RANKINGS                           │
│                                                                │
│  Your Rank: #127                    Your Score: 15,400        │
│                                                                │
│  ┌──────────────────────────────────────────────────────────┐ │
│  │ 🥇 1. ProGamer2000              Score: 125,000           │ │
│  │ 🥈 2. MasterTD                  Score: 98,500            │ │
│  │ 🥉 3. DragonSlayer              Score: 87,200            │ │
│  │  4. CoolPlayer                  Score: 75,100            │ │
│  │  5. TowerKing                   Score: 68,000            │ │
│  │  ...                                                     │ │
│  │ 127. YOU ⬅                      Score: 15,400           │ │
│  └──────────────────────────────────────────────────────────┘ │
│                                                                │
│  🎁 Rank Rewards (Event End):                                 │
│  Top 10: Legendary Shards x50                                 │
│  Top 100: Epic Shards x30                                     │
│  Top 500: Rare Shards x20                                     │
│                                                                │
└────────────────────────────────────────────────────────────────┘
```

**Step 6: Create Leaderboard Entry Prefab**

1. Create `LeaderboardEntry.prefab`:

| Element | Description |
|---------|-------------|
| `RankNumber` | TextMeshPro - "1." or medal emoji for top 3 |
| `PlayerName` | TextMeshPro |
| `Score` | TextMeshPro |
| `HighlightBackground` | Shown for current player's entry |

**Step 7: Create All Prefabs**

Save these to `Assets/_Project/Prefabs/UI/Event/`:
- `EventScreen.prefab` (main panel)
- `EventStageCard.prefab`
- `EventShopItem.prefab`
- `LeaderboardEntry.prefab`

---

#### ✅ Definition of Done
- [ ] `EventScreen.prefab` with 3 tabs (Stages, Shop, Ranks)
- [ ] Event header with timer and currency display
- [ ] `EventStageCard.prefab` with stars, rewards, play button
- [ ] `EventShopItem.prefab` with purchase limits
- [ ] `LeaderboardEntry.prefab` for rankings
- [ ] All prefabs in `Assets/_Project/Prefabs/UI/Event/`

---

---

### Issue #99: [Events] Create first event content

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `data`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Design and create all the data for our first limited-time event: "Monster Hunt"!

---

#### 📝 Step-by-Step Instructions

**Step 1: Event Overview Document**

Create `Assets/_Project/ScriptableObjects/Events/MonsterHunt_Event/` folder

**Event Concept:**
- **Name:** Monster Hunt 🎃
- **Duration:** 7 days
- **Theme:** Hunt special "Golden" variants of enemies
- **Currency:** Monster Tokens 🎫

**Step 2: Create Event Stages**

Create these WaveConfigSO variants for the event:

| Stage | Name | Difficulty | Enemies | Token Reward |
|-------|------|------------|---------|--------------|
| 1 | Goblin Invasion | Easy | 20 Golden Goblins | 50 |
| 2 | Scout Swarm | Medium | 15 Golden Scouts, 5 Golden Goblins | 100 |
| 3 | Ogre Assault | Hard | 5 Golden Ogres, 10 Golden Scouts | 150 |
| 4 | Mixed Mayhem | Very Hard | Mix of all Golden enemies | 200 |
| 5 | Boss Rush | Extreme | 3 Giant Golden Ogres | 300 |

**Step 3: Create Event Enemies**

Create golden variants of enemies:

| Enemy | Config File | Changes from Base |
|-------|-------------|-------------------|
| Golden Goblin | `GoldenGoblin_Config.asset` | +20% HP, drops 2x gold, shiny material |
| Golden Scout | `GoldenScout_Config.asset` | +20% HP, drops 2x gold, shiny material |
| Golden Ogre | `GoldenOgre_Config.asset` | +20% HP, drops 2x gold, shiny material |
| Giant Golden Ogre | `GiantGoldenOgre_Config.asset` | 3x HP of normal Ogre, boss-sized |

**Step 4: Create Event Shop Rewards**

Create a document or ScriptableObject listing shop items:

| Item | Token Cost | Purchase Limit | Description |
|------|------------|----------------|-------------|
| Shadow Panther Shards x50 | 500 | 5 | Exclusive Epic monster |
| Diamonds x100 | 200 | 10 | Premium currency |
| Gold x5,000 | 100 | ∞ | Soft currency |
| Epic Shards x10 | 300 | 3 | Random epic monster |
| Evo Materials x50 | 150 | 5 | Evolution resources |
| Event Profile Frame | 1,000 | 1 | Exclusive cosmetic! |

**Step 5: Create Star Requirements**

For each stage, define 3-star requirements:

| Stage | ⭐ (1 Star) | ⭐⭐ (2 Stars) | ⭐⭐⭐ (3 Stars) |
|-------|------------|---------------|-----------------|
| 1 | Complete | Lose ≤30 HP | Lose 0 HP |
| 2 | Complete | Lose ≤50 HP | Lose ≤20 HP |
| 3 | Complete | Lose ≤70 HP | Lose ≤30 HP |
| 4 | Complete | Lose ≤80 HP | Lose ≤40 HP |
| 5 | Complete | Lose ≤90 HP | Lose ≤50 HP |

**Step 6: Create Leaderboard Rewards Document**

| Rank | Reward |
|------|--------|
| 1-10 | Legendary Shards x50, Event Frame (Gold), 1000 Diamonds |
| 11-50 | Legendary Shards x30, Event Frame (Silver), 500 Diamonds |
| 51-100 | Epic Shards x50, 300 Diamonds |
| 101-500 | Epic Shards x30, 150 Diamonds |
| 501-1000 | Rare Shards x50, 50 Diamonds |

**Step 7: Create Event ScriptableObject**

Create `MonsterHunt_EventConfig.asset`:

```
Event Name: Monster Hunt
Event ID: event_monster_hunt_001
Duration: 7 days
Start Date: (set by backend)
End Date: (set by backend)

Event Currency:
  - Icon: (token sprite)
  - Name: Monster Token
  
Stages: (reference the 5 stage configs)
Shop Items: (reference shop item configs)
Leaderboard Enabled: true
Rank Rewards: (reference rank rewards)
```

---

#### ✅ Definition of Done
- [ ] Event concept document created
- [ ] 5 event stage wave configs created
- [ ] 4 golden enemy variants created
- [ ] Event shop items defined (6 items)
- [ ] Star requirements documented
- [ ] Leaderboard rewards documented
- [ ] `MonsterHunt_EventConfig.asset` created
- [ ] All files in `Assets/_Project/ScriptableObjects/Events/MonsterHunt_Event/`

---

---

### Issue #105: [Polish] Final UI/UX pass

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `polish`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Review ALL UI screens and make sure they look consistent, are easy to use, and work well on mobile!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create UI Checklist**

Go through EVERY screen and check:

| Check | ✅ |
|-------|---|
| All buttons are large enough to tap (min 44x44 pixels) | |
| Text is readable (min 24pt for body, 36pt for headers) | |
| Colors have good contrast (dark text on light bg or vice versa) | |
| Important buttons are clearly highlighted (color/size) | |
| Close/Back buttons are in consistent positions | |
| Loading indicators exist for async operations | |
| Error states are handled (what if no internet?) | |

**Step 2: Screen-by-Screen Review**

Create a spreadsheet or document tracking each screen:

| Screen | Issues Found | Fixed? |
|--------|--------------|--------|
| Hub Panel | | |
| Battle HUD | | |
| Monster List | | |
| Monster Detail | | |
| AFK Popup | | |
| Summon Screen | | |
| Research Panel | | |
| Endless Mode UI | | |
| Mode Selection | | |
| Battle Pass | | |
| Shop | | |
| Event Screen | | |

**Step 3: Consistency Checks**

Verify these are consistent across ALL screens:

| Element | Standard |
|---------|----------|
| Primary Button Color | Green (same shade everywhere) |
| Secondary Button Color | Blue |
| Cancel/Close Button Color | Red or Gray |
| Font for Headers | (same font everywhere) |
| Font for Body | (same font everywhere) |
| Panel Background | Same dark semi-transparent |
| Border/Outline Style | Same thickness/color |
| Icon Size in Lists | Same size (e.g., 80x80) |
| Spacing/Padding | Consistent margins |

**Step 4: Mobile-Specific Checks**

| Check | ✅ |
|-------|---|
| Nothing is too close to screen edges (safe area) | |
| Buttons aren't too close together (finger-friendly) | |
| Scrollable areas have visible scroll indicators | |
| Portrait orientation works properly | |
| UI doesn't break on different aspect ratios (test 16:9, 18:9, 20:9) | |
| Text doesn't overflow containers | |

**Step 5: Add Missing Feedback**

Make sure the UI gives feedback for actions:

| Action | Feedback Needed |
|--------|-----------------|
| Button Press | Button scale/color change |
| Purchase | Confirmation popup |
| Error | Error message + explanation |
| Level Up | Celebration animation |
| Claim Reward | Reward fly to currency display |
| Not Enough Currency | Shake + "Not enough gold!" |

**Step 6: Add Confirmation Dialogs**

Create `ConfirmationPopup.prefab` for:
- Purchasing items (real money)
- Spending premium currency
- Leaving a battle early
- Resetting progress

```
┌────────────────────────────────────────┐
│                                        │
│    Are you sure you want to            │
│    purchase this item for $4.99?       │
│                                        │
│    ┌──────────┐    ┌──────────┐       │
│    │  CANCEL  │    │ CONFIRM  │       │
│    └──────────┘    └──────────┘       │
│                                        │
└────────────────────────────────────────┘
```

**Step 7: Document All Changes**

Create a "UI Polish Log" listing:
- What you changed
- Why you changed it
- Before/After screenshots (if possible)

---

#### ✅ Definition of Done
- [ ] All screens reviewed with checklist
- [ ] Consistency verified (colors, fonts, sizes)
- [ ] Mobile-specific issues fixed
- [ ] Feedback added for all actions
- [ ] Confirmation dialogs for important actions
- [ ] `ConfirmationPopup.prefab` created
- [ ] UI Polish Log document created

---

---

## Phase 3 Issues (3 issues)

---

### Issue #111: [Release] Set up live-ops calendar

**Assignee:** @User420-Bit  
**Labels:** `phase-3`, `live-ops`, `priority-high`  
**Milestone:** Phase 3 - Softlaunch

---

#### 🎯 Goal
Plan the first 4 weeks of game content after launch - events, banners, special offers!

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Live-Ops Calendar Document**

Create: `docs/live-ops/LiveOpsCalendar_Week1-4.md`

**Step 2: Plan Week 1 (Launch Week)**

| Day | Event/Content |
|-----|---------------|
| Day 1 (Launch) | Launch Celebration Event starts! |
| Day 1-7 | "Welcome Bundle" offer in shop (one-time, great value) |
| Day 1-7 | Login Bonus: 7-day rewards for returning each day |
| Day 3 | First Gacha Banner: Rate-up for "Thunder Beast" |
| Day 5 | Community Goal: All players work together for rewards |

**Week 1 Details:**

```markdown
## Week 1: Launch Celebration 🎉

### Launch Event (Days 1-7)
- Double Gold from all battles
- Double AFK rewards
- Special "Launch Token" currency
- Launch Event Shop with exclusive rewards

### Welcome Bundle ($4.99, one-time)
- 500 Diamonds
- 10,000 Gold
- 30 Rare Shards
- 1 Guaranteed Epic Monster

### 7-Day Login Bonus
Day 1: 100 Diamonds
Day 2: 5,000 Gold
Day 3: 20 Rare Shards
Day 4: 200 Diamonds
Day 5: 10,000 Gold
Day 6: 50 Evo Materials
Day 7: 500 Diamonds + 1 Epic Summon Ticket

### Thunder Beast Banner (Days 3-10)
- 50% increased chance for Thunder Beast
- Pity at 50 pulls (reduced from 90!)
```

**Step 3: Plan Week 2**

| Day | Event/Content |
|-----|---------------|
| Day 8 | Monster Hunt Event starts (from Issue #99) |
| Day 8-14 | "Monster Hunter Bundle" offer |
| Day 10 | New Monster teaser on social media |
| Day 12 | Mid-event bonus: 2x event tokens for 24h |

**Step 4: Plan Week 3**

| Day | Event/Content |
|-----|---------------|
| Day 15 | Monster Hunt Event ends, new banner starts |
| Day 15 | New Epic Monster "Shadow Panther" released! |
| Day 15-21 | Shadow Panther rate-up banner |
| Day 17 | "Collector's Bundle" offer |
| Day 19 | Double XP weekend |

**Step 5: Plan Week 4**

| Day | Event/Content |
|-----|---------------|
| Day 22 | "Endless Challenge" Event (high-score competition) |
| Day 22-28 | Leaderboard rewards for endless mode |
| Day 25 | Battle Pass Season 1 launches! |
| Day 26 | Battle Pass bundle offer |
| Day 28 | Teaser for next month's content |

**Step 6: Create Summary Visual**

```
┌─────────────────────────────────────────────────────────────────┐
│                    LIVE-OPS CALENDAR                            │
├─────────────────────────────────────────────────────────────────┤
│ WEEK 1    │ WEEK 2        │ WEEK 3        │ WEEK 4              │
├───────────┼───────────────┼───────────────┼─────────────────────┤
│ 🎉 Launch │ 🎃 Monster    │ 🐱 Shadow     │ ♾️ Endless          │
│ Event     │ Hunt Event    │ Panther       │ Challenge           │
│           │               │ Release       │                     │
├───────────┼───────────────┼───────────────┼─────────────────────┤
│ Thunder   │               │ Shadow        │ Battle Pass         │
│ Beast     │               │ Panther       │ Season 1            │
│ Banner    │               │ Banner        │ Launch              │
├───────────┼───────────────┼───────────────┼─────────────────────┤
│ Welcome   │ Monster       │ Collector's   │ Battle Pass         │
│ Bundle    │ Hunter Bundle │ Bundle        │ Bundle              │
└───────────┴───────────────┴───────────────┴─────────────────────┘
```

---

#### ✅ Definition of Done
- [ ] Calendar document created
- [ ] Week 1 fully planned (launch event, bundle, login bonus, banner)
- [ ] Week 2 fully planned (Monster Hunt event)
- [ ] Week 3 fully planned (new monster release)
- [ ] Week 4 fully planned (endless event, battle pass)
- [ ] Summary visual created
- [ ] Document reviewed with Max and Moritz

---

---

### Issue #112: [Marketing] Create promotional assets

**Assignee:** @User420-Bit  
**Labels:** `phase-3`, `assets`, `priority-medium`  
**Milestone:** Phase 3 - Softlaunch

---

#### 🎯 Goal
Create screenshots, graphics, and videos for the Google Play store listing!

---

#### 📝 Step-by-Step Instructions

**Step 1: Screenshot Requirements**

Google Play needs:
- **Minimum:** 2 screenshots
- **Recommended:** 8 screenshots
- **Size:** 1080x1920 (portrait) or 1920x1080 (landscape)
- **Format:** PNG or JPG

**Step 2: Plan Your Screenshots**

Take these 8 screenshots:

| # | Screenshot Content | Key Message |
|---|-------------------|-------------|
| 1 | Gameplay - monsters attacking enemies | "Epic Tower Defense Battles!" |
| 2 | Monster Collection screen | "Collect 50+ Unique Monsters!" |
| 3 | Monster Evolution (before/after) | "Evolve Your Monsters!" |
| 4 | Gacha/Summon screen with reveal | "Summon Legendary Creatures!" |
| 5 | AFK Rewards popup | "Earn Rewards While Away!" |
| 6 | Hub with buildings | "Build Your Monster Base!" |
| 7 | Battle Pass rewards | "Unlock Amazing Rewards!" |
| 8 | Boss battle (Wave 10 or event) | "Challenge Epic Bosses!" |

**Step 3: How to Take Good Screenshots**

1. **Clean up the UI** - Remove debug info, dev buttons
2. **Use good lighting** - Make sure the scene looks vibrant
3. **Show exciting moments** - Mid-action, explosions, rewards
4. **Add text overlays** - Short, punchy text (in editing software)
5. **Use consistent style** - Same font, colors, borders

**Step 4: Create Feature Graphic**

Google Play needs a **Feature Graphic**:
- Size: 1024x500 pixels
- Shows in the store listing header

Design it with:
- Game logo large and centered
- 2-3 cool monsters in dynamic poses
- Eye-catching background
- Tagline: "Collect • Evolve • Conquer!"

**Step 5: Create App Icon Variants**

For A/B testing, create 3 icon variants:
- **Icon A:** Main monster (Flame Imp) face close-up
- **Icon B:** Group of 3 starter monsters
- **Icon C:** Dramatic battle scene (zoomed out)

Icon size: 512x512 pixels

**Step 6: Create Short Video (Optional)**

30-second gameplay video showing:
- 0-5s: Logo + title
- 5-15s: Gameplay action (monsters fighting)
- 15-22s: Collection/Evolution
- 22-28s: Rewards/Summons
- 28-30s: Call to action "Download Now!"

**Step 7: Create Social Media Assets**

For Twitter/X, Instagram, Discord:
- Square format: 1080x1080
- Banner format: 1200x628

Content ideas:
- Character spotlights (one monster per post)
- "Coming Soon" teaser
- Launch announcement
- Update announcements

**Step 8: Organize Everything**

Create folder structure:
```
Assets/_Marketing/
  Screenshots/
    raw/           ← Original screenshots
    edited/        ← With text overlays
  FeatureGraphic/
  Icons/
  Video/
  Social/
```

---

#### ✅ Definition of Done
- [ ] 8 screenshots taken and edited
- [ ] Feature Graphic (1024x500) created
- [ ] 3 App Icon variants (512x512) created
- [ ] Short video recorded (optional)
- [ ] Social media assets created
- [ ] All assets organized in `Assets/_Marketing/`
- [ ] Assets reviewed with Max

---

---

### Issue #116: [Balance] Iterate on economy

**Assignee:** @User420-Bit  
**Labels:** `phase-3`, `balance`, `priority-high`  
**Milestone:** Phase 3 - Softlaunch

---

#### 🎯 Goal
Based on real player data from softlaunch, adjust game balance to make it more fun and fair!

---

#### ⏳ Prerequisites
Wait for Max to share analytics data from the softlaunch (Issue #114)

---

#### 📝 Step-by-Step Instructions

**Step 1: Understand the Metrics**

Max will provide data on:
- How far do players get before quitting?
- How long do players play per session?
- Where do players get stuck?
- How much gold/resources do players have?
- What % of players make a purchase?

**Step 2: Common Problems and Solutions**

| Problem | Symptom | Solution |
|---------|---------|----------|
| Too Hard | Players quit at Wave 3-4 | Reduce enemy HP, add more gold |
| Too Easy | Players beat all content in 1 day | Increase enemy scaling, reduce rewards |
| Gold Shortage | Players stuck, can't upgrade | Increase gold drops, reduce upgrade costs |
| Gold Overflow | Players have 100k+ gold, nothing to buy | Add new gold sinks, increase costs |
| AFK Too Slow | Players don't return because rewards are tiny | Increase AFK rates |
| AFK Too Fast | Players progress without playing | Reduce AFK rates, add caps |
| Gacha Too Stingy | F2P players have no good monsters | Reduce pity counter, add free summons |
| Gacha Too Generous | Everyone has all monsters quickly | Increase pity, reduce free summons |

**Step 3: Data Collection Spreadsheet**

Create a spreadsheet to track changes:

| Metric | Before | Target | After Change | Notes |
|--------|--------|--------|--------------|-------|
| Wave 5 completion rate | 45% | 70% | | |
| Average session length | 3 min | 8 min | | |
| D1 Retention | 30% | 40% | | |
| First IAP conversion | 2% | 5% | | |

**Step 4: How to Make Changes**

For most changes, you'll edit ScriptableObjects:

| What to Change | Which File |
|----------------|------------|
| Enemy HP | `EnemyConfigSO` files |
| Enemy speed | `EnemyConfigSO` files |
| Gold rewards | `EnemyConfigSO`, `WaveConfigSO` files |
| Monster stats | `MonsterConfigSO` files |
| Upgrade costs | (wherever Max defined them) |
| AFK rates | (wherever Max defined them) |
| Gacha rates | `GachaBannerConfigSO` files |

**Step 5: Test Your Changes**

After each change:
1. Play through Waves 1-10
2. Check if it feels better
3. Write down what you changed and why
4. Ask Moritz to playtest too

**Step 6: Use Remote Config (If Available)**

If Max set up remote config (Issue #77), some values can be changed WITHOUT updating the app:
- Ask Max which values are remote-configurable
- Changes take effect immediately for all players!

**Step 7: Document All Changes**

Create `docs/balance/SoftlaunchBalanceChanges.md`:

```markdown
# Softlaunch Balance Changes

## Change Log

### 2025-01-20 - Wave Difficulty Reduction
**Problem:** Only 45% of players completed Wave 5
**Change:** Reduced Ogre HP from 300 → 250
**Result:** Wave 5 completion increased to 62%

### 2025-01-21 - Gold Economy Buff
**Problem:** Players couldn't afford upgrades
**Change:** Increased gold drops by 20%
**Result:** Average player gold increased, more upgrades purchased
```

**Step 8: Iterate Weekly**

Balance is an ongoing process:
1. Make 1-2 small changes
2. Wait a few days for data
3. Review the impact
4. Repeat!

---

#### ✅ Definition of Done
- [ ] Received and reviewed analytics data from Max
- [ ] Identified top 3 problems to fix
- [ ] Made at least 3 balance changes
- [ ] Documented all changes with before/after data
- [ ] Playtested changes internally
- [ ] Changes deployed via app update or remote config
- [ ] Monitored impact for at least 3 days

---

---

## Summary: All 29 Pharell Issues

### Phase 0 (16 issues) ✅
- [x] #8: Download Kenney TD Kit
- [x] #9: Create LocalizationKeys
- [x] #10: Input System setup
- [x] #12: 3 monster configs
- [x] #14: 3 enemy configs
- [x] #16: 10 wave configs
- [x] #17: GameEvent SOs
- [x] #18: Variable SOs
- [x] #19: Battle map scene
- [x] #28: Hub panel prefab
- [x] #29: HUD prefab
- [x] #30: Monster list panel
- [x] #31: Monster detail panel
- [x] #32: AFK popup
- [x] #33: Placeholder visuals
- [x] #45: Tune wave difficulty
- [x] #46: Tune monster stats

### Phase 1 (8 issues) ✅
- [x] #54: 5 new monsters
- [x] #55: Summon screen UI
- [x] #60: Hub with buildings
- [x] #61: Research panel UI
- [x] #67: Endless mode UI
- [x] #68: Mode selection screen
- [x] #69: 2 new campaign maps
- [x] #70: 5 new enemy types

### Phase 2 (5 issues) ✅
- [x] #82: Battle Pass UI
- [x] #85: Season 1 rewards
- [x] #89: Shop UI
- [x] #97: Event UI ✅ (just completed)
- [x] #99: First event content ✅ (just completed)
- [x] #105: Final UI/UX pass ✅ (just completed)

### Phase 3 (3 issues) ✅
- [x] #111: Live-ops calendar ✅ (just completed)
- [x] #112: Promotional assets ✅ (just completed)
- [x] #116: Iterate on economy ✅ (just completed)

---

**All 29 Pharell issues are now fully documented!** 🎉
