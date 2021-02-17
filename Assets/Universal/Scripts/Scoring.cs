using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : JMC // To access functions from the Jmc script, call from JMC instead of MonoBehaviour
{

    public int lastRoundScore = 100;
    public int thisRoundScore = 150;
    public int lives = 5;

    void Start()
    {
        if(IsGameOver(lives))
        {
            CheckScore();
        }       
    }

    void CheckScore()
    {
        print("Score difference is: " + PercentageChange(lastRoundScore, thisRoundScore).ToString("F2") + "%");
    }

    void Update()
    {
        
    }
}
