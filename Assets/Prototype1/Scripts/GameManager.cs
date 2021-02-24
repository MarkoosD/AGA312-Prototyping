using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype1
{
    public class GameManager : Singleton<GameManager>
    {
        public int lives;
        public int score = 0;

        public bool gameOver = false;

        public float obstacleSpeed = 10f;
        public float increaseRate;

        private void Update()
        {
            obstacleSpeed = obstacleSpeed * increaseRate * Time.deltaTime;
            increaseRate += 0.00001f;


        }
    }
}


