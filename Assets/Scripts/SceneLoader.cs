using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    

    

    // Start is called before the first frame update
    void Start()
    {

        try
        {
            if (scoreText != null)
            {
                int score = FindObjectOfType<GameSession>().score;
                scoreText.text = "Score: " + score.ToString();
                if (score > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }

            }
            if (highScoreText != null)
            {
                highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
            }
        }
        catch (Exception)
        {

            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame()
    {
        FindObjectOfType<SoundManager>().Clicked();
        SceneManager.LoadScene("Game");
        
        PauseGame.gameIsPaused = false;
        Time.timeScale = 1f;
        try
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
        catch (NullReferenceException)
        {

            
        }
        
    }
    public void LoadMenu()
    {

        FindObjectOfType<SoundManager>().Clicked();
        SceneManager.LoadScene("Start Menu");
        
        PauseGame.gameIsPaused = false;
        Time.timeScale = 1f;
        try
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
        catch (NullReferenceException)
        {


        }

    }
    public void LoadOptionsMenu()
    {
        FindObjectOfType<SoundManager>().Clicked();
        SceneManager.LoadScene("Options Menu");
      

    }
    public void LoadHelpScreen()
    {
        FindObjectOfType<SoundManager>().Clicked();
        SceneManager.LoadScene("Help Screen");


    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
        
        
    }

    public void QuitGame()
    {
        FindObjectOfType<SoundManager>().Clicked();
        Application.Quit();
    }
}
