using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip notHitSFX;
    [SerializeField] AudioClip shot;
    [SerializeField] AudioClip playerDeath;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyIsHit()
    {
        audioSource.PlayOneShot(hitSFX,1f);
    }
    public void enemyIsNotsHit()
    {
        audioSource.PlayOneShot(notHitSFX,0.7f);
    }
    public void shotsFired()
    {
        audioSource.PlayOneShot(shot,0.4f);
    }
    public void playerDead()
    {
        audioSource.PlayOneShot(playerDeath);
    }
}
