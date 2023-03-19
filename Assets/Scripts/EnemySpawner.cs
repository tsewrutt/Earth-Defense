using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    //TUTORIAL STUFF
    public TutorialScript ts;
    public Text allUpdateTxt;
    public Text ghostTxt;
    public GameObject[] enemyPrefabs;

    public int[] waveSizes;
    public float spawnDelay = 1.0f;
    public float timeBetweenWaves = 5.0f;
    public float timebefore1stwave = 10.0f;
    private int waveNumber = 0;
    private int currentEnemies = 0;
    private GameObject[] enemies;

    //BUTTON INTERACTIBILITY
    public Button b1;
    public Button b2;
    public Button b3;

    //MONEY MANAGEMENT
    public MoneyManager mm;
    public Text timer_txt;
    public Text waveTxt;
   

    private string updateTxt;
    private bool start = false;
    private bool moneyRewarded = false;

    //HEALTH

    //COIN
    public float shakeMagnitude = 1f;
    public float shakeDuration = 1f;
    public float elapsed = 0.0f;
    public GameObject coin;

    //Wining Object
    public Gamesignal signal;

    void Start()
    {
        b2.interactable = false;
        b3.interactable = false;
       // press_s.text = "Press 's' to start";
       // 
    }

    IEnumerator Spawn()
    {
        int x;
        yield return new WaitForSeconds(timebefore1stwave);

        while (waveNumber < enemyPrefabs.Length)
        {
            for (int i = 0; i < waveSizes[waveNumber]; i++)
            {
                x = Random.Range(0, enemyPrefabs.Length); // we know we have 5 different types of enemy
                GameObject enemy = Instantiate(enemyPrefabs[x], transform.position, transform.rotation);
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
                //check if wavenumber 1 2 3
                //then update text
                switch (waveNumber)
                {
                    case 0:
                       // StartCoroutine(Shake(coin));
                        allUpdateTxt.text = "New Turret Unlocked!";
                        break;
                    case 1:
                        //StartCoroutine(Shake(coin));
                        allUpdateTxt.text = "New Turret Unlocked!";
                        break;
                    case 2:
                        
                        allUpdateTxt.text = "Warning: Excessive pollution detected! No more coins will be rewarded from this point onward.";
                        break;
                }
                timer_txt.text = "Starting next wave in: " + startTimer.ToString("F1") + " seconds";
                startTimer -= Time.deltaTime;

                yield return null;
                
            }
            timer_txt.text = "";

            yield return new WaitForSeconds(timeBetweenWaves);
            waveNumber++;
            moneyRewarded = false;
            UpdateText();
        }
    }

    public void DecrementEnemies()
    {
        currentEnemies--;
    }

    private void Update()
    {
        //COULD BE AN ISSUE OF CLASHING WHERE AFTER ENEMY SPAWN PLAYER PRESSES SKIP
        //OR WE COULD REMOVE SKIP BUTTON THE MOMENT WE PLACED TURRET
        if (ts.tutorialComplete == true)
        {
          //we can get a boolean from the tutorialscript, then check if the bool is true, meaning it is done,
          //when tutorial done, then go in here then change start = true; // or press skip to change the bool right away
            //HERE WE WILL START THE ACTUAL GAME ONCE THE TUTORIAL PART IS DONE!!!
            
            start = true;
            UpdateText(); // this writes the wave number now
           
            StartCoroutine(Spawn());
        }
        ts.tutorialComplete = false;
        //check for amount of enemies left
        if (start == true)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");

            if (enemies.Length == 0)
            {
                currentEnemies = 0;
            }
            //meaning we've reached the end of the game
            //endscene
            
        }

        //money rewarded
        switch (waveNumber)
        {
            case 1:
                if (!moneyRewarded)
                {
                    mm.money += 500;

                    StartCoroutine(Shake(coin));
                    b2.interactable = true;
                    StartCoroutine(WaitForCashIn());
                    moneyRewarded = true;
                }
                break;
            case 2:
                if (!moneyRewarded)
                {
                    mm.money += 1500;
                    StartCoroutine(Shake(coin));
                    StartCoroutine(Shake(coin));
                    b3.interactable = true;
                    StartCoroutine(WaitForCashIn());
                    moneyRewarded = true;
                }
                break;

            case 3:
                if (!moneyRewarded)
                {
                    mm.money += 1000;
                    StartCoroutine(Shake(coin));
                    StartCoroutine(WaitForCashIn());
                    moneyRewarded = true;
                }
                break;
            // add more cases for additional waves if needed
            default:  
                break;
        }


        
        //this works but we'll get rid of the delay
        if (waveNumber == waveSizes.Length)
        {
            // win = true; //we will use this to alter the content of endscene
            //RUN FINAL BOSS 
            //wave text to Final Boss wave
            //Have a switch for if waveNumber is numb 5, then we go on a FinalBoss Coroutine!!! (just increase hp of fire hazard)

            //THIS IS FOR WINNING!!!
            signal.win = true;
            SceneManager.LoadScene("endscene");
        }

    }

    private void UpdateText()
    {
        updateTxt = "Wave: " + (waveNumber + 1);
        waveTxt.text = updateTxt;
        allUpdateTxt.text = "";
    }

    public IEnumerator Shake(GameObject obj)
    {
        Vector3 initialPosition = obj.transform.position;
        elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            //float x = initialPosition.x + Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = initialPosition.y + UnityEngine.Random.Range(-shakeMagnitude, shakeMagnitude);
            obj.transform.position = new Vector3(initialPosition.x, y, initialPosition.z);

            elapsed += Time.deltaTime;

            // Pause for one frame before continuing the loop
            yield return null;
        }

        obj.transform.position = initialPosition;

    }

    private IEnumerator WaitForCashIn()
    {
        yield return new WaitForSeconds(1);
        
    }


    private IEnumerator FinalBoss()
    {


        yield return null;
    }

}
