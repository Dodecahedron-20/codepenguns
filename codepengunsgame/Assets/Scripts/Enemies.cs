using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemyBullet;

    public GameObject playerCatcher;
    public GameObject playerShooter;

    public float targetCatcherPreference;
    

    public Rigidbody2D rb;
    public float maxRange;
    public float minRange;


    private bool targettingCatcher = false;

    private float currentBulletDelay;
    private float bulletDelay = 0.5f;

    private bool shotBullet = false;

    public float moveSpeed;

    private float distFromPlayer;
    private Vector3 dir;


    private void FixedUpdate()
    {

        if ((Vector2.Distance(transform.position, playerShooter.transform.position)) + targetCatcherPreference >= Vector2.Distance(transform.position, playerCatcher.transform.position))
        {
            distFromPlayer = Vector2.Distance(transform.position, playerCatcher.transform.position);
            targettingCatcher = true;

        }
        else
        {
            distFromPlayer = Vector2.Distance(transform.position, playerShooter.transform.position);
            targettingCatcher = false;

        }




        if (distFromPlayer <= maxRange)
        {

           

            if (targettingCatcher == true)
            {
                dir = (playerCatcher.transform.position - transform.position).normalized;
            }
            else
            {
                dir = (playerShooter.transform.position - transform.position).normalized;

            }


            Vector3 angle = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            rb.rotation = angle.z;
            if (distFromPlayer >= minRange)
            {
                rb.velocity = new Vector2(dir.x, dir.y) * moveSpeed;
            }
            Shoot();
        }

        if (shotBullet == true)
        {
            currentBulletDelay = Mathf.Clamp(currentBulletDelay -= Time.deltaTime, 0f, bulletDelay);
        }

        if (currentBulletDelay <= 0f)
        {
            shotBullet = false;
        }
    }

    private void Shoot()
    {
        if(currentBulletDelay <= 0f && shotBullet == false)
        {



            GameObject bullet = Instantiate(enemyBullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
           
            
            
            
            currentBulletDelay = bulletDelay;
            shotBullet = true;
        }
    }
}
