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
    [SerializeField] public GameObject Point;

    [SerializeField] public float waveDuration = 10f;
    [SerializeField] public float waveBreak = 5f;

    [SerializeField] public List<ShipObject> shipObjects;


    BulletSpawner bulletSpawner;
    EnemySpawner enemySpawner;
    public SoundManager soundManager;
    ShopScript shop;

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
        shop = FindObjectOfType<ShopScript>();
        scoreText.text = "Score: " + score.ToString();
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
                try
                {
                    StartCoroutine(UpdateWave());
                }
                catch
                {

                }

                enemySpawner.Add();
                bulletSpawner.Add();
               
                
                timePassed = 0f;
            }
        }
        
    }

    public void UpdateScoreByOne()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        soundManager.PickedUpPoint();
    }
    public void UpdateScoreByRandomAmount()
    {
        score+=Random.Range(2,5);
        scoreText.text = "Score: " + score.ToString();
        soundManager.PickedUpPoint();
    }
    public void UpdateScore(int x)
    {
        score+=x;
        scoreText.text = "Score: " + score.ToString();
        //soundManager.PickedUpPoint();
    }
    public bool DecreaseScoreAfterPurchase(int price)
    {
        if (price <= score)
        {
            score -= price;
            scoreText.text = "Score: " + score.ToString();
            soundManager.PickedUpPoint();
            return true;
        }
        else
        {
            soundManager.NotEnoughPoints();
            return false;
        }
    }
    public void ResetGame()
    {
        Destroy(soundManager.gameObject);
        Destroy(gameObject);

    }
    public IEnumerator UpdateWave()
    {
        wait = true;
        wave++;
        yield return new WaitUntil(() => FindObjectsOfType<Enemy>().Length < 1);        
        waveText.text = "Wave " + wave;
        shop.EnableShopButton();
        yield return new WaitForSeconds(waveBreak);
        waveText.text = "";
        shop.DisableShopButton();
        wait = false;

    }
    
    
    
}
