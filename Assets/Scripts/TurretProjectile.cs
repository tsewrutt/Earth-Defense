using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] protected Transform projectileSpawnPos;
    [SerializeField] protected float delaybtwAttacks = 2f;
    [SerializeField] protected int damage = 10;
    public GameObject bprefab;
    // Start is called before the first frame update
    public AudioSource a;
    public int Damage { get; set; }
    
    public float DelayPerShot { get; set; }
    protected float _nextAttacktime;
    protected Turret _turret;
    protected Bullet b;
    void Start()
    {
        _turret = GetComponent<Turret>();
       
        Damage = damage;
        DelayPerShot = delaybtwAttacks;
       
    }

    protected virtual void Update()
    {
        if (Time.time > _nextAttacktime)
        {
            if (_turret.target != null)
            {
                _nextAttacktime = Time.time + DelayPerShot;
                Vector2 direction = (_turret.target.transform.position - transform.position).normalized;
                GameObject bullet = Instantiate(bprefab, projectileSpawnPos.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * 2;
                Bullet bulletComponent = bullet.GetComponent<Bullet>();
                //sfx
                a.Stop();
                a.Play();
                //sfx
                bulletComponent.Damage = Damage;
                bulletComponent.SetEnemy(_turret.target);
                Destroy(bullet, 3.0f);
            }
        }
    }


}
