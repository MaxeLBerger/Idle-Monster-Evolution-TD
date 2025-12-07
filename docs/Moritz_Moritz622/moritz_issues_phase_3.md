
# Moritz – Phase 3 Issues (Weeks 13–16)

Phase 3 is about **softlaunch operations and iteration**. Max drives store setup, crash reporting, analytics, and final decisions; Pharrel supports live-ops and economy tweaks; you focus on **player-facing support flows** and **implementing quick gameplay wins** based on data and feedback.

You have fewer issues here, but they are cross-cutting and require touching multiple systems.

---

## Weeks 14–15 – Softlaunch & Iteration

### Issue #115 – [Support] Handle user feedback

**Assignee:** @Moritz622  |  **Labels:** phase-3, testing, priority-high  
**GitHub Issue Body (source):** "Handle user feedback."

#### Goal

Create a **lightweight feedback handling pipeline** inside the game: collect in-app feedback reports (simple form), and wire them into whatever reporting/issue-tracking Max sets up (e.g. sending to backend, logging with analytics, or exporting to a file) so the team can respond quickly during softlaunch.

#### Pre-requisites

- Max:
	- Decision where feedback goes (Supabase table, external service, or just local logs).
	- Any required backend endpoints or database tables are created.
- Pharrel:
	- If we want an in-game feedback UI (optional), a basic feedback panel prefab is created.
- Status:
	- **Soft-blocked:** you can implement a local feedback logger and simple UI even before backend is fully wired.

#### Implementation Notes

- Implement a `FeedbackService` in `Assets/_Project/Scripts/Core/Support/`.
- Responsibilities:
	- Provide methods like `SubmitFeedback(string message, string category, string emailOptional)`.
	- Add automatic context: app version, device model, OS, current wave/progression, last error (if any).
	- Send feedback to backend (Supabase row insert / HTTP endpoint) or log to a local file that QA can extract.
- UI (if desired):
	- Add a small Feedback button in the settings menu.
	- Feedback panel with a text area, optional email field, and category dropdown.
	- On submit, call `FeedbackService.SubmitFeedback` and show a "Thanks for your feedback" message.
- Consider privacy and spam:
	- Do not collect sensitive personal data beyond what the user types.
	- Add simple rate limiting or cooldown if needed.

#### Definition of Done

- [ ] There is a clear way (UI or otherwise) for softlaunch testers to submit feedback.
- [ ] Feedback entries include helpful automatic context (build, device, progression snapshot).
- [ ] Feedback is stored somewhere Max can access (backend or file) and can be correlated with analytics/crash data.

---

### Issue #118 – [Iteration] Implement quick wins

**Assignee:** @Moritz622  |  **Labels:** phase-3, gameplay, priority-medium  
**GitHub Issue Body (source):** "Implement quick wins."

#### Goal

Based on **softlaunch data and feedback**, implement a set of **small, high-impact improvements** ("quick wins") that don’t require full redesigns: small balance tweaks, UI clarity improvements, extra feedback (SFX/VFX), or quality-of-life changes.

> This issue is intentionally open-ended. The concrete quick wins will be decided after we see real player data and feedback. Your job is to implement them cleanly and safely.

#### Pre-requisites

- Max:
	- Provides a curated list of specific quick-win tasks (e.g. in a Google Doc or GitHub checklist) based on analytics and feedback.
	- Confirms any risky changes (monetization, progression pacing) and their intended impact.
- Pharrel:
	- May provide updated assets or UI mocks for any visual/UI quick wins.
- Status:
	- **Blocked until** there is an agreed list of concrete quick-win items.

#### Implementation Notes

- Treat this as a **bucket of small sub-tasks**. For each quick win:
	- Write down a short description ("Increase AFK gold by ~10% for early levels", "Make Battle button more visible", "Add crit hit popups").
	- Identify which systems/files are affected (e.g. balance SOs, UI prefabs, services).
	- Implement the change with minimal risk, following established patterns.
	- Add or update tests where relevant (even if just simple play-mode checks or asserts).
- Typical examples (actual list will come from Max):
	- **Balance tuning**: Slightly adjust monster damage, enemy HP curves, AFK multipliers.
	- **UI clarity**: Better tooltips on confusing buttons, clearer reward numbers, highlight important CTAs.
	- **Feedback & juice**: Extra hit flash, more obvious AFK chest glow, subtle screen shake on boss death.
	- **QoL**: Auto-repeat last battle mode, confirmation dialogs for big spends.
- Keep a mini-changelog inside this issue or a separate doc listing:
	- What you changed.
	- Why you changed it (which feedback/data).
	- How to revert it if it backfires.

#### Definition of Done

- [ ] There is a checklist of concrete quick-win items agreed with Max and (optionally) Pharrel.
- [ ] All items on that list are implemented, reviewed, and tested.
- [ ] The team can clearly see in one place what changed and why.

