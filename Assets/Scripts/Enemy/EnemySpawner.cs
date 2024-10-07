using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float Timer = 0f;
    private Player player;
    public GameObject[] enemyPrefabs;
    private int maxHealth;
    private int lastPlayerLevel = 0;

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public void RemoveSpawnedEnemy(GameObject enemy) => spawnedEnemies.Remove(enemy);

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        lastPlayerLevel = player.currentLevel;
    }
    public void SpawnerUpdate()
    {
        Timer -= Time.deltaTime;
        if (lastPlayerLevel != player.currentLevel)
        {
            IncreaseHealth();
            lastPlayerLevel = player.currentLevel;
        }

         if (Timer <= 0)
         {
            SpawnEnemy(UnityEngine.Random.Range(0, enemyPrefabs.Length));

         }

        foreach (GameObject enemy in spawnedEnemies)
        {
            enemy.GetComponent<EnemyMovement>().EnemyMovementUpdate();
            if (enemy.GetComponent<Enemy>().maxHealth > maxHealth)
                maxHealth = enemy.GetComponent<Enemy>().maxHealth;
        }
    }

    public void IncreaseHealth()
    {
       
        if (player.currentLevel % 5 == 0)
        {
            maxHealth += 5;
        }


    }


    public void SpawnEnemy(int index)
    {
        index = index % enemyPrefabs.Count();
        // random -> Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)]();
        GameObject newEnemy = Instantiate(enemyPrefabs[index]);
        spawnedEnemies.Add(newEnemy);
        newEnemy.GetComponent<Enemy>().enemySpawner = this;
        newEnemy.GetComponent<Enemy>().maxHealth = maxHealth;

        Timer = 1f; 

    }
}
