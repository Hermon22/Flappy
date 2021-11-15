using Controllers;
using Obstacules;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 10f;
    
        private Rigidbody2D _rb;
    

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                _rb.AddForce(Vector2.up * jumpForce);
        }
        
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            GameController.Instance.EndGame();
            
        }
    }
}
