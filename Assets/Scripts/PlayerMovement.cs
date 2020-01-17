using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed=15f;
    [SerializeField] public int maxHealth = 10;
    public int health;
    
    //public float maxOverheat = 20f;
    GameSession gameSession;
    Rigidbody2D rb;
    SoundManager soundManager;
    [SerializeField] public TextMeshProUGUI healthText;
    [SerializeField] ParticleSystem jetBack;
    [SerializeField] ParticleSystem jetRight;
    [SerializeField] ParticleSystem jetLeft;

    // Start is called before the first frame update
    void Start()
    {
         gameSession = FindObjectOfType<GameSession>();
         rb = GetComponent<Rigidbody2D>();
         soundManager = FindObjectOfType<SoundManager>();
         health = maxHealth;
         healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        var Xpos = CrossPlatformInputManager.GetAxis("Horizontal");
        var Ypos = CrossPlatformInputManager.GetAxis("Vertical");

        Vector2 offset = new Vector2(Xpos, Ypos);
        ActivateJetParticles(offset);

        //if (speed >= GetComponent<PlayerShooting>().overheatFactor)
        //{
        //    var movement = offset * (speed - GetComponent<PlayerShooting>().slowFactor*speed);
        //    rb.velocity = movement;
        //}
        //else
        //{
        //    GetComponent<PlayerShooting>().overheatFactor = speed;
        //    GetComponent<PlayerShooting>().lockGun();
        //}
        
        
        var movement = offset * (speed - GetComponent<PlayerShooting>().slowFactor * speed);
        rb.velocity = movement;
        
        

    }

    private void ActivateJetParticles(Vector2 offset)
    {
        if (offset != Vector2.zero)
        {
            jetBack.Play();
            jetRight.Play();
            jetLeft.Play();
        }
        else
        {
            jetBack.Stop();
            jetRight.Stop();
            jetLeft.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(collision);

        }


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
