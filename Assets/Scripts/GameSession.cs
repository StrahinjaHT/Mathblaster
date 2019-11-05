using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waveText;
    
    [SerializeField] public List<EnemyObject> enemies;
    [SerializeField] public List<BulletObject> bulletObjects;
    [SerializeField] public float waveDuration = 10f;
    [SerializeField] public float waveBreak = 5f;



    BulletSpawner bulletSpawner;
    EnemySpawner enemySpawner;
    public SoundManager soundManager;

    public int score = 0;
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
        soundManager = FindObjectOfType<SoundManager>();
        scoreText.text = score.ToString();
        soundManager.PlayTheme();
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
                if(wave%2==0)
                {
                    bulletSpawner.AddBulletPickUp();
                }
               
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
        Destroy(soundManager.gameObject);
        Destroy(gameObject);

    }
    public IEnumerator UpdateWave()
    {
        wait = true;
        yield return new WaitUntil(() => FindObjectsOfType<Enemy>().Length < 1);
        wave++;
        waveText.text = "Wave " + wave;
        yield return new WaitForSeconds(waveBreak);
        waveText.text = "";
        wait = false;

    }
    
    
    
}
