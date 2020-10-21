using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class ImpulseController : MonoBehaviour {
    public float speed = 10f;
    public float jumpForce = 5f;
    public float rayDistance = 5f;
    public LayerMask WhatIsGround;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        movement = (transform.right * Horizontal + transform.forward * Vertical) * speed; // multiply by speed and you got your movement ready
                                                                                          // removed this part, don't know what was the point of it

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, rayDistance, WhatIsGround);
    }

    private void FixedUpdate() {
        // y axis -> rb.velocity.y
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}