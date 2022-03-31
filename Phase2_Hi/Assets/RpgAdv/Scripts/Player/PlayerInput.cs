using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RpgAdv
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private bool Attack;

        public Vector3 MoveInput
        {
            get
            {
                return movement;
            }
        }

        public bool isMoveInput
        {
            get
            {
                //if not zero player is moving 
                return !Mathf.Approximately(MoveInput.magnitude, 0);
            }
        }
        public bool IsAttack
        {
            get{
                return Attack;
            }
        }

        // Update is called once per frame
        void Update()
        {
            movement.Set(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical"));

            if (Input.GetButtonDown("Fire1") && !IsAttack)
            {
                StartCoroutine(AttackAndWait());
            }
        }

        private IEnumerator AttackAndWait()
        {
            Attack = true;
            yield return new WaitForSeconds(0.03f);
            Attack = false;
        }
    }
}

