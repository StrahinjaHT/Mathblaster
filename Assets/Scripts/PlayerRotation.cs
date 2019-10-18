using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerRotation : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RotateAndShoot();
    }

    private void RotateAndShoot()
    {
        if(!PauseGame.gameIsPaused)
        {
            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(Input.touchCount - 1);
                Vector2 touchPoint = Camera.main.ScreenToWorldPoint(touch.position);
                if (touchPoint.x > -10)
                {
                    Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                    transform.up = touchPoint - pos;
                    if (touch.phase == TouchPhase.Began)
                    {
                        Shoot();
                    }

                }

            }
        }
        
        
        
    }

    private void Shoot()
    {
          GetComponent<PlayerShooting>().Shoot();
    }

    

}
