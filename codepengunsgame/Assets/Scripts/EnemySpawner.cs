using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject enemy;

    private float currentSpawnDelay;
    public float spawnDelay;

    private bool playerInRange;
    private bool hasSpawned;

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
                enemy.transform.position = transform.position;
                enemy.transform.rotation = transform.rotation;
                enemy.SetActive(true);
                hasSpawned = true;
            }         
        }
    }
}
