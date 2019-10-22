using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] float time = 0f;
    [SerializeField] float timeUp = 5f;
    [SerializeField] public Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        
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
