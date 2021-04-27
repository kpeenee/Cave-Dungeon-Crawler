using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyPool enemyPool;
    private Arena arena;

    private void Start()
    {
        arena = transform.parent.GetComponent<Arena>();
        arena.OnArenaEnter += SpawnEnemy;
    }

    private void SpawnEnemy()
    {
        Enemy toSpawn = enemyPool.GetEnemyToSpawn();
        Enemy newEnemy = Instantiate(toSpawn, transform.position, Quaternion.identity);
        newEnemy.transform.parent = transform.parent;
        DestroySpawner();
    }

    private void DestroySpawner()
    {
        arena.OnArenaEnter -= SpawnEnemy;
        Destroy(gameObject);
    }
}
