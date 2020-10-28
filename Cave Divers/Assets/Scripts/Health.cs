using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void takeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Ouch!! I have " + currentHealth + " health left!!");
        if(currentHealth<= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
