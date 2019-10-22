using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float camShakeAmt = 0.1f;
    Shaker camShake;
    public GameObject particles;
    public float duration = 1f;
    public int bulletDamage = 2;

    void Start()
    {  
        camShake = GameObject.Find("Camera").GetComponent<Shaker>();
        if (camShake == null)
            Debug.LogError("No hay camara");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {;
        GameObject firework = Instantiate(particles, transform.position, Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
        //Shake camera
        camShake.Shake(camShakeAmt, 0.2f);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            GameObject firework = Instantiate(particles, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            camShake.Shake(0.18f, 0.2f);
        }
    }
}
