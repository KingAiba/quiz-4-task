using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    public HealthManager playerManager;

    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<HealthManager>();
    }

    
    void Update()
    {
        
    }

    public void AddScore(int val)
    {
        score += val;
    }
}
