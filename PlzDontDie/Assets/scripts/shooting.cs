using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public static float fireRate;
    public static float nextFire = 1f;

    void Start()
    {
        fireRate = FindObjectOfType<GameManager>().fireRate;
        //nextFire = FindObjectOfType<GameManager>().nextShot;
    }

    void Update()
    {
        
        //nextFire = FindObjectOfType<GameManager>().nextShot;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        //if (Input.GetButtonDown("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        
    }

    void Shoot()
    {
        AudioManager.instance.PlaySound("PlayerAttack");
        fireRate = FindObjectOfType<GameManager>().fireRate;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //print ("Daño: "+bulletController.bulletDamage);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
