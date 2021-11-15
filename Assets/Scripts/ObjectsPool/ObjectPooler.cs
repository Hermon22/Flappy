using System.Collections.Generic;
using UnityEngine;

namespace ObjectsPool
{
    public class ObjectPooler : MonoBehaviourSingleton<ObjectPooler>
    {
        public List<PoolData> pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        private void Start()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (var pool in pools)
            {
                var objectsPool = new Queue<GameObject>();

                for (var i = 0; i < pool.size; i++)
                {
                    var obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectsPool.Enqueue(obj);
                }
                _poolDictionary.Add(pool.tag,objectsPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector2 position)
        {
            if (!_poolDictionary.ContainsKey(tag)) return null;
        
            var objectToSpawn = _poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            var pooledObjet = objectToSpawn.GetComponent<IPooledObject>();
            pooledObjet?.OnObjectSpawn();

            _poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}
