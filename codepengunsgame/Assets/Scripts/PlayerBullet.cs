using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    private Rigidbody2D rb;

    public float setLifeSpan;
    private float currentLifeSpan;

    void Start()
    {
        currentLifeSpan = setLifeSpan;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * moveSpeed);
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        currentLifeSpan = Mathf.Clamp(currentLifeSpan -= Time.deltaTime, 0f, setLifeSpan);

        if (currentLifeSpan <= 0)
        {
            Destroy(gameObject);
        }
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
