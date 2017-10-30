using UnityEngine;
using System.Collections.Generic;

namespace Assets.Code.Structure
{
    public class Game : MonoBehaviour
    {
        /// <summary>
        /// The game context.
        /// A pointer to the currently active game (so that we don't have to use something slow like "Find").
        /// </summary>
        public static Game Ctx;
 
        public static ScoreManager Score;
        public static Player Player;
        public static BulletManager Bullets;
        public static EdgeCollider2D Walls;
        public List<Vector2> wallVertices = new List<Vector2>();

        internal void Start () {
            Ctx = this;

            Score = GameObject.Find("ScoreText").GetComponent<ScoreManager>();
            Player = GameObject.Find("Player").GetComponent<Player>();
            Walls = GameObject.Find("Walls").GetComponent<EdgeCollider2D>();
            wallVertices.Add(new Vector2(100, 100));
            wallVertices.Add(new Vector2(100, 300));
            wallVertices.Add(new Vector2(300, 300));
            wallVertices.Add(new Vector2(300, 100));
            Walls.points = wallVertices.ToArray();

            Bullets = new BulletManager(GameObject.Find("Bullets").transform);
        }

        private static bool IsMac () {
            return Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer;
        }
    }
}