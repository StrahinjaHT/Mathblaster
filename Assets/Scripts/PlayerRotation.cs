using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        if (!PauseGame.gameIsPaused && !ShopScript.shopWindowOpen)
        {
            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(Input.touchCount - 1);
                
                

                if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Vector2 touchPoint = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                    transform.up = touchPoint - pos;
                    Shoot();
                }


            }
        }



    }

    private void Shoot()
    {
        GetComponent<PlayerShooting>().Shoot();
    }



}
