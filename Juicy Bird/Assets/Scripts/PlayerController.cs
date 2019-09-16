using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anime;

    private bool GameOver = false;

    public float obstacles;
    public float upForce;

    public AudioSource GameOverSound;

    void Start()
    {
        anime = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Player, press SPACE to fly
        if(GameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anime.SetTrigger("Fly");
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        GameOver = true;
        anime.SetTrigger("Die");
        //GameControl.instance.GhostDied();
    }

    
}
