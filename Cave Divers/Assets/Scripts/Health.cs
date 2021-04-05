﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    private float currentHealth;
    [SerializeField] float regenHealthPerSecond = 0.0f;
    [SerializeField] HealthBar healthBar;
    public Animator anim;
    [SerializeField] AudioClip damageSound;


    private void Start()
    {
        currentHealth = maxHealth;
        if(healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    private void Update()
    {
        if(regenHealthPerSecond > 0)
        {
            RegenHealth();
        }
    }

    private void RegenHealth()
    {
        currentHealth += regenHealthPerSecond * Time.deltaTime;
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth);
        }
        if(currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }

    public void takeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (damageSound != null)
        {
            AudioSource.PlayClipAtPoint(damageSound, transform.position);
        }
        if(healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth);
        }
        Debug.Log("Ouch!! I have " + currentHealth + " health left!!");
        if(currentHealth<= 0)
        {
            Die();
        }
        if (anim != null)
        {
            anim.SetTrigger("hit");
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
