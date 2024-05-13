using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Making an instance of this game manger so it can be called
    // anywhere. Since it's a static variable it's stored in memory
    // for the duration of the runtime.
    public static GameManager instance;

    int score = 0;
    int lives = 3;
    bool gameOver = false;

    public GameObject livesHolder; // Drag and drop LivesPanel here.

    public GameObject gameOverPanel;

    public Text scoreText; // Text is an object type in UnityEngine.UI

    // Setting the instance of the GameManger to be this instance.
    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Calling this function will add to the score
    // and print it to the console to check the
    // functionality.
    public void IncrementScore()
    {
        if (!gameOver) // If the game is not over
        {
            score++;
            scoreText.text = score.ToString();

            // This is some code I'll add to version 2 that gives the player back
            // a life after every x candies (Currently 5). I can also add a streak
            // counter later and make it after every x in a row instead of just
            // after every x.

            //if (score % 5 == 0)
            //{
            //    livesHolder.transform.GetChild(lives).gameObject.SetActive(true);
            //    lives++;
            //}
        }

    }

    public void DecrementLives()
    {
        if (lives > 0)
        {
            lives--;
            print(lives);

            // The number of child objects in the livesHolder aligns with how
            // we count the number of lives in the game ie when lives goes down
            // to 2, delete the child object at index 2 (the third heart), then
            // the same when lives go down to 1 and 0: delete the second and
            // first heart.

            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }

        if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        CandySpawner.instance.StopSpawningCandies(); // Stop spawning candies

        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false; // Disabling player movement

        gameOverPanel.SetActive(true);

        print("Game over!");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
