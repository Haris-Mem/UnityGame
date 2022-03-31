using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    Renderer test;
    // Start is called before the first frame update
    void Start()
    {
        test= GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey("1"))
        {
            test.enabled= false;
        }
        
        if (Input.GetKey("2"))
        {
            test.enabled= true;
        }
    }
}

