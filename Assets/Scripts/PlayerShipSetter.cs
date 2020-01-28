using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerShipSetter : MonoBehaviour
{
    [SerializeField] public float speed ;
    [SerializeField] public int maxHealth ;
    public int health;
    [SerializeField] public TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI gunOverheatedText;
    [SerializeField] Image overheatBar;

    public float overheatFactor = 0f;
    public float maxOverheat ;
    public float overheatDecreaseRate = 2;
    public float slowFactor;
    Color standardOverheatBarColor;
    public bool gunLock = false;
    SoundManager soundManager;
    PlayerShooting playerShooting;
    
    public ShipObject shipObject;
    

    
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        playerShooting = GetComponent<PlayerShooting>();

        SetShip();
        SetShipSpecifications();

        health = maxHealth;
        healthText.text = health.ToString();
        slowFactor = overheatFactor / maxOverheat;
        standardOverheatBarColor = overheatBar.color;
    }

    private void SetShipSpecifications()
    {
        maxHealth = shipObject.maxHealth;
        maxOverheat = shipObject.maxOverheat;
        speed = shipObject.speed;
        GetComponent<SpriteRenderer>().sprite = shipObject.sprite;
    }

    private void SetShip()
    {


        shipObject = FindObjectOfType<GameSession>().shipObjects[PlayerPrefs.GetInt("PlayerShip", 0)];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(collision);

        }


    }
    public void RegulateOverheat()
    {
        if (overheatFactor > 0)
        {
            if (overheatFactor > maxOverheat)
            {
                overheatFactor = maxOverheat;
                lockGun();
            }
            else if (overheatFactor + playerShooting.bulletObject.number > maxOverheat && !gunLock)
            {
                overheatBar.color = Color.yellow;
            }
            else if (!gunLock)
            {
                overheatBar.color = standardOverheatBarColor;
            }
            overheatFactor -= Time.deltaTime * overheatDecreaseRate;
        }

        else
        {
            unlockGun();
        }

        slowFactor = overheatFactor / maxOverheat;
        GameObject.Find("Overheat Bar").GetComponent<SimpleHealthBar>().UpdateBar(overheatFactor, maxOverheat);
    }
    public void lockGun()
    {
        gunLock = true;
        gunOverheatedText.enabled = true;
        overheatBar.color = Color.red;
    }
    public void unlockGun()
    {
        gunLock = false;
        gunOverheatedText.enabled = false;
        overheatBar.color = standardOverheatBarColor;
    }
    private void TakeDamage(Collider2D collision)
    {
        health -= collision.gameObject.GetComponent<Enemy>().enemyObject.number;
        GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(health, maxHealth);
        healthText.text = health.ToString();
        Handheld.Vibrate();


        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        soundManager.PlayerDead();
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }
}
