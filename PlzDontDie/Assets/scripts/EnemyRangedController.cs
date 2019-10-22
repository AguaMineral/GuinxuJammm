using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyRangedController : MonoBehaviour
{

    public float life;
    public bulletController bulletCont;


    //IA
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float timeBtwShots;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Rigidbody2D rb;
    public float bulletForce = 20f;
    Transform target; 

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < nearDistance)
        { 
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < nearDistance)
        {
            transform.position = this.transform.position;
        }

        //Enemy shots
        if(timeBtwShots <= 0)
        {
            Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject bullet = Instantiate(bulletPrefab, posicion, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        //aim
        Vector2 position = new Vector2(target.transform.position.x, target.transform.position.y);
        Vector2 dirLook = position - rb.position;
        float angle = Mathf.Atan2(dirLook.y, dirLook.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            life -= bulletCont.bulletDamage;
            print(life);
            print("Enemy: hit!");
            if (CheckIsDeath())
                Destroy(gameObject);
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
