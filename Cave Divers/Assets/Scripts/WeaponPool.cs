using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon Pool", menuName = "Weapon Pool")]
public class WeaponPool : ScriptableObject
{
    [SerializeField] List<Weapon> pool = new List<Weapon>();

    public Weapon GetRandomWeaponFromPool()
    {
        int randNum = Random.Range(0, pool.Count - 1);
        return pool[randNum];
    }
}
