using UnityEngine;

namespace IdleMonsterTD.Gameplay.Monster
{
    /// <summary>
    /// Factory for spawning monsters using MonsterConfigSO and pooling.
    /// </summary>
    public interface IMonsterFactory
    {
        /// <summary>
        /// Spawns a monster at the given position.
        /// </summary>
        /// <param name="configId">The ID of the monster config to spawn.</param>
        /// <param name="position">World position to spawn at.</param>
        /// <param name="laneIndex">The lane index for targeting purposes.</param>
        /// <returns>The spawned monster GameObject, or null if config not found.</returns>
        GameObject SpawnMonster(string configId, Vector3 position, int laneIndex = 0);

        /// <summary>
        /// Spawns a monster using a direct config reference.
        /// </summary>
        /// <param name="config">The monster config to use.</param>
        /// <param name="position">World position to spawn at.</param>
        /// <param name="laneIndex">The lane index for targeting purposes.</param>
        /// <returns>The spawned monster GameObject.</returns>
        GameObject SpawnMonster(ScriptableObject config, Vector3 position, int laneIndex = 0);

        /// <summary>
        /// Despawns a monster and returns it to the pool.
        /// </summary>
        /// <param name="monster">The monster to despawn.</param>
        void DespawnMonster(GameObject monster);

        /// <summary>
        /// Pre-warms the pool for a specific monster type.
        /// </summary>
        /// <param name="configId">The monster config ID to pre-warm.</param>
        /// <param name="count">Number of instances to create.</param>
        void PrewarmPool(string configId, int count);
    }
}