using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Scoring : JMC // To access functions from the Jmc script, call from JMC instead of MonoBehaviour
{
    public int highScore = 0;
    public int score = 150;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreMessage;
    public CanvasGroup scoreCanvas;


    private void Start()
    {
        FadeCanvas(scoreCanvas, 0, 0);
        GetHighScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CheckScore();
        }
    }

    void CheckScore()
    {
        GetHighScore();
        highScoreText.text = highScore.ToString();
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            scoreMessage.text = "<color=green> Congratulations! \n <color=blue>You got a new high score!";
            //scoreMessage.gameObject.transform.DOScale(Vector3.one, 1.2f, 2).SetLoop(-1);
        }
        else
        {
            scoreMessage.text = "Too bad! \n Better luck next time!";
        }

        FadeCanvas(scoreCanvas, 1, 1);
            
    }
    
    void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log("High Score is " + highScore);
    }
}
