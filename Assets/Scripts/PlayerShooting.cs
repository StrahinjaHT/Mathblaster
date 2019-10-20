using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public Bullet bullet;
    [SerializeField] GameObject gun;
    [SerializeField] AudioClip shoot;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Shoot()
    {
        
        var gunPos = gun.transform.position;
        audioSource.PlayOneShot(shoot);
        Bullet instance = Instantiate(bullet, gunPos, transform.rotation);

    }
}
