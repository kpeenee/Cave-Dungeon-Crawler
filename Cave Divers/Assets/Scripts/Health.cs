using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    private float currentHealth;
    [SerializeField] HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        if(healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }
    public void takeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if(healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth);
        }
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
