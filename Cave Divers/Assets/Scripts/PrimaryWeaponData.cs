using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Primary Weapon", menuName ="Primary Weapon")]
public class PrimaryWeaponData : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float range;
    public float attackSpeed;

    public void ShowData()
    {
        Debug.Log("This is the " + weaponName + " It deals " + damage.ToString() + " damage!");
    }
}
