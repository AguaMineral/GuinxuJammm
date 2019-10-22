using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWUPatckSpeed : MonoBehaviour
{
    public float shotRateMult = 1.1f;
    public shooting shotRate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            shotRate.fireRate *= shotRateMult;
        }
    }
}
