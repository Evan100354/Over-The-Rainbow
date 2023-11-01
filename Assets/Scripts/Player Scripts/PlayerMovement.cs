using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public static float speed = 10f;
    public Rigidbody rb;
    public bool grounded = false;
    public bool forward = true;

    float horizontalnput;

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalnput * speed * Time.fixedDeltaTime * -1;
        Vector3 backMove = transform.forward * speed * Time.fixedDeltaTime * -1;

        //Constantly moves player forward
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        
        //Player inputs for movement
        if (Input.GetKey("s"))
        {
            rb.MovePosition(rb.position + (backMove * 2) + horizontalMove);
        }
        if (Input.GetKey("w"))
        {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }


        //Left, Right and Jump Inputs
        horizontalnput = Input.GetAxis("Horizontal");
        if (Input.GetKey("space") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        horizontalMove.Normalize();
    }

    private void Update()
    {

    }

    //GroundCheck
    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }
}
    /*SCRIPT IDEAS
     * In order for the ability to move back in a certain space while still moving the gameplay forward we could use a while loop
     * with an if statement and a bool maybe...?
     * something like; while(moveBack == true)
     *                 {
     *                      if(Input.GetKeyDown("s"))
     *                      {
     *                          move back script or smn idk bro im losin myself
     *                      }
     *                 }
     *                 
     */