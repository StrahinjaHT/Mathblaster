using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{

    public Ammo ammo;
    public List<BulletObject> bulletObjects;

    // Start is called before the first frame update
    public override void Start()
    {
        SetUpBulletSpawner();
        base.Start();
        
    }

    private void SetUpBulletSpawner()
    {

        bulletObjects = new List<BulletObject>();
        
    }


    public override void Add()
    {
        if (gameSession.bulletObjects.Count != 0)
        {
            BulletObject newBulletObject = gameSession.bulletObjects[0];
            gameSession.bulletObjects.Remove(newBulletObject);
            bulletObjects.Add(newBulletObject);

        }
    }

    public override void Spawn()
    {
        int randomPos = Random.Range(0, SpawnPoints.Length);
        ammo.bulletObject = bulletObjects[Random.Range(0, bulletObjects.Count)];
        Instantiate(ammo, SpawnPoints[randomPos].transform.position, Quaternion.identity);
    }
}
