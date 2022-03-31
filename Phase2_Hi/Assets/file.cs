using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class file : MonoBehaviour
{
    private string m_Path;
    // Start is called before the first frame update
    void Start()
    {
        m_Path = Application.dataPath;
        
        Debug.Log("Data path : " + m_Path);
    }
}
