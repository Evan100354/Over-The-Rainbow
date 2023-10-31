using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    
    private TimeManager timemanager;
    
    private Rigidbody rb;
    
    private Vector3 recordedVelocity;
    private float recordedMagnitude;


    public float TimeBeforeAffected; //The time after the object spawns until it will be affected by the timestop(for projectiles etc)
    private float TimeBeforeAffectedTimer;
    public bool CanBeAffected;
    public bool IsStopped;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        TimeBeforeAffectedTimer = TimeBeforeAffected;
    }


    void Update()
    {
        TimeBeforeAffectedTimer -= Time.deltaTime; // minus 1 per second
        if (TimeBeforeAffectedTimer <= 0f)
        {
            CanBeAffected = true; // Will be affected by timestop
        }

        if (CanBeAffected && timemanager.TimeIsStopped && !IsStopped)
        {
            if (rb.velocity.magnitude >= 0f) //If Object is moving
            {
                recordedVelocity = rb.velocity.normalized; //records direction of movement
                recordedMagnitude = rb.velocity.magnitude; // records magitude of movement

                rb.velocity = Vector3.zero; //makes the rigidbody stop moving
                rb.isKinematic = true; //not affected by forces
                IsStopped = true; // prevents this from looping
            }


        }

    }
    public void ContinueTime()
    {
        rb.isKinematic = false;
        IsStopped = false;
        rb.velocity = recordedVelocity * recordedMagnitude; //Adds back the recorded velocity when time continues
    }
}