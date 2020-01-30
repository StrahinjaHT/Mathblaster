using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public float time = 0f;
    public float timeUp = 5f;

    
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            PickedUp();
            Destroy(gameObject);
        }
    }

    internal abstract void PickedUp();
}
