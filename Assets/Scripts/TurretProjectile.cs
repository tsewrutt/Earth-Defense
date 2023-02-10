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
    
    public int Damage { get; set; }
    
    public float DelayPerShot { get; set; }
    protected float _nextAttaktime;
    protected Turret _turret;
    protected Bullet b;
    void Start()
    {
        _turret = GetComponent<Turret>();
        //we dont need pooler
        Damage = damage;
        DelayPerShot = delaybtwAttacks;
       // LoadProjectile();
    }

    // Update is called once per frame
  protected virtual void Update()
    {
/*        if (IsTurretEmpty())
        {
            LoadProjectile();
        }*/
        if(Time.time > _nextAttaktime)
        {
            _nextAttaktime = Time.time + 1.0f / delaybtwAttacks;
            GameObject bullet = Instantiate(bprefab, transform.position, transform.rotation);
            //Vector2 direction = (transform.position - transform.position).normalized;
            //bullet.GetComponent<Rigidbody2D>().velocity = direction * b_speed;
            
            bullet.transform.parent = null;
            //bullet.SetEnemy(_turret.target);
            bullet.transform.localPosition = projectileSpawnPos.position;
            //newI.transform.SetParent(projectileSpawnPos);
            Destroy(bullet, 5.0f);
            if (_turret.target != null && b != null)
            {
                b.transform.parent = null;
                b.SetEnemy(_turret.target);
            }
            _nextAttaktime = Time.time + DelayPerShot;
        }
    }

  /*  protected virtual void LoadProjectile()
    {
        //GameObject newI = _pooler.GetInstanceFromPool();
        newI.transform.localPosition = projectileSpawnPos.position;
        newI.transform.SetParent(projectileSpawnPos);

        b = newI.GetComponent<Bullet>();
        b.TurretOwner = this;
       // b.ResetProjectile();
        b.Damage = Damage;
        newI.SetActive(true);
    }*/


}
