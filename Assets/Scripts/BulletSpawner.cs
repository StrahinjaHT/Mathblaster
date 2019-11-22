﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{


    [SerializeField] Transform[] bulletSpawnPoints;
    [SerializeField] float minStartTimeBetweenSpawns;
    [SerializeField] float maxStartTimeBetweenSpawns;


    public Ammo ammo;
    public List<BulletObject> bulletObjects;


    float timeBetweenSpawns;

    GameSession gameSession;





    // Start is called before the first frame update
    void Start()
    {
        SetUpBulletSpawner();
    }

    private void SetUpBulletSpawner()
    {
        gameSession = FindObjectOfType<GameSession>();

        ResetTime();
        bulletObjects = new List<BulletObject>();
        AddBulletPickUp();
    }
    private void ResetTime()
    {
        timeBetweenSpawns = Random.Range(minStartTimeBetweenSpawns, maxStartTimeBetweenSpawns);

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
            ResetTime();
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }

    }

    private void SpawnBulletPickUp()
    {
        int randomPos = Random.Range(0, bulletSpawnPoints.Length);
        ammo.bulletObject = bulletObjects[Random.Range(0, bulletObjects.Count)];
        Instantiate(ammo, bulletSpawnPoints[randomPos].transform.position, Quaternion.identity);
    }
}
