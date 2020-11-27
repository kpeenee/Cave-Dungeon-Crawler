using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData data;

    public abstract void Attack();

    public WeaponData GetStats()
    {
        return data;
    }
}
