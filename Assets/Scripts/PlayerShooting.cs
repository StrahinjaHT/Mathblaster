using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public Bullet bullet;
    [SerializeField] GameObject gun;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Shoot()
    {
        
        var gunPos = gun.transform.position;
        Bullet instance = Instantiate(bullet, gunPos, transform.rotation);

    }
}
