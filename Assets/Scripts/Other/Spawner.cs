using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPref;
    [SerializeField] private Wave[] waves;
 
    private int currentWaveNumber;
    private Wave currentWave;

    private int amountOfEnemySpawn;
    private int amountOfEnemyAlive;
    private float nextSpawnTime;

    void Start()
    {
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(amountOfEnemySpawn > 0 && Time.time > nextSpawnTime)
        {
            amountOfEnemySpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawn;
            Enemy spawnedEnemy = Instantiate(enemyPref, transform.position, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        amountOfEnemyAlive--;
        if(amountOfEnemyAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            amountOfEnemySpawn = currentWave.enemyCount;
            amountOfEnemyAlive = amountOfEnemySpawn;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawn;
    }
}
