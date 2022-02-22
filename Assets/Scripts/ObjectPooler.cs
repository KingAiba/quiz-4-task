using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType { Projectile, Enemy, Boulder}

[System.Serializable]
public class Pool
{
    public PoolType key;
    public GameObject prefab;
    public int amount;

    public Pool(GameObject Obj, int Amount, PoolType Key)
    {
        prefab = Obj;
        amount = Amount;
        key = Key;
    }
}

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> objectsToPool;
    public Dictionary<PoolType, Queue<GameObject>> poolDictionary;

    public static ObjectPooler Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }

    void Start()
    {
        InitializeDictionary();
    }

    
    void Update()
    {
        
    }

    private void InitializeDictionary()
    {
        poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();

        foreach(Pool item in objectsToPool)
        {
            Queue<GameObject> newPool = new Queue<GameObject>();
            for(int i=0; i<item.amount; i++)
            {
                GameObject newobj = Instantiate(item.prefab);
                newobj.SetActive(false);
                newPool.Enqueue(newobj);
            }

            poolDictionary.Add(item.key, newPool);
        }
    }

    public GameObject GetObjectFromPool(PoolType key)
    {
        GameObject output = poolDictionary[key].Peek();

        if(!output.activeInHierarchy)
        {
            output = poolDictionary[key].Dequeue();
            poolDictionary[key].Enqueue(output);
        }
        else
        {
            Pool chosen = objectsToPool.Find(x => x.key == key);

            output = Instantiate(chosen.prefab);
            output.SetActive(false);

            poolDictionary[key].Enqueue(output);           
        }

        return output;
    }
}
