using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public int[] waveSizes;
    public float spawnDelay = 1.0f;
    public float timeBetweenWaves = 5.0f;
    public float timebefore1stwave = 10.0f;
    private int waveNumber = 0;
    private int currentEnemies = 0;
    private GameObject[] enemies;

    
    public Text timer_txt;
    public Text press_s;
    public Text waveTxt;
    private string updateTxt;
    private bool start = false;

    void Start()
    {
        press_s.text = "Press any key to start";
        UpdateText();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timebefore1stwave);

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

            float startTimer = timeBetweenWaves;
            while (startTimer > 0)
            {
                timer_txt.text = "Starting next wave in: " + startTimer.ToString("F1") + " seconds";
                startTimer -= Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(timeBetweenWaves);
            waveNumber++;
            UpdateText();
        }
    }

    public void DecrementEnemies()
    {
        currentEnemies--;
    }

    private void Update()
    {
        if (Input.anyKey && !start)
        {
            start = true;
            Destroy(press_s);
            StartCoroutine(Spawn());
        }
        //check for amount of enemies left
        if(start == true)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");

            if (enemies.Length == 0)
            {
                currentEnemies = 0;
            }
            //meaning we've reached the end of the game
            //endscene
            
        }
        //Debug.Log("waveNum: " + waveNumber + "waveSizeLength: " + waveSizes.Length);
        //this works but we'll get rid of the delay later
        if (waveNumber == waveSizes.Length)
        {
            SceneManager.LoadScene("endscene");
        }

    }

    private void UpdateText()
    {
        updateTxt = "Wave: " + (waveNumber + 1);
        waveTxt.text = updateTxt;
    }
}
