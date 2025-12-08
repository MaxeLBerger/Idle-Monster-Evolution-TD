using UnityEngine;

namespace IdleMonsterTD.Gameplay.Enemy
{
    /// <summary>
    /// Factory for spawning enemies using EnemyConfigSO and pooling.
    /// </summary>
    public interface IEnemyFactory
    {
        /// <summary>
        /// Spawns an enemy at the given position.
        /// </summary>
        /// <param name="configId">The ID of the enemy config to spawn.</param>
        /// <param name="position">World position to spawn at.</param>
        /// <param name="pathIndex">The path index for the enemy to follow.</param>
        /// <returns>The spawned enemy GameObject, or null if config not found.</returns>
        GameObject SpawnEnemy(string configId, Vector3 position, int pathIndex = 0);

        /// <summary>
        /// Spawns an enemy using a direct config reference.
        /// </summary>
        /// <param name="config">The enemy config to use.</param>
        /// <param name="position">World position to spawn at.</param>
        /// <param name="pathIndex">The path index for the enemy to follow.</param>
        /// <returns>The spawned enemy GameObject.</returns>
        GameObject SpawnEnemy(ScriptableObject config, Vector3 position, int pathIndex = 0);

        /// <summary>
        /// Despawns an enemy and returns it to the pool.
        /// </summary>
        /// <param name="enemy">The enemy to despawn.</param>
        void DespawnEnemy(GameObject enemy);

        /// <summary>
        /// Pre-warms the pool for a specific enemy type.
        /// </summary>
        /// <param name="configId">The enemy config ID to pre-warm.</param>
        /// <param name="count">Number of instances to create.</param>
        void PrewarmPool(string configId, int count);
    }
}