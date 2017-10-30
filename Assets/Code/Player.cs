using System;
using Assets.Code.Structure;
using UnityEngine;

namespace Assets.Code
{
    /// <summary>
    /// Player controller class
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Player : MonoBehaviour
    {
        private string _fireaxis;
        private string _fireaxis2;

        private Rigidbody2D _rb;
        private Gun _gun;

        // ReSharper disable once UnusedMember.Global
        internal void Start () {
            _rb = GetComponent<Rigidbody2D>();
            _gun = GetComponent<Gun>();

            _fireaxis = Platform.GetFireAxis();
            _fireaxis2 = Platform.GetFireAxis2();
        }

        // ReSharper disable once UnusedMember.Global
        internal void Update () {
            HandleInput();
        }

        /// <summary>
        /// Check the controller for player inputs and respond accordingly.
        /// </summary>
        private void HandleInput () {
            bool isRed = (gameObject.name == "Player");
            if (isRed){
                Turn(Input.GetAxis("Horizontal"));
                Thrust(Input.GetAxis("Vertical"));
                if (Input.GetAxis(_fireaxis) == 1)
                {
                    Fire();
                }
            }
            else{
                Turn(Input.GetAxis("Horizontal2"));
                Thrust(Input.GetAxis("Vertical2"));
                if (Input.GetAxis(_fireaxis2) == 1)
                {
                    Fire();
                }
            }
        }

        private void Turn (float direction) {
            if (Mathf.Abs(direction) < 0.2f) { return; }
            _rb.AddTorque(direction * -0.05f);
        }

        private void Thrust (float intensity) {
            if (Mathf.Abs(intensity) < 0.02f) { return; }
            _rb.AddRelativeForce(Vector2.up * intensity);
        }

        private void Fire () {
            _gun.Fire();
        }
    }
}
