using System;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Service for managing wave progression and enemy spawning during battle.
    /// </summary>
    public interface IWaveManager
    {
        /// <summary>
        /// The current wave index (0-based).
        /// </summary>
        int CurrentWaveIndex { get; }

        /// <summary>
        /// Total number of waves in the current level.
        /// </summary>
        int TotalWaves { get; }

        /// <summary>
        /// Whether a wave is currently active (enemies spawning or alive).
        /// </summary>
        bool IsWaveActive { get; }

        /// <summary>
        /// Whether all waves have been completed.
        /// </summary>
        bool AllWavesCompleted { get; }

        /// <summary>
        /// Number of enemies still alive in the current wave.
        /// </summary>
        int RemainingEnemies { get; }

        /// <summary>
        /// Event raised when a wave starts.
        /// Parameter: wave index (0-based).
        /// </summary>
        event Action<int> OnWaveStarted;

        /// <summary>
        /// Event raised when a wave is completed (all enemies killed).
        /// Parameter: wave index (0-based).
        /// </summary>
        event Action<int> OnWaveCompleted;

        /// <summary>
        /// Event raised when all waves are completed.
        /// </summary>
        event Action OnAllWavesCompleted;

        /// <summary>
        /// Event raised when an enemy is spawned.
        /// </summary>
        event Action OnEnemySpawned;

        /// <summary>
        /// Event raised when an enemy dies.
        /// </summary>
        event Action OnEnemyKilled;

        /// <summary>
        /// Starts the first wave.
        /// </summary>
        void StartFirstWave();

        /// <summary>
        /// Starts the next wave. Does nothing if already on last wave.
        /// </summary>
        void StartNextWave();

        /// <summary>
        /// Stops all spawning and clears remaining enemies.
        /// </summary>
        void StopAllWaves();

        /// <summary>
        /// Resets the wave manager for a new run.
        /// </summary>
        void Reset();

        /// <summary>
        /// Notifies the manager that an enemy was killed.
        /// Call this from enemy death logic.
        /// </summary>
        void NotifyEnemyKilled();
    }
}