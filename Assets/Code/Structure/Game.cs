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
 
        public static ScoreManager Score,Score2;

        public static Player Player;
        public static BulletManager Bullets;
        public static EdgeCollider2D Walls;
        public List<Vector2> wallVertices = new List<Vector2>();

        internal void Start () {
            Ctx = this;

            Score = GameObject.Find("ScoreText").GetComponent<ScoreManager>();
            Score2 = GameObject.Find("ScoreText2").GetComponent<ScoreManager>();
            Player = GameObject.Find("Player").GetComponent<Player>();
            Walls = GameObject.Find("Walls").GetComponent<EdgeCollider2D>();

            var cam = Camera.main;
            var bottomleft = cam.ViewportToWorldPoint(Vector3.zero);
            var topright = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

            wallVertices.Add(new Vector2(bottomleft.x, bottomleft.y));
            wallVertices.Add(new Vector2(bottomleft.x, topright.y));
            wallVertices.Add(new Vector2(topright.x, topright.y));
            wallVertices.Add(new Vector2(topright.x, bottomleft.y));
            wallVertices.Add(new Vector2(bottomleft.x, bottomleft.y));
            Walls.points = wallVertices.ToArray();

            Bullets = new BulletManager(GameObject.Find("Bullets").transform);
        }

        private static bool IsMac () {
            return Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer;
        }
    }
}