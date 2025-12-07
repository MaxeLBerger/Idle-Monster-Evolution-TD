# Phase 0 – Interface-First Scaffolding (Unity + VContainer)

This document defines the initial interface contracts, ScriptableObject data, and DI registrations for the Phase 0 vertical slice (waves, game state, monster placement, projectile pooling). Implement these in Unity 2022/2023 LTS following the project’s Copilot instructions.

## Namespaces & Assemblies
- Core services/interfaces: `IdleMonsterTD.Core`
- Gameplay services/interfaces: `IdleMonsterTD.Gameplay`
- UI: `IdleMonsterTD.UI`

Recommended Unity folder structure:
```
Assets/
  IdleMonsterTD.Core/
    Scripts/
      Services/
        ICloudSaveService.cs
        IRemoteConfigService.cs
        Pooling/IPoolingService.cs
      ScriptableObjects/
        Variables/
        Events/
  IdleMonsterTD.Gameplay/
    Scripts/
      Waves/IWaveManager.cs
      State/IGameStateService.cs
      Placement/IMonsterPlacementService.cs
    ScriptableObjects/
      WaveConfigSO.cs
      MonsterConfigSO.cs
      ProjectileConfigSO.cs
  IdleMonsterTD.DI/
    Scripts/
      GameLifetimeScope.cs
```
Use assembly definition files per top-level folder to keep code modular and testable.

## Interfaces (Contracts)

### IPoolingService (Core)
```csharp
namespace IdleMonsterTD.Core.Pooling
{
    public interface IPoolingService
    {
        T Get<T>() where T : class;
        void Release<T>(T instance) where T : class;
        void WarmUp<T>(int count) where T : class;
    }
}
```

### IGameStateService (Gameplay.State)
```csharp
namespace IdleMonsterTD.Gameplay.State
{
    public interface IGameStateService
    {
        void SetPaused(bool paused);
        bool IsPaused { get; }
        void SetSpeed(float multiplier);
        float Speed { get; }
    }
}
```

### IWaveManager (Gameplay.Waves)
```csharp
namespace IdleMonsterTD.Gameplay.Waves
{
    public interface IWaveManager
    {
        void StartWave(int waveIndex);
        void EndWave();
        int CurrentWaveIndex { get; }
    }
}
```

### IMonsterPlacementService (Gameplay.Placement)
```csharp
namespace IdleMonsterTD.Gameplay.Placement
{
    public interface IMonsterPlacementService
    {
        bool CanPlaceMonster(string monsterId, int gridX, int gridY);
        void PlaceMonster(string monsterId, int gridX, int gridY);
    }
}
```

### Backend-facing (Core.Services)
Stub now; implement later:
```csharp
namespace IdleMonsterTD.Core.Services
{
    public interface ICloudSaveService
    {
        void Save(string userId, string payloadJson);
        string Load(string userId);
    }

    public interface IRemoteConfigService
    {
        string GetValue(string key, string env);
    }
}
```

## ScriptableObjects (Data)
- `WaveConfigSO`: list of enemy entries per wave.
- `MonsterConfigSO`: base stats, cost, allowed grid types.
- `ProjectileConfigSO`: speed, damage, lifetime, pooling key.
- Event SOs: `GameEvent` (wave start/end, monster placed).
- Variable SOs: `GoldVariable`, `WaveIndexVariable`, `GameSpeedVariable`.

Keep SOs lightweight and validated (guard missing refs with `Debug.LogError`).

## VContainer DI Registration (GameLifetimeScope)
- Register interfaces to concrete implementations within `GameLifetimeScope`.
- Inject services via constructors or `[Inject]` fields (MonoBehaviours created by VContainer only).
- No singletons, no `FindObjectOfType`/`Resources.Load` in runtime logic.

Example (pseudo):
```csharp
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        // Core
        builder.Register<PoolingService>(Lifetime.Singleton).As<IdleMonsterTD.Core.Pooling.IPoolingService>();
        builder.Register<CloudSaveService>(Lifetime.Singleton).As<IdleMonsterTD.Core.Services.ICloudSaveService>();
        builder.Register<RemoteConfigService>(Lifetime.Singleton).As<IdleMonsterTD.Core.Services.IRemoteConfigService>();

        // Gameplay
        builder.Register<GameStateService>(Lifetime.Singleton).As<IdleMonsterTD.Gameplay.State.IGameStateService>();
        builder.Register<WaveManager>(Lifetime.Singleton).As<IdleMonsterTD.Gameplay.Waves.IWaveManager>();
        builder.Register<MonsterPlacementService>(Lifetime.Singleton).As<IdleMonsterTD.Gameplay.Placement.IMonsterPlacementService>();
    }
}
```

## PR Workflow & Acceptance Checklist
For each feature PR into `dev`:
- Relates to `#<issue>` (use Closes only when done).
- Includes:
  - Interfaces and minimal concrete impls.
  - DI registrations in `GameLifetimeScope`.
  - SO definitions and sample assets (if applicable).
  - Manual test plan for `DevTestScene` (how to verify basic flows).
- Meets constraints:
  - No singletons; DI-only.
  - No runtime object lookups; use injected refs/SO.
  - No allocations in hot paths; pooling for projectiles/enemies.

## Manual Test Plan (DevTestScene)
- Place a monster on a valid grid; verify placement service validates and spawns.
- Start a wave via `IWaveManager`; enemies spawn based on `WaveConfigSO`.
- Fire projectiles; pooling service reuses instances; verify no allocations per frame.
- Pause/resume via `IGameStateService`; speed adjustments affect enemy/projectile movement.

## Notes
- Backend integration (Supabase) should route through `ICloudSaveService`/`IRemoteConfigService`; never embed keys or call SDKs directly from gameplay.
- Add analytics hooks only through approved interfaces; no PII.
