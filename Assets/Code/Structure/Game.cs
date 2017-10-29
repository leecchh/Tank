using UnityEngine;

namespace Assets.Code.Structure
{
    public class Game : MonoBehaviour
    {
        /// <summary>
        /// The game context.
        /// A pointer to the currently active game (so that we don't have to use something slow like "Find").
        /// </summary>
        public static Game Ctx;

 
        // all of the things that we can about saving/loading
        public static ScoreManager Score;
        public static Player Player;
        public static BulletManager Bullets;


        internal void Start () {
            Ctx = this;

            Score = GameObject.Find("ScoreText").GetComponent<ScoreManager>();
            Player = GameObject.Find("Player").GetComponent<Player>();
            Bullets = new BulletManager(GameObject.Find("Bullets").transform);

            _saveAxis = Platform.GetSaveAxis();
        }

        // all of this is done so that you can save/load with the Start/Back buttons
        private static string _saveAxis;
        private bool _locked;
        internal void Update () {
            float axis = Input.GetAxis(_saveAxis);
            if (_locked && Mathf.Abs(axis) < 0.1f) { _locked = false; }
            if (_locked) { return; }

            if (axis > 0.1f) {
                _locked = true;
            } else if (axis < -0.1f) {
                _locked = true;
            }
        }


        private static bool IsMac () {
            return Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer;
        }
    }
}