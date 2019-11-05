using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{


    [SerializeField] Transform[] bulletSpawnPoints;
    [SerializeField] float minStartTimeBetweenSpawns;
    [SerializeField] float maxStartTimeBetweenSpawns;


    public PickUp pickUp;
    public List<BulletObject> bulletObjects;


    public float startTimeBetweenSpawns;
    float timeBetweenSpawns;

    GameSession gameSession;





    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        startTimeBetweenSpawns = Random.Range(minStartTimeBetweenSpawns, maxStartTimeBetweenSpawns);
        timeBetweenSpawns = startTimeBetweenSpawns;
        bulletObjects = new List<BulletObject>();
        AddBulletPickUp();
    }

    public void AddBulletPickUp()
    {
        if (gameSession.bulletObjects.Count != 0)
        {
            BulletObject newBulletObject = gameSession.bulletObjects[0];
            gameSession.bulletObjects.Remove(newBulletObject);
            bulletObjects.Add(newBulletObject);

        }

    }




    // Update is called once per frame
    void Update()
    {

        if (timeBetweenSpawns <= 0)
        {
            SpawnBulletPickUp();
            startTimeBetweenSpawns = Random.Range(minStartTimeBetweenSpawns, maxStartTimeBetweenSpawns);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }

    }

    private void SpawnBulletPickUp()
    {
        int randomPos = Random.Range(0, bulletSpawnPoints.Length);
        pickUp.bulletObject = bulletObjects[Random.Range(0, bulletObjects.Count)];
        Instantiate(pickUp, bulletSpawnPoints[randomPos].transform.position, Quaternion.identity);
    }
}
