using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] Button shopButton;
    public static bool shopWindowOpen = false;
    public GameObject shopMenuUI;
    PlayerMovement playerMovement;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        DisableShopButton();
        playerMovement = FindObjectOfType<PlayerMovement>();
        gameSession = FindObjectOfType<GameSession>();
    }

    public void DisableShopButton()
    {
        shopButton.interactable = false;
        shopButton.spriteState.Equals(shopButton.spriteState.disabledSprite);
    }
    public void EnableShopButton()
    {
        shopButton.interactable = true;
        shopButton.spriteState.Equals(shopButton.spriteState.highlightedSprite);
    }
    public void ToggleShopWindow()
    {
        FindObjectOfType<SoundManager>().Clicked();
        if (shopWindowOpen)
        {
            CloseShopWindow();
        }
        else
        {
            OpenShopWindow();
        }
    }
    public void CloseShopWindow()
    {

        shopMenuUI.SetActive(false);
        shopWindowOpen = false;
        Time.timeScale = 1f;
        
    }
    void OpenShopWindow()
    {

        shopMenuUI.SetActive(true);
        shopWindowOpen = true;
        Time.timeScale = 0f;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PurchaseHealthRefill()
    {
        if(gameSession.DecreaseScoreAfterPurchase(10))
        {
            playerMovement.health = playerMovement.maxHealth;
            GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(playerMovement.health, playerMovement.maxHealth);
            playerMovement.healthText.text = playerMovement.health.ToString();
        }
        
        
    }
    public void PurchaseMaxHealthIncrease()
    {
        if (gameSession.DecreaseScoreAfterPurchase(20))
        {
            playerMovement.maxHealth*=2;
            playerMovement.health *= 2;
            GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(playerMovement.health, playerMovement.maxHealth);
            playerMovement.healthText.text = playerMovement.health.ToString();
        }


    }
}
