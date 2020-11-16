using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    public IEnemyState DoStateAction(Enemy enemy)
    {
        ChasePlayer(enemy);

        if (Physics.CheckSphere(enemy.transform.position, enemy.radius,enemy.isPlayer))
        {
            return enemy.chase;
        }
        else
        {
            return enemy.patrol;
        }
    }

    private void ChasePlayer(Enemy enemy)
    {
        enemy.agent.SetDestination(enemy.playerPos.position);
    }
}
