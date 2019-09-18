using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject player;
    public GameObject topPipe;
    public GameObject groundPipe;
    public Rigidbody rb2d;

    public bool GameOver;
    public bool start;
    public float yta;
    public float time;
    public float addPoints;

    public List<GameObject> ajj;
    
    
    public AudioSource DeathSound;
    public Text points;



    
    void Start()
    {
        yta = gameObject.transform.GetSiblingIndex();
        time = 3;
    }

    
    void Update()
    {
        points.text = "Score: " + addPoints;
        yta += time;
        time -= Time.deltaTime;
        if (time <= 0)
        {
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
            ajj.Add(typ);
            time = 3;
        }

        if (start == true)
        {
            if (GameOver != true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb2d.AddForce(Vector3.up * 250);
                }
            }
        }

        if (GameOver == true)
        {
            if (DeathSound.isPlaying == false)
            {
                if (yta == 13)
                {
                    yta = yta / yta;
                }
                DeathSound.Play();
            }
            
            rb2d.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("It's over");
        }

        if (ajj.Count > 10)
        {
            Destroy(ajj[0]);
            ajj.RemoveAt(0);
        }
        if (start == true)
        {
            if (GameOver == false)
            {
                addPoints += 1 * Time.deltaTime;
            }
        }
        for (int i = 0; i < ajj.Count; i++)
        {

            ajj[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }

        if (start == false)
        {
            rb2d.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("Not started");
        }
        else
        {
            if (GameOver == false)
            {
                rb2d.constraints = RigidbodyConstraints.None;
                rb2d.constraints = RigidbodyConstraints.FreezeRotation;
                Debug.Log("started");
            }
            
        }

        //Players press Space to fly
        if (start == false)
        {
          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
                rb2d.AddForce(Vector3.up * 250);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "DON'T TOUCH")
        {
            GameOver = true;
            rb2d.velocity = Vector2.zero;
        }
    }


}
