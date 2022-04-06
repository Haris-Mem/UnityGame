using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Teleporter : MonoBehaviour
{
// variable declarations 
    public GameObject Player;
    public GameObject TeleportTo;

// when the player steps on the teleport pad they get teleported to the target pad.
    void OnTriggerEnter(Collider col)
    {
        Player.transform.position = TeleportTo.transform.position;
    }
}
