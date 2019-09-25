using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    // here's where the magic happens
    // let's make this collider a bit point hungry

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.score++;
    }
}
