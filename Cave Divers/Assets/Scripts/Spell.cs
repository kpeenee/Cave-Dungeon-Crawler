using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Weapon
{
    [SerializeField] Projectile spellToCast;
    public override void Attack()
    {
        Instantiate(spellToCast, transform.position, Camera.main.transform.rotation);
    }
}
