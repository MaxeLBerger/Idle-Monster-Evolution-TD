# Max's Issues (@MaxeLBerger) - Complete Index

## Overview

Max is responsible for **58 issues** across all 4 phases, focusing on:
- Architecture & DI infrastructure
- Core systems & services
- Backend integration (Supabase)
- Monetization systems
- Release management

---

## Issue Distribution

| Phase | Issues | Focus Areas |
|-------|--------|-------------|
| **Phase 0** | 20 issues | Unity setup, VContainer, core interfaces, factories, save/AFK systems |
| **Phase 1** | 14 issues | Gacha, Hub buildings, Endless mode, Supabase backend |
| **Phase 2** | 14 issues | Battle Pass, Shop/IAP, Ads, Events, Analytics |
| **Phase 3** | 10 issues | Release prep, Softlaunch, KPI monitoring, Global launch |

---

## Documentation Files

| File | Phase | Issues | Status |
|------|-------|--------|--------|
| [issues_phase_0.md](./issues_phase_0.md) | Phase 0 | #1-50 (Max: 20) | ✅ Complete |
| [issues_phase_1.md](./issues_phase_1.md) | Phase 1 | #51-79 (Max: 14) | ✅ Complete |
| [issues_phase_2.md](./issues_phase_2.md) | Phase 2 | #80-107 (Max: 14) | ✅ Complete |
| [issues_phase_3.md](./issues_phase_3.md) | Phase 3 | #108-122 (Max: 10) | ✅ Complete |

---

## Max's Issue Numbers by Phase

### Phase 0 (20 issues)
#1, #2, #3, #4, #5, #6, #7, #11, #13, #15, #20, #21, #22, #23, #39, #40, #47, #48, #49, #50

### Phase 1 (14 issues)
#51, #52, #53, #57, #58, #59, #65, #72, #73, #74, #75, #78, #79

### Phase 2 (14 issues)
#80, #81, #86, #87, #88, #92, #93, #95, #100, #101, #102, #103, #104, #106, #107

### Phase 3 (10 issues)
#108, #109, #110, #113, #114, #117, #119, #120, #121, #122

## Alignment Notes

### Shared Logging

- Phase 0 introduces a unified logging abstraction (`ILoggingService` / `LoggingService`) registered in VContainer.
- All systems in Phases 1–3 use `ILoggingService` instead of calling `Debug.Log*` directly, enabling consistent diagnostics across gameplay, backend, monetization, and live-ops.

### Global Balance Config

- `GlobalBalanceConfigSO` is a central ScriptableObject holding core tuning knobs:
	- AFK caps and base AFK income
	- Shard thresholds and evolution cost multipliers
	- Enemy difficulty and reward multipliers
	- High-level monetization curve parameters for gacha, shop, Battle Pass, VIP, and events
- Phase 1 gameplay systems (Gacha, Shards, Endless, Hub/Research) and Phase 2 monetization systems (Battle Pass, Shop, VIP, Events) read their tunables from this config (with remote config overrides) instead of hard-coded values.

### Analytics & Debug Panel

- Phase 2 adds an in-game analytics/debug panel that surfaces analytics events, A/B variants, and remote config values, and allows sending test events.
- Phase 3 softlaunch and post-launch workflows rely on this panel and dashboards to validate instrumentation and to safely roll out balance and monetization changes driven by `GlobalBalanceConfigSO` and remote config.
