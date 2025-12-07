## Phase 3 Issues for Pharell (@User420-Bit)

This file contains all Phase 3 issues assigned to Pharell, scoped to Softlaunch and Release work.

---

### Issue #111: [Release] Set up live-ops calendar

**Assignee:** @User420-Bit  
**Labels:** `phase-3`, `live-ops`, `priority-high`  
**Milestone:** Phase 3 - Softlaunch

---

#### 🎯 Goal
Create a simple, visual **live-ops calendar** (in Notion/Google Sheets or similar) that lists all planned events, Battle Pass seasons, and special offers for the **softlaunch period (first 4–8 weeks)**.

This is mostly an **organizational / design task**, not Unity coding. Think of it as preparing a clear schedule so everyone knows **what happens when** once the game is live.

---

#### 📝 Step-by-Step Instructions

**Step 1: Pick the Tool**
You can use any of these (ask Max which he prefers):
- Notion page (recommended)
- Google Sheets
- Excel in OneDrive / Google Drive

Create a new document called:  
`Idle Monster Evolution TD – Live Ops Calendar (Softlaunch)`

**Step 2: Create the Table Structure**

Create a table with columns like:

| Column | Example Value |
|--------|---------------|
| Week | Week 1 (Softlaunch) |
| Start Date | 2025-04-01 |
| End Date | 2025-04-07 |
| Feature | Battle Pass S1, Double AFK, Event "Slime Invasion" |
| Type | Event / Battle Pass / Offer / Update |
| Description | Short human-readable description |
| Rewards Focus | Gold / Evo Mats / Shards / Cosmetics |
| Monetization Hook | Pass / Shop / Ads / None |
| Status | Planned / Confirmed / Done |

**Step 3: Read PRD for Live-Ops Ideas**

Open the PRD (`PRD_IdleMonsterEvolutionTD.md`) and look for:
- Mentions of **Events**, **Battle Pass**, **Seasonal content**, **Daily challenges**, etc.

Use those as inspiration for what kind of events to schedule.

**Step 4: Plan First 4 Weeks of Softlaunch**

Fill the calendar for at least **4 weeks**, for example:

- **Week 1 – Launch Week**
	- Feature: Battle Pass Season 1 start
	- Event: "Welcome Week" login rewards
	- Offers: Starter Pack in Shop

- **Week 2 – Engagement Week**
	- Event: "Slime Invasion" (extra Slime enemies, bonus rewards)
	- Offers: Monster Growth Pack

- **Week 3 – Monetization Focus**
	- Event: Double AFK Rewards Weekend
	- Offers: Diamond bundles highlighted

- **Week 4 – Retention Focus**
	- Event: "Hero’s Trial" challenge map
	- Possibly: Start preparing for Season 2

You don’t need to be perfect; think of it as a **first draft** we can adjust later.

**Step 5: Mark Pharrel-Relevant Tasks**

In the calendar, mark which things likely need **art/UI/content work** from you, for example:
- Event banners / icons
- Shop offer art
- Event UI variations

You can add a column `Owner` or `Needs Assets` and tag yourself.

**Step 6: Share the Calendar**

When you’re done:
1. Make sure the file is shared with Max and Moritz (view/edit).
2. Paste the link into our internal doc or send it in Discord.

---

#### ✅ Definition of Done
- [ ] Live-ops calendar document created (Notion/Sheets/etc.)
- [ ] Columns for week, dates, feature, type, description, rewards, monetization hook, status
- [ ] At least 4 weeks of softlaunch content filled in
- [ ] Pharrel-relevant items clearly visible/marked
- [ ] Link shared with the team

---

---

### Issue #112: [Marketing] Create promotional assets

**Assignee:** @User420-Bit  
**Labels:** `phase-3`, `assets`, `priority-medium`  
**Milestone:** Phase 3 - Softlaunch

---

#### 🎯 Goal
Create a small set of **promo assets** that can be used for:
- Google Play store listing (placeholder graphics for now)
- Social media / Discord announcements

These don’t need to be perfect final marketing art – just **clean, consistent, game-themed visuals**.

---

#### 📝 Step-by-Step Instructions

**Step 1: Pick a Simple Design Style**

Use a simple, consistent style that matches our game:
- Bright colors, clean shapes (like our in-game UI)
- Clear, readable text

You can use tools like:
- Figma, Photopea, GIMP, Canva, or similar

**Step 2: Create Store Icon Concept (512×512)**

Create a square image (512×512 px):
- Simple background gradient (e.g., blue → purple)
- Central character/monster silhouette (one of our monsters)
- Optional: small TD path or enemies in the background

Name it: `icon_concept_v1.png`.

