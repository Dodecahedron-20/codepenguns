using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoolManager : MonoBehaviour
{
    public static EnemySpawnPoolManager SharedInstance;

    [HideInInspector]
    public List<GameObject> enemies;

    public GameObject[] pooledEnemy;

    public int enemiesToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < enemiesToPool; i++)
        {
            GameObject enemy = pooledEnemy[Random.Range(0, pooledEnemy.Length)];
            GameObject obj = Instantiate(enemy);
            obj.SetActive(false);
            enemies.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }
        return null;
    }
}
