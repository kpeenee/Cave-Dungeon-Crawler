using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrimaryWeapon : Weapon
{
    Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    public override void Attack()
    {
        CheckForHit();
        PlayAttackAnimation();
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

    void PlayAttackAnimation()
    {
        if (anim.gameObject.activeSelf)
        {
            anim.SetTrigger("attack");
        }
    }
}
