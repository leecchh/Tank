using UnityEngine;
using System.Collections.Generic;

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
            ScoreManager score = Game.Score.GetComponent<ScoreManager>();
            ScoreManager score2 = Game.Score2.GetComponent<ScoreManager>();

            if (this.tag=="red" && other.gameObject.name=="Player2"){
                Debug.Log("red hit blue");
                score.AddScore(2);
            }
            if (this.tag == "red" && other.gameObject.name == "Player")
            {
                score.AddScore(-1);
            }
            if (this.tag == "blue" && other.gameObject.name == "Player2")
            {
                score2.AddScore(-1);
            }
            if (this.tag == "blue" && other.gameObject.name == "Player")
            {
                score2.AddScore(2);
                Debug.Log("blue hit red");
            }
            Die();
        }

        private void Die () {
            Destroy(gameObject);
        }
    }
}
