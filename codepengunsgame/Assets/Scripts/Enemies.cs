using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject playerCatcher;
    public GameObject playerShooter;
    public Rigidbody2D rb;
    public float targetCatcherPreference;
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

            dir = (playerShooter.transform.position - transform.position).normalized;

            if (targettingCatcher == true)
            {
                dir = (playerCatcher.transform.position - transform.position).normalized;
            }
            else
            {
                dir = (playerShooter.transform.position - transform.position).normalized;
            }
            transform.right = dir;

            if (distFromPlayer >= minRange)
            {
                rb.AddForce(transform.right * moveSpeed);
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
            Instantiate(enemyBullet, gameObject.transform.position, gameObject.transform.rotation);
            currentBulletDelay = bulletDelay;
            shotBullet = true;
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
