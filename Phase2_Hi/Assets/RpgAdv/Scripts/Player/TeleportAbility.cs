using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
// variable declarations
    public GameObject Player;
  
  
// this method calls the teleport method
    void FixedUpdate() {
        teleport();
    }

// when T is pressed the player teleports 3 units 
    void teleport() {
        if (Input.GetKeyDown(KeyCode.T)) {
            
            Player.transform.position += Player.transform.forward * 3;
        }
    }

}
