using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : JMC
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);


    void Start()
    {
        StartCoroutine("SpawnCoin");
        StartCoroutine("SpawnObstacle");
    }

    void Update()
    {
        
    }

   

    IEnumerator SpawnObstacle()
    {
        float rnd = Random.Range(2, 5);
        yield return new WaitForSeconds(rnd);
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        if (_GM1.gameOver == false)
            StartCoroutine("SpawnObstacle");
    }

    IEnumerator SpawnCoin()
    {
        float rnd = Random.Range(1, 5);
        Vector3 coinSpawnPos = new Vector3(25, Random.Range(1.5f, 4.5f), 0);
        yield return new WaitForSeconds(rnd);
        Instantiate(coinPrefab, coinSpawnPos, coinPrefab.transform.rotation);
        if (_GM1.gameOver == false)
            StartCoroutine("SpawnCoin");
    }
}
