using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ammo : PickUp
{
    [SerializeField] public BulletObject bulletObject;
    TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        SetUpPickUp();
    }



    internal override void PickedUp()
    {
        FindObjectOfType<PlayerShooting>().ChangeBullet(this);
        FindObjectOfType<SoundManager>().PickedUpBullet();
    }

    void SetUpPickUp()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.text = bulletObject.number.ToString();
        textMeshPro.color = bulletObject.color;
    }
}
