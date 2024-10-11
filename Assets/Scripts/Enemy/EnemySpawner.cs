using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Player player;
    public GameObject[] enemyPrefabs;
    public float spawnTimer;

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public void RemoveSpawnedEnemy(GameObject enemy) => spawnedEnemies.Remove(enemy);

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        spawnTimer = 0;
    }
    public void SpawnerUpdate()
    {

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemy(UnityEngine.Random.Range(0, enemyPrefabs.Length));

        }


        foreach (GameObject enemy in spawnedEnemies)
        {
            enemy.GetComponent<EnemyMovement>().EnemyMovementUpdate();
        }
    }

    Vector3 getRandomPosition()
    {
        float xAxis = Random.Range(-32, 27);
        float yAxis = Random.Range(-17, 18);
        float zAxis = Random.Range(0, 0);

        Vector3 newPosition = new Vector3(xAxis, yAxis, zAxis);
        return newPosition;
    }


    public void SpawnEnemy(int index)
    {
        index = index % enemyPrefabs.Count();
        // random -> Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)]();
        GameObject newEnemy = Instantiate(enemyPrefabs[index], getRandomPosition(), Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
        newEnemy.GetComponent<Enemy>().enemySpawner = this;

        spawnTimer = 3;

    }
}
