using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Enemy;
    public bool StopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int maxNumOfEnemies = 10;
    int enemiesInRoom;
    float enemy01CurrentLife;
    float enemy02CurrentLife;
    float enemy03CurrentLife;
    float enemyLifeMultiplier = 1.06f;
    float enemyLife03Mulkt = 1.5f;
    

    private void Start()
    {
        enemy01CurrentLife = 7f;
        enemy02CurrentLife = 10f;
        enemy03CurrentLife = 150;
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    private void Update()
    {
        //CheckMaxEnemies();
    }

    /*void CheckMaxEnemies()
    {
        if (Enemy.gameObject.tag == "enem01")
        {
            enemiesInRoom = GameObject.FindGameObjectsWithTag("enem01").Length;
        }else
        {
            enemiesInRoom = GameObject.FindGameObjectsWithTag("enem02").Length;
        }
       
        if (enemiesInRoom >= maxNumOfEnemies - 1)
            StopSpawning = true;
        else if (enemiesInRoom <= maxNumOfEnemies - 1)
            StopSpawning = false;
    }*/
    public void SpawnEnemy()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(Enemy, position, Quaternion.identity);
        if ( Enemy.gameObject.tag == "enem02")
        {
            Enemy.GetComponent<EnemyRangedController>().life = enemy01CurrentLife;
            //print("Ranged enemy life: " + enemy01CurrentLife);
            //print(enemy01CurrentLife);
            enemy01CurrentLife *= enemyLifeMultiplier;

        }
        else if (Enemy.gameObject.tag == "enem01")
        {
            Enemy.GetComponent<enemyController>().life = enemy02CurrentLife;
            //print("Melee enemy life: ");
            //print(enemy02CurrentLife);
            enemy02CurrentLife *= enemyLifeMultiplier;
        }
        else if (Enemy.gameObject.tag == "enem03")
        {
            Enemy.GetComponent<enem03controller>().life = enemy03CurrentLife;
            //print("Melee enemy life: ");
            //print(enemy02CurrentLife);
            enemy03CurrentLife *= enemyLife03Mulkt;
        }

        if (StopSpawning)
        {
            CancelInvoke("SpawnEnemy");
        }
        
    }

}
