using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucketClip : MonoBehaviour
{

    private GameObject Clip0;
    private GameObject Clip1;
    private GameObject Clip2;
    private GameObject Clip3;
    private GameObject Clip4;
    private GameObject Clip5;
    private GameObject Clip6;
    private GameObject Clip7;
    private GameObject Clip8;
    private GameObject Clip9;
    private GameObject Clip10;
    private GameObject Clip11;

    public GameObject CollectSound;
    public GameObject MissSound;

    public PlayerMovement catcher;
    public AudioSource bucket;
    


    private GameObject Player1;
    private GameObject Player2;
    private GameObject Chain;



    public static int clipSize;

    private void Awake()
    {
        Clip0 = GameObject.Find("Clip0");
        Clip1 = GameObject.Find("Clip1");
        Clip2 = GameObject.Find("Clip2");
        Clip3 = GameObject.Find("Clip3");
        Clip4 = GameObject.Find("Clip4");
        Clip5 = GameObject.Find("Clip5");
        Clip6 = GameObject.Find("Clip6");
        Clip7 = GameObject.Find("Clip7");
        Clip8 = GameObject.Find("Clip8");
        Clip9 = GameObject.Find("Clip9");
        Clip10 = GameObject.Find("Clip10");
        Clip11 = GameObject.Find("Clip11");

        Clip0.SetActive(true);
        Clip1.SetActive(false);
        Clip2.SetActive(false);
        Clip3.SetActive(false);
        Clip4.SetActive(false);
        Clip5.SetActive(false);
        Clip6.SetActive(false);
        Clip7.SetActive(false);
        Clip8.SetActive(false);
        Clip9.SetActive(false);
        Clip10.SetActive(false);
        Clip11.SetActive(false);

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

                if (clipSize < 11)
                {
                    clipSize += 1;
                }

                CollectSound.GetComponent<AudioSource>().Play();

            }
            else
            {
                MissSound.GetComponent<AudioSource>().Play();
            }
        }


        switch (clipSize)
        {

            case 1:
                Clip0.SetActive(false);
                Clip1.SetActive(true);
                break;

            case 2:
                Clip1.SetActive(false);
                Clip2.SetActive(true);
                break;

            case 3:
                Clip2.SetActive(false);
                Clip3.SetActive(true);
                break;
            case 4:
                Clip3.SetActive(false);
                Clip4.SetActive(true);
                break;


            case 5:
                Clip4.SetActive(false);
                Clip5.SetActive(true);
                break;

            case 6:
                Clip5.SetActive(false);
                Clip6.SetActive(true);
                break;

            case 7:
                Clip6.SetActive(false);
                Clip7.SetActive(true);
                break;

            case 8:
                Clip7.SetActive(false);
                Clip8.SetActive(true);
                break;

            case 9:
                Clip8.SetActive(false);
                Clip9.SetActive(true);
                break;
            case 10:
                Clip9.SetActive(false);
                Clip10.SetActive(true);
                break;
            case 11:
                Clip10.SetActive(false);
                Clip11.SetActive(true);
                break;

        }


    }
}
