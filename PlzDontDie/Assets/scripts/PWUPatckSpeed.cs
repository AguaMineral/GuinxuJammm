using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWUPatckSpeed : MonoBehaviour
{
    public float shotRateMult = 1.1f;
    public float nextShotMinus = 0.04f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            FindObjectOfType<GameManager>().fireRate *= shotRateMult;
           // FindObjectOfType<GameManager>().nextShot -= nextShotMinus;
            Destroy(gameObject);
        }
    }
}
