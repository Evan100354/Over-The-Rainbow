using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public bool moveRight;
    public float moveSpeed;

    public float leftPos;
    public float rightPos;

    void FixedUpdate()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= rightPos)
        {
            moveRight = false;
        }
        else if (transform.position.x <= leftPos)
        {
            moveRight = true;
        }
    }
}
