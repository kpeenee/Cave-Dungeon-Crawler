using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy pool", menuName ="New Enemy Pool")]
public class EnemyPool : ScriptableObject
{
    [SerializeField] List<Enemy> enemies;

    public Enemy GetEnemyToSpawn()
    {
        int randNum = Random.Range(0, enemies.Count);
        return enemies[randNum];
    }
}
