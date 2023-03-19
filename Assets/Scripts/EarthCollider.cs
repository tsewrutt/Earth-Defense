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
   // public Text moneyTxt;
    private string updateTxt;
    // Start is called before the first frame update

    //GRAB STUFF FROM ES AND MANIPULATE IT
    public EnemySpawner em;
    public GameObject heart;
    void Start()
    {
        UpdateText();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            health = health - enemydamage;
            StartCoroutine(em.Shake(heart));

            UpdateText();
            if(health == 0)
            {
                SceneManager.LoadScene("endscene");
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
        /*if(tp != null)
        {
            Turret t = tp.selectedPrefab.GetComponent<Turret>();
            //placed
            money = money - t.cost;
            UpdateText();
        }
*/
    }
}
