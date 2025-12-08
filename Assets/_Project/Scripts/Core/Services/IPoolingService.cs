using UnityEngine;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Generic object pooling service for frequently spawned objects.
    /// Reduces GC allocations by reusing GameObjects.
    /// </summary>
    public interface IPoolingService
    {
        /// <summary>
        /// Gets an object from the pool, or creates a new one if the pool is empty.
        /// The returned object is activated and ready to use.
        /// </summary>
        /// <param name="prefab">The prefab to spawn.</param>
        /// <param name="position">World position for the spawned object.</param>
        /// <param name="rotation">Rotation for the spawned object.</param>
        /// <returns>A pooled or newly instantiated GameObject.</returns>
        GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation);

        /// <summary>
        /// Gets an object from the pool with a specific parent.
        /// </summary>
        /// <param name="prefab">The prefab to spawn.</param>
        /// <param name="position">World position for the spawned object.</param>
        /// <param name="rotation">Rotation for the spawned object.</param>
        /// <param name="parent">Parent transform for the spawned object.</param>
        /// <returns>A pooled or newly instantiated GameObject.</returns>
        GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent);

        /// <summary>
        /// Gets a typed component from the pool.
        /// </summary>
        /// <typeparam name="T">Component type to retrieve.</typeparam>
        /// <param name="prefab">The prefab to spawn.</param>
        /// <param name="position">World position for the spawned object.</param>
        /// <param name="rotation">Rotation for the spawned object.</param>
        /// <returns>The component from the pooled object.</returns>
        T Spawn<T>(GameObject prefab, Vector3 position, Quaternion rotation) where T : Component;

        /// <summary>
        /// Returns an object to the pool for later reuse.
        /// The object will be deactivated.
        /// </summary>
        /// <param name="instance">The object to return to the pool.</param>
        void Despawn(GameObject instance);

        /// <summary>
        /// Pre-warms the pool by instantiating a number of objects ahead of time.
        /// </summary>
        /// <param name="prefab">The prefab to pre-warm.</param>
        /// <param name="count">Number of instances to create.</param>
        void Prewarm(GameObject prefab, int count);

        /// <summary>
        /// Clears all pooled objects for a specific prefab.
        /// </summary>
        /// <param name="prefab">The prefab pool to clear.</param>
        void ClearPool(GameObject prefab);

        /// <summary>
        /// Clears all pools and destroys all pooled objects.
        /// </summary>
        void ClearAllPools();
    }
}