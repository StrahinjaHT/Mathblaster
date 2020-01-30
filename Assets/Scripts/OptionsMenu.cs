
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    //public AudioMixer audioMixer;
    [SerializeField] Dropdown dropdown;
    [SerializeField] Dropdown dropdown1;
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

        
        
        //if (PlayerPrefs.GetString("SCStormUnlocked", "false") == "true") 
        //if (PlayerPrefs.GetString("BSTitanUnlocked", "false") == "true") 

      

    }
}
