using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 generatePosition = new Vector3(0, 0, 8.5f);

    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);

    }

 
    void Update()
    {

        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
        
    }

    public void SpawnEnemyWave(int _enemyCount)
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            var randomPosX = Random.Range(-8.0f, 8.0f);
            var randomPosZ = Random.Range(-8.0f, 8.0f);
            generatePosition = new Vector3(randomPosX, 0, randomPosZ);
            Instantiate(enemyPrefab, generatePosition, enemyPrefab.transform.rotation);
        }
    }
}
