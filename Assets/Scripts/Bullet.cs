using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    [SerializeField] ParticleSystem explosionVFX;
    
    public int number;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        number = Convert.ToInt32(GetComponent<TextMeshPro>().text);
        explosionVFX.startColor = GetComponent<TextMeshPro>().color;
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
