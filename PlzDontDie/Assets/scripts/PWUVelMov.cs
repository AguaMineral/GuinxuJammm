using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWUVelMov : MonoBehaviour
{
    public float velocityMult = 1.07f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            FindObjectOfType<GameManager>().moveSpeed *= velocityMult;
            Destroy(gameObject);
        }
    }
}
