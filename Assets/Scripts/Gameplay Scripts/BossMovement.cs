using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float bossspeed = 5f;
    public Rigidbody rbBoss;

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * bossspeed * Time.fixedDeltaTime;

        rbBoss.MovePosition(rbBoss.position + forwardMove);
    }
}
