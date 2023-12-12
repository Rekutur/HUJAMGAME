using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    public int runSpeed = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMovement (InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        runSpeed = 3 + DataManager.Instance.SPD_stat * 2;
        rb.MovePosition(rb.position += movement * runSpeed * Time.fixedDeltaTime);
    }
}
