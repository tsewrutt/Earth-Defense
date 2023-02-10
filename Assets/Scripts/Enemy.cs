using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenth;
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
        if (currenth <= 0 || enemyMovement.waypointIndex > enemyMovement.waypoints.Count - 1)
        {
            //spawner.DecrementEnemies();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currenth -= damage;

        healthbar.SetHealth(currenth);
    }

}
