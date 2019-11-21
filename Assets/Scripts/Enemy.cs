using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    Transform target;
    public EnemyObject enemyObject;
    EnemySpawner enemySpawner;

    public float speed;
   // public int number;
    SoundManager soundManager;
    TextMeshPro textMeshPro;

    [SerializeField] float timeUntilSpeedUp;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
        SetEnemy();
    }

    private void SetEnemy()
    {
        

        //number = enemyObject.number;

        speed = enemyObject.speed;

        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.text = enemyObject.number.ToString();
        textMeshPro.color = enemyObject.color;


        enemySpawner = FindObjectOfType<EnemySpawner>();
        soundManager = FindObjectOfType<SoundManager>();
        try
        {
            target = FindObjectOfType<PlayerMovement>().transform;
        }
        catch (Exception)
        {

            target = null;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if(target!=null)
        EnemyFollow();
        if(timer>=timeUntilSpeedUp)
        {
            speed += 1f;
            timer = 0f;
            textMeshPro.fontSize++;
            soundManager.EnemyPowerUp();
        }
        timer += Time.deltaTime;
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
            if (this.enemyObject.number % collision.gameObject.GetComponent<Bullet>().bulletObject.number == 0)
            {
                soundManager.EnemyIsHit();

                int x = this.enemyObject.number / collision.gameObject.GetComponent<Bullet>().bulletObject.number;

                switch (x)
                {
                    case 1:
                        Destroy(gameObject);

                        Instantiate(enemySpawner.One, transform.position, Quaternion.identity);
                        break;

                    default:
                        Destroy(gameObject);

                        foreach (EnemyObject e in FindObjectOfType<EnemySpawner>().Enemies)
                        {
                            if (e.number == x)
                            {
                                enemySpawner.enemy.enemyObject = e;
                            }

                        }
                        if (enemyObject == null)
                        {
                            foreach (EnemyObject e in FindObjectOfType<GameSession>().enemies)
                            {
                                if (e.number == x)
                                {
                                    enemySpawner.enemy.enemyObject = e;
                                }

                            }
                        }


                        Instantiate(enemySpawner.enemy, transform.position, Quaternion.identity);
                        break;
                }

            }
            else
            {
                soundManager.EnemyIsNotsHit();
            }


        }
        else if((collision.gameObject.tag == "Player"))
        {
            
            soundManager.EnemyIsHit();
            ParticleSystem ps = Instantiate(GetComponentInChildren<ParticleSystem>(), transform.position, Quaternion.identity);
            ps.Play();
            Destroy(gameObject);
        }
    }
}
