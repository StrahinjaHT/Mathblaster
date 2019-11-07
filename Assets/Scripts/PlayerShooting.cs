using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public BulletObject bulletObject;
    [SerializeField] public GameObject bullet;
    [SerializeField] GameObject gun;
    [SerializeField] public TextMeshProUGUI bulletText;


    // Start is called before the first frame update
    void Start()
    {

        bulletText.text = "Bullet: " + bulletObject.number;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        
        var gunPos = gun.transform.position;
        FindObjectOfType<SoundManager>().ShotsFired();
        bullet.GetComponent<Bullet>().bulletObject = bulletObject;
        bullet.GetComponent<Bullet>().SetBullet();
        
        Instantiate(bullet, gunPos, transform.rotation);
        GetComponent<PlayerMovement>().slowFactor += bulletObject.number;

    }
    public void changeBullet(PickUp pickUp)
    {
        bulletObject = pickUp.bulletObject;
        bulletText.text = "Bullet: " + bulletObject.number;
    }
}

