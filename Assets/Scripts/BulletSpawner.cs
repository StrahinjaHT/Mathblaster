using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{


    [SerializeField] Transform[] bulletSpawnPoints;
    [SerializeField] float startTimeBetweenSpawns;


    
    public List<PickUp> bulletPickUps;

    

    float timeBetweenSpawns;
    
    GameSession gameSession;
    PickUp pickUp;




    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
  
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
        if(gameSession.wait==false)
        {
            
            if (timeBetweenSpawns <= 0)
            {
                int randomPos = Random.Range(0, bulletSpawnPoints.Length);
                pickUp = bulletPickUps[Random.Range(0, bulletPickUps.Count)];
                Instantiate(pickUp, bulletSpawnPoints[randomPos].transform.position, Quaternion.identity);
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
