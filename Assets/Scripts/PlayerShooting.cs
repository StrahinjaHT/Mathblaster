using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public Bullet bullet;
    [SerializeField] GameObject gun;

    SoundManager soundManager;
    
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
        soundManager.shotsFired();
        Bullet instance = Instantiate(bullet, gunPos, transform.rotation);

    }
}
