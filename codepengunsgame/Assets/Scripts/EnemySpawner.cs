using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public float currentSpawnDelay;
    public float spawnDelay;

    public bool playerInRange;
    public bool hasSpawned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpawnDelay > 0)
        {
            currentSpawnDelay = Mathf.Clamp(currentSpawnDelay -= Time.deltaTime, 0f, spawnDelay);
        }       

        if (currentSpawnDelay <= 0f && hasSpawned == true)
        {
            hasSpawned = false;
            currentSpawnDelay = spawnDelay;
        }
        else
        if(currentSpawnDelay <= 0 && hasSpawned == false)
        {
            SpawnEnemy();
        }

        if(playerInRange == true)
        {
            Debug.Log("Player within Spawn");
        }
    }

    private void SpawnEnemy()
    {
        if (hasSpawned == false)
        {
            enemy = EnemySpawnPoolManager.SharedInstance.GetPooledObject();

            if (enemy != null)
            {
                Debug.Log("Enemy Spawned");
                enemy.transform.position = this.transform.position;
                enemy.transform.rotation = this.transform.rotation;
                enemy.SetActive(true);
                hasSpawned = true;
            }         
        }
    }
}
