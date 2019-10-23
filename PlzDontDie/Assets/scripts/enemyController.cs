using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyController : MonoBehaviour
{
    
    public float life;
    

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
            life -= bulletController.bulletDamage;
            //print(life);
            //print("Enemy: hit!");
            if (CheckIsDeath())
            {
                GetComponent<PowerUpDrop>().dropPowerUp(transform.position);
                Destroy(gameObject);
                FindObjectOfType<GameManager>().UpdateScore();
                FindObjectOfType<GameManager>().enemyCount++;
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
