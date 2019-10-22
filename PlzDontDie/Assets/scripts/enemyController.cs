using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyController : MonoBehaviour
{
    
    public int life = 10;
    public bulletController bulletCont;
    

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
        if(Vector2.Distance(transform.position, target.position) > minDistance)
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if ( collision.gameObject.tag == "playerBullet")
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
