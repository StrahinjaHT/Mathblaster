using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip notHitSFX;
    [SerializeField] AudioClip shot;
    [SerializeField] AudioClip playerDeath;
    [SerializeField] AudioClip click;
    [SerializeField] AudioClip enemyPowerUp;
    [SerializeField] AudioClip pickedUpBullet;
    [SerializeField] AudioClip pickedUpPoint;
    [SerializeField] AudioClip freezenovaBombUsed;
    [SerializeField] AudioClip notEnoughPoints;
    public string music;

    AudioSource audioSource;

    private void Awake()
    {
        if (FindObjectsOfType<SoundManager>().Length > 1)
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
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
    }


    public void EnemyIsHit()
    {
        audioSource.PlayOneShot(hitSFX,2f);
    }
    public void EnemyIsNotsHit()
    {
        audioSource.PlayOneShot(notHitSFX,0.7f);
    }
    public void ShotsFired()
    {

        audioSource.PlayOneShot(shot,0.4f);
    }
    public void PlayerDead()
    {
        audioSource.PlayOneShot(playerDeath,0.8f);
    }
    public void Clicked()
    {
        audioSource.PlayOneShot(click,0.7f);
    }
    public void PlayTheme()
    {
        music = PlayerPrefs.GetString("music", "true");
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetString("music", "true") == "true")
            audioSource.Play();
    }
    public void StopTheme()
    {
        audioSource.Stop();
    }
    public void EnemyPowerUp()
    {
        audioSource.PlayOneShot(enemyPowerUp, 0.5f);
    }
    public void PickedUpBullet()
    {
        audioSource.PlayOneShot(pickedUpBullet, 0.5f);
    }
    public void PickedUpPoint()
    {
        audioSource.PlayOneShot(pickedUpPoint, 1f);
    }
    public void FreezenovaBombUsed()
    {
        audioSource.PlayOneShot(freezenovaBombUsed, 1f);
    }
    public void NotEnoughPoints()
    {
        audioSource.PlayOneShot(notEnoughPoints, 1f);
    }

}
