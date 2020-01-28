using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    //public AudioMixer audioMixer;
    [SerializeField] Dropdown dropdown;
    [SerializeField] Dropdown dropdown1;
    [SerializeField] Slider slider;
    Dropdown.OptionData SSHawk;
    Dropdown.OptionData SCStorm;
    Dropdown.OptionData BSTitan;
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
        LoadShipDropDown();
        try
        {
            dropdown1.value = PlayerPrefs.GetInt("PlayerShip",0);
        }
        catch (System.Exception)
        {

            

        }
        dropdown1.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetVolume(float volume)
    {
        FindObjectOfType<SceneLoader>().audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality Index", qualityIndex);
    }
    public void SetShip(int ship)
    {
        FindObjectOfType<SoundManager>().Clicked();
        PlayerPrefs.SetInt("PlayerShip", ship);
    }

    public void ResetScore()
    {
        FindObjectOfType<SoundManager>().Clicked();
        PlayerPrefs.DeleteKey("HighScore");
    }
    public void LoadShipDropDown()
    {
        SSHawk = new Dropdown.OptionData("SS Hawk");
        SCStorm = new Dropdown.OptionData("SC Storm");
        BSTitan = new Dropdown.OptionData("BS Titan");

        
        dropdown1.options.Insert(0,SSHawk);
        
        if (PlayerPrefs.GetString("SCStormUnlocked", "false") == "true") dropdown1.options.Insert(1,SCStorm);
        if (PlayerPrefs.GetString("BSTitanUnlocked", "false") == "true") dropdown1.options.Insert(2,BSTitan);

      
        //if (PlayerPrefs.GetString("BSTitanUnlocked", "false") == "true") DisablePurchaseBSTitanButton();
        //else EnablePurchaseBSTitanButton();
    }
}
