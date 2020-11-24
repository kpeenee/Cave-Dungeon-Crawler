using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IInteract
{
    PrimaryWeapon pickupWeapon;

    [SerializeField] PrimaryWeapon testMethod;

    private void Start()
    {
        setWeapon(testMethod);
    }
    public void setWeapon(PrimaryWeapon weapon)
    {
        pickupWeapon = weapon;
        Weapon newWeapon = Instantiate(pickupWeapon, transform.position, Quaternion.identity);
        newWeapon.transform.parent = transform;
    }

    public void Interact()
    {
        Debug.Log("Thing should happen");
    }

    public void Display()
    {
        Debug.Log("You can see me");
    }
}
