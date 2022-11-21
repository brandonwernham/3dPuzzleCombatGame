using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody rb;
    float moveX;
    float moveZ;

    private float previousTap;
    public float doubleTapTime = 0.2f;

    public int jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    private CapsuleCollider capCollider;
    public LayerMask groundLayerMask;
    public bool isGrounded;

    public Transform orientation;
    Vector3 moveDir;
    public float drag;

    public GameObject projectile;
    public Transform shootPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCollider = transform.GetComponent<CapsuleCollider>();
        readyToJump = true;
    }

    void Update()
    {
        MyInput();
        DragControl();
        SpeedControl();
    }

    void FixedUpdate()
    {
        PlayerPhysics();
    }

    private void PlayerPhysics()
    {
        isGrounded = Physics.Raycast(capCollider.bounds.center, Vector3.down, 1.5f, groundLayerMask);
        moveDir = orientation.forward * moveZ + orientation.right * moveX;
        
        if (isGrounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void MyInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
        {
            Run();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moveSpeed = 5f;
        }
        else if (!Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        {
            moveSpeed = 5f;
        }
        else if (!Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
        {
            moveSpeed = 5f;
        }

        if (Input.GetKey(KeyCode.Space) && readyToJump && isGrounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        }
    }

    public void Run()
    {
        float timeSinceTap = Time.time - previousTap;

        if (timeSinceTap <= doubleTapTime)
        {
            moveSpeed = 8f;
        }
        else
        {
            moveSpeed = 5f;
        }

        previousTap = Time.time;
    }

    private void DragControl()
    {
        if (isGrounded)
        {
            rb.drag = drag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void SpeedControl()
    {
        Vector3 constVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (constVelocity.magnitude > moveSpeed)
        {
            Vector3 limitSpeed = constVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitSpeed.x, rb.velocity.y, limitSpeed.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
