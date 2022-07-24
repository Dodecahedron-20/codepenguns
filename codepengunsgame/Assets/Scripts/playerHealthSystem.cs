using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthSystem : MonoBehaviour
{
    private int touchers = 0;
    private GameObject Heart1;
    private GameObject Heart2;
    private GameObject Heart3;
    private GameObject Heart4;
    private GameObject Heart5;

    private GameObject DamagedHeart1;
    private GameObject DamagedHeart2;
    private GameObject DamagedHeart3;
    private GameObject DamagedHeart4;
    private GameObject DamagedHeart5;

    private GameObject Player1;
    private GameObject Player2;
    private GameObject Chain;

    public GameObject hitSound;


    public GameObject gameOver;

    public static int hitCounter;

    private void Awake()
    {
        Heart1 = GameObject.Find("FullHeartOne");
        Heart2 = GameObject.Find("FullHeartTwo");
        Heart3 = GameObject.Find("FullHeartThree");
        Heart4 = GameObject.Find("FullHeartFour");
        Heart5 = GameObject.Find("FullHeartFive");

        DamagedHeart1 = GameObject.Find("DamagedHeartOne");
        DamagedHeart2 = GameObject.Find("DamagedHeartTwo");
        DamagedHeart3 = GameObject.Find("DamagedHeartThree");
        DamagedHeart4 = GameObject.Find("DamagedHeartFour");
        DamagedHeart5 = GameObject.Find("DamagedHeartFive");

        Player1 = GameObject.Find("Gunner");
        Player2 = GameObject.Find("Catcher");

        Chain = GameObject.Find("Chain");


        //gameOver = GameObject.Find("gameOver");
        gameOver.SetActive(false);

    }
    private void FixedUpdate()
    {
        touchers = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchers++;
        if (touchers >= 2)
        {
            touchers = 1;
            return;
        }
        Vector2 respawner = new Vector3(0, 0, 0);
        if (collision.CompareTag("EnemyBullet") )
        {
            hitCounter += 1;

            hitSound.GetComponent<AudioSource>().Play();
          
        }
        
        switch(hitCounter) {
            case 1: 
                Destroy(Heart1);
            break;

            case 2:
                Destroy(DamagedHeart1);
                break;

            case 3:
                Destroy(Heart2);
                break;
            case 4:
                Destroy(DamagedHeart2);
                break;


            case 5:
                Destroy(Heart3);
                break;

            case 6:
                Destroy(DamagedHeart3);
                break;

            case 7:
                Destroy(Heart4);
                break;

            case 8:
                Destroy(DamagedHeart4);
                break;

            case 9:
                Destroy(Heart5);
                break;
            case 10:
                Destroy(DamagedHeart5);
                break;

        }

        if (hitCounter == 10)
        {

            gameOver.SetActive(true);
            gameOver.GetComponent<AudioSource>().Play();

            Destroy(Player1);
            Destroy(Player2);
            Destroy(Chain);

         
        }
    }
}
