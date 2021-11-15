using System.Collections;
using Controllers;
using ObjectsPool;
using UnityEngine;

namespace Obstacules
{
    public class ObstSpawner : MonoBehaviour
    {
        private bool _spawnObjects;
        public float timeToSpawn = 1.5f;
    
        private void Start()
        {
            _spawnObjects = true;
            StartCoroutine(TimedSpawn());
        }


        IEnumerator TimedSpawn()
        {
            yield return new WaitForSeconds(1);
            while (_spawnObjects)
            {
                ObjectPooler.Instance.SpawnFromPool("Pipes",transform.position);
                GameController.Instance.UpdateScore();
                yield return new WaitForSeconds(timeToSpawn);
            }
        }
    }
}
