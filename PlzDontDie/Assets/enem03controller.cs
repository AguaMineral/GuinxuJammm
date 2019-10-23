using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enem03controller : MonoBehaviour
{

    public float life;

    public GameObject bulletPrefab;
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
    public Rigidbody2D rb4;
    public Rigidbody2D rb5;
    public Rigidbody2D rb6;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public float bulletForce = 20f;
    public float startTimeBtwShots;
    private float timeBtwShots;



    //IA
    public float speed;
    Transform target;
    public float minDistance;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minDistance)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //Enemy shots
        if (timeBtwShots <= 0)
        {
            
            Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            GameObject bullet01 = Instantiate(bulletPrefab, posicion, Quaternion.identity);
            GameObject bullet02 = Instantiate(bulletPrefab, posicion, Quaternion.identity);
            GameObject bullet03 = Instantiate(bulletPrefab, posicion, Quaternion.identity);
            GameObject bullet04 = Instantiate(bulletPrefab, posicion, Quaternion.identity);
            GameObject bullet05 = Instantiate(bulletPrefab, posicion, Quaternion.identity);
            GameObject bullet06 = Instantiate(bulletPrefab, posicion, Quaternion.identity);

            Rigidbody2D rbBullet1 = bullet01.GetComponent<Rigidbody2D>();
            rbBullet1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);

            Rigidbody2D rbBullet2 = bullet02.GetComponent<Rigidbody2D>();
            rbBullet2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);

            Rigidbody2D rbBullet3 = bullet03.GetComponent<Rigidbody2D>();
            rbBullet3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);

            Rigidbody2D rbBullet4 = bullet04.GetComponent<Rigidbody2D>();
            rbBullet4.AddForce(firePoint4.up * bulletForce, ForceMode2D.Impulse);

            Rigidbody2D rbBullet5 = bullet05.GetComponent<Rigidbody2D>();
            rbBullet5.AddForce(firePoint5.up * bulletForce, ForceMode2D.Impulse);

            Rigidbody2D rbBullet6 = bullet06.GetComponent<Rigidbody2D>();
            rbBullet6.AddForce(firePoint6.up * bulletForce, ForceMode2D.Impulse);
            
            AudioManager.instance.PlaySound("EnemyShot");
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            life -= bulletController.bulletDamage;
            //print(life);
            //print("Enemy: hit!");
            if (CheckIsDeath())
            {
                GetComponent<PowerUpDrop>().dropPowerUp(transform.position);
                Destroy(gameObject);
                FindObjectOfType<GameManager>().UpdateScore();
                FindObjectOfType<GameManager>().enemyCount++;
                AudioManager.instance.PlaySound("EnemyDeath");
            }
        }
    }

    bool CheckIsDeath()
    {
        if (life < 0)
            return true;
        else
            return false;
    }
}
