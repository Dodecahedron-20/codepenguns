using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int playerNumber;
    public float moveSpeed;
    public Animator animator;
    public float abilityDelay = 0.5f;
    public AudioSource abilitySFX;
    public AudioSource[] footsteps;
    private Vector2 moveInput;
    private Vector2 lastInput;
    private Rigidbody2D rb;
    [HideInInspector]
    public bool ability;
    private Vector2 mousePos;
    public GameObject playerBullet;

    private int bulletNumber;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Footstep");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(moveInput * moveSpeed);
    }

    private void Update()
    {
        if (true)
        {
            if (moveInput != Vector2.zero)
            {
                lastInput = moveInput;
            }
            animator.SetFloat("lastx", lastInput.x);
            animator.SetFloat("lasty", lastInput.y);
            animator.SetFloat("x", moveInput.x);
            animator.SetFloat("y", moveInput.y);

        }

        animator.SetBool("ability", ability);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.action.ReadValue<Vector2>();
    }
    public void OnAbility(InputAction.CallbackContext context)
    {
        if (context.started && ability == false)
        {
            ability = true;
            abilitySFX.Play();
            Invoke("StopAbility", abilityDelay);
            bulletNumber = BulletSystems.Instance.currentBullets;
            if (bulletNumber > 0)
            {
                Instantiate(playerBullet, transform.position, Quaternion.AngleAxis((Mathf.Atan2(transform.position.y - mousePos.y, transform.position.x - mousePos.x) * Mathf.Rad2Deg) + 180, Vector3.forward));
                bulletNumber -= 1;
                BulletSystems.Instance.currentBullets = bulletNumber;
                BulletSystems.Instance.shoot = true;
            }
        }
    }
    public void OnAim(InputAction.CallbackContext context)
    {
        mousePos = context.action.ReadValue<Vector2>();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void StopAbility()
    {
        ability = false;
    }

    IEnumerator Footstep()
    {
        while (true)
        {
            if (moveInput != Vector2.zero)
            {
                footsteps[Random.Range(0, footsteps.Length - 1)].Play();
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}
