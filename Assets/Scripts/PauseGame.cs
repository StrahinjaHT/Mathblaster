using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseOrUResume()
    {
        soundManager.clicked();
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Resume()
    {
        
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
        //soundManager.GetComponent<AudioSource>().UnPause();
        soundManager.GetComponent<AudioSource>().volume = 0.5f;
    }
    void Pause()
    {
        
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;
        //soundManager.GetComponent<AudioSource>().Pause();
        soundManager.GetComponent<AudioSource>().volume = 0.1f;
    }
}
