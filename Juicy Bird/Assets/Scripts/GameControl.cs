using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    //public text scoreText;

    public GameObject gameOvertext;

    private int score = 0;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }
    
}
