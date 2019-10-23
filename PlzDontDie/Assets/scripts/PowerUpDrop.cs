using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDrop : MonoBehaviour
{
    public GameObject velPWUP;
    public GameObject shotPWUP;
    public GameObject dmgPWUP;

    public void dropPowerUp()
    {
        int prob = Random.Range(100, 1);

        if (prob < 15 )
        {
            //Instancia de dmg power up
            Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(dmgPWUP, posicion, Quaternion.identity); 
        }
        /*else if ( prob < 20 && prob > 10)
        {
            //Instancia de shot rate power up
            Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(shotPWUP, posicion, Quaternion.identity);
        }*/
        else if ( prob < 30 && prob > 15)
        {
            //instancia de vel mov power up
            Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(velPWUP, posicion, Quaternion.identity);
        }
    }
}
