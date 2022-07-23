using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public Rigidbody2D rb;
    public float maxRange;
    public float minRange;

    private float currentBulletDelay;
    private float bulletDelay = 0.5f;

    private bool shotBullet = false;

    public float moveSpeed;

    private float distFromPlayer;

    private void FixedUpdate()
    {
        distFromPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distFromPlayer <= maxRange)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
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
            Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
            currentBulletDelay = bulletDelay;
            shotBullet = true;
        }
    }
}
