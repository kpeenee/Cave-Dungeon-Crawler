using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class PatrolState : IEnemyState
{
    Vector3 targetPoint;
    float timer = 3f;
    public IEnemyState DoStateAction(Enemy enemy)
    {
        if(timer <= 0)
        {
            PickNewPoint(enemy);
            timer = 3f;
        }
        timer -= Time.deltaTime;
        Debug.Log(targetPoint);
        return enemy.patrol;
    }

    private void PickNewPoint(Enemy enemy)
    {
        float randomX = UnityEngine.Random.Range(-5f,5f);
        float randomZ = UnityEngine.Random.Range(-5f, 5f);
        targetPoint = enemy.transform.position + new Vector3(randomX, 0, randomZ);
        enemy.agent.SetDestination(targetPoint);
    }
}
