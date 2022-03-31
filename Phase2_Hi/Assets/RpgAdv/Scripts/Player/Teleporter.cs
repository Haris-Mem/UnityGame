using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Teleporter : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportTo;

    void OnTriggerEnter(Collider col)
    {
        Player.transform.position = TeleportTo.transform.position;
    }
}