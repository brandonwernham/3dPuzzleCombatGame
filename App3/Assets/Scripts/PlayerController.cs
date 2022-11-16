using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody rb;

    private float previousTap;
    public float doubleTapTime = 0.2f;

    public int jumpForce;
    private CapsuleCollider capCollider;
    public LayerMask groundLayerMask;
    public bool isGrounded;
    public bool isJumping = false;
    public float yVelocity;
    public float gravity = -9.81f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCollider = transform.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (isGrounded && yVelocity < 0)
        {
            yVelocity = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            float timeSinceTap = Time.time - previousTap;

            if (timeSinceTap <= doubleTapTime)
            {
                moveSpeed = 10f;
            }
            else
            {
                moveSpeed = 5f;
            }

            previousTap = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            moveSpeed = 5f;
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            isJumping = false;
            isGrounded = false;
            yVelocity += jumpForce * Time.deltaTime;
        }
        else
        {
            isGrounded = Physics.Raycast(capCollider.bounds.center, Vector3.down, 1f, groundLayerMask);
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(moveX, yVelocity, moveZ) * moveSpeed;

        yVelocity += gravity * Time.deltaTime;
    }
}
