using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed=10f;
    [SerializeField] int maxHealth = 10;
    int health;
    public float slowFactor = 0f;
    GameSession gameSession;
    Rigidbody2D rb;
    SoundManager soundManager;
    
    // Start is called before the first frame update
    void Start()
    {
         gameSession = FindObjectOfType<GameSession>();
         rb = GetComponent<Rigidbody2D>();
         soundManager = FindObjectOfType<SoundManager>();
         health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(slowFactor>0)
        slowFactor -= Time.deltaTime*2;


        GameObject.Find("Overheat Bar").GetComponent<SimpleHealthBar>().UpdateBar(slowFactor, speed);
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

        

        if (speed >= slowFactor)
        {
            var movement = offset * (speed - slowFactor);
            rb.velocity = movement;
        }
        else slowFactor = speed;
        
        
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
