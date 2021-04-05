using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{
    private float timeBTWAttack = 0.0f;
    private Health playerHealth;
    public IEnemyState DoStateAction(Enemy enemy)
    {
        if (playerHealth == null)
        {
            playerHealth = enemy.playerPos.GetComponent<Health>();
        }
        if(timeBTWAttack <= 0)
        {
            ProcessAttack(enemy);
            timeBTWAttack = enemy.attackRate;
        }
        timeBTWAttack -= Time.deltaTime;

        if (Physics.CheckSphere(enemy.transform.position, enemy.attackRadius, enemy.isPlayer))
        {
            return enemy.attack;
        }
        else
        {
            return enemy.chase;
        }
    }

    private void ProcessAttack(Enemy enemy)
    {
            playerHealth.takeDamage(enemy.attackDamage);
            timeBTWAttack = enemy.attackRate;   
    }
}
