using UnityEngine;

namespace PoolingSystem
{
    public sealed class PoolRelease : MonoBehaviour
    {
        private PoolingItem _poolingItem;

        public PoolingItem PoolingItem { get => _poolingItem; set => _poolingItem = value; }

        public void OnDisable() => _poolingItem?.ObjectPool.Release(gameObject);
        public void OnDestroy() => _poolingItem?.ObjectPool.Dispose();
    }
}