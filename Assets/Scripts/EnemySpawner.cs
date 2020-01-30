using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{

    public Enemy enemy;
    public List<EnemyObject> Enemies;
    

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
        if (FindObjectOfType<GameSession>().wave % addEveryWave == 0)
            for (int i = 0; i < numberOfTypesPerWave; i++)
            {
                if (gameSession.enemies.Count != 0)
                {
                    EnemyObject newEnemy = gameSession.enemies[0];
                    gameSession.enemies.Remove(newEnemy);
                    Enemies.Add(newEnemy);


                }
            }
        
   
    }

    public override void Spawn()
    {
        try
        {
            int randomPos = SelectPosition();
            SelectEnemy();
            Instantiate(enemy, SpawnPoints[randomPos].transform.position, Quaternion.identity);
        }
        catch
        {

        }
    }

    private void SelectEnemy()
    {
        if (Enemies.Count < 10)
            enemy.enemyObject = Enemies[Random.Range(0, Enemies.Count)];
        else
            enemy.enemyObject = Enemies[Random.Range(Enemies.Count - 10, Enemies.Count)];
    }

    public override void AddAtStart()
    {
        for (int i = 0; i < numberOfTypesAtStart; i++)
        {
            if (gameSession.enemies.Count != 0)
            {
                EnemyObject newEnemy = gameSession.enemies[0];
                gameSession.enemies.Remove(newEnemy);
                Enemies.Add(newEnemy);


            }
        }
    }
}
