using Prototype1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : JMC
{
    public GameObject forrestObstaclePrefab;
    public GameObject cityObstaclePrefab;
    public GameObject townObstaclePrefab;
    public GameObject coinPrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);

  

    void Start()
    {
        StartCoroutine("SpawnCoin");
        StartCoroutine("SpawnObstacle");
    }

   

   

    IEnumerator SpawnObstacle()
    {
        if(_GM1.currentEnvironment == GameManager.CurrentEnvironment.FORREST)
        {
            float rnd = Random.Range(2, 5);
            yield return new WaitForSeconds(rnd);
            Instantiate(forrestObstaclePrefab, spawnPosition, forrestObstaclePrefab.transform.rotation);
            if (_GM1.gameOver == false)
                StartCoroutine("SpawnObstacle");
        }
        else if (_GM1.currentEnvironment == GameManager.CurrentEnvironment.CITY)
        {
            float rnd = Random.Range(2, 5);
            yield return new WaitForSeconds(rnd);
            Instantiate(cityObstaclePrefab, spawnPosition, cityObstaclePrefab.transform.rotation);
            if (_GM1.gameOver == false)
                StartCoroutine("SpawnObstacle");
        }       
        else
        {
            float rnd = Random.Range(2, 5);
            yield return new WaitForSeconds(rnd);
            Instantiate(townObstaclePrefab, spawnPosition, townObstaclePrefab.transform.rotation);
            if (_GM1.gameOver == false)
                StartCoroutine("SpawnObstacle");
        }
    }

    IEnumerator SpawnCoin()
    {        
        float rnd = Random.Range(1, 5);
        Vector3 coinSpawnPos = new Vector3(25, Random.Range(2.5f, 4.5f), 0);
        yield return new WaitForSeconds(rnd);
        Instantiate(coinPrefab, coinSpawnPos, coinPrefab.transform.rotation);
        if (_GM1.gameOver == false)
            StartCoroutine("SpawnCoin");
    }
}
