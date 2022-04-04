using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    public GameObject Player;
  

    void FixedUpdate() {
        teleport();
    }

    void teleport() {
        if (Input.GetKeyDown(KeyCode.T)) {
            
            Player.transform.position += Player.transform.forward * 3;
        }
    }

}
