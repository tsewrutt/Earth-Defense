using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public static Action<Enemy, int> OnEnemyHit;

    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] private float minDistanceDamage = 0.1f;

    public TurretProjectile TurretOwner { get; set; }
    public int Damage { get; set; }

    protected Enemy _etarget;

    protected virtual void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, _etarget.transform.position, moveSpeed * Time.deltaTime);

        float distanceToTarget = (_etarget.transform.position - transform.position).magnitude;
        if (distanceToTarget < minDistanceDamage)
        {
            OnEnemyHit?.Invoke(_etarget, Damage);
        }
    }

    protected virtual void RotateProjectile()
    {
        Vector3 direction = _etarget.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void SetEnemy(Enemy e)
    {
        _etarget = e;
    }

    private void Update()
    {
        if (_etarget == null)
        {
            Destroy(gameObject);
            return;
        }

        MoveProjectile();
        RotateProjectile();
    }
}
