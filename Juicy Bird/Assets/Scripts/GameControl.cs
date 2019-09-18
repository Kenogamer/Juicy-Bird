using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    //public text scoreText;

    public GameObject gameOvertext;

    private int score = 0;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public Text scoreText;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GhostScored()
    {
        //the ghost can not score if the game is over
        if (gameOver)
            return;

        score++;
        scoreText.text = "Score; " + score.ToString();

        
    }

    public void GhostDied()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
    }


}
