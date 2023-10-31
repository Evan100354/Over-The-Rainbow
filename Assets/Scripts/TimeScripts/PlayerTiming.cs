using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTiming : MonoBehaviour
{

    public float delay = 3;
    float timer = 0;

    private TimeManager timemanager;
    
    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    void Update()
    {
        //Freeze objects when Q is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            timemanager.StopTime();
            timer++;
        }

        //Trying to unfreeze objects after a certain amount of time passes, so far not working
        if (timer > delay)
        {
            timemanager.ContinueTime();
        }

        //Unfreeze objects when E is pressed
        if (Input.GetKeyDown(KeyCode.E) && timemanager.TimeIsStopped)  //Continue Time when E is pressed
        {
            //timemanager.ContinueTime();
        }
    }
}
