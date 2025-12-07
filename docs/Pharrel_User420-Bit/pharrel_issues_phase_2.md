## Phase 2 Issues for Pharell (@User420-Bit)

This file contains all Phase 2 issues assigned to Pharell, copied 1:1 from `pharrel_issues.md` but scoped to Monetization work.

---

### Issue #82: [Battle Pass] Create Season 1 reward track UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the Battle Pass Season 1 reward track UI with a horizontal scroll of tiers.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Battle Pass Panel**
1. In HubScene Canvas, create new Panel
2. Name: `BattlePassPanel`
3. Full screen with header

**Step 2: Layout Sketch**

```
┌────────────────────────────────────────────────────────────┐
│  [←]                BATTLE PASS S1                     [?] │
├────────────────────────────────────────────────────────────┤
│   Season Ends In: 06d 14h 23m                             │
├────────────────────────────────────────────────────────────┤
│   XP: [██████████░░░░░░░░░░░░░░]  4,250 / 10,000          │
├────────────────────────────────────────────────────────────┤
│  Free Track                     Premium Track              │
│  ┌────────┐  ┌────────┐  ┌────────┐  ┌────────┐           │
│  │  Tier1 │  │  Tier2 │  │  Tier3 │  │  Tier4 │  ...      │
│  │  🪙100 │  │  🌟Key │  │  🧱Mat │  │  🧪XP  │           │
│  └────────┘  └────────┘  └────────┘  └────────┘           │
│  ┌────────┐  ┌────────┐  ┌────────┐  ┌────────┐           │
│  │  Tier1 │  │  Tier2 │  │  Tier3 │  │  Tier4 │  ...      │
│  │  💎 10 │  │  🐉Egg │  │  🧪XP  │  │  💎 50 │           │
│  └────────┘  └────────┘  └────────┘  └────────┘           │
│                                                            │
│   [ Unlock Premium Pass ]                                  │
├────────────────────────────────────────────────────────────┤
│   Selected Tier: 4                                         │
│   Free: 100 Gold                                           │
│   Premium: Phoenix Egg                                     │
│   Progress: Claimed / Not Claimed / Locked                │
└────────────────────────────────────────────────────────────┘
```

**Step 3: Create XP Bar**
1. Add XP bar at top (Slider or Image fill)
2. Text: `CurrentXPText` (e.g., "4,250 / 10,000")
3. Season timer text: `SeasonTimerText`

**Step 4: Create Reward Tier Prefab**

Create `BattlePassTier.prefab`:
```
BattlePassTier
├── Background (Image)
├── TierNumberText (TMP)
├── RewardIcon (Image)
├── RewardText (TMP - "100 Gold")
├── StatusBadge (Image - claimed/locked)
└── Button (for claim/select)
```

States:
- Locked: Gray, lock icon
- Available: Normal, highlight border
- Claimed: Dimmed with checkmark

**Step 5: Horizontal Scroll View**
1. Create Scroll View (horizontal)
2. Content has 2 rows: Free and Premium
3. Each row populates with `BattlePassTier` instances

**Step 6: Bottom Info Panel**
1. Shows selected tier info
2. Free reward text
3. Premium reward text
4. Claim button (if available)

**Step 7: Unlock Premium Button**
1. Button: `Button_UnlockPremium`
2. Text: "Unlock Premium Pass"
3. Moritz will wire this to purchase

**Step 8: Create Prefabs**
1. `BattlePassPanel.prefab`
2. `BattlePassTier.prefab`

---

#### ✅ Definition of Done
- [ ] `BattlePassPanel.prefab` created
- [ ] `BattlePassTier.prefab` created
- [ ] Horizontal scroll with at least 10 tiers visible
- [ ] Free and Premium rows
- [ ] XP bar and season timer displayed
- [ ] Selected tier info panel at bottom
- [ ] Unlock Premium button present

---

---

