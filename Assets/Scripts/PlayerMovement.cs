using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed=10f;
    GameSession gameSession;
    Rigidbody2D rb;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
         gameSession = FindObjectOfType<GameSession>();
         rb = GetComponent<Rigidbody2D>();
         soundManager = FindObjectOfType<SoundManager>();
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

        //transform.position += offset*speed*Time.deltaTime;
        rb.velocity = offset * speed;
        //rb.AddForce(offset * speed,ForceMode2D.Force);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            soundManager.PlayerDead();
            FindObjectOfType<SceneLoader>().LoadGameOver();
            
        }
        else if (collision.gameObject.tag == "PickUp")
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            PickUp pickUp = collision.gameObject.GetComponent<PickUp>();
            Destroy(collision.gameObject);
            
            if (pickUp.name.Contains("One"))
                FindObjectOfType<GameSession>().UpdateScore();
            else
                GetComponent<PlayerShooting>().bulletObject= pickUp.bulletObject;
        }
        
    }
   

}
