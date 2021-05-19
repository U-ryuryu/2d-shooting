using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;

    public Text scoreText;
    int score = 0;

    void Start()
    {
        gameOverText.SetActive(false);
        scoreText.text = "SCORE:" + score;
    }

    public void Update()
    {
        if (gameOverText.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Main");
            } 
        }
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
