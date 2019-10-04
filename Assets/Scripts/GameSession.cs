using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] public List<Bullet> bullets;
    [SerializeField] public List<Enemy> enemies;
    [SerializeField] public List<PickUp> bulletPickUps;
    [SerializeField] public float waveDuration = 10f;
    [SerializeField] public float waveBreak = 5f;



    BulletSpawner bulletSpawner;
    EnemySpawner enemySpawner;

    private int score = 0;
    public int wave = 1;
    public float timePassed = 0f;
    public bool wait = false;



    private void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawner = FindObjectOfType<BulletSpawner>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (wait==false)
        {
            timePassed += Time.deltaTime;
            if (timePassed > waveDuration)
            {
                enemySpawner.AddEnemy();
                bulletSpawner.AddBulletPickUp();
                StartCoroutine(UpdateWave());
                timePassed = 0f;
            }
        }
        
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);

    }
    public IEnumerator UpdateWave()
    {
        wait = true;
        wave++;
        waveText.text = "Wave " + wave;
        yield return new WaitForSeconds(waveBreak);
        waveText.text = "";
        wait = false;

    }
    
    
    
}
