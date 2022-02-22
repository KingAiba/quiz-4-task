using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHP;
    public int curHP;

    public bool isDead;

    public GameManager gameManger;
    public int scoreWorth = 10;

    void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        
    }

    public void Resurrect(Vector2 pos, int newHP, int worth = 10)
    {
        isDead = false;
        scoreWorth = worth;
        SetHealth(newHP);
        transform.position = pos;

        gameObject.SetActive(true);
    }

    public void Die()
    {
        isDead = true;
        gameManger.AddScore(scoreWorth);

        gameObject.SetActive(false);      
    }


    public void SetHealth(int newHP)
    {
        maxHP = newHP;
        curHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        
        if (!isDead)
        {
            curHP -= damage;
            Debug.Log(curHP + "/" + maxHP);
        }

        if (curHP <= 0)
        {
            Die();
        }
        else if(curHP > maxHP)
        {
            curHP = maxHP;
        }

    }

}
