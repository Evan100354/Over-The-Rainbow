using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public float health = 3f;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bossObstacle")
        {
            health = health - 1;
        }
    }

    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
