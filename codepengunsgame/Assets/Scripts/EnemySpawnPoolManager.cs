using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoolManager : MonoBehaviour
{
    public static EnemySpawnPoolManager SharedInstance;

    public List<GameObject> enemies;

    public GameObject enemy;

    public int enemiesToPool;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < enemiesToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.SetActive(false);
            enemies.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < enemies.Count; i++)
        {
            //2
            if (!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }
        //3   
        return null;
    }
}
