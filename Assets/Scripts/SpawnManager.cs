using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Collider2D spawnArea;

    public GameManager gameManager;

    public GameObject enemyPrefab;

    public float spawnRate=1;
    public bool canSpawn = true;

    public int amount = 5;

    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        Spawn();
    }

    public void SetSpawnSmount(int a)
    {
        amount = a;
    }

    public void Spawn()
    {
        if(canSpawn && !gameManager.isPaused && gameManager.isGameActive && amount > 0 && !gameManager.isGameOver)
        {
            Vector2 pos = new Vector2(Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
        Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y));

            Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation);
            amount--;
            StartCoroutine(SpawnCooldown());
        }
    }

    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(1 / spawnRate);
        canSpawn = true;
    }
}
