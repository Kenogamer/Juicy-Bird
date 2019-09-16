using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D fysik;
    public bool dead;
    public float yta;
    public bool alive;
    public List<GameObject> ajj;
    public GameObject pipetack;
    public GameObject NERIPE;
    public float tid;
    public AudioSource DeathSound;
    public Text points;
    public float pointsIgen;
    


    
    void Start()
    {
        yta = gameObject.transform.GetSiblingIndex();
        tid = 3;
        DeathSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        points.text = "Score: " + pointsIgen;
        yta += tid;
        tid -= Time.deltaTime;
        if (tid <= 0)
        {
            GameObject typ = new GameObject();
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                typ = Instantiate(pipetack, new Vector3(3, 2.5f, 0), Quaternion.identity);
            }
            if (r == 1)
            {
                yta = transform.position.y;
                typ = Instantiate(NERIPE, new Vector3(3, 0.6f, 0), Quaternion.identity);
            }
            ajj.Add(typ);
            tid = 3;
        }

        if (alive == true || dead != true)
        {            
          if (Input.GetKeyDown(KeyCode.Space))
          {
              fysik.AddForce(Vector3.up * 250);
          }
        }

        if (dead == true)
        {
            if (DeathSound.isPlaying == false)
            {
                if (yta == 13)
                {
                    yta = yta / yta;
                }
                DeathSound.Play();
            }
            
            fysik.constraints = RigidbodyConstraints2D.FreezePosition;
            Debug.Log("lost");
        }

        if (ajj.Count > 10)
        {
            Destroy(ajj[0]);
            ajj.RemoveAt(0);
        }
        if (alive == true)
        {
            if (dead == false)
            {
                pointsIgen += 1 * Time.deltaTime;
            }
        }
        for (int i = 0; i < ajj.Count; i++)
        {

            ajj[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }

        if (alive == false)
        {
            fysik.constraints = RigidbodyConstraints2D.FreezePosition;
            Debug.Log("Not started");
        }
        else
        {
            if (dead == false)
            {
                fysik.constraints = RigidbodyConstraints2D.None;
                fysik.constraints = RigidbodyConstraints2D.FreezeRotation;
                Debug.Log("started");
            }
            
        }

        if (alive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                alive = true;
                fysik.AddForce(Vector3.up * 250);
            }
        }


    }


    private void OnCollisionEnter(Collision2D collision)
    {
        if (collision.transform.tag == "Kill")
        {
            dead = true;
        }
    }
    
}
