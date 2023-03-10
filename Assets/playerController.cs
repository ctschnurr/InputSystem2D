using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public PlayerInputActions playerControls;

    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction fire;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    void Update()
    {
        // float moveX = Input.GetAxis("Horizontal");
        // float moveY = Input.GetAxis("Vertical");

        moveDirection = move.ReadValue<Vector2>();


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("We fired");
    }
}
