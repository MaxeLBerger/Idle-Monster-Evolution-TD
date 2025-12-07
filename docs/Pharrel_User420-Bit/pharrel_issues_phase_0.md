## Phase 0 Issues for Pharell (@User420-Bit)

This file contains all Phase 0 issues assigned to Pharell, copied 1:1 from `pharrel_issues.md` but scoped to Vertical Slice work.

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
