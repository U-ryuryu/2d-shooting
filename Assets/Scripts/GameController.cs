using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    int score = 1000;

    void Start()
    {
        scoreText.text = "SCORE:" + score;
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }
}
