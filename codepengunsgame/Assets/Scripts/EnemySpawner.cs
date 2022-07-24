using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject enemy;
    
    public GameObject playerCatcher;
    public GameObject playerGunner;

    private float currentSpawnDelay;
    public float spawnDelay;

    [SerializeField]
    private bool playerInRange;
    private bool hasSpawned;

    // Update is called once per frame
    void Update()
    {
        if(playerCatcher && playerGunner != null)
        {
            float gunnerDistance = Vector2.Distance(transform.position, playerGunner.transform.position);
            float catcherDistance = Vector2.Distance(transform.position, playerCatcher.transform.position);

            if (gunnerDistance <= 3f || catcherDistance <= 3f)
            {
                Debug.Log("Player too close to spawner");
                playerInRange = true;
            }
            else if (gunnerDistance >= 3f || catcherDistance <= 3f)
            {
                Debug.Log("Player away from spawner");
                playerInRange = false;
            }
        }

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
    }

    private void SpawnEnemy()
    {
        if (hasSpawned == false)
        {
            if(playerInRange == false)
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
}
