using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostGameControl : MonoBehaviour
{

    public GameObject player;
    public GameObject topPipe;
    public GameObject groundPipe;
    public Rigidbody2D rb2d;

    public bool gameOver;
    public bool start;
    public float yta;
    public float time;
    public int addPoints;

    public List<GameObject> Obsticles;
    public AudioSource sound;
    public Text points;


    // Start is called before the first frame update
    void Start()
    {
        yta = gameObject.transform.GetSiblingIndex();
        time = 2;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Score:" + addPoints;

        yta += time;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            //Adds obsticles

            GameObject typ = new GameObject();
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                typ = Instantiate(topPipe, new Vector3(3, 2.5f, 0), Quaternion.identity);
            }
            if (r == 1)
            {
                yta = transform.position.y;
                typ = Instantiate(groundPipe, new Vector3(3, 0.6f, 0), Quaternion.identity);
            }
            Obsticles.Add(typ);
            time = 3;
        }

        // Player needs to press SPACE to fly
        if (start == true)
        {
            if (gameOver == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb2d.AddForce(Vector2.up * 250);
                }
            }
        }

        //it's game over once the player hit the roof or the ground :)
        //Also play the "death sound" + debug.log. "lost"
        if (gameOver == true)
        {
            if (sound.isPlaying == false)
            {
                if (yta == 13)
                {
                    yta = yta / yta;
                }
                sound.Play();
            }

            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
            Debug.Log("lost");
        }

        if (Obsticles.Count > 10)
        {
            Destroy(Obsticles[0]);
            Obsticles.RemoveAt(0);

        } 
        
        // add point once the game is on
        if (start == true)
        {
            addPoints += 1;
        }

        for (int i = 0; i < Obsticles.Count; i++)
        {

            Obsticles[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }

        if (start == false)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
            Debug.Log("Not started");
        }
        else
        {
            if (gameOver == false)
            {
                rb2d.constraints = RigidbodyConstraints2D.None;
                rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
                Debug.Log("started");
            }

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "DONTTOUCH")
        {
            gameOver = true;
        }
    }
}
