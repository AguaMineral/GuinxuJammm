using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWUdamage : MonoBehaviour
{
    public float damageMult = 1.03f;
    public bulletController damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            damage.bulletDamage *= damageMult;
        }
    }
}
