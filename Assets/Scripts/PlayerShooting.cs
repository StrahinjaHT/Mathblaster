using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public BulletObject bulletObject;
    [SerializeField] public Bullet bullet;
    [SerializeField] Transform gun;
    [SerializeField] public TextMeshProUGUI bulletText;
    PlayerShipSetter playerShip;
    // Start is called before the first frame update
    void Start()
    {
        bullet.bulletObject = bulletObject;
        UpdateBulletText();
        playerShip = GetComponent<PlayerShipSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        playerShip.RegulateOverheat();
    }

    

    public void Shoot()
    {
        if(playerShip.gunLock == false)
        {
            var gunPos = gun.position;
            FindObjectOfType<SoundManager>().ShotsFired();

            Instantiate(bullet, gunPos, transform.rotation);
            GetComponentInChildren<ParticleSystem>().Play();
            playerShip.overheatFactor += bulletObject.number;
        }
        

    }
    public void ChangeBullet(Ammo ammo)
    {
        bulletObject = ammo.bulletObject;
        bullet.bulletObject = bulletObject;
        UpdateBulletText();
    }

    private void UpdateBulletText()
    {
        bulletText.text = bulletObject.number.ToString();
        bulletText.color = bulletObject.color;
    }
    
}

