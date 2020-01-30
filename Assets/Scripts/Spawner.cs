using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform[] SpawnPoints;
    [SerializeField] protected float minStartTimeBetweenSpawns;
    [SerializeField] protected float maxStartTimeBetweenSpawns;
    [SerializeField] protected bool spawnDuringBreak;
    [SerializeField] protected int numberOfTypesAtStart;
    [SerializeField] protected int numberOfTypesPerWave;
    [SerializeField] protected int addEveryWave;

    public int numberOfSpawnsAtMoment = 1;

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
        AddAtStart();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnDuringBreak || gameSession.wait == false)
        {

            if (timeBetweenSpawns <= 0)
            {
                for (int i = 0; i < numberOfSpawnsAtMoment; i++)
                {
                    Spawn();
                }
                
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
    public abstract void AddAtStart();
    public abstract void Spawn();

}
