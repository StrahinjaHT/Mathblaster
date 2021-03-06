﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI startMenuHighScoreText;
    public AudioMixer audioMixer;

    public static int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("volume",0);
        audioMixer.SetFloat("volume", volume);

        try
        {
            
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
        if (SceneLoader.counter%5==0)
        {
            PlayVideoAd();
        }
        SceneLoader.counter++;
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
        if (SceneLoader.counter % 5 == 0) 
        PlayVideoAd();
        SceneLoader.counter++;
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
        if (SceneLoader.counter % 5 == 0)
            PlayVideoAd();
        SceneLoader.counter++;
        FindObjectOfType<SoundManager>().Clicked();
        SceneManager.LoadScene("Options Menu");
      

    }
    public void LoadHelpScreen()
    {
        if (SceneLoader.counter % 5 == 0)
            PlayVideoAd();
        SceneLoader.counter++;
        FindObjectOfType<SoundManager>().Clicked();
        SceneManager.LoadScene("Help Screen");


    }
    public void LoadGameOver()
    {
        if (SceneLoader.counter % 5 == 0)
            PlayVideoAd();
        SceneLoader.counter++;
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
        
        //showingAd = true;
    }
    public void PlayVideoAd()
    {
        FindObjectOfType<AdController>().ShowVideoAd();
        //showingAd = true;
    }
    //public void PlayBannerVideoAd()
    //{
    //    FindObjectOfType<AdController>().ShowBannerVideoAd();

    //}
}
