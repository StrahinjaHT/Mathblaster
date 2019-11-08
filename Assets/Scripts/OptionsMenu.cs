using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    [SerializeField] Dropdown dropdown;
    [SerializeField] Slider slider;

    // Start is called before the first frame update
    void Start()
    {

        try
        {
            
            slider.value = PlayerPrefs.GetFloat("volume");
            
                
        }
        catch (System.Exception)
        {
            slider.value = 1f;

        }
        try
        {
            dropdown.value = PlayerPrefs.GetInt("Quality Index");
        }
        catch (System.Exception)
        {

            dropdown.value = QualitySettings.GetQualityLevel();
            
        }
        dropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality Index", qualityIndex);
    }

    public void ResetScore()
    {
        FindObjectOfType<SoundManager>().Clicked();
        PlayerPrefs.DeleteKey("HighScore");
    }
}
