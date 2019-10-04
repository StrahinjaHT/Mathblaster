using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Transform[] enemySpawnPoints;
    [SerializeField] float startTimeBetweenSpawns;


    
    public List<Enemy> Enemies;

   

    public float timeBetweenSpawns;
    
    GameSession gameSession;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
       
        
        timeBetweenSpawns = startTimeBetweenSpawns;
        Enemies = new List<Enemy>();
        AddEnemy();
    }

    public void AddEnemy()
    {
        if (gameSession.enemies.Count != 0)
        {
            Enemy newEnemy = gameSession.enemies[0];
            gameSession.enemies.Remove(newEnemy);
            Enemies.Add(newEnemy);
            
        }

    }
    
    

    // Update is called once per frame
    void Update()
    {
        if(gameSession.wait==false)
        {
            
            if (timeBetweenSpawns <= 0)
            {
                int randomPos = Random.Range(0, enemySpawnPoints.Length);
                enemy = Enemies[Random.Range(0, Enemies.Count)];
                Instantiate(enemy, enemySpawnPoints[randomPos].transform.position, Quaternion.identity);
                timeBetweenSpawns = startTimeBetweenSpawns;
            }
            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
        else timeBetweenSpawns = startTimeBetweenSpawns;
    }
}
