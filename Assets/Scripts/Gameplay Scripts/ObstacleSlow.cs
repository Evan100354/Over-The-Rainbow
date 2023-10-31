using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSlow : MonoBehaviour
{
    public float duration = 10f;
    //public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SlowDown(other));
        }

    }

    IEnumerator SlowDown(Collider player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerMovement.speed = 2.5f;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        PlayerMovement.speed = 5f;

        Destroy(gameObject);
    }
}
