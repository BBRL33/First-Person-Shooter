using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public int numEnemySpawn;
    public int wave;
    public int numActiveEnemy;
    bool spawningEnemies;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (numEnemySpawn > 0)
        {
            int point = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[point].position, spawnPoints[point].rotation);
            numEnemySpawn--;
        }
        if (numActiveEnemy == 0 && spawningEnemies == false)
        {
            StartCoroutine(StartNextWave());
        }
    }

    IEnumerator StartNextWave()
    {
        spawningEnemies = true;
        yield return new WaitForSeconds(10);
        wave++;
        numEnemySpawn = wave * 5;
        spawningEnemies = false;
    }    
}
