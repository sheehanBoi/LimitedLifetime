using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;

    Vector2 moveForce = new Vector2(1, 0);

    Rigidbody2D rb;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction.Enable();


        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
}
