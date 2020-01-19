using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] Button shopButton;
    public static bool shopWindowOpen = false;
    public static bool descriptionWindowOpen = false;
    public GameObject shopMenuUI;
    public GameObject itemDescriptionWindow;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    GameSession gameSession;
   

    [SerializeField] int healthRefillPrice = 10;
    [SerializeField] int maxHealthIncreasePrice = 20;
    [SerializeField] int engineUpgradePrice = 30;
    [SerializeField] int freezenovaBombPrice = 10;
    [SerializeField] int firestormBombPrice = 20;

    [SerializeField] TextMeshProUGUI healthRefillPriceText;
    [SerializeField] TextMeshProUGUI maxHealthIncreasePriceText;
    [SerializeField] TextMeshProUGUI engineUpgradePriceText;
    [SerializeField] TextMeshProUGUI freezenovaBombPriceText;
    [SerializeField] TextMeshProUGUI firestormBombPriceText;

    // Start is called before the first frame update
    void Start()
    {
        DisableShopButton();
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerShooting = FindObjectOfType<PlayerShooting>();
        gameSession = FindObjectOfType<GameSession>();
        UpdateShopItemPrices();
    }

    private void UpdateShopItemPrices()
    {
        healthRefillPriceText.text = "Price: " + healthRefillPrice.ToString() + " points";
        maxHealthIncreasePriceText.text = "Price: " + maxHealthIncreasePrice.ToString() + " points";
        engineUpgradePriceText.text = "Price: " + engineUpgradePrice.ToString() + " points";
        freezenovaBombPriceText.text = "Price: " + freezenovaBombPrice.ToString() + " points";
        firestormBombPriceText.text = "Price: " + firestormBombPrice.ToString() + " points";
    }

    public void DisableShopButton()
    {
        try
        {
            shopButton.interactable = false;
            shopButton.spriteState.Equals(shopButton.spriteState.disabledSprite);
        }
        catch (System.Exception)
        {

            
        }
    }
    public void EnableShopButton()
    {
        try
        {
            shopButton.interactable = true;
            shopButton.spriteState.Equals(shopButton.spriteState.highlightedSprite);
        }
        catch (System.Exception)
        {

            
        }
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
        
        if(gameSession.DecreaseScoreAfterPurchase(healthRefillPrice))
        {
            playerMovement.health = playerMovement.maxHealth;
            GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(playerMovement.health, playerMovement.maxHealth);
            playerMovement.healthText.text = playerMovement.health.ToString();
        }
        
        
    }
    public void PurchaseMaxHealthIncrease()
    {
        if (gameSession.DecreaseScoreAfterPurchase(maxHealthIncreasePrice))
        {
            playerMovement.maxHealth*=2;
            playerMovement.health *= 2;
            GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(playerMovement.health, playerMovement.maxHealth);
            playerMovement.healthText.text = playerMovement.health.ToString();

            maxHealthIncreasePrice *= 2;
            UpdateShopItemPrices();
        }


    }
    public void PurchaseEngineUpgrade()
    {
        if (gameSession.DecreaseScoreAfterPurchase(engineUpgradePrice))
        {
            playerShooting.maxOverheat*= 2;
            playerShooting.overheatDecreaseRate *= 2;
            GameObject.Find("Overheat Bar").GetComponent<SimpleHealthBar>().UpdateBar(playerShooting.overheatFactor, playerShooting.maxOverheat);

            engineUpgradePrice *= 2;
            UpdateShopItemPrices();
        }


    }
    public void PurchaseFirestormBomb()
    {
        if (gameSession.DecreaseScoreAfterPurchase(firestormBombPrice))
        {
            FindObjectOfType<UsableItemsController>().AddFirestormBomb();
        }


    }
    public void PurchaseFreezenovaBomb()
    {
        if (gameSession.DecreaseScoreAfterPurchase(freezenovaBombPrice))
        {
            FindObjectOfType<UsableItemsController>().AddFreezenovaBomb();
        }


    }
    public void ShowItemDescription(string item)
    {
        itemDescriptionWindow.SetActive(true);
        descriptionWindowOpen = true;
        Touch touch = Input.GetTouch(Input.touchCount -1);
        itemDescriptionWindow.transform.position = touch.position;
        itemDescriptionWindow.GetComponentInChildren<TextMeshProUGUI>().text = item;
    }
    public void HideItemDescription()
    {
        itemDescriptionWindow.SetActive(false);
        descriptionWindowOpen = false;
    }
}