### Issue #85: [Shop] Create Shop screen UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the main Shop screen layout with tabs (Offers, Currency, Bundles).

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Shop Panel**
1. In HubScene Canvas, create Panel
2. Name: `ShopPanel`
3. Full screen

**Step 2: Layout Sketch**

```
┌────────────────────────────────────────────────────────────┐
│  [←]                      SHOP                        [?] │
├────────────────────────────────────────────────────────────┤
│  💎 1,250      🪙 45,000                                   │
├────────────────────────────────────────────────────────────┤
│  [Offers]   [Currency]   [Bundles]                        │
├────────────────────────────────────────────────────────────┤
│                                                            │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  🔥 LIMITED TIME PACK                                │  │
│  │  1x Phoenix Egg + 2,000 Gold                         │  │
│  │                                                      │  │
│  │  -80%  |  💰 $4.99                                   │  │
│  └──────────────────────────────────────────────────────┘  │
│                                                            │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  DAILY DIAMONDS                                      │  │
│  │  Get 300 💎 instantly + 30/day for 7 days           │  │
│  │                                                      │  │
│  │        💰 $9.99                                      │  │
│  └──────────────────────────────────────────────────────┘  │
│                                                            │
│  (more cards...)                                           │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

**Step 3: Create Top Bar**
1. Currency display (diamonds + gold)
2. Back button
3. Help button

**Step 4: Create Tab Buttons**
1. `Tab_Offers`, `Tab_Currency`, `Tab_Bundles`
2. Highlight selected tab (color or underline)

**Step 5: Content Area**
1. Add Scroll View for item cards
2. Vertical layout
3. Placeholder entries like above sketch

**Step 6: Create Prefab**
1. Save as `ShopPanel.prefab`

---

#### ✅ Definition of Done
- [ ] `ShopPanel.prefab` created
- [ ] Tabs for Offers/Currency/Bundles
- [ ] Currency display in header
- [ ] Scrollable area with placeholder cards
- [ ] Back + Help buttons

---

---

### Issue #89: [Shop] Create Shop item card prefab

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create a reusable Shop item card prefab used in `ShopPanel`.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Item Card**

Create `ShopItemCard.prefab`:
```
ShopItemCard
├── Background (Image - rounded rectangle)
├── Icon (Image - item icon)
├── TitleText (TMP - "LIMITED PACK")
├── DescriptionText (TMP - multi-line)
├── PriceContainer
│   ├── PriceText (TMP - "$4.99" or "💎 500")
│   └── OldPriceText (TMP - "$19.99", strikethrough, optional)
├── TagBadge (Image + TMP - "-80%" or "Best Value")
└── Button (whole card clickable)
```

**Step 2: Visual Style**
1. Background: dark panel with light border
2. Tag badge: bright color (orange/red)
3. Price: large, clear font

**Step 3: States**
- Normal: regular colors
- Highlighted: border glow
- Disabled: grayed out

**Step 4: Example Uses**

Create 3 example ShopItemCard instances in scene:
1. Limited Time Pack
2. Diamond Pack
3. Gold Pack

---

#### ✅ Definition of Done
- [ ] `ShopItemCard.prefab` created
- [ ] Includes icon, title, description, price, tag
- [ ] Button component on whole card
- [ ] Looks good in `ShopPanel` scroll view

---

---

### Issue #97: [Events] Create Event UI

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `ui`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the **Event UI** where players can see active events, read what they do, and claim rewards.

This should feel similar in quality to the Battle Pass and Shop screens: clean, readable, and mobile-friendly.

---

#### 📝 Step-by-Step Instructions

**Step 1: Create Event Panel**
1. In HubScene Canvas, create a new Panel
2. Name: `EventPanel`
3. Full-screen, with a header bar

**Step 2: Layout Sketch**

```
┌────────────────────────────────────────────────────────────┐
│  [←]                      EVENTS                      [?] │
├────────────────────────────────────────────────────────────┤
│  Active Events:                                           │
│                                                            │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  🎉 SLIME INVASION                                  │  │
│  │  Duration: 3d 12h                                   │  │
│  │  Defeat slimes to earn SLIME TOKENS and rewards!    │  │
│  │                                                      │  │
│  │  Progress:  45 / 100 Slimes                         │  │
│  │  Reward:   🪙 5,000  +  10 Evo Mats                  │  │
│  │                                                      │  │
│  │  [View Details]          [Claim] (disabled until 100)│  │
│  └──────────────────────────────────────────────────────┘  │
│                                                            │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  🔥 DOUBLE AFK WEEKEND                              │  │
│  │  Duration: 1d 18h                                   │  │
│  │  AFK rewards are doubled while this event is live.  │  │
│  │                                                      │  │
│  │  [View Details]                                     │  │
│  └──────────────────────────────────────────────────────┘  │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

