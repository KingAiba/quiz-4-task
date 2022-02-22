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


    void Start()
    {
        hpManager = GetComponent<HealthManager>();
        projShooter = GetComponent<ProjectileShooter>();
    }

    
    void Update()
    {
        
    }
}
