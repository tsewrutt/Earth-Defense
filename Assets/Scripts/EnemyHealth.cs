using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100.0f;
    private float currentHealth;

    public Transform enemy;
    public Vector3 offset;
    public GameObject healthBar;
    public int damagePerShot = 10;
   

    private EnemyMovement enemyMovement;

    void Start()
    {
        currentHealth = maxHealth;
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {

        if (currentHealth <= 0 || enemyMovement.waypointIndex > enemyMovement.waypoints.Count - 1)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
