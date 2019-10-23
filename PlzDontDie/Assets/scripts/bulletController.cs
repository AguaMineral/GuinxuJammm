using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float camShakeAmt = 0.1f;
    Shaker camShake;
    public GameObject particles;
    public float duration = 1f;
    public static float bulletDamage;

    void Start()
    {
        bulletDamage = FindObjectOfType<GameManager>().bulletDamage;
        
        camShake = GameObject.Find("Camera").GetComponent<Shaker>();
        if (camShake == null)
            Debug.LogError("No hay camara");
    }
    private void Update()
    {
        bulletDamage = FindObjectOfType<GameManager>().bulletDamage;
       // print(bulletDamage);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "enem01" || collision.gameObject.tag == "enem02" || collision.gameObject.tag == "enem03")
        {
            GameObject firework = Instantiate(particles, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(firework, 1f);
            Destroy(gameObject);
            //Shake camera
            camShake.Shake(camShakeAmt, 0.2f);
            AudioManager.instance.PlaySound("PlayerHit");
        }
        else
        {
            GameObject firework = Instantiate(particles, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(firework, 1f);
            Destroy(gameObject);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            GameObject firework = Instantiate(particles, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(firework, 1f);
            Destroy(gameObject);
            AudioManager.instance.PlaySound("EnemyHitPlayer");
            camShake.Shake(0.18f, 0.2f);
        }else if (collision.gameObject.tag == "wall")
        {
            GameObject firework = Instantiate(particles, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(firework, 1f);
            Destroy(gameObject);

        }
    }
}
