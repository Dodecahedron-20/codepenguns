using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public PlayerMovement catcher;
    public AudioSource bucket;
    public GameObject CollectSound;
    public GameObject MissSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (catcher.ability == true)
        {
           // bool isEnemy = collision.CompareTag("EnemyBullet");
            if (collision.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);

                CollectSound.GetComponent<AudioSource>().Play();
            }
            else
            {
                MissSound.GetComponent<AudioSource>().Play();
            }
        }
    }
}
