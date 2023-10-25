using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float speed = 5f;
    public Rigidbody rb;
    public bool grounded = false;

    float horizontalnput;

    private void FixedUpdate()
    {
        //Constantly moves player forward
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalnput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        //Left, Right and Jump Inputs
        horizontalnput = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown("space") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    //GroundCheck
    void OnCollisionEnter(Collision collision)
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