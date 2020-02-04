
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    //public AudioMixer audioMixer;
    [SerializeField] Dropdown dropdown;
    [SerializeField] Dropdown dropdown1;
    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        GetVolumeValue();
        GetGraphicsValue();
        GetShipValue();
        GetMusicValue();
    }

    private void GetMusicValue()
    {
        try
        {
            if (PlayerPrefs.GetString("music", "true") == "true")
            {
                toggle.isOn = true;
            }
            else
            {
                toggle.isOn = false;
            }

            ToggleMusic(toggle.isOn);

        }
        catch (System.Exception)
        {



        }
        
    }

    private void GetShipValue()
    {
        try
        {
            dropdown1.value = PlayerPrefs.GetInt("PlayerShip", 0);
        }
        catch (System.Exception)
        {



        }
        dropdown1.RefreshShownValue();
    }

    private void GetGraphicsValue()
    {
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

    private void GetVolumeValue()
    {
        try
        {

            slider.value = PlayerPrefs.GetFloat("volume");


        }
        catch (System.Exception)
        {
            slider.value = 1f;

        }
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
    public void ToggleMusic(bool musicToggle)
    {
        if(musicToggle)
        PlayerPrefs.SetString("music", "true");
        else
        PlayerPrefs.SetString("music", "false");
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
    
}
