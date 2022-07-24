using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public PlayerMovement catcher;
    public AudioSource bucket;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (catcher.ability == true)
        {
            bool isEnemy = collision.gameObject.name.Contains("Bullet");
            if (isEnemy)
            {
                Destroy(collision.gameObject);
                bucket.Play();
            }
        }
    }
}
