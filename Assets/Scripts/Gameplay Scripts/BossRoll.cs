using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoll : MonoBehaviour
{
    public GameObject Haybale;

    void FixedUpdate()
    {
        Haybale.transform.Rotate(0, 0, -1, Space.Self);
    }
}
