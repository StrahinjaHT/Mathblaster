using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{


    [SerializeField] Transform[] bulletSpawnPoints;
    [SerializeField] float minStartTimeBetweenSpawns;
    [SerializeField] float maxStartTimeBetweenSpawns;



    public List<PickUp> bulletPickUps;


    public float startTimeBetweenSpawns;
    float timeBetweenSpawns;
    
    GameSession gameSession;
    PickUp pickUp;




    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        startTimeBetweenSpawns = Random.Range(minStartTimeBetweenSpawns, maxStartTimeBetweenSpawns);
        timeBetweenSpawns = startTimeBetweenSpawns;
        bulletPickUps = new List<PickUp>();
        AddBulletPickUp();
    }

    public void AddBulletPickUp()
    {
        if(gameSession.bulletPickUps.Count!=0)
        {
            PickUp newBulletPickUp = gameSession.bulletPickUps[0];
            gameSession.bulletPickUps.Remove(newBulletPickUp);
            bulletPickUps.Add(newBulletPickUp);
            
        }
        
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
            if (timeBetweenSpawns <= 0)
            {
                int randomPos = Random.Range(0, bulletSpawnPoints.Length);
                pickUp = bulletPickUps[Random.Range(0, bulletPickUps.Count)];
                Instantiate(pickUp, bulletSpawnPoints[randomPos].transform.position, Quaternion.identity);
                startTimeBetweenSpawns = Random.Range(minStartTimeBetweenSpawns, maxStartTimeBetweenSpawns);
                timeBetweenSpawns = startTimeBetweenSpawns;
            }
            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        
    }
}
