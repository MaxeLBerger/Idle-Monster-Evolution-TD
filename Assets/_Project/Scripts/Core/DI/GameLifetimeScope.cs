using UnityEngine;
using VContainer;
using VContainer.Unity;
using IdleMonsterTD.Core.Data;
using IdleMonsterTD.Core.Services;

namespace IdleMonsterTD.Core.DI
{
    /// <summary>
    /// Root dependency injection scope for the entire game.
    /// This is the composition root where all core services and configs are registered.
    /// Attach this to a GameObject in the Boot scene.
    /// </summary>
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Global Configuration")]
        [SerializeField] private GlobalBalanceConfigSO _globalBalanceConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            // ============ Core Services ============
            builder.Register<ILoggingService, LoggingService>(Lifetime.Singleton);
            builder.Register<IPoolingService, PoolingService>(Lifetime.Singleton);

            // ============ Configuration ScriptableObjects ============
            if (_globalBalanceConfig != null)
            {
                builder.RegisterInstance(_globalBalanceConfig);
            }
            else
            {
                Debug.LogError("[GameLifetimeScope] GlobalBalanceConfigSO is not assigned!");
            }

            // ============ Future Services (Phase 1+) ============
            // TODO: Register these services as they are implemented
            // builder.Register<ISaveService, SaveService>(Lifetime.Singleton);
            // builder.Register<IAFKRewardService, AFKRewardService>(Lifetime.Singleton);
            // builder.Register<IGameStateService, GameStateService>(Lifetime.Singleton);

            // ============ Entry Points ============
            // TODO: Register entry points as they are implemented
            // builder.RegisterEntryPoint<GameBootstrapper>();
        }

        protected override void Awake()
        {
            // Ensure this scope persists across scene loads
            if (Parent == null)
            {
                DontDestroyOnLoad(gameObject);
            }
            
            base.Awake();
        }
    }
}