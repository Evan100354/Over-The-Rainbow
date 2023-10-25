using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    //public float jumpForce = 5f;
    public float speed = 5f;
    public Rigidbody rb;
    //public bool grounded = false;

    float horizontalnput;

    private void FixedUpdate()
    {
        //Constantly moves player forward
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalnput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
}
