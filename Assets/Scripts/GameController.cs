using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //UI
    public Text timer;
    public Text scoreText;


    //Variables
    public bool startGame = false;
    public float gameTimer = 60f; //initial duration of timer
    public int score = 0;


    void Start()
    {
        timer.text = "Whack a mole";
        scoreText.text = "Score: 0";
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score; 
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (gameTimer > 0f) //We check if the game is still running
            {
                //Update timer
                gameTimer -= Time.deltaTime;

                //Update Timer text
                timer.text = "Timer: " + Mathf.Floor(gameTimer);
            }

            else
            {
                timer.text = "GAME OVER";
                gameTimer = 60f;
                startGame = false;
            }
        }
    }
}
