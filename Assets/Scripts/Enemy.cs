using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    [SerializeField] float speed = 3f;
    [SerializeField] GameObject One;
    
   
    public int number;
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        number= Convert.ToInt32(GetComponent<TextMeshPro>().text);
        soundManager = FindObjectOfType<SoundManager>();
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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessHit(collision);
    }

    private void ProcessHit(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if(this.number%collision.gameObject.GetComponent<Bullet>().number==0)
            {
                soundManager.EnemyIsHit();

                int x = this.number / collision.gameObject.GetComponent<Bullet>().number;
                
                switch (x)
                {
                    case 1:
                        Destroy(gameObject);

                        Instantiate(One, transform.position, Quaternion.identity);
                        break;
               
                    default:
                        Destroy(gameObject);
                        Enemy enemy = new Enemy();
                        foreach (Enemy e in FindObjectOfType<EnemySpawner>().Enemies)
                        {
                            if (e.number == x)
                            {
                                enemy = e;
                            }
                           
                        }
                        if(enemy==null)
                        {
                            foreach (Enemy e in FindObjectOfType<GameSession>().enemies)
                            {
                                if (e.number == x)
                                {
                                    enemy = e;
                                }

                            }
                        }
                        Instantiate(enemy, transform.position, Quaternion.identity);
                        break;
                }
                
            }
            else
            {
                soundManager.EnemyIsNotsHit();
            }
            

        }
    }
}
