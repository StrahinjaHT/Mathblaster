﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform[] SpawnPoints;
    [SerializeField] protected float minStartTimeBetweenSpawns;
    [SerializeField] protected float maxStartTimeBetweenSpawns;
    [SerializeField] protected bool spawnDuringBreak;
    protected float timeBetweenSpawns;
    protected GameSession gameSession;
    
    private void ResetTime()
    {
        timeBetweenSpawns = Random.Range(minStartTimeBetweenSpawns, maxStartTimeBetweenSpawns);

    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        SetUpSpawner();
    }

    private void SetUpSpawner()
    {
        
        gameSession = FindObjectOfType<GameSession>();
        ResetTime();
        Add();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnDuringBreak || gameSession.wait == false)
        {

            if (timeBetweenSpawns <= 0)
            {
                Spawn();
                ResetTime();
            }
            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
    }
    internal int SelectPosition()
    {
        int randomPos;

        do
        {
            randomPos = Random.Range(0, SpawnPoints.Length);
        } while ((Vector2.Distance(SpawnPoints[randomPos].position, FindObjectOfType<PlayerMovement>().transform.position) < 2f)
                 //  || (Vector2.Distance(enemySpawnPoints[randomPos].position, FindObjectOfType<Enemy>().transform.position) < 2f)
                 );

        return randomPos;
    }
    public abstract void Add();
    public abstract void Spawn();

}
