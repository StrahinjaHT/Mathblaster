using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] Button shopButton;
    [SerializeField] Button showAdButton;
    [SerializeField] Button purchaseSCStorm;
    [SerializeField] Button purchaseBSTitan;
    public int lastWavePlayedAd;
    public static bool shopWindowOpen = false;
    public static bool descriptionWindowOpen = false;
    public GameObject shopMenuUI;
    public GameObject itemDescriptionWindow;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    PlayerShipSetter playerShip;
    GameSession gameSession;
   

    [SerializeField] int healthRefillPrice = 10;
    [SerializeField] int maxHealthIncreasePrice = 20;
    [SerializeField] int engineUpgradePrice = 30;
    [SerializeField] int stunRayPrice = 10;
    [SerializeField] int firestormBombPrice = 20;
    [SerializeField] int SCStormPrice = 100;
    [SerializeField] int BSTitanPrice = 200;

    [SerializeField] TextMeshProUGUI healthRefillPriceText;
    [SerializeField] TextMeshProUGUI maxHealthIncreasePriceText;
    [SerializeField] TextMeshProUGUI engineUpgradePriceText;
    [SerializeField] TextMeshProUGUI stunRayPriceText;
    [SerializeField] TextMeshProUGUI firestormBombPriceText;
    [SerializeField] TextMeshProUGUI SCStormPriceText;
    [SerializeField] TextMeshProUGUI BSTitanPriceText;



    // Start is called before the first frame update
    void Start()
    {
        DisableShopButton();
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerShooting = FindObjectOfType<PlayerShooting>();
        playerShip = FindObjectOfType<PlayerShipSetter>();
        gameSession = FindObjectOfType<GameSession>();
        UpdateShopItemPrices();
        UpdateShipPurchaseButtons();
    }

    private void UpdateShipPurchaseButtons()
    {
        if (PlayerPrefs.GetString("SCStormUnlocked", "false") == "true") DisablePurchaseSCStormButton();
        else EnablePurchaseSCStormButton();
        if (PlayerPrefs.GetString("BSTitanUnlocked", "false") == "true") DisablePurchaseBSTitanButton();
        else EnablePurchaseBSTitanButton();
    }

    private void UpdateShopItemPrices()
    {
        healthRefillPriceText.text = "Price: " + healthRefillPrice.ToString() + " points";
        maxHealthIncreasePriceText.text = "Price: " + maxHealthIncreasePrice.ToString() + " points";
        engineUpgradePriceText.text = "Price: " + engineUpgradePrice.ToString() + " points";
        stunRayPriceText.text = "Price: " + stunRayPrice.ToString() + " points";
        firestormBombPriceText.text = "Price: " + firestormBombPrice.ToString() + " points";
        SCStormPriceText.text = "Price: " + SCStormPrice.ToString() + " points";
        BSTitanPriceText.text = "Price: " + BSTitanPrice.ToString() + " points";

   
        
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
    public void DisablePurchaseSCStormButton()
    {
        try
        {
            purchaseSCStorm.interactable = false;
            purchaseSCStorm.spriteState.Equals(purchaseSCStorm.spriteState.disabledSprite);
        }
        catch (System.Exception)
        {


        }
    }
    public void DisablePurchaseBSTitanButton()
    {
        try
        {
            purchaseBSTitan.interactable = false;
            purchaseBSTitan.spriteState.Equals(purchaseBSTitan.spriteState.disabledSprite);
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
    public void EnablePurchaseSCStormButton()
    {
        try
        {
            purchaseSCStorm.interactable = true;
            purchaseSCStorm.spriteState.Equals(purchaseSCStorm.spriteState.highlightedSprite);
        }
        catch (System.Exception)
        {


        }
    }
    public void EnablePurchaseBSTitanButton()
    {
        try
        {
            purchaseBSTitan.interactable = true;
            purchaseBSTitan.spriteState.Equals(purchaseBSTitan.spriteState.highlightedSprite);
        }
        catch (System.Exception)
        {


        }
    }
    public void ToggleShopWindow()
    {
        if (PauseGame.gameIsPaused) return;
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


    public void EnableShowAdButton()
    {
        try
        {
            showAdButton.interactable = true;
            showAdButton.spriteState.Equals(showAdButton.spriteState.highlightedSprite);
        }
        catch (System.Exception)
        {


        }
    }
    public void DisableShowAdButton()
    {
        try
        {
            showAdButton.interactable = false;
            showAdButton.spriteState.Equals(showAdButton.spriteState.disabledSprite);
        }
        catch (System.Exception)
        {


        }
    }
    // Update is called once per frame
    void Update()
    {
        if (gameSession.wave > lastWavePlayedAd && FindObjectOfType<AdController>().RewardedVideoIsReady())
        {

            EnableShowAdButton();
        }
        else DisableShowAdButton();
    }
    public void PurchaseHealthRefill()
    {
        
        if(gameSession.DecreaseScoreAfterPurchase(healthRefillPrice))
        {
            playerShip.health = playerShip.maxHealth;
            GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(playerShip.health, playerShip.maxHealth);
            playerShip.healthText.text = playerShip.health.ToString();
        }
        
        
    }
    public void PurchaseMaxHealthIncrease()
    {
        if (gameSession.DecreaseScoreAfterPurchase(maxHealthIncreasePrice))
        {
            playerShip.maxHealth*=2;
            playerShip.health *= 2;
            GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(playerShip.health, playerShip.maxHealth);
            playerShip.healthText.text = playerShip.health.ToString();

            healthRefillPrice *= 2;
            maxHealthIncreasePrice *= 2;
            UpdateShopItemPrices();
        }


    }
    public void PurchaseEngineUpgrade()
    {
        if (gameSession.DecreaseScoreAfterPurchase(engineUpgradePrice))
        {
            playerShip.maxOverheat*= 2;
            playerShip.overheatDecreaseRate *= 2;
            GameObject.Find("Overheat Bar").GetComponent<SimpleHealthBar>().UpdateBar(playerShip.overheatFactor, playerShip.maxOverheat);

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
    public void PurchaseStunRay()
    {
        if (gameSession.DecreaseScoreAfterPurchase(stunRayPrice))
        {
            FindObjectOfType<UsableItemsController>().AddStunRay();
        }


    }
    public void PurchaseSCStorm()
    {
        if (gameSession.DecreaseScoreAfterPurchase(SCStormPrice))
        {
            PlayerPrefs.SetString("SCStormUnlocked", "true");
            UpdateShipPurchaseButtons();
        }


    }
    public void PurchaseBSTitan()
    {
        if (gameSession.DecreaseScoreAfterPurchase(BSTitanPrice))
        {
            PlayerPrefs.SetString("BSTitanUnlocked", "true");
            UpdateShipPurchaseButtons();
        }


    }
    public void ResetShips()
    {
        PlayerPrefs.SetString("SCStormUnlocked", "false");
        PlayerPrefs.SetString("BSTitanUnlocked", "false");
        UpdateShipPurchaseButtons();
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
    public void PlayRewardedVideoAd()
    {
        FindObjectOfType<AdController>().ShowRewardedVideoAd();

        DisableShowAdButton();
        lastWavePlayedAd = gameSession.wave;
    }

}
