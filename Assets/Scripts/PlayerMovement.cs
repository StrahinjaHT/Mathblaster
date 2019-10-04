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
    // Start is called before the first frame update
    void Start()
    {
         gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var Xpos = CrossPlatformInputManager.GetAxis("Horizontal");
        var Ypos = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 offset = new Vector3(Xpos, Ypos,0);

        transform.position += offset*speed*Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            FindObjectOfType<SceneLoader>().loadGameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            PickUp pickUp = collision.gameObject.GetComponent<PickUp>();
            Destroy(collision.gameObject);
            //          Debug.Log("One");
            if (pickUp.name.Contains("One"))
                FindObjectOfType<GameSession>().UpdateScore();
            else
                GetComponent<PlayerShooting>().bullet = pickUp.bullet;
        }
    }
   

}
