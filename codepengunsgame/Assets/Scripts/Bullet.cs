using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    private Rigidbody2D rb;

    void Start()
    {
        currentLifeSpan = setLifeSpan;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * moveSpeed);
        Destroy(gameObject, 10f);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Players"))
        {
            Debug.Log("PlayerHit!");
            Destroy(gameObject);
        }
    }
}