**Step 3: Create Event Card Prefab**

Create `EventCard.prefab`:
```
EventCard
├── Background (Image - rounded rectangle)
├── Icon (Image - event icon)
├── TitleText (TMP - event name)
├── DurationText (TMP - remaining time)
├── DescriptionText (TMP - short description)
├── ProgressText (TMP - e.g., "45 / 100 Slimes")
├── RewardPreviewText (TMP - main reward)
├── Button_Details
├── Button_Claim (can be disabled)
└── LayoutGroup (for responsive layout)
```

**Step 4: Scroll View of Events**
1. Add a Vertical Scroll View to `EventPanel`
2. Content area will hold multiple `EventCard` instances
3. Use a VerticalLayoutGroup and ContentSizeFitter

**Step 5: Empty State**
If there are no active events, show:
```
"No events are active right now. Check back soon!"
```
Center this text in the panel.

**Step 6: Create Prefab**
1. Save `EventPanel` as `EventPanel.prefab` in `Assets/_Project/Prefabs/UI/`
2. Save `EventCard.prefab` in `Assets/_Project/Prefabs/UI/`

---

#### ✅ Definition of Done
- [ ] `EventPanel.prefab` created
- [ ] `EventCard.prefab` created
- [ ] Scrollable list of events works visually
- [ ] Each card shows title, duration, description, progress, rewards
- [ ] Details and Claim buttons present on each card
- [ ] Nice empty state when no events are active

---

---

### Issue #99: [Events] Create first event content

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `data`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Create the **data and basic visuals** for the first in-game event, matching the Event UI you built.

Think of it as filling the Event screen with one concrete, fully specified example event.

---

#### 📝 Step-by-Step Instructions

**Step 1: Decide the First Event Theme**
Use a simple, on-brand theme, for example:
- **"Slime Invasion"** – lots of Slime enemies appear, kill them for rewards.

**Step 2: Create Event ScriptableObject(s)**

In `Assets/_Project/ScriptableObjects/Events/`:
1. Create folder `Events` if it doesn’t exist
2. Create new SO: `SlimeInvasion_Event.asset`
3. Fill in fields (names will depend on what Max/Moritz define, but aim for):

```
Event ID:          slime_invasion
Display Name:      Slime Invasion
Description:       "Defeat as many slimes as you can during the event to earn bonus rewards!"
Start Offset:      0 days from softlaunch
Duration:          3 days

Goal Type:         KillCount
Goal Target:       100 (Slimes)

Reward:            5,000 Gold, 10 Evo Materials
Currency:          (if event tokens exist later, leave blank for now)
```

**Step 3: Connect to Enemy Types (Design Side)**
Make sure there is an enemy that represents "Slime" (from your earlier enemy configs). If not, write a small note for Max/Moritz:
- "Event expects an enemy type tagged as Slime for kill counting"

**Step 4: Create Simple Event Icon**

