using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    

    GameSession gameSession;
    Rigidbody2D rb;
    PlayerShipSetter playerShip;  
    [SerializeField] ParticleSystem jetBack;
    [SerializeField] ParticleSystem jetRight;
    [SerializeField] ParticleSystem jetLeft;

    // Start is called before the first frame update
    void Start()
    {
         gameSession = FindObjectOfType<GameSession>();
         rb = GetComponent<Rigidbody2D>();
         
         playerShip= GetComponent<PlayerShipSetter>();
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
     
        var movement = offset * (playerShip.speed - GetComponent<PlayerShipSetter>().slowFactor * playerShip.speed);
        rb.velocity = movement;
        
        

    }

    private void ActivateJetParticles(Vector2 offset)
    {
        if (offset != Vector2.zero)
        {
            jetBack.Play();
            if(playerShip.shipObject.name !="BS Titan")
            {
                jetRight.Play();
                jetLeft.Play();
            }
            
        }
        else
        {
            jetBack.Stop();
            jetRight.Stop();
            jetLeft.Stop();
        }
    }

    
}
