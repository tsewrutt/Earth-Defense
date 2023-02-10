using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public float speed = 10.0f;
    //public int damage = 10;
    //private Transform target;
    public static Action<Enemy, int> OnEnemyHit;

    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] private float minDistanceDamage = 0.1f;

    public TurretProjectile TurretOwner { get; set; }

    public int Damage { get; set; }
    protected Enemy _etarget;
    protected virtual void MovePrjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, _etarget.transform.position, moveSpeed * Time.deltaTime);
        float distanceTotarget = (_etarget.transform.position - transform.position).magnitude;
        if(distanceTotarget < minDistanceDamage)
        {
            OnEnemyHit?.Invoke(_etarget, Damage);
            //TurretOwner.ResetTurretProjectile();
            //ObjectPooler.ReturnToPool(gameObject);
        }
    }

    private void RotateProjectile()
    {
        Vector3 enemyPos = _etarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
        transform.Rotate(0f, 0f, angle);
    }

    public void SetEnemy(Enemy e)
    {
        _etarget = e;
    }
}
