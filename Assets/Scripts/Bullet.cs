﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] ParticleSystem explosionVFX;
    public BulletObject bulletObject;
    Rigidbody2D rb;
    TextMeshPro textMeshPro;
    public float speed;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        SetBullet();
    }

    public void SetBullet()
    {
        number = bulletObject.number;

        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.text = number.ToString();
        textMeshPro.color = bulletObject.color;
        explosionVFX.startColor = bulletObject.color;

        rb = GetComponent<Rigidbody2D>();
        speed = bulletObject.speed;
        rb.velocity = transform.up * speed;
    }

    public Bullet(BulletObject bulletObject)
    {
        this.bulletObject = bulletObject;
        SetBullet();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,-30f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            ParticleSystem ps= Instantiate(explosionVFX,transform.position,Quaternion.identity);
            
            ps.Play();
            
            Destroy(gameObject);
            
        }
        
    }
}
