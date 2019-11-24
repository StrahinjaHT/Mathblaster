using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
        audioSource.PlayOneShot(hitSFX,1f);
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
        
        audioSource = GetComponent<AudioSource>();

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
        audioSource.PlayOneShot(pickedUpPoint, 0.5f);
    }
 
}
