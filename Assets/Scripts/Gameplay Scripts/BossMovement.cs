using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float bossspeed = 3f;
    public Rigidbody rbBoss;
    public bool running = false;

    private void Start()
    {
        StartCoroutine(RunDelay(5));
    }
    private void FixedUpdate()
    {
        if (running)
        {
            Vector3 forwardMove = transform.forward * bossspeed * Time.fixedDeltaTime;

            rbBoss.MovePosition(rbBoss.position + forwardMove);
        }
    }

    IEnumerator RunDelay(float duration)
    {
        yield return new WaitForSeconds(duration);

        running = true;
    }
}
