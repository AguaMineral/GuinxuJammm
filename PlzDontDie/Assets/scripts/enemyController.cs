using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public int life = 10;
    public bulletController bulletCont;

    void Start()
    {
      
    }

    void Update()
    {
        
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
