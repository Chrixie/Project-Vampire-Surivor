using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float Timer = 0f;
    public GameObject[] enemyPrefabs;

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public void RemoveSpawnedEnemy(GameObject enemy) => spawnedEnemies.Remove(enemy);


    void Update()
    {
        
        Timer -= Time.deltaTime;
        if( Timer <= 0) 
        {
            SpawnEnemy(UnityEngine.Random.Range(0, enemyPrefabs.Length));
        }
    }

    public void SpawnEnemy(int index)
    {
        index = index % enemyPrefabs.Count();
        // random -> Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)]();
        GameObject newEnemy = Instantiate(enemyPrefabs[index]);
        spawnedEnemies.Add(newEnemy);
        newEnemy.GetComponent<Enemy>().enemySpawner = this;

        Timer = 1f; 

    }
}
