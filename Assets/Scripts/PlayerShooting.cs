using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public BulletObject bulletObject;
    [SerializeField] public Bullet bullet;
    [SerializeField] Transform gun;
    [SerializeField] public TextMeshProUGUI bulletText;
    [SerializeField] public TextMeshProUGUI gunOverheatedText;
    public int overloadRate = 1;
    public bool gunLock = false;


    // Start is called before the first frame update
    void Start()
    {
        bullet.bulletObject = bulletObject;
        UpdateBulletText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if(gunLock==false)
        {
            var gunPos = gun.position;
            FindObjectOfType<SoundManager>().ShotsFired();

            Instantiate(bullet, gunPos, transform.rotation);
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<PlayerMovement>().overheatFactor += bulletObject.number / overloadRate;
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
    public void lockGun()
    {
        gunLock = true;
        gunOverheatedText.enabled = true;
    }
    public void unlockGun()
    {
        gunLock = false;
        gunOverheatedText.enabled = false;
    }
}

