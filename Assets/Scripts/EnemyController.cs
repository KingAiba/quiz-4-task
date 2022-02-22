using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector2 moveDir;
    public float moveSpeed;

    public bool isBounded = false;

    private HealthManager hpManager;
    private ProjectileShooter projShooter;

    public GameObject target;

    private Vector2 screenBounds;
    private float widthExtent;
    private float heightExtent;

    void Start()
    {

        moveDir = transform.forward;
        hpManager = GetComponent<HealthManager>();
        projShooter = GetComponent<ProjectileShooter>();

        target = GameObject.Find("Player");

        CalcScreenBounds();
    }

    
    void Update()
    {
        PickDirection();
        MoveEnemy();
        Shoot();
        ConstrainPlayerToBounds();
        
    }

    public void onDeath()
    {
        if(hpManager.isDead)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        if(Random.Range(0, 10) > 5)
        {
            projShooter.Shoot();
        }        
    }

    public void PickDirection()
    {
        if(Random.Range(0, 10) > 6)
        {
            moveDir = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
        }
    }

    public void MoveEnemy()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    private void ConstrainPlayerToBounds()
    {
        Vector2 newPos = transform.position;

        newPos.x = Mathf.Clamp(newPos.x, screenBounds.x * -1 + widthExtent, screenBounds.x - widthExtent);
        newPos.y = Mathf.Clamp(newPos.y, screenBounds.y * -1 + heightExtent, screenBounds.y - heightExtent);

        transform.position = newPos;
    }

    private void CalcScreenBounds()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        widthExtent = GetComponent<SpriteRenderer>().bounds.extents.x/2;
        heightExtent = GetComponent<SpriteRenderer>().bounds.extents.y;
    }
}
