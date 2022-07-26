using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    private Rigidbody2D rb;
    public float setLifeSpan;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * moveSpeed);
        Destroy(gameObject, setLifeSpan);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyHit!");
            Destroy(gameObject);
        }
    }
}
