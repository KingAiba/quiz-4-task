using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileTarget { Enemy, Player }

public class ProjectileShooter : MonoBehaviour
{
    public ObjectPooler pooler;

    public PoolType toShoot;
    public ProjectileTarget target;

    public float fireRate;
    public bool canShoot = false;

    public float projSpeed;
    public float projTTL;
    public int projDamage;

    void Start()
    {
        pooler = ObjectPooler.Instance;
    }

    
    void Update()
    {
        
    }

    public void Shoot()
    {
        if(canShoot)
        {
            canShoot = false;
            ProjectileScript proj = pooler.GetObjectFromPool(toShoot).GetComponent<ProjectileScript>();
            proj.FireProjectile(transform.position, transform.up, projSpeed, projTTL, projDamage, target);
            StartCoroutine(FireRateCooldown());
        }


        
    }

    IEnumerator FireRateCooldown()
    {
        yield return new WaitForSeconds(1 / fireRate);
        canShoot = true;
    }
}
