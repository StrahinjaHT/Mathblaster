using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform[] SpawnPoints;
    [SerializeField] protected float minStartTimeBetweenSpawns;
    [SerializeField] protected float maxStartTimeBetweenSpawns;
    [SerializeField] protected bool spawnDuringBreak;
    [SerializeField] protected int numberOfTypesAtStart;

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
        for (int i = 0; i < numberOfTypesAtStart; i++)
        {
            Add();
        }
        
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
        bool tooClose = false;
        do
        {
            tooClose = false;
            randomPos = Random.Range(0, SpawnPoints.Length);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(SpawnPoints[randomPos].position, 2f);
            foreach (Collider2D c in colliders)
            {
                if (c.tag == "Enemy" || c.tag == "PickUp" || c.tag == "Player")
                {
                    tooClose = true;
                }
            }
        } while (tooClose);
                 
                 

        return randomPos;
    }
    public abstract void Add();
    public abstract void Spawn();

}
