using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public bool moveRight;
    public float moveSpeed;

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

        if (transform.position.x >= 5)
        {
            moveRight = false;
        }
        else if (transform.position.x <= -5)
        {
            moveRight = true;
        }
    }
}