In `Assets/_Project/Art/Events/`:
1. Create folder `Events` if needed
2. Make a simple icon:
	- Green slime blob
	- White outline
	- Export as `icon_event_slime.png`

Link this icon in the Event SO (or note the path).

**Step 5: Fill Example Data in Event UI (Optional Wiring Notes)**

In your `EventPanel` mock (in a test scene):
1. Drop in one `EventCard`
2. Manually set:
	- Title: "Slime Invasion"
	- Duration: "3d 0h left" (placeholder)
	- Description: matches SO description
	- Progress: "0 / 100 Slimes" (placeholder)
	- Reward text: "5,000 Gold + 10 Evo Mats"

This gives Moritz a **clear visual reference** when he hooks the data.

**Step 6: Add Notes for Integration**

Create a small markdown file:  
`Assets/_Project/DesignNotes/Event_SlimeInvasion.md`

Include:
- Event name and ID
- What counts as "kills" (enemy type Slime)
- Reward breakdown
- Any UI hints (e.g., show small slime icon next to progress)

---

#### ✅ Definition of Done
- [ ] `SlimeInvasion_Event.asset` created with name, duration, goal, rewards
- [ ] Simple Slime event icon created and saved under Art/Events
- [ ] At least one `EventCard` example filled in scene as a reference
- [ ] Design notes markdown created explaining how the event should work
- [ ] Moritz knows where the SO and notes are

---

---

### Issue #105: [Polish] Final UI/UX pass

**Assignee:** @User420-Bit  
**Labels:** `phase-2`, `polish`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

#### 🎯 Goal
Do a **visual polish pass** on all major UI screens you created (Hub, Battle HUD, Summon, Shop, Battle Pass, Events) to make them feel more cohesive, readable, and satisfying.

No new features – just **visual/UX improvements**.

---

#### 📝 Step-by-Step Instructions

**Step 1: Make a Checklist of Screens**

Create a small checklist (on paper or in a markdown file) for:
- Hub panel
- Battle HUD / Endless HUD
- Monster List & Detail panels
- AFK popup
- Summon screen
- Shop screen + item cards
- Battle Pass UI
- Event Panel + Event Cards

**Step 2: Check Consistent Fonts & Sizes**

For each screen, look at:
- Title font sizes (e.g., all big titles use same size)
- Body text sizes (not too small on mobile)
- Button label sizes

Adjust TextMeshPro settings so similar elements use consistent values.

**Step 3: Check Colors & Contrast**

Make sure:
- Text is readable on all backgrounds
- Important buttons (e.g., "BATTLE!", "SUMMON", "BUY") use strong, consistent colors
- Disabled buttons look clearly disabled

If needed, create a simple color palette in a note, like:
- Primary: #3B82F6 (buttons)
- Accent: #F59E0B (special offers)
- Danger: #EF4444 (warnings)

**Step 4: Align & Space Elements**

Use layout groups and anchors where possible:
- Even spacing between cards
- Margins to screen edges
- Titles consistently aligned (e.g., centered or left-aligned)

Avoid hand-placing things pixel by pixel if a layout group solves it.

**Step 5: Add Small Feedback Animations (Optional)**

If time allows (and without adding heavy code):
- Use simple scale punch or color change on button click
- Use subtle fade-in for popups (AFK, Event, Battle Pass)

You can coordinate with Max if DOTween or animation tools are already set up.

**Step 6: Verify on Different Aspect Ratios**

In the Game view:
- Test 16:9, 18:9, and maybe tablet ratio
- Make sure nothing critical is cut off

---

#### ✅ Definition of Done
- [ ] All main UI screens reviewed using a checklist
- [ ] Fonts and sizes consistent across similar elements
- [ ] Colors readable and consistent with a simple palette
- [ ] Buttons and cards aligned and spaced nicely
- [ ] (Optional) Basic feedback animations on key buttons/popups
- [ ] Screens look good on at least 2–3 aspect ratios

---

---
