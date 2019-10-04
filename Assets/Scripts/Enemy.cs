using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    [SerializeField] float speed = 3f;
    [SerializeField] GameObject One;
    [SerializeField] public int number = 1;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        }
        catch (Exception)
        {

            target=null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=null)
        EnemyFollow();
    }

    private void EnemyFollow()
    {
        
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);

            Instantiate(One, transform.position, Quaternion.identity);
            
        }
        
    }
   
}
