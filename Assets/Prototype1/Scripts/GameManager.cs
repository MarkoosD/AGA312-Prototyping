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
            TOWN,
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
        public SpriteRenderer townSprite;


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
            if (!gameOver)
            {
                currentEnvironment = CurrentEnvironment.CITY;
                FadeSprite(forrestSprite, 0, 2f);
                FadeSprite(citySprite, 1, 2f);
                yield return new WaitForSeconds(10);
                if (!gameOver)
                {
                    currentEnvironment = CurrentEnvironment.TOWN;
                    FadeSprite(citySprite, 0, 2f);
                    FadeSprite(townSprite, 1, 2f);
                    yield return new WaitForSeconds(10);
                    if (!gameOver)
                    {
                        currentEnvironment = CurrentEnvironment.FORREST;
                        FadeSprite(townSprite, 0, 2f);
                        FadeSprite(forrestSprite, 1, 2f);
                        StartCoroutine("ChangeEnvironment");
                    }
                }
            }
        }
    }
}


