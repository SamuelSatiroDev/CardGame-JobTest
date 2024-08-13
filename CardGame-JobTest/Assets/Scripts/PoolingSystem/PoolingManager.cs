using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

namespace PoolingSystem
{
    [CreateAssetMenu(fileName = "PoolingManager", menuName = "Game Manager/Pooling/Pooling Manager")]
    public sealed class PoolingManager : ScriptableSingleton<PoolingManager>
    {
        private Dictionary<string, PoolingItem> _poolingItems = new Dictionary<string, PoolingItem>();

        public static Dictionary<string, PoolingItem> PoolingItems { get => Instance._poolingItems; set => Instance._poolingItems = value; }

        /// <summary>
        /// Set item pooling information.
        /// </summary>
        public static void HandlerInitialize(string ID, GameObject prefab, short defaultCapacity = 0, int maxSize = int.MaxValue)
        {
            if (PoolingItems.ContainsKey(ID) == true)
            {
                return;
            }

            PoolingItem pooling = new PoolingItem();
            pooling.OnInitialize(prefab, defaultCapacity, maxSize);

            PoolingItems.Add(ID, pooling);
        }

        /// <summary>
        /// Get a gameObject pool, if queue is empty a new one is generated according to the defined maximum limit.
        /// </summary>
        public static GameObject HandlerOnGet(string ID, GameObject prefab, short defaultCapacity = 0, int maxSize = int.MaxValue)
        {
            HandlerInitialize(ID, prefab, defaultCapacity, maxSize);

            GameObject pool = PoolingItems[ID].OnGetFromPool();

            return pool;
        }

        /// <summary>
        /// Deactivate the gameObject and add it back to the queue.
        /// </summary>
        public static void HandlerRelease(string ID, GameObject pool)
        {
            if (PoolingItems.ContainsKey(ID) == false)
            {
                return;
            }

            PoolingItems[ID].OnReleaseToPool(pool);
        }

        /// <summary>
        /// Deactivate all gameObjects and add them back to the queue.
        /// </summary>
        public static void HandlerReleaseAll(string ID)
        {
            if (PoolingItems.ContainsKey(ID) == false)
            {
                return;
            }

            PoolingItems[ID].OnReleaseToAllPool();
        }       
    }
}