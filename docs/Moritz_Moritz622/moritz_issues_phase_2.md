
# Moritz – Phase 2 Issues (Weeks 9–12)

Phase 2 is where your integration work shifts heavily into **monetization and live-ops**: Battle Pass logic, Shop logic & offers, Ads reward flows, and Event systems. Max focuses on core monetization services and config SOs; Pharrel builds the UI and content; you plug the **player-facing logic** into those services.

---

## Week 9 – Battle Pass

### Issue #83 – [Pass] Implement Battle Pass UI logic

**Assignee:** @Moritz622  |  **Labels:** phase-2, ui, priority-high  
**GitHub Issue Body (source):** "Implement Battle Pass UI logic."

#### Goal

Make the **Battle Pass screen** functional: it should display the Season track from `SeasonConfigSO`, show free vs premium rewards, reflect the player’s current pass XP/level, and allow the player to claim unlocked rewards.

#### Pre-requisites

- Max:
	- `SeasonConfigSO` and `IBattlePassService` are implemented (issues #80, #81).
	- Player data schema includes pass XP, pass level, and which rewards are already claimed.
- Pharrel:
	- Battle Pass UI prefab exists (issue #82) with tier list, progress bar, claim buttons, and premium pass purchase entry.
- Status:
	- **Blocked until** `IBattlePassService` exposes methods like `GetCurrentSeason()`, `GetPlayerPassState()`, and `ClaimReward(tierId, trackType)`.

#### Implementation Notes

- Create `BattlePassPanel` controller in `Assets/_Project/Scripts/UI/Pass/`.
- On open:
	- Ask `IBattlePassService` for the current season config and player state.
	- Instantiate UI rows/tiles for each tier using Pharrel’s prefab setup.
	- Mark tiers as locked, unlocked-but-unclaimed, or claimed, for both free and premium tracks.
- Claiming rewards:
	- When the player presses a Claim button, call `IBattlePassService.ClaimReward(...)`.
	- If successful, update UI state (e.g. grey out button, show "Claimed").
	- Rewards (currency, shards, cosmetics) are applied by the service itself.
- Progress display:
	- Show current pass level and XP progress bar.
	- Keep it in sync with events from gameplay (XP gain from core loop actions).

#### Definition of Done

- [ ] Battle Pass screen shows correct tiers and rewards for the current season.
- [ ] Free and premium tracks visually differentiate.
- [ ] Claiming unlocked rewards works, updates visual state, and cannot be repeated.
- [ ] Pass level and XP progress update correctly during play.

---

### Issue #84 – [Pass] Create pass missions system

**Assignee:** @Moritz622  |  **Labels:** phase-2, gameplay, priority-high  
**GitHub Issue Body (source):** "Create pass missions system."

#### Goal

Implement the **Battle Pass missions subsystem**: daily/weekly missions (e.g. "Clear 5 waves", "Do 3 summons") that grant Pass XP when completed, driving progression through the Pass.

#### Pre-requisites

- Max:
	- Data design for missions (likely a `PassMissionConfigSO`) and how they are stored (daily/weekly, reset timers).
	- `IBattlePassService` extensions or a dedicated `IPassMissionsService` interface.
- Status:
	- **Soft-blocked:** the exact mission types and numbers may not be final; implement a flexible system.

#### Implementation Notes

- Design a mission model:
	- Fields like `id`, `type` (e.g. ClearWaves, Summon, SpendGold), `targetValue`, `currentValue`, `rewardPassXp`, `resetType` (Daily/Weekly).
- Implement a `PassMissionsService` that:
	- Loads available missions for the current rotation.
	- Listens to gameplay events (waves completed, summons performed, gold spent) to increment mission progress.
	- Marks missions as complete and grants Pass XP via `IBattlePassService`.
	- Handles daily/weekly reset timestamps.
- UI integration:
	- Battle Pass screen should show missions list, progress bars, and a Claim button per mission.

#### Definition of Done

- [ ] Missions increment correctly when the player performs the required actions.
- [ ] Completing a mission grants the configured Pass XP and marks it as completed.
- [ ] Daily/weekly missions reset according to design.

---

## Week 10 – Shop & IAP

### Issue #90 – [Shop] Implement Shop UI logic

**Assignee:** @Moritz622  |  **Labels:** phase-2, ui, priority-high  
**GitHub Issue Body (source):** "Implement Shop UI logic."

#### Goal

Wire up the **Shop screen** so it reads available offers from the monetization backend, displays them in Pharrel’s UI, and reacts to button presses (buying soft-currency offers, IAP bundles, etc.).

#### Pre-requisites

- Max:
	- `ShopOfferConfigSO` defines the types of offers (hard currency packs, soft currency bundles, starter bundles, etc.) (issue #86).
	- Unity IAP integration and purchase flow exist (issues #87, #88).
	- A `ShopService` or similar exists to expose current offers and handle purchase requests.
- Pharrel:
	- Shop UI prefab (`ShopPanel`) with sections/tabs and offer cards is created (issue #89).
- Status:
	- **Blocked until** the Shop service exposes an API to list offers and trigger a purchase.

#### Implementation Notes

- Create `ShopPanel` controller in `Assets/_Project/Scripts/UI/Shop/`.
- On open:
	- Request the current list of offers from the Shop service.
	- Instantiate an offer card for each offer using Pharrel’s `ShopItemCard` prefab.
	- Bind title, price, rewards, tags (Daily, Weekly, Best Value, etc.).
- When the player presses Buy:
	- For IAP offers, call into the IAP/Shop service to start the purchase; show loading/feedback.
	- For soft-currency or free offers, apply them directly through the service.
- Handle results:
	- On success, show a confirmation popup and mark the offer as purchased/claimed if it is limited.
	- On failure, show an error message.

#### Definition of Done

- [ ] Shop lists all expected offers with correct data.
- [ ] Pressing Buy for any offer calls the underlying Shop/IAP service correctly.
- [ ] One-time offers cannot be bought repeatedly beyond their allowed count.
- [ ] UI handles network errors or purchase failures gracefully.

---

### Issue #91 – [Shop] Implement daily/weekly offers

**Assignee:** @Moritz622  |  **Labels:** phase-2, monetization, priority-medium  
**GitHub Issue Body (source):** "Implement daily/weekly offers."

#### Goal

Add support for **rotating daily and weekly offers** (e.g. discounted bundles, special packs) that appear in the Shop for a limited time and then change.

#### Pre-requisites

- Max:
	- Shop backend design supports daily/weekly rotations (in Supabase or other backend).
	- `ShopOfferConfigSO` indicates which offers are daily/weekly and their rotation rules.
- Status:
	- **Soft-blocked:** final rotation rules might change; keep logic data-driven.

#### Implementation Notes

- Extend the Shop service to understand offer lifetimes:
	- Each offer has fields like `rotationType` (Daily/Weekly/Static) and `startUtc`/`endUtc`.
	- Use device or server time to compute whether an offer is active.
- When requesting offers for display:
	- Filter out any offers that are not active.
	- Sort active offers so daily/weekly ones appear in their own sections.
- Handle rotation:
	- When the rotation boundary is crossed (e.g. at midnight), refresh offers from remote config or backend.
	- Make sure UI updates without requiring an app restart.

#### Definition of Done

- [ ] Daily and weekly offers appear only during their configured time windows.
- [ ] After the rotation boundary, a new set of offers appears.
- [ ] Expired offers cannot be purchased anymore, even if their card is still visible (guard in service).

---

## Week 11 – Ads & Events

### Issue #94 – [Ads] Implement ad reward flow

**Assignee:** @Moritz622  |  **Labels:** phase-2, monetization, priority-high  
**GitHub Issue Body (source):** "Implement ad reward flow."

#### Goal

Implement the **Rewarded Ads flow**: when the player taps a rewarded placement (e.g. "Double AFK rewards" or "Get extra gold"), an ad is shown via the ad SDK, and if it completes, the appropriate reward is granted.

#### Pre-requisites

- Max:
	- Ad SDK integration is in place (Unity Ads / AdMob) and exposes callbacks (issue #93).
	- A mapping of placement IDs to reward types/amounts is defined.
- Moritz:
	- Access to `IAFKRewardService`, `PlayerDataSO`, and currency variables.
- Status:
	- **Blocked until** basic ad integration is working. You can still build a fake adapter for testing the reward flow.

#### Implementation Notes

- Design a small `IAdRewardService` wrapper that:
	- Starts an ad for a given `placementId`.
	- Exposes events or callbacks for OnAdCompleted, OnAdSkipped, OnAdFailed.
- For each placement (e.g. AFK Double, Bonus Gold):
	- Define what reward to give when the ad completes.
	- Implement a simple handler that calls into AFK/PlayerData to grant rewards.
- UI integration:
	- Add buttons in relevant UIs (AFK popup, maybe Battle result) that call `ShowRewardedAd("placementId")`.
	- Disable buttons or show cooldowns as needed to avoid abuse.

#### Definition of Done

- [ ] Tapping a rewarded ad button triggers the ad, and on completion, the correct reward is granted.
- [ ] Skipped or failed ads do **not** grant rewards.
- [ ] Analytics events are logged for ad impressions and rewards.

---

### Issue #96 – [Events] Implement IEventService

**Assignee:** @Moritz622  |  **Labels:** phase-2, live-ops, priority-high  
**GitHub Issue Body (source):** "Implement IEventService."

#### Goal

Create an **Event Service** that manages live events (e.g. "Slime Invasion"): it knows which events are currently active, exposes them to the UI, tracks player progress within an event, and hands out event rewards.

#### Pre-requisites

- Max:
	- `EventConfigSO` defines event metadata, goals, rewards, and schedule (issue #95).
	- `IEventService` interface is declared.
- Pharrel:
	- Event UI and first content (e.g. "Slime Invasion" assets) are created (issues #97, #99).
- Status:
	- **Soft-blocked:** the event types and schedule may evolve, but you can still build a generic event engine.

#### Implementation Notes

- Implement `EventService : IEventService` in `Assets/_Project/Scripts/Core/Events/`.
- Responsibilities:
	- Load the list of possible events from `EventConfigSO` assets.
	- Based on time and/or server flags, determine which events are currently active.
	- Track player progress per event (e.g. number of waves cleared, enemies killed, AFK claimed) in `PlayerDataSO`.
	- Support claiming event rewards when goals are met.
- Integration:
	- Event UI asks `IEventService` for the list of active events and their progress.
	- Gameplay hooks (waves, kills, etc.) call into `IEventService` to update progress.

#### Definition of Done

- [ ] Game can list currently active events with their names, timers, and goals.
- [ ] Player progress within at least one event is tracked and visible.
- [ ] Event rewards can be claimed and do not re-trigger once claimed.

---

### Issue #98 – [Events] Implement Event UI logic

**Assignee:** @Moritz622  |  **Labels:** phase-2, ui, priority-high  
**GitHub Issue Body (source):** "Implement Event UI logic."

#### Goal

Make the **Events screen** functional: it should display all active events, show their progress and remaining time, and allow the player to claim rewards.

#### Pre-requisites

- Pharrel:
	- Event panel UI (`EventPanel`, `EventCard` prefabs) is created (issue #97).
	- First event content (e.g. "Slime Invasion" icon, description) exists (issue #99).
- Moritz:
	- `IEventService` from issue #96 returns active events and progress.
- Status:
	- **Blocked until** `IEventService` is at least stubbed; you can still mock data in the UI controller.

#### Implementation Notes

- Create `EventPanelController` in `Assets/_Project/Scripts/UI/Events/`.
- On open:
	- Ask `IEventService` for the list of active events.
	- For each event, instantiate an `EventCard` and bind:
		- Name, description, icon.
		- Progress (e.g. "3 / 10 waves cleared").
		- Remaining time until event ends.
	- If no events are active, show a friendly "No events right now" state.
- Reward claiming:
	- If an event is completed but its reward not yet claimed, show a Claim button.
	- On click, call `IEventService.ClaimReward(eventId)` and update card state.

#### Definition of Done

- [ ] Events panel accurately lists all active events and their basic info.
- [ ] Progress bars or text update correctly as the player plays relevant content.
- [ ] Claiming event rewards works and the UI reflects claimed state.

