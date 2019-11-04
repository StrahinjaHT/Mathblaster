using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float time = 0f;
    public float timeUp = 5f;

    [SerializeField] public BulletObject bulletObject;
    TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        SetUpPickUp();
    }

    private void SetUpPickUp()
    {
        try
        {

            textMeshPro = GetComponent<TextMeshPro>();
            textMeshPro.text = bulletObject.number.ToString();
            textMeshPro.color = bulletObject.color;
        }
        catch (Exception)
        {

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterSetTime();
    }

    private void DestroyAfterSetTime()
    {
        if (time > timeUp) Destroy(gameObject);
        time += Time.deltaTime;
    }
}
