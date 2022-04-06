using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RpgAdv { }
public class HudManager : MonoBehaviour
{

// variable declarations
    public Slider healthSlider;

// set max health
    public void SetMaxHealth(int health) {

        healthSlider.maxValue = health;
        SetHealth(health);
    }

// set the health
    public void SetHealth(int health) {
        healthSlider.value = health;

    }
}
