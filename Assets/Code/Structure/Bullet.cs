using UnityEngine;

namespace Assets.Code.Structure
{
    public class Bullet : MonoBehaviour
    {
        public void Initialize (Vector2 velocity) {
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

        internal void Update () {
            
        }

        internal void OnCollisionEnter2D(Collision2D other) {
            Die();
        }

        private void Die () {
            Destroy(gameObject);
        }
    }
}
