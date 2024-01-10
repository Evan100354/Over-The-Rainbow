using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCollide : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            anim.Play("Punch");
        }
    }
}
