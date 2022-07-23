using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public float abilityDelay = 0.5f;
    private Vector2 moveInput;
    private Vector2 lastInput;
    private Rigidbody2D rb;
    private bool ability;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (context.started)
        {
            ability = true;
            Invoke("StopAbility", abilityDelay);
        }
    }

    private void StopAbility()
    {
        ability = false;
    }
}
