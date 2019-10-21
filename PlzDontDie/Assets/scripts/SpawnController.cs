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

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    private void Update()
    {
        CheckMaxEnemies();
    }

    void CheckMaxEnemies()
    {
        enemiesInRoom = GameObject.FindGameObjectsWithTag("enem01").Length;
        if (enemiesInRoom >= maxNumOfEnemies - 1)
            StopSpawning = true;
    }
    public void SpawnEnemy()
    {
        Vector3 position = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0);
        Instantiate(Enemy, position, Quaternion.identity);
        if (StopSpawning)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

}
