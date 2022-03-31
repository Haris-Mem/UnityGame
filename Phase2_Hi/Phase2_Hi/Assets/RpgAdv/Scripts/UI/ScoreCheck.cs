using System.Collections;
using System.Collections.Generic;
using RpgAdv;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCheck : Enemy_1
{
    public static ScoreCheck instance;

    public Text scoreText;

    private int score = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    public void addPoints()
    {
        score += 1;
        scoreText.text = "Enemies killed: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
