using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EarthCollider : MonoBehaviour
{
    public int health;

   // public TurretPlacement tp;
    public int enemydamage;
    public Text txt;
    private bool killEnemybool;
   // public Text moneyTxt;
    private string updateTxt;
    // Start is called before the first frame update

    //sfx
    public AudioSource a;


    //GRAB STUFF FROM ES AND MANIPULATE IT
    public EnemySpawner em;
    public GameObject heart;
    void Start()
    {
        killEnemybool = false;
        UpdateText();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            health = health - enemydamage;
            StartCoroutine(em.Shake(heart));
            a.Stop();
            a.Play();
            UpdateText();
            if(health == 0)
            {
                StopAllCoroutines();
                em.endtxt.text = "Animals and Plants perished! You Lose!!\nPress any key to go back to main menu";

                //Now can press anything to move scene
            }
        }
    }

    private void UpdateText()
    {
        updateTxt = "" + health;
        //moneyTxt.text = "$ " + money;
        txt.text = updateTxt;
    }


    private void Update()
    {
        if(health <= 0)
        {
            
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("startscene");

            }
            if (!killEnemybool)
            {
                //stops spawing any more enemies then destroy all the current one's
                StopCoroutine(em.co);
                GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");
                foreach (GameObject go in objs)
                {
                    GameObject.Destroy(go);
                }
                killEnemybool = true;
            }
           

        }

    }
}
