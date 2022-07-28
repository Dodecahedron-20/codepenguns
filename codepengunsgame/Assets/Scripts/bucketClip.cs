using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucketClip : MonoBehaviour
{
    public GameObject CollectSound;
    public GameObject MissSound;

    public PlayerMovement catcher;
    public AudioSource bucket;
    


    private GameObject Player1;
    private GameObject Player2;
    private GameObject Chain;



    public static int clipSize;

    private int caughtBullets = 0;



    private void Awake()
    {

        Player1 = GameObject.Find("Gunner");
        Player2 = GameObject.Find("Catcher");

        Chain = GameObject.Find("Chain");

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        /* if (collision.CompareTag("EnemyBullet"))
         {
             if (clipSize < 11) {
                 clipSize += 1;
             }
            // CollectSound.GetComponent<AudioSource>().Play();
         }*/

        if (catcher.ability == true)
        {
            // bool isEnemy = collision.CompareTag("EnemyBullet");
            if (collision.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);

                clipSize += 1;
                caughtBullets += 1;
                BulletSystems.Instance.currentBullets = caughtBullets;
                BulletSystems.Instance.shoot = true;
                CollectSound.GetComponent<AudioSource>().Play();

            }
            else
            {
                MissSound.GetComponent<AudioSource>().Play();
            }

        }

    }
}
