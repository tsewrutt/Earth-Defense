using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int[] waveSizes;
    public float spawnDelay = 1.0f;
    public float timeBetweenWaves = 5.0f;

    private int waveNumber = 0;
    private int currentEnemies = 0;
    private GameObject[] enemies;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (waveNumber < enemyPrefabs.Length)
        {
            for (int i = 0; i < waveSizes[waveNumber]; i++)
            {
                GameObject enemy = Instantiate(enemyPrefabs[waveNumber], transform.position, transform.rotation);
                currentEnemies++;
                yield return new WaitForSeconds(spawnDelay);
            }

            //this part keeps track on when the enemies of current wave is dead
            //if enemy from current wave all dead, runs new wave

            while (currentEnemies > 0)
            {
                yield return null;
            }

            yield return new WaitForSeconds(timeBetweenWaves);
            waveNumber++;
        }
    }

    public void DecrementEnemies()
    {
        currentEnemies--;
    }

    private void Update()
    {
        //check for amount of enemies left
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        if(enemies.Length == 0)
        {
            currentEnemies = 0;
        }
    }
}
