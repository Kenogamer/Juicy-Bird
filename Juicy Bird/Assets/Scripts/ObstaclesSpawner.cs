using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{       // Time to make the pipes/obstacles appear! - L.

    public float height;
    public float maxTime = 1;
    private float timer = 0;
    public GameObject obstacles;

    void Start()
    {
        GameObject newobstacles = Instantiate(obstacles);
        newobstacles.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    void Update()
    {
        if(timer > maxTime)
        {
            GameObject newobstacles = Instantiate(obstacles);
            newobstacles.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newobstacles, 15);
            timer = 0;
        }

        timer += Time.deltaTime;

    }

}
