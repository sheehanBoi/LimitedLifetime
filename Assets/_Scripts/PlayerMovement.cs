using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /*
    InputAction moveAction;
    InputAction jumpAction;

    Vector2 moveForce = new Vector2(1, 0);
    */

    float moveSpeed = 5f;
    Rigidbody2D rb;
    Vector2 moveInput;

    void Start()
    {
        /*
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction.Enable();
        */

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void Attack()
    {

    }
}
