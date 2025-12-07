# Idle Monster Evolution TD – GitHub Copilot Instructions

These instructions tell GitHub Copilot exactly how to generate code for this project so that all developers (Max, Moritz, Pharrel, and contributors) push only high‑quality code.

Copilot: Always follow these rules unless a file explicitly documents an exception.

---

## 1. Tech Stack & Project Context

- Engine: Unity 2022/2023 LTS, mobile (Android first, then iOS).
- Language: C#.
- Patterns: Dependency Injection via VContainer, ScriptableObjects for data, interface‑driven design, pooling, event/variable SOs.
- Game type: Hybrid Idle / Tower Defense / RPG with strong monetization systems (Gacha, Battle Pass, Shop/IAP, Ads, Events).

Copilot MUST:

- Prefer Unity‑idiomatic, mobile‑friendly solutions.
- Avoid editor‑only APIs or experimental packages unless explicitly requested.

---

## 2. Architecture & Design Rules (MUST FOLLOW)

1. **Dependency Injection (VContainer)**
   - Always inject services via constructors or `[Inject]` fields in MonoBehaviours created by VContainer.
   - Do NOT introduce new singletons (`static Instance`, `DontDestroyOnLoad` managers, etc.).
   - New services MUST be defined as interfaces (`IServiceName`) and registered in `GameLifetimeScope` or appropriate child scopes.

2. **Interfaces & Boundaries**
   - Public behavior MUST go through interfaces (e.g., `ISaveService`, `IAFKRewardService`, `IGachaService`, `IBattlePassService`, `IEventService`, `IPoolingService`).
   - Do NOT reference concrete classes across layers when an interface exists.
   - When adding new systems, define:
     - An interface in the appropriate Core/Gameplay assembly.
     - A concrete implementation in an implementation folder.

3. **ScriptableObjects**
   - Use `*ConfigSO` for data (e.g., `MonsterConfigSO`, `EnemyConfigSO`, `WaveConfigSO`, `SeasonConfigSO`, `ShopOfferConfigSO`, `EventConfigSO`).
   - Use `GameEvent` and `*Variable` ScriptableObjects for decoupled events and runtime state.
   - Do NOT access PlayerPrefs or raw JSON directly from gameplay code; go through `ISaveService` or backend interfaces.

4. **No Hidden Dependencies**
   - Do NOT use `FindObjectOfType`, `FindAnyObjectByType`, `GameObject.Find`, or `Resources.Load` inside runtime logic.
   - All dependencies must be provided via DI, serialized fields, or ScriptableObject references.

5. **Pooling & Allocations**
   - Use `IPoolingService` / pooling patterns for projectiles, enemies, and other frequently spawned objects.
   - Avoid allocations in `Update`/`FixedUpdate` (no `new` in hot paths, avoid LINQ there).

---

## 3. Coding Style & Conventions

Copilot MUST follow these for all new or modified C# code:

1. **Naming**
   - Classes, structs, enums: `PascalCase`.
   - Interfaces: `IPascalCase` with `I` prefix.
   - Methods: `PascalCase`.
   - Fields: `camelCase` with `_` prefix for private instance fields (`_currentTarget`).
   - Constants: `PascalCase` or `SCREAMING_SNAKE_CASE` only when clearly constant.
   - ScriptableObjects: suffix with `SO` (e.g., `MonsterConfigSO`).

2. **Structure**
   - Order members: fields → properties → constructors → public methods → private methods.
   - Keep classes small and focused. If a class exceeds ~300 lines or has more than one clear responsibility, propose refactoring.

