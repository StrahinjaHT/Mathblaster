using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI startMenuHighScoreText;
    public AudioMixer audioMixer;

    

    // Start is called before the first frame update
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("volume",0);
        audioMixer.SetFloat("volume", volume);

        try
        {
            //TextMeshProUGUI gameOverScoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            //TextMeshProUGUI startMenuHighScoreText = GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>();
            if (gameOverScoreText != null)
            {
                int score = FindObjectOfType<GameSession>().score;
                gameOverScoreText.text = "Score: " + score.ToString();
                if (score > PlayerPrefs.GetInt("HighScore"))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                    GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>().text="New High Score!";
                }

            }
            if (startMenuHighScoreText != null)
            {
                startMenuHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
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
        if(SceneManager.GetActiveScene().name== "Game Over")
        {
            PlayVideoAd();
        }
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
        PlayBannerVideoAd();
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
    public void PlayRewardedVideoAd()
    {
        FindObjectOfType<AdController>().ShowRewardedVideoAd();
    }
    public void PlayVideoAd()
    {
        FindObjectOfType<AdController>().ShowVideoAd();
    }
    public void PlayBannerVideoAd()
    {
        FindObjectOfType<AdController>().ShowBannerVideoAd();
    }
}
