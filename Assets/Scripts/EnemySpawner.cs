using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Transform[] enemySpawnPoints;
    [SerializeField] float minStartTimeBetweenSpawns;
    [SerializeField] float maxStartTimeBetweenSpawns;
    [SerializeField] public  GameObject One;

    public Enemy enemy;
    public List<EnemyObject> Enemies;


    public float startTimeBetweenSpawns;
    public float timeBetweenSpawns;
    
    GameSession gameSession;
   
    
    

    // Start is called before the first frame update
    void Start()
    {
        SetUpEnemySpawner();
    }

    private void SetUpEnemySpawner()
    {
        gameSession = FindObjectOfType<GameSession>();

        startTimeBetweenSpawns = Random.Range(minStartTimeBetweenSpawns, maxStartTimeBetweenSpawns);
        timeBetweenSpawns = startTimeBetweenSpawns;
        Enemies = new List<EnemyObject>();
        AddEnemy();
    }

    public void AddEnemy()
    {
        if (gameSession.enemies.Count != 0)
        {
            EnemyObject newEnemy = gameSession.enemies[0];
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
                SpawnEnemy();
                startTimeBetweenSpawns = Random.Range(minStartTimeBetweenSpawns, maxStartTimeBetweenSpawns);
                timeBetweenSpawns = startTimeBetweenSpawns;
            }
            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
        else timeBetweenSpawns = startTimeBetweenSpawns;
    }

    private void SpawnEnemy()
    {
        try
        {
            int randomPos = SelectPosition();
            enemy.enemyObject = Enemies[Random.Range(0, Enemies.Count)];

            Instantiate(enemy, enemySpawnPoints[randomPos].transform.position, Quaternion.identity);
        }
        catch
        {

        }
        
    }

    private int SelectPosition()
    {
        int randomPos;
        
        do
        {
            randomPos = Random.Range(0, enemySpawnPoints.Length);
        } while ((Vector2.Distance(enemySpawnPoints[randomPos].position, FindObjectOfType<PlayerMovement>().transform.position) < 2f) 
            //  || (Vector2.Distance(enemySpawnPoints[randomPos].position, FindObjectOfType<Enemy>().transform.position) < 2f)
                 );

        return randomPos;
    }
}
