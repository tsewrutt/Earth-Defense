using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 5.0f;

    public int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoints[waypointIndex];
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            Vector3 targetPosition = waypoints[waypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
    }

    public static void Initialize(EnemyMovement enemyPath, List<Vector3> waypoints, float speed)
    {
        enemyPath.waypoints = waypoints;
        enemyPath.speed = speed;
    }

}
