using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager gameManager;

    public float velocity = 1;
    public Rigidbody2D rb2d;
    public AudioSource flySound;
    public AudioSource deathSound;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Player press space the ghost shall jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * velocity;  // the "jump"
            //add fly sound
            if(flySound.isPlaying == false)
            {
                flySound.Play();
            }
        
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
        if(deathSound.isPlaying == false)
        {
            deathSound.Play();
        }
    }


}
