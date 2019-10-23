using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWUdamage : MonoBehaviour
{
    public float damageMult = 1.05f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            FindObjectOfType<GameManager>().bulletDamage *= damageMult;
            Destroy(gameObject);
        }
    }
}