**Step 3: Create Feature Graphic Mock (1024×500)**

Create a wide banner (1024×500 px):
- Left side: game logo text: `Idle Monster Evolution TD`
- Right side: 2–3 monsters + enemies + a path
- Overlay tagline text: "Build. Evolve. Defend."

Name it: `feature_graphic_concept_v1.png`.

**Step 4: Create 2–3 Simple Screenshot Compositions**

Take actual screenshots from the game (once UI is ready), or mock them up:
- One showing **Battle Scene** with monsters and enemies
- One showing **Hub** with buildings and AFK chest
- One showing **Summon Screen** or **Battle Pass**

If real screenshots aren’t ready yet, you can create **fake compositions**:
- Use colored rectangles and UI mockups that match our current planning

Name them like:
- `screenshot_battle_mock_v1.png`
- `screenshot_hub_mock_v1.png`
- `screenshot_summon_mock_v1.png`

**Step 5: Export and Organize Assets**

Create folder in the repo (or shared drive):
`Assets/Marketing/Softlaunch/`

Save all files there with clear names.

**Step 6: Create a Short Readme/Notes File**

In the same folder, create `README_SoftlaunchAssets.md` with:
- List of all files
- Short description of each (what it’s for)
- Any ideas/suggestions you have for future improvements

---

#### ✅ Definition of Done
- [ ] One icon concept (512×512) created
- [ ] One feature graphic concept (1024×500) created
- [ ] 2–3 screenshot compositions (real or mocked) created
- [ ] All assets saved under `Assets/Marketing/Softlaunch/`
- [ ] README explaining each asset and its purpose
- [ ] Assets shared with Max for review

---

---

### Issue #116: [Balance] Iterate on economy

**Assignee:** @User420-Bit  
**Labels:** `phase-3`, `balance`, `priority-high`  
**Milestone:** Phase 3 - Softlaunch

---

#### 🎯 Goal
Work with Max and Moritz to run a **balance pass on the game economy** after softlaunch data starts coming in.

For you, this mainly means adjusting **ScriptableObject values** (rewards, costs, AFK rates, event rewards) in a safe, controlled way based on guidelines.

---

#### 📝 Step-by-Step Instructions

**Step 1: Collect Current Values**

Make a simple overview document (Notion/Markdown) listing:
- Monster upgrade costs (per level or tier)
- AFK reward rates
- Battle rewards (gold per wave/map)
- Event rewards (from your event content)
- Shop prices (diamond/gold amounts)

Name it something like:  
`Economy_CurrentValues_Softlaunch.md`

**Step 2: Talk to Max About Targets**

Ask Max for **target feels**, for example:
- How long should it take (in days) to:
	- Reach certain account levels
	- Unlock key features (Gacha, Endless, Events)
	- Evolve a monster to a specific stage

Write down these targets in your doc.

**Step 3: Identify Pain Points from Feedback/Data**

With Moritz/Max, look at:
- Player feedback (too grindy? too fast?)
- Which parts feel too easy/hard in your own playtests

Write bullets like:
- "Gold progression feels too slow after Map 2"
- "AFK rewards feel too low compared to active play"

**Step 4: Propose Concrete Value Changes**

For each pain point, propose **simple numeric changes**, for example:
- Increase AFK gold rate by +20%
- Reduce monster level-up cost for early levels by -15%
- Increase event rewards for "Slime Invasion" by +25%

Document proposals in your markdown:

| Area | Current | Proposed | Reason |
|------|---------|----------|--------|
| AFK Gold/hr | 100 | 120 | Make offline progress feel better |
| Map 2 Wave Reward | 50 | 70 | Too low vs difficulty |

**Step 5: Apply Changes in ScriptableObjects**

Carefully edit the relevant SOs:
- Monster upgrade cost tables
- AFK reward config
- Wave rewards
- Event reward SOs

After each small batch of changes:
- Save assets
- Do a quick in-editor test run to feel the difference

**Step 6: Keep a Simple Changelog**

In your markdown file, add a **changelog section**:
- Date
- What was changed (values and reason)

Example:
- `2025-04-10 – Increased AFK Gold/hr from 100→120, Map2 wave rewards 50→70`

---

#### ✅ Definition of Done
- [ ] `Economy_CurrentValues_Softlaunch.md` created with a clear overview
- [ ] Targets and problems discussed with Max/Moritz
- [ ] Concrete, documented proposals for value changes
- [ ] ScriptableObject values updated for AFK, rewards, and key costs
- [ ] Simple changelog kept of what changed and why
- [ ] Game feels noticeably smoother in early/mid progression (subjective but agreed by team)

---

---
