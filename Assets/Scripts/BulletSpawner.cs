using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{

    public Ammo ammo;
    public List<BulletObject> bulletObjects;
    [SerializeField] public  int numberOfAddedBulletsPerWave;

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
        for (int i = 0; i < numberOfAddedBulletsPerWave; i++)
        {
            if (gameSession.bulletObjects.Count != 0)
            {
                BulletObject newBulletObject = gameSession.bulletObjects[0];
                gameSession.bulletObjects.Remove(newBulletObject);
                bulletObjects.Add(newBulletObject);

            }
            else break;
        }
        
    }

    public override void Spawn()
    {
        int randomPos = SelectPosition();
        SelectBullet();
        Instantiate(ammo, SpawnPoints[randomPos].transform.position, Quaternion.identity);
    }

    private void SelectBullet()
    {
        if (bulletObjects.Count < 3)
            ammo.bulletObject = bulletObjects[Random.Range(0, bulletObjects.Count)];
        else
            ammo.bulletObject = bulletObjects[Random.Range(bulletObjects.Count - 3, bulletObjects.Count)];
    }
}
