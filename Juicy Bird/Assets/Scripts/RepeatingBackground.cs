using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundcollider;
    private float groundHlength;


    void Start()
    {
        groundcollider = GetComponent<BoxCollider2D>();
        groundHlength = groundcollider.size.x;
    }

    
    void Update()
    {
        if (transform.position.x < -groundHlength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundoffset = new Vector2(groundHlength * 2f, 0);
        transform.position = (Vector2)transform.position + groundoffset;
    }
}
