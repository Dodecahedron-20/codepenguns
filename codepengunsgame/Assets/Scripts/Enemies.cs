using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private bool seenPlayer;
    [SerializeField]
    private bool shotBullet = false;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float currentCDTimer;
    [SerializeField]
    private float setCDTimer = 0.5f;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private bool stopMoving;

    [SerializeField]
    private float distFromPlayer;

    Transform target;
    Vector2 moveDir;

    [SerializeField]
    private GameObject player;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distFromPlayer = Vector2.Distance(this.transform.position, player.transform.position);

        if(target && seenPlayer == true)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDir = dir;
        }

        if(shotBullet == true)
        {
            currentCDTimer = Mathf.Clamp(currentCDTimer -= Time.deltaTime, 0f, setCDTimer);
        }

        if(currentCDTimer <= 0f)
        {
            shotBullet = false;
        }

        if (seenPlayer == true)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            Shoot();
        }
        else if(seenPlayer == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        if(distFromPlayer >= 15f)
        {
            seenPlayer = false;
        }
        else if (distFromPlayer <= 15f)
        {
            seenPlayer = true;
        }

        if(distFromPlayer <= 5f)
        {
            seenPlayer = false;
        }
    }

    private void FixedUpdate()
    {
        if(target && seenPlayer == true)
        {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * moveSpeed;
        }
    }

    private void Shoot()
    {
        if(currentCDTimer <= 0f && shotBullet == false)
        {
            Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
            currentCDTimer = setCDTimer;
            shotBullet = true;
        }
    }
}
