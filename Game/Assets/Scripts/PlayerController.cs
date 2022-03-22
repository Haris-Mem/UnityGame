using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RpgAdv
{

    public class PlayerController : MonoBehaviour
    {
       
        public float speed;
        public float rotationSpeed; 

        private Rigidbody rb;
        public Vector3 movement1;


        // Update is called once per frame
        void FixedUpdate()
        {
            float hoizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            movement1 = new Vector3(hoizontalInput, 0, verticalInput);
            movement1.Normalize();

            Vector3 desiredForward = Vector3.RotateTowards(
                transform.forward,
                movement1,Time.fixedDeltaTime * rotationSpeed,0);

            transform.Translate(movement1 * speed * Time.fixedDeltaTime);
            



        }
    }
}
