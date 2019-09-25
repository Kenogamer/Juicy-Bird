using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{       //Time to make the obstacles to move!

    public float speed;     //so we can easy change the speed of the moving obstacles
    

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
