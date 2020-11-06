using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public abstract class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage;
    public void ShowData()
    {
        Debug.Log("This is the " + weaponName + " It deals " + damage.ToString() + " damage!");
    }
}
