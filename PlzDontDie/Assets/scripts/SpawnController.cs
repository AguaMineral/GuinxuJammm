using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Enemy;
    public bool StopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int maxNumOfEnemies;
    int enemiesInRoom;
    float enemy01CurrentLife;
    float enemy02CurrentLife;
    float enemyLifeMultiplier = 1.12f;
    

    private void Start()
    {
        enemy01CurrentLife = 7f;
        enemy02CurrentLife = 10f;
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    private void Update()
    {
        //CheckMaxEnemies();
    }

    void CheckMaxEnemies()
    {
       /* enemiesInRoom = GameObject.FindGameObjectsWithTag("enem01").Length;
        if (enemiesInRoom >= maxNumOfEnemies - 1)
            StopSpawning = true;*/
    }
    public void SpawnEnemy()
    {
        Vector3 position = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0);
        Instantiate(Enemy, position, Quaternion.identity);
        if ( Enemy.gameObject.tag == "enem02")
        {
            Enemy.GetComponent<EnemyRangedController>().life = enemy01CurrentLife;
            print("Ranged enemy life: " + enemy01CurrentLife);
            //print(enemy01CurrentLife);
            enemy01CurrentLife *= enemyLifeMultiplier;

        }
        else if (Enemy.gameObject.tag == "enem01")
        {
            Enemy.GetComponent<enemyController>().life = enemy02CurrentLife;
            print("Melee enemy life: ");
            print(enemy02CurrentLife);
            enemy02CurrentLife *= enemyLifeMultiplier;
        }
        
        if (StopSpawning)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

}
