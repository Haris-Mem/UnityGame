using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using RpgAdv;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public PlayerStats _playerStats;
    public Text levelText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Current Level: " + _playerStats.getLevel();
    }
}
