using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    //TUTO STUFF
    public bool tutorialComplete = false;
    public Button skipb;

   //MIDDLE TEXT
   //TAKEN FROM ENEMY SPAWNER (called ghostTExt)

    //WAVE INFO 
    public GameObject wave_arrow;
    public Text wave_info_txt;
    //CASH INFO
    public GameObject cash_arrow;
    public Text cash_info_txt;

    //ALRETS INFO
    //WE GRAB UPDATE ALL TEXT FROM ENEMY SPAWNER
    public GameObject updateallTxt_arrow;

    //TURRET INFO
    public GameObject turret_arrow;
    public Text turret_info_txt;

    //TURRET BUTTON SELECTION
    public TurretButtonSelection t1;
    public TurretButtonSelection t2;
    public TurretButtonSelection t3;
    public TurretPlacement tp;
    //TURRET PLACEMENT
    public GameObject placement_arrow;
    public Text here_txt;

    //WAVE STUFF
    public GameObject enemyprefab;
    private int enemyCount = 1;
    public MoneyManager mm;
    public EnemySpawner em;
    public EarthCollider ec;

    //COROUTINE
    private Coroutine co;
    void Start()
    {
       
        //Set all arrows to invisible
        ToggleGOVisibility(wave_arrow,wave_info_txt, false);
        ToggleGOVisibility(cash_arrow, cash_info_txt, false);
        ToggleGOVisibility(updateallTxt_arrow, em.allUpdateTxt, false);
        ToggleGOVisibility(turret_arrow, turret_info_txt, false);
        ToggleGOVisibility(placement_arrow, here_txt, false);
    

        //gives player an extra 400 before starting actual game 
        mm.money += 400;
        skipb.onClick.AddListener(TaskOnClick);
        //Coroutine Contains Labels info then spawning of one enemy
        co = StartCoroutine(SpawnThisEnemy());



       
    }

    // Update is called once per frame
    void Update()
    {

    }
    //right now clicking skip just run emenyspawaner 
    // it does not STOP THE Spawnthisememy coroutine !!!
    private void TaskOnClick()
    {
        StopCoroutine(co);
        ToggleGOVisibility(wave_arrow, wave_info_txt, false);
        ToggleGOVisibility(cash_arrow, cash_info_txt, false);
        ToggleGOVisibility(updateallTxt_arrow, em.allUpdateTxt, false);
        ToggleGOVisibility(turret_arrow, turret_info_txt, false);
        ToggleGOVisibility(placement_arrow, here_txt, false);
    
        tutorialComplete = true;

        //disable button
        ec.health = 100;
        Destroy(skipb.gameObject);
    }



    private IEnumerator SpawnThisEnemy()
    {
        em.ghostTxt.text = "Tutorial Starting...";
        yield return new WaitForSeconds(1f);
        em.ghostTxt.text = "";

        //THEN SHOW EACH UI COMPONENT

        //SHOW WAVE FIRST
        RunWaveInfo(true, "this keeps track of the wave");
        yield return new WaitForSeconds(3f);
        RunWaveInfo(false, "");
        
        //NOW ACTIVATE COINS INFO
        RunCashInfo(true, "coins left");
        yield return new WaitForSeconds(3f);
        RunCashInfo(false, "");
        
        //NOW ACTIVATE ALERTS INFO
        RunAlertsInfo(true, "Alerts are here!");
        yield return new WaitForSeconds(3f);
        RunAlertsInfo(false, ""); // this one will be updated by em frequently

        RunTurretInfo(true, "Turret Selection");
        yield return new WaitForSeconds(3f);
        
        
        
        
        //make other turrets disabled so player can't use the other ones
        RunTurretInfo(true, "Now Select this turret");
        yield return StartCoroutine(WaitForSelection());



       
        yield return StartCoroutine(EnemyIncoming());
        yield return new WaitForSeconds(1);
        em.allUpdateTxt.text = "";
        em.timer_txt.text = "Starting next wave in: " + 3 + " seconds";
        yield return new WaitForSeconds(1);
        em.timer_txt.text = "Starting next wave in: " + 2 + " seconds";
        yield return new WaitForSeconds(1);
        em.timer_txt.text = "Starting next wave in: " + 1 + " seconds";
        yield return new WaitForSeconds(1);
        em.timer_txt.text = "";
       
        tutorialComplete = true;
        ec.health = 100;
    }



    //private bool isVisible = false;
    private void ToggleGOVisibility(GameObject go,Text txt, bool isVisible)
    {
        if (isVisible)
        {
            go.SetActive(true);
            
        }
        else
        {
            go.SetActive(false);
            txt.text = "";
        }
        
    }

    private void RunWaveInfo(bool visibility, string s)
    {
        wave_info_txt.text = s;
        ToggleGOVisibility(wave_arrow, wave_info_txt, visibility);
    }
    private void RunCashInfo(bool visibility, string s)
    {
        cash_info_txt.text = s;
        ToggleGOVisibility(cash_arrow, cash_info_txt, visibility);
    }
    private void RunAlertsInfo(bool visibility, string s)
    {
        em.allUpdateTxt.text = s;
        ToggleGOVisibility(updateallTxt_arrow, em.allUpdateTxt, visibility);
    }

    private void RunTurretInfo(bool visibility, string s)
    {
        turret_info_txt.text = s;
        ToggleGOVisibility(turret_arrow, turret_info_txt, visibility);
    }

    private void RunTurretPlacement(bool visibility, string s)
    {
        here_txt.text = s;
        ToggleGOVisibility(placement_arrow, here_txt, visibility);
    }


    private IEnumerator WaitForSelection()
    {
        //Disable other buttons 
        
        while(t1.btnClick != true)
        {
            if(t2.btnClick == true || t3.btnClick == true)
            {
                em.allUpdateTxt.text = "Wrong Turret Selected, Try Again!";
                t2.btnClick = false;
                t3.btnClick = false;
                tp.selectedPrefab = null;
            }
            yield return null;
        }
        //meaning we have turret selected and now wait until selected prefab goes to empty
        //then we resume stuff
        RunTurretInfo(false, "");
        em.allUpdateTxt.text = "Place Turret in Showed location!";
        RunTurretPlacement(true, "Here!");

        while (tp.selectedPrefab != null)
        {
            yield return null;
        }
        RunTurretPlacement(false, "");
        //now that selected prefab means turret has been placed

        em.allUpdateTxt.text = "Hooray! Now prepare for enemies";
        

        //show this timer in text if can

    }

    private IEnumerator EnemyIncoming()
    {
        em.waveTxt.text = "Practice Wave";
        Destroy(skipb.gameObject); // now player cant skip to avoid the problem of having an extra enemy on the field
        em.timer_txt.text = "Starting next wave in: " + 5 + " seconds";
        yield return new WaitForSeconds(1);
        em.timer_txt.text = "Starting next wave in: " + 4 + " seconds";
        yield return new WaitForSeconds(1);
        em.timer_txt.text = "Starting next wave in: " + 3 + " seconds";
        yield return new WaitForSeconds(1);
        em.timer_txt.text = "Starting next wave in: " + 2 + " seconds";
        yield return new WaitForSeconds(1);
        em.timer_txt.text = "Starting next wave in: " + 1 + " seconds";
        yield return new WaitForSeconds(1);
        em.timer_txt.text = "";

        //gives player time before spawning 
        GameObject go = Instantiate(enemyprefab, transform.position, transform.rotation);
        
        while(enemyCount != 0)
        {
            GameObject[] g_l = GameObject.FindGameObjectsWithTag("enemy");
            if (g_l.Length == 0)
            {
                //enemy died
                enemyCount = 0;
                em.allUpdateTxt.text = "Congrats! Tutorial Complete.";
                yield return new WaitForSeconds(1.5f);
                
            }
            yield return null;
        }

       
        
    }
    

}
