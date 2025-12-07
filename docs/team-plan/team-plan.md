## Team Plan – Idle Monster Evolution TD

High-level entry point for the whole project: what we are building, who does what, and where to find detailed plans and issues.

---

### Vision & Product

- **PRD:** See `docs/PRD/PRD_IdleMonsterEvolutionTD.md` for the full product requirements (core loop, monetization, target KPIs).
- **Goal:** Ship a mobile F2P Tower-Defense × Idle × RPG game with a sustainable hybrid monetization model (Gacha, Battle Pass, Shop/IAP, Rewarded Ads, Events).

---

### Team & Roles

| Role | GitHub | Focus |
|------|--------|-------|
| **Architecture & Monetization** | @MaxeLBerger | Unity project setup, DI (VContainer), core services, backend, monetization systems, quality lead |
| **Gameplay & Integration** | @Moritz622 | Enemy/monster components, wave & game state, UI wiring, analytics, remote config, events, support flows |
| **SO Data, UI & Live-Ops** | @User420-Bit | ScriptableObject data, placeholder art, UI prefabs, balance tuning, live-ops calendar, promo assets |
| **Additional Contributors** | (TBD) | Join on clearly scoped gameplay/UI/backend issues; follow `.github/copilot-instructions.md` and `team-workflow` |

For new contributors, see **“How to Join as a Contributor”** below.

---

### Phases & Milestones (High-Level)

| Phase | Milestone | Focus | Example Outcomes |
|-------|-----------|-------|------------------|
| **Phase 0 – Vertical Slice** (Weeks 1–4) | `Phase 0 - Vertical Slice` | Core TD gameplay, 3 monsters, 3 enemies, AFK, basic HUD/Hub | One map, 10 waves, offline AFK chest, monster level-up |
| **Phase 1 – Feature Expansion** (Weeks 5–8) | `Phase 1 - Feature Expansion` | Gacha, Hub meta, Endless, Supabase basics | Summon screen, research & building upgrades, endless mode, cloud save/auth |
| **Phase 2 – Monetization & Live-Ops** (Weeks 9–12) | `Phase 2 - Monetization` | Battle Pass, Shop/IAP, Rewarded Ads, Events, Analytics | Battle Pass S1, shop offers, rewarded ad placements, first live event, analytics funnels |
| **Phase 3 – Softlaunch** (Weeks 13–16) | `Phase 3 - Softlaunch` | Store listings, crash reporting, live-ops calendar, softlaunch iteration | Google Play listing, promo assets, live-ops plan, feedback loop, go/no-go decision |

Canonical issue list and milestone setup: `docs/team-plan/team-final-implementation.md`.

---

### Where To Find Detailed Plans

- **Per-Phase Design & Decisions**
  - `docs/Phasen/planning_Phase_0.md` – Vertical slice design & architecture decisions.
  - `docs/Phasen/planning_Phase_1.md` – Feature expansion (Gacha, Hub, Endless, basic backend).
  - `docs/Phasen/planning_Phase_2.md` (if present later) – Monetization & live-ops details.
  - `docs/Phasen/planning_Phase_3.md` – Softlaunch strategy & KPIs.

- **Per-Developer Issue Playbooks**
  - Max: `docs/Max_MaxeLBerger/issues_phase_0.md` .. `issues_phase_3.md`
  - Moritz: `docs/Moritz_Moritz622/mo_issues_phase_0.md` .. `mo_issues_phase_3.md`
  - Pharrel: `docs/Pharrel_User420-Bit/pharrel_issues_phase_0.md` .. `pharrel_issues_phase_3.md`

Each of these contains: **summary table/list, per-issue Goal, Pre‑requisites, Implementation Notes, Definition of Done**.

- **Global Issue & GitHub Configuration**
  - `docs/team-plan/team-final-implementation.md` – 122 issues, labels, milestones, project board setup, and gh CLI script.

- **Workflow & Collaboration**
  - `docs/team-plan/team-workflow` – Daily standups, code review rules, DevTestScene usage, branch strategy.

---

### How Work Flows Day-to-Day

- **Daily Standup (15 minutes)** – see `team-workflow` for agenda template.
- **Board-Driven:** Issues live on the GitHub project board (Backlog → Ready → In Progress → In Review → Done).
- **Per-Dev Playbooks:** Each dev pulls from their `issues_phase_X.md` file and keeps it in sync with issue status.
- **DevTestScene:** All new components/services should first be proven in `Assets/_Project/Scenes/DevTestScene.unity` before integrating into main scenes.

Operational details (branching, standups, reviews) are in `team-workflow`.

---

### How to Join as a Contributor

1. **Read First**
   - `docs/PRD/PRD_IdleMonsterEvolutionTD.md` – understand the game and monetization.
   - `.github/copilot-instructions.md` – coding style, architecture rules, VContainer patterns.
   - `docs/team-plan/team-workflow` – how we collaborate.

2. **Pick an Issue**
   - Go to the GitHub project board: "Idle Monster Evolution TD".
   - Filter by label (e.g. `gameplay`, `ui`, `backend`) and phase.
   - If you’re new, prefer **Phase 0/1 issues with `priority-medium` or `priority-low`** unless agreed otherwise.

3. **Branching**
   - Base your work on `dev`.
   - Create a feature branch: `feature/<issue-number>-short-description`, e.g. `feature/34-wave-manager`.

4. **Before Opening a PR**
   - Verify Definition of Done from the corresponding `issues_phase_X.md` file.
   - Test your change in `DevTestScene` (and in main scenes if applicable).
   - Check Console for errors/warnings.

5. **Pull Request**
   - Link the GitHub issue in the PR description ("Closes #NN").
   - Follow review rules in `team-workflow` (who needs to approve what).

---

### Quality & Testing

- **Manual Testing:** Each phase has explicit QA issues (`[QA]`); use those checklists.
- **Automated Testing (Planned):**
  - Unity Test Framework for core services (save, AFK, Gacha, Battle Pass, Shop, Events).
  - Simple CI (GitHub Actions) to run tests and build a headless Unity project.
  - Crash reporting integration to monitor softlaunch stability.

See `team-final-implementation.md` Phase 1–2 for the testing/CI/crash-report issues once created.
