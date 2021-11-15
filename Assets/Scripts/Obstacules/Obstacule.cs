using System.Collections;
using ObjectsPool;
using UnityEngine;

namespace Obstacules
{
    public class Obstacule : MonoBehaviour, IPooledObject
    {
        [SerializeField] private float timeToMove = 0.5f;
        [SerializeField] private AnimationCurve timeCurve;
        
        
        public void OnObjectSpawn()
        {
            var initialY = Random.Range(-2, 3);
            var initialPosition = new Vector2(17, initialY);

            transform.position = initialPosition;
            
            StartCoroutine(MoveToPlayer());
        }
        
        
        IEnumerator MoveToPlayer()
        {
            float t = 0;
            do
            {
                t += Time.deltaTime / timeToMove;
                var objPosition = transform.position;
                var movementVector = new Vector2( Mathf.Lerp(17, -17, timeCurve.Evaluate(t)), objPosition.y);
                transform.position = movementVector;
                yield return null;
            } while (t < 1f);
        }
    }
}
