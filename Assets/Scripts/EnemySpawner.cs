using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{

    public Enemy enemy;
    public List<EnemyObject> Enemies;
    [SerializeField] public int numberOfAddedEnemiesPerWave;

    // Start is called before the first frame update
    public override void Start()
    {
        SetUpEnemySpawner();
        base.Start();
    }

    private void SetUpEnemySpawner()
    {      
        Enemies = new List<EnemyObject>();
        
    }


    public override void Add()
    {
        
            if (gameSession.enemies.Count != 0)
            {
                EnemyObject newEnemy = gameSession.enemies[0];
                gameSession.enemies.Remove(newEnemy);
                Enemies.Add(newEnemy);

            }
            
        
        
        
    }

    public override void Spawn()
    {
        try
        {
            int randomPos = SelectPosition();
            enemy.enemyObject = Enemies[Random.Range(0, Enemies.Count)];

            Instantiate(enemy, SpawnPoints[randomPos].transform.position, Quaternion.identity);
        }
        catch
        {

        }
    }
}
