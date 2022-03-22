using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RpgAdv
{
    public class FixedUpdateFollow : MonoBehaviour
    {

        public Transform toFollow;

        void FixedUpdate()
        {
            transform.position = toFollow.position;
            transform.rotation = toFollow.rotation;
        }
    }
}

