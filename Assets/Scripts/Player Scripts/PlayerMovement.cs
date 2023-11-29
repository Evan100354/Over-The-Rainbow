using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public static float speed = 7.5f;
    public Rigidbody rb;
    public bool grounded = false;
    public bool forward = true;

    public GameObject footstep;
    public GameObject jump;

    float horizontalnput;

    public Animator animator;
    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalnput * speed * Time.fixedDeltaTime * -1;
        Vector3 backMove = transform.forward * speed * Time.fixedDeltaTime * -1;

        //Constantly moves player forward
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        
        //Player inputs for movement
        if (Input.GetKey("w"))
        {
            rb.MovePosition(rb.position + (backMove * 2) + horizontalMove);
        }
        if (Input.GetKey("s"))
        {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }


        //Left, Right and Jump Inputs
        horizontalnput = Input.GetAxis("Horizontal");
        if (Input.GetKey("space") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            animator.Play("Jumping");
        }

        horizontalMove.Normalize();
    }

    void Update()
    {
        footsteps();
        jumping();
    }

    //GroundCheck
    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if(collision.gameObject.CompareTag("Player Wall"))
        {
            grounded = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
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