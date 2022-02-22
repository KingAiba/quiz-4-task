using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 moveDir;

    public float ttl;

    public float damage;
    void Start()
    {
        
    }

    void Update()
    {
        MoveProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            ProjectileDestroy();
            StopCoroutine(TTLTimer());
        }
    }

    public void FireProjectile(Vector2 pos, Vector2 dir, float speed, float projectileTTL, float dmg)
    {
        transform.position = pos;
        moveSpeed = speed;
        moveDir = dir;
        ttl = projectileTTL;
        damage = dmg;

        gameObject.SetActive(true);

        StartCoroutine(TTLTimer());
    }

    public void MoveProjectile()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    public void ProjectileDestroy()
    {
        gameObject.SetActive(false);
    }

    IEnumerator TTLTimer()
    {
        yield return new WaitForSeconds(ttl);
        ProjectileDestroy();
    }
}
