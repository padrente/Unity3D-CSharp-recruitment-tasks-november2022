using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerControll : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float movementSpeed = 3f;
    float movement = 0f;

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

}
