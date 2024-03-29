﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrimaryWeapon : Weapon
{
   
    [SerializeField] Animator anim;
    AudioSource attackSound;
    [SerializeField] GameObject attackVFX;
    
    private void Awake()
    {
        attackSound = GetComponent<AudioSource>();
    }

    public override void Attack()
    {
        CheckForHit();
        attackSound.Play();
        if(attackVFX != null)
        {
            StartCoroutine(PlayVFX());
        }
    }

    IEnumerator PlayVFX()
    {
        attackVFX.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        attackVFX.SetActive(false);
    }

    private void CheckForHit()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, data.range))
        {
            Health objectHealth = hit.transform.GetComponent<Health>();
            if (objectHealth != null)
            {
                objectHealth.takeDamage(data.damage);
            }
        }
    }
}
