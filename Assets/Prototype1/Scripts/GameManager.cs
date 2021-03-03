using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype1
{
    
    public class GameManager : Singleton<GameManager>
    {
        public enum CurrentEnvironment
        {
            FORREST,
            CITY
        }

        public CurrentEnvironment currentEnvironment;

        public int lives;
        public int score = 0;

        public bool gameOver = false;

        public float obstacleSpeed = 10f;
        public float increaseRate;

        public SpriteRenderer forrestSprite;
        public SpriteRenderer citySprite;


        private void Start()
        {
            StartCoroutine("ChangeEnvironment");
        }

        private void Update()
        {
            obstacleSpeed = obstacleSpeed * increaseRate * Time.deltaTime;
            increaseRate += 0.00001f;
        }

        IEnumerator ChangeEnvironment()
        {
            //fade to next environment, then back to first one once you reach the last 
            yield return new WaitForSeconds(10);
            currentEnvironment = CurrentEnvironment.CITY;
            FadeSprite(forrestSprite, 0, 2f);
            FadeSprite(citySprite, 1, 2f);
            StopCoroutine("ChangeEnvironment");
        }
    }
}


