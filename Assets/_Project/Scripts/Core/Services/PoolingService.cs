using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Object pooling service implementation using dictionaries keyed by prefab.
    /// Reduces GC allocations by reusing GameObjects instead of Instantiate/Destroy.
    /// </summary>
    public class PoolingService : IPoolingService
    {
        private readonly Dictionary<GameObject, Queue<GameObject>> _pools = new();
        private readonly Dictionary<GameObject, GameObject> _instanceToPrefab = new();
        private readonly Transform _poolRoot;
        private readonly ILoggingService _logger;

        private const int DefaultPoolSize = 5;
        private const int ExpansionSize = 5;

        public PoolingService(ILoggingService logger)
        {
            _logger = logger;
            
            // Create a root object to hold all pooled objects
            var rootGo = new GameObject("[PoolingService]");
            Object.DontDestroyOnLoad(rootGo);
            _poolRoot = rootGo.transform;
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Spawn(prefab, position, rotation, null);
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            if (prefab == null)
            {
                _logger.LogError(LogCategory.Core, "PoolingService.Spawn called with null prefab");
                return null;
            }

            GameObject instance = GetFromPool(prefab);
            
            if (instance == null)
            {
                // Pool is empty, create new instance
                instance = Object.Instantiate(prefab, position, rotation, parent);
                _instanceToPrefab[instance] = prefab;
            }
            else
            {
                // Reset transform
                instance.transform.SetParent(parent);
                instance.transform.SetPositionAndRotation(position, rotation);
                instance.SetActive(true);
            }

            return instance;
        }

        public T Spawn<T>(GameObject prefab, Vector3 position, Quaternion rotation) where T : Component
        {
            var instance = Spawn(prefab, position, rotation);
            if (instance == null) return null;
            
            if (!instance.TryGetComponent<T>(out var component))
            {
                _logger.LogError(LogCategory.Core, 
                    $"PoolingService.Spawn<{typeof(T).Name}> - Prefab does not have required component");
                return null;
            }

            return component;
        }

        public void Despawn(GameObject instance)
        {
            if (instance == null) return;

            if (!_instanceToPrefab.TryGetValue(instance, out var prefab))
            {
                // Instance wasn't spawned by this pool, just destroy it
                _logger.LogWarning(LogCategory.Core, 
                    $"PoolingService.Despawn - Instance '{instance.name}' was not spawned by pool, destroying");
                Object.Destroy(instance);
                return;
            }

            ReturnToPool(prefab, instance);
        }

        public void Prewarm(GameObject prefab, int count)
        {
            if (prefab == null)
            {
                _logger.LogError(LogCategory.Core, "PoolingService.Prewarm called with null prefab");
                return;
            }

            EnsurePoolExists(prefab);

            for (int i = 0; i < count; i++)
            {
                var instance = Object.Instantiate(prefab, _poolRoot);
                instance.SetActive(false);
                _instanceToPrefab[instance] = prefab;
                _pools[prefab].Enqueue(instance);
            }

            _logger.LogInfo(LogCategory.Core, $"PoolingService.Prewarm - Created {count} instances of '{prefab.name}'");
        }

        public void ClearPool(GameObject prefab)
        {
            if (prefab == null || !_pools.TryGetValue(prefab, out var pool)) return;

            while (pool.Count > 0)
            {
                var instance = pool.Dequeue();
                if (instance != null)
                {
                    _instanceToPrefab.Remove(instance);
                    Object.Destroy(instance);
                }
            }

            _pools.Remove(prefab);
            _logger.LogInfo(LogCategory.Core, $"PoolingService.ClearPool - Cleared pool for '{prefab.name}'");
        }

        public void ClearAllPools()
        {
            foreach (var kvp in _pools)
            {
                while (kvp.Value.Count > 0)
                {
                    var instance = kvp.Value.Dequeue();
                    if (instance != null)
                    {
                        Object.Destroy(instance);
                    }
                }
            }

            _pools.Clear();
            _instanceToPrefab.Clear();
            _logger.LogInfo(LogCategory.Core, "PoolingService.ClearAllPools - All pools cleared");
        }

        private GameObject GetFromPool(GameObject prefab)
        {
            EnsurePoolExists(prefab);

            var pool = _pools[prefab];

            // Try to get an inactive object from the pool
            while (pool.Count > 0)
            {
                var instance = pool.Dequeue();
                if (instance != null)
                {
                    return instance;
                }
                // Instance was destroyed externally, remove from tracking
            }

            return null;
        }

        private void ReturnToPool(GameObject prefab, GameObject instance)
        {
            EnsurePoolExists(prefab);

            instance.SetActive(false);
            instance.transform.SetParent(_poolRoot);
            _pools[prefab].Enqueue(instance);
        }

        private void EnsurePoolExists(GameObject prefab)
        {
            if (!_pools.ContainsKey(prefab))
            {
                _pools[prefab] = new Queue<GameObject>();
            }
        }
    }
}