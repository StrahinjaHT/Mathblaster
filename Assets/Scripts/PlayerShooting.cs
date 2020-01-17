using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public BulletObject bulletObject;
    [SerializeField] public Bullet bullet;
    [SerializeField] Transform gun;
    [SerializeField] public TextMeshProUGUI bulletText;
    [SerializeField] public TextMeshProUGUI gunOverheatedText;
    [SerializeField] Image overheatBar;
    public bool gunLock = false;
    public float overheatFactor = 0f;
    public float maxOverheat = 20f;
    public float slowFactor;
    Color standardOverheatBarColor;
    // Start is called before the first frame update
    void Start()
    {
        bullet.bulletObject = bulletObject;
        UpdateBulletText();
        slowFactor = overheatFactor / maxOverheat;
        standardOverheatBarColor = overheatBar.color;
    }

    // Update is called once per frame
    void Update()
    {
        RegulateOverheat();
    }

    private void RegulateOverheat()
    {
        if (overheatFactor > 0)
        {
            if (overheatFactor > maxOverheat)
            {
                overheatFactor = maxOverheat;
                lockGun();
            }
            else if (overheatFactor + bulletObject.number > maxOverheat && !gunLock)
            {
                overheatBar.color = Color.yellow;
            }
            else if(!gunLock)
            {
                overheatBar.color = standardOverheatBarColor;
            }
            overheatFactor -= Time.deltaTime * 2;
        }

        else
        {
            unlockGun();
        }

        slowFactor = overheatFactor / maxOverheat;
        GameObject.Find("Overheat Bar").GetComponent<SimpleHealthBar>().UpdateBar(overheatFactor, maxOverheat);
    }

    public void Shoot()
    {
        if(gunLock==false)
        {
            var gunPos = gun.position;
            FindObjectOfType<SoundManager>().ShotsFired();

            Instantiate(bullet, gunPos, transform.rotation);
            GetComponentInChildren<ParticleSystem>().Play();
            overheatFactor += bulletObject.number;
        }
        

    }
    public void ChangeBullet(Ammo ammo)
    {
        bulletObject = ammo.bulletObject;
        bullet.bulletObject = bulletObject;
        UpdateBulletText();
    }

    private void UpdateBulletText()
    {
        bulletText.text = bulletObject.number.ToString();
        bulletText.color = bulletObject.color;
    }
    public void lockGun()
    {
        gunLock = true;
        gunOverheatedText.enabled = true;
        overheatBar.color = Color.red;
    }
    public void unlockGun()
    {
        gunLock = false;
        gunOverheatedText.enabled = false;
        overheatBar.color = standardOverheatBarColor;
    }
}

