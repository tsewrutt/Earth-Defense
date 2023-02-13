using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenth;
    public int reward;
    //for some reason having a moneymanager script me
    //public MoneyManager mm;
    private EnemyMovement enemyMovement;
    public HealthBar healthbar;
    private EnemySpawner spawner;

    private void Start()
    {
        currenth = maxhealth;
        //spawner = gameObject.GetComponent<EnemySpawner>();
        enemyMovement = GetComponent<EnemyMovement>();
        healthbar.SetMaxHealth(maxhealth);
    }

    private void Update()
    {
        //this is for testing purpose
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
        //
        if (currenth <= 0)
        {
           
       //     mm.money = mm.money + reward;
            Destroy(gameObject);
        }
        if(enemyMovement.waypointIndex > enemyMovement.waypoints.Count - 1)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currenth -= damage;

        healthbar.SetHealth(currenth);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet1")){
            Bullet n_b = collision.GetComponent<Bullet>();
            TakeDamage(n_b.Damage);
            Destroy(collision.gameObject);
        }
    }

}
