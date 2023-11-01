using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float bossspeed = 10f;
    public Rigidbody rbBoss;

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.right * bossspeed * Time.fixedDeltaTime;

        rbBoss.MovePosition(rbBoss.position + forwardMove);
    }
}
