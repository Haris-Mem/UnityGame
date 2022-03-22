using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
        // moves the character to a specifc coordinate 
        float newZPosition = Mathf.Lerp(0, 182.0f, Time.deltaTime);

        if (transform.position.z >= 182)
        {
            return;
        }

        //moves character
        transform.position = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z + newZPosition);
    }
}
