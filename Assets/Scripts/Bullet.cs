using UnityEngine;
using TMPro;


public class Bullet : MonoBehaviour
{
    
    ParticleSystem explosionVFX;
    public BulletObject bulletObject;
    Rigidbody2D rb;
    TextMeshPro textMeshPro;
  
    // Start is called before the first frame update
    void Start()
    {
        SetBullet();
        LaunchBullet();
    }

    public void SetBullet()
    {
       
        textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.text =bulletObject.number.ToString();
        textMeshPro.color = bulletObject.color;
        explosionVFX = GetComponentInChildren<ParticleSystem>();
        explosionVFX.startColor = bulletObject.color;
        
    }

    private void LaunchBullet()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = transform.up * bulletObject.speed;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,-30f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            ParticleSystem ps= Instantiate(explosionVFX,transform.position,Quaternion.identity);
            
            ps.Play();
            
            Destroy(gameObject);
            
        }
        
    }
}