3. **Formatting**
   - Use spaces, not tabs.
   - 4‑space indentation.
   - Place braces on new lines (C# standard in this repo).

4. **Comments & Regions**
   - Avoid excessive comments; prefer clear naming.
   - Use `///` XML docs only for public APIs, services, or complex algorithms.
   - Do NOT auto‑generate noisy comments (e.g., "// Start is called before the first frame update").

---

## 4. Unity‑Specific Rules

1. **MonoBehaviours**
   - Keep MonoBehaviours thin; heavy logic goes into plain C# services or components injected via DI.
   - Avoid logic in constructors; use `Awake`, `OnEnable`, `Start`, or a DI `Initialize` method.
   - Prefer `SerializeField` for design‑time references instead of looking up objects at runtime.

2. **Update Loops**
   - Minimize `Update` usage; consider events, coroutines, or tick services when possible.
   - Never allocate lists, strings, lambdas, or LINQ queries inside `Update`/`FixedUpdate`/`LateUpdate`.

3. **ScriptableObject Events & Variables**
   - For cross‑system communication (e.g., wave start, monster placed, gold changed), use `GameEvent` SOs.
   - For global runtime values (gold, wave index, game speed), use `*Variable` SOs.
   - Copilot should wire UI to variables via listeners or injected services, not direct static access.

4. **Scenes & Prefabs**
   - Respect the DevTestScene usage: use it for isolated feature testing, not production flows.
   - Prefer prefab variants and configuration through SOs vs. hard‑coded values.

---

## 5. Quality & Testing Requirements

Copilot MUST bias toward testable, clean code.

1. **Testability**
   - New services and non‑trivial logic should be written so they can be covered by Unity Test Framework (edit mode or play mode tests).
   - Avoid direct static calls or Unity APIs in core domain logic; inject abstractions so tests can run without the engine where reasonable.
   - When adding non‑trivial logic, Copilot SHOULD also propose a matching Unity Test (edit/play mode) where feasible.

2. **Error Handling**
   - Fail fast on invalid configurations (e.g., missing ScriptableObject references) with clear error messages using `Debug.LogError`.
   - Prefer clear guards and early returns over broad `try/catch`.
   - Do NOT silently swallow exceptions.

3. **Definitions of Done (DoD)**
   - When generating code tied to a GitHub issue, ensure steps align with that issue’s Definition of Done from `max_issues_phase_X.md`, `mo_issues_phase_X.md`, or `pharrel_issues_phase_X.md`.
   - Include:
     - Integration with existing services/interfaces.
     - Basic manual test plan (e.g., how to verify in `DevTestScene`).

---

## 6. Monetization & Live‑Ops Constraints

1. **Fair Monetization**
   - Do NOT introduce hard pay‑to‑win mechanics that bypass core progression.
   - Gacha, Battle Pass, Shop, VIP, and Ads must respect pity systems, reasonable rewards, and voluntary ad viewing.

2. **Backend & Supabase**
   - All networked features (cloud save, analytics, remote config) must go through defined backend interfaces (e.g., `IBackendClient`, `ICloudSaveService`, etc., if present).
   - Do NOT embed credentials or secrets in code. Use environment variables or secure config as defined in the project.

3. **Analytics & A/B Testing**
   - When adding new features with measurable impact, provide hooks for analytics events (e.g., funnel steps, economy changes).
   - Keep event names consistent and documented.

4. **Async & Network Patterns**
   - Copilot MUST NOT use `async void` except for Unity event handlers; prefer `async Task`.
   - Prefer Unity coroutines or small async abstractions over scattering async code throughout MonoBehaviours.
   - Wrap backend calls in services (e.g., `IBackendClient`) instead of calling SDKs directly from MonoBehaviours.

---

## 7. What Copilot Should Avoid

Copilot MUST NOT:

- Add new singleton patterns or global static managers.
- Use `FindObjectOfType`, `GameObject.Find`, or `Resources.Load` in new code.
- Introduce hardcoded magic numbers where SO configs exist or are planned.
- Add large, generic utility classes unrelated to the current issue.
- Generate unused code, dead code, or commented‑out blocks as "alternatives".
 - Overusing `Debug.Log`; keep logs minimal and purposeful. Do not log sensitive data.
 - Using `Debug.Log` for permanent behavior; prefer structured, minimal logs or dedicated logging utilities.

If a legacy pattern exists in older code (e.g., a singleton), prefer introducing a DI‑friendly variant and migrating incrementally instead of copying the pattern.

---

## 8. Per‑Developer Focus (Max, Moritz, Pharrel)

Copilot should bias suggestions based on who is editing:

- **Max (Architecture, Monetization, Backend)**
  - Focus on clean interfaces, DI, robust services, and data models.
  - For monetization features (Gacha, Pass, Shop, Ads), prefer configurable SO‑driven systems and testable business logic.

- **Moritz (Gameplay, Integration, Components, Testing)**
  - Focus on clear gameplay components (`EnemyMovement`, `EnemyHealth`, `MonsterTargeting`, `WaveManager`, `GameStateService`).
  - Ensure integrations respect existing interfaces and SO events/variables.

- **Pharrel (UI, Assets, SO Data, Live‑Ops Content)**
  - Focus on clean prefab hierarchies, re‑usable UI components, and data‑driven content via SOs.
  - Avoid putting heavy logic into UI components; delegate to services or view‑models when needed.

For external contributors, keep suggestions conservative and well‑documented.

Copilot should keep namespaces aligned with assemblies: gameplay logic in `IdleMonsterTD.Gameplay`, UI in `IdleMonsterTD.UI`, and shared core abstractions in the appropriate Core assembly. Do not mix UI and gameplay concerns in the same namespace.

---

## 9. Documentation & Comments

When creating new systems or significant features Copilot should:

- Add a short summary at the top of key service classes explaining their role.
- Ensure public methods and interfaces have clear, concise XML docs if their behavior is non‑obvious.
- Keep comments focused on "why" rather than "what".
 - When generating implementation for a specific issue, reference that issue number in comments or TODOs sparingly and never leave TODOs without an issue link.

---

## 10. Security & Privacy

- Do NOT log sensitive data (emails, tokens, payment identifiers).
- Follow platform privacy requirements (GDPR, etc.) as defined in project docs.
- For analytics or crash reporting, only send anonymized or allowed fields.

---

## 11. When in Doubt

If multiple implementations are possible, Copilot should choose the one that:

1. Respects DI and existing interfaces.
2. Is easiest to test.
3. Minimizes allocations and complexity.
4. Fits the patterns used in similar existing files in this repo.

If the user’s inline instructions conflict with this file, prefer the user’s explicit instructions but keep architecture and quality rules in mind.
