using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    public IEnemyState DoStateAction(Enemy enemy)
    {
        ChasePlayer(enemy);

        if(enemy.anim.GetBool("isWalking") == false)
        {
            AudioSource.PlayClipAtPoint(enemy.chaseSound, enemy.transform.position);
            enemy.anim.SetBool("isWalking", true);
        }

        if (Physics.CheckSphere(enemy.transform.position, enemy.attackRadius, enemy.isPlayer))
        {
            return enemy.attack;
        }
        if (Physics.CheckSphere(enemy.transform.position, enemy.chaseRadius,enemy.isPlayer))
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
