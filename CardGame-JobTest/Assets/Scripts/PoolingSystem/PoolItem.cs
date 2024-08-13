using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

namespace PoolingSystem
{
    [System.Serializable]
    public sealed class PoolingItem
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private short _defaultCapacity = 0;
        [SerializeField] private int _maxSize = 0;

        private ObjectPool<GameObject> _objectPool;
        private List<GameObject> _generatedPool = new List<GameObject>();

        public event System.Action<GameObject> OnGet;
        public event System.Action<GameObject> OnRelease;
        public event System.Action<GameObject> OnDestroy;

        public GameObject Prefab { get => _prefab; set => _prefab = value; }
        public short DefaultCapacity { get => _defaultCapacity; set => _defaultCapacity = value; }
        public int MaxSize { get => _maxSize; set => _maxSize = value; }
        public ObjectPool<GameObject> ObjectPool { get => _objectPool; set => _objectPool = value; }
        public List<GameObject> GeneratedPool { get => _generatedPool; set => _generatedPool = value; }

        public void OnInitialize(GameObject prefab, short defaultCapacity = 0, int maxSize = int.MaxValue)
        {
            _prefab = prefab;
            _defaultCapacity = defaultCapacity;
            _maxSize = maxSize == 0 ? int.MaxValue : maxSize;

            _objectPool = new ObjectPool<GameObject>(CreatePool, GetPool, ReleasePool, DestroyPool, false, _defaultCapacity, _maxSize);

            for (int i = 0; i < _defaultCapacity; i++)
            {
                GameObject pool = CreatePool();
                pool?.SetActive(false);
            }
        }

        /// <summary>
        /// Get a gameObject pool, if queue is empty a new one is generated according to the defined maximum limit.
        /// </summary>
        /// <returns></returns>
        public GameObject OnGetFromPool()
        {
            GameObject pool = _objectPool.Get();

            if (pool == null)
            {
                return null;
            }

            return pool;
        }

        /// <summary>
        /// Deactivate the gameObject and add it back to the queue.
        /// </summary>
        /// <param name="pool"></param>
        public void OnReleaseToPool(GameObject pool)
        {
            ReleasePool(pool);
        }

        /// <summary>
        /// Deactivate all gameObjects and add them back to the queue.
        /// </summary>
        public void OnReleaseToAllPool()
        {
            foreach (GameObject pool in _generatedPool)
            {
                OnReleaseToPool(pool);
            }
        }

        private void GetPool(GameObject pool)
        {
            if (pool == null)
            {
                return;
            }

            OnGet?.Invoke(pool);
            pool?.SetActive(true);
        }

        private void DestroyPool(GameObject pool)
        {
            OnDestroy?.Invoke(pool);
            MonoBehaviour.Destroy(pool.gameObject);

            if (_generatedPool.Contains(pool))
            {
                _generatedPool.Remove(pool);
            }
        }

        private void ReleasePool(GameObject pool)
        {
            if (pool == null)
            {
                return;
            }

            OnRelease?.Invoke(pool);
            pool?.SetActive(false);
        }

        private GameObject CreatePool()
        {
            GameObject pool = _generatedPool.Count < _maxSize ? MonoBehaviour.Instantiate(_prefab) : null;

            if (pool != null)
            {
                PoolRelease poolRelease = pool.AddComponent<PoolRelease>();
                poolRelease.PoolingItem = this;

                _generatedPool.Add(pool);
            }

            return pool;
        }
    }
}