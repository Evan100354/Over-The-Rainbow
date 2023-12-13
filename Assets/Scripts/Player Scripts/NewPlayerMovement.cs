using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{

    //Movement setup

    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public KeyCode sprintKey = KeyCode.LeftShift;

    public Transform Orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    //Apply resistance

    public float playerHeight;
    public float groundResistance;
    public LayerMask ground;
    bool grounded;

    //Jump setup

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public KeyCode jumpKey = KeyCode.Space;
    bool canJump = true;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        inAir
    }

    private void StateHandler()
    {
        //Sprinting

        if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        //Walking
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        //InAir
        else
        {
            state = MovementState.inAir;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && canJump && grounded)
        {
            canJump = false;

            Jump();

            Invoke(nameof(resetJump), jumpCooldown);
        }
    }

    private void Update()
    {

        //Check if grounded by raycast

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.5f, ground);

        //Apply resistance to speed if grounded

        if (grounded == true)
        {
            rb.drag = groundResistance;
        }
        else
        {
            rb.drag = 0;
        }

        myInput();
        speedLimit();
        StateHandler();
    }

    private void movePlayer()
    {
        //Set player to always move towards mouse

        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        //Move Player
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    void FixedUpdate()
    {
        movePlayer();
    }

    private void speedLimit()
    {

        //Get velocity of rigidbody

        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //Limit the velocity if it's greater than intended move speed

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        //Make y velocity = 0 so all jumps are same height

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        canJump = true;
    }
}
