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
        
        if(scoreText!=null)
        {
            int score = FindObjectOfType<GameSession>().score;
            scoreText.text = "Score: " + score.ToString();
            if(score>PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            
        }
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        try
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
        catch (NullReferenceException)
        {

            
        }
        
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
        
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
