using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject catcher;
    public GameObject gunner;
    public GameObject bullet;
    public Animator animator;
    public AudioSource hit;
    public AudioSource shoot;
    public float gunnerDisadvantage;

    public float targetOffset;

    public float bulletDelay;
    public float bulletCreationDelay;
    public float bulletAngleRandom;
    public float moveForce;
    public float maxRange;
    public float minRange;
    public float abilityDelay;

    private Transform target;
    private Rigidbody2D rb;
    private Rigidbody2D catcherRb;
    private Rigidbody2D gunnerRb;
    private int targetType;
    private Vector2 targetPosition;
    private Vector2 targetVelocity;

    private bool ability;

    private void Awake()
    {
        if(catcher == null && gunner == null)
        {
            catcher = GameObject.FindGameObjectWithTag("Catcher");
            gunner = GameObject.FindGameObjectWithTag("Gunner");
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        catcherRb = catcher.GetComponent<Rigidbody2D>();
        gunnerRb = gunner.GetComponent<Rigidbody2D>();
        targetType = Random.Range(0, 4);
        InvokeRepeating("TryToShoot", 1, bulletDelay);
    }

    void Update()
    {
        float gunnerDistance = Vector2.Distance(transform.position, gunner.transform.position);
        float catcherDistance = Vector2.Distance(transform.position, catcher.transform.position);

        if (gunnerDistance <= minRange || catcherDistance <= minRange)
        {
            Vector2 averagePos = (gunner.transform.position + catcher.transform.position) / 2;
            Vector2 distance = (Vector2)transform.position - averagePos;
            targetPosition = averagePos + minRange * distance.normalized;
        }
        else
        {
            if (gunnerDisadvantage + gunnerDistance <= catcherDistance)
            {
                target = gunner.transform;
                targetVelocity = catcherRb.velocity.normalized;
            }
            else
            {
                target = catcher.transform;
                targetVelocity = gunnerRb.velocity.normalized;
            }

            switch (targetType)
            {
                case 0:
                    targetPosition = targetVelocity * targetOffset;
                    break;
                case 1:
                    targetPosition = Vector2.Perpendicular(targetVelocity) * targetOffset;
                    break;
                case 2:
                    targetPosition = -Vector2.Perpendicular(targetVelocity) * targetOffset;
                    break;
                case 3:
                    targetPosition = -targetVelocity * targetOffset;
                    break;
                case 4:
                    targetPosition = target.position;
                    break;
            }
        }

        if (gunnerDisadvantage + gunnerDistance <= catcherDistance)
        {
            target = gunner.transform;
            targetVelocity = catcherRb.velocity.normalized;
        }
        else
        {
            target = catcher.transform;
            targetVelocity = gunnerRb.velocity.normalized;
        }

        switch (targetType)
        {
            case 0:
                targetPosition = targetVelocity * targetOffset;
                break;
            case 1:
                targetPosition = Vector2.Perpendicular(targetVelocity) * targetOffset;
                break;
            case 2:
                targetPosition = -Vector2.Perpendicular(targetVelocity) * targetOffset;
                break;
            case 3:
                targetPosition = -targetVelocity * targetOffset;
                break;
            case 4:
                targetPosition = target.position;
                break;
        }

        animator.SetFloat("lastx", rb.velocity.x);
        animator.SetFloat("lasty", rb.velocity.y);
        animator.SetBool("ability", ability);
    }
    private void TryToShoot()
    {
        if (Vector2.Distance(transform.position, target.position) <= maxRange)
        {
            Shoot((Mathf.Atan2(transform.position.y - target.position.y, transform.position.x - target.position.x) * Mathf.Rad2Deg) + Random.Range(-bulletAngleRandom, bulletAngleRandom));
        }
    }

    private void CancelAbility()
    {
        ability = false;
    }
    private IEnumerator InstatiateBullet(float angle)
    {
        yield return new WaitForSeconds(bulletCreationDelay);
        Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle + 180, Vector3.forward));
        shoot.Play();
    }
    private void Shoot(float angle)
    {
        if (!ability)
        {
            StartCoroutine(InstatiateBullet(angle));
            ability = true;
            Invoke("CancelAbility", abilityDelay);
        }
    }
    private void FixedUpdate()
    {
        Vector2 dir = targetPosition - (Vector2)transform.position;
        rb.AddForce(dir.normalized * moveForce);
    }

    //I added this: Jet, disables enemy if (player) bullet hits collider.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("PlayerBullet"))
        {
            Debug.Log("I'm dead x_x");
            gameObject.SetActive(false);
        }
    }
}
