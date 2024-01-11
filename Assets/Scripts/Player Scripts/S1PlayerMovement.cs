using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S1PlayerMovement : MonoBehaviour
{

    //Movement setup

    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public Animator anim;

    public GameObject footstep;
    public GameObject jump;

    public KeyCode sprintKey = KeyCode.LeftShift;

    public Transform Orientation;

    float horizontalInput;
    float verticalInput;

    public string gameOverScene;

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
        horizontalInput = Input.GetAxisRaw("Horizontal") * -1;
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && canJump && grounded)
        {
            canJump = false;

            Jump();

            Invoke(nameof(resetJump), jumpCooldown);

            anim.SetTrigger("Jump");
            anim.SetTrigger("Land");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(gameOverScene);
        }
    }

    private void Update()
    {

        //Check if grounded by raycast

        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, ground);

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

        /* Vector3 currentSpeed = (rb.velocity.x, rb.velocity.y, rb.velocity.z);

        if(rb.velocity = 0)
        {
            anim.SetFloat("Walk", 0);
            anim.Play("Idle");
        }
        */

        if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d"))
        {
            anim.SetFloat("Walk", 1);
        }

        if (Input.GetKeyDown("w") && Input.GetKeyDown("a") && Input.GetKeyDown("s") && Input.GetKeyDown("d"))
        {
            anim.Play("Idle");
        }

        if (Input.GetKeyDown("left shift"))
        {
            anim.SetFloat("Run", 1);
            anim.SetFloat("Walk", 0);
        }

        if (Input.GetKeyUp("left shift"))
        {
            anim.SetFloat("Run", 0);
        }
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

    void footsteps()
    {
        if (grounded == true)
        {
            footstep.SetActive(true);
        }
        else
        {
            footstep.SetActive(false);
        }
    }

    void jumping()
    {
        if (grounded == false)
        {
            jump.SetActive(true);
        }
        else
        {
            jump.SetActive(false);
        }
    }
}
