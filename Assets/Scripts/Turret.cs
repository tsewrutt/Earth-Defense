using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private List<Enemy> e_list = new List<Enemy>();
    public Enemy target;
    public int cost;

    private void Update()
    {
        GetCurrentEnemytarget();
        RotateTowardsTarget();
    }

    private void GetCurrentEnemytarget()
    {
        if (e_list.Count <= 0)
        {
            target = null;
            return;
        }
        target = e_list[0];
    }

    private void RotateTowardsTarget()
    {
        /* if (target != null)
         {
             Vector3 targetPos = target.transform.position - transform.position;
             float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
             transform.Rotate(0f, 0f, angle);
         }
         else
         {
             return;
         }*/

        if (target != null)
        {
            Vector3 targetPos = target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 180f);
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Enemy n_e = collision.GetComponent<Enemy>();
            e_list.Add(n_e);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Enemy e = collision.GetComponent<Enemy>();
            if (e_list.Contains(e))
            {
                e_list.Remove(e);
            }
        }
    }
}
