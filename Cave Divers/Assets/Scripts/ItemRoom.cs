using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoom : MonoBehaviour
{
    [SerializeField] WeaponPickup roomItem;
    [SerializeField] WeaponPool pool;

    private void Start()
    {
        roomItem.SetWeapon(pool.GetRandomWeaponFromPool());
    }
}
