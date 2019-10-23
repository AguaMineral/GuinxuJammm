using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{

    public int lifes;
    
    void Start()
    {
        lifes = 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "enem01" || collision.gameObject.tag == "enem03")
        {
            AudioManager.instance.PlaySound("EnemyHitPlayer");
            lifes--;
            //print("Player lifes: ");
           // print(lifes);

            //Game over check
            if ( lifes <= 0)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<playerMovement>().enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemBullet")
        {
            lifes--;
           // print("Player lifes: ");
           // print(lifes);

            //Game over check
            if (lifes <= 0)
            {
                AudioManager.instance.PlaySound("PlayerDeath");
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<shooting>().enabled = false;
                FindObjectOfType<GameManager>().EndGame();
                
            }

        }
    }
}
