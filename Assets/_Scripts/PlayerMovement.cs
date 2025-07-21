using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /*
    InputAction moveAction;
    InputAction jumpAction;

    Vector2 moveForce = new Vector2(1, 0);
    */

    private Animator animator;

    float moveSpeed = 5f;
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 lastMoveDir = Vector2.down;

    void Start()
    {
        /*
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction.Enable();
        */

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);
        animator.SetBool("IsMoving", moveInput != Vector2.zero);

        if(moveInput != Vector2.zero)
        {
            lastMoveDir = moveInput;
        }

        animator.SetFloat("LastMoveX", lastMoveDir.x);
        animator.SetFloat("LastMoveY", lastMoveDir.y);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
