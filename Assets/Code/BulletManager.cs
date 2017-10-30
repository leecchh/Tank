using System;
using System.Collections.Generic;
using Assets.Code.Structure;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Code
{
    /// <summary>
    /// Bullet manager for spawning and tracking all of the game's bullets
    /// </summary>
    public class BulletManager
    {
        private readonly Transform _holder;

        /// <summary>
        /// Bullet prefab. Use GameObject.Instantiate with this to make a new bullet.
        /// </summary>
        private readonly Object _bullet;
        private readonly Object _bullet2;

        public BulletManager (Transform holder) {
            _holder = holder;
            _bullet = Resources.Load("Bullet");
            _bullet2 = Resources.Load("Bullet2");
        }

        public void ForceSpawn (Vector2 pos, Quaternion rotation, Vector2 velocity, bool isRed) {
            GameObject newBullet;
            if (isRed)
            {
                newBullet = (GameObject)Object.Instantiate(_bullet, pos, rotation, _holder);
                newBullet.tag = "red";
            }
            else
            {
                newBullet = (GameObject)Object.Instantiate(_bullet2, pos, rotation, _holder);
                newBullet.tag = "blue";
            }
            newBullet.GetComponent<Bullet>().Initialize(velocity);
        }
    }
}