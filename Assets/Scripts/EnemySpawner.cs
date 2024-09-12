using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float Timer = 0f;
    public GameObject[] enemies;
    void Update()
    {
        Timer -= Time.deltaTime;
        if( Timer <= 0) 
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemies[UnityEngine.Random.Range(0,enemies.Length)]);
        Timer = 1f; 

    }
}
