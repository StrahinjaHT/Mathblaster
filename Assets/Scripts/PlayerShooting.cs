using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public BulletObject bulletObject;
    [SerializeField] public GameObject bullet;
    [SerializeField] GameObject gun;

    public  SoundManager soundManager;
    
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Shoot()
    {
        
        var gunPos = gun.transform.position;
        soundManager.ShotsFired();
        bullet.GetComponent<Bullet>().bulletObject = bulletObject;
        bullet.GetComponent<Bullet>().SetBullet();
        
        Instantiate(bullet, gunPos, transform.rotation);

    }
}
