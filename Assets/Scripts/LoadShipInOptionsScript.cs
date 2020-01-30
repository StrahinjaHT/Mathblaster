using UnityEngine;
using UnityEngine.UI;

public class LoadShipInOptionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Toggle toggle = gameObject.GetComponent<Toggle>();
        if(toggle!=null)
        {
            if(toggle.name.Contains("SC Storm"))
            {
                if (PlayerPrefs.GetString("SCStormUnlocked", "false") != "true")
                {
                    toggle.interactable = false;
                }
            }
            if (toggle.name.Contains("BS Titan"))
            {
                if (PlayerPrefs.GetString("BSTitanUnlocked", "false") != "true")
                {
                    toggle.interactable = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
