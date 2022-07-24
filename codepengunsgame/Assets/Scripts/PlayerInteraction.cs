using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private int startHp = 6;
    public int hp;
    public float bulletCooldown;
    float bulletTimer;
    void Start()
    {
        hp = startHp;
    }
    void Update()
    {
        bulletTimer -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        
        if (collision.CompareTag("Bullet") && bulletTimer <= 0)
        {
            hp -= 1;
            print(hp);
            bulletTimer = bulletCooldown;
        }

        if (collision.CompareTag("Players") && hp <= 0)
        {
            hp = 1;
            print(hp);
            
        }


    }
}


