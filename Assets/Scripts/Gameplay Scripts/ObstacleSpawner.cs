using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject Obstacle;

    public float maxX;
    public float minX;

    public float TimeBetweenSpawn;
    public float SpawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > SpawnTime)
        {
            Spawn();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);

        Instantiate(Obstacle, transform.position + new Vector3(x, 0, 0), Random.rotation);
    }
}
