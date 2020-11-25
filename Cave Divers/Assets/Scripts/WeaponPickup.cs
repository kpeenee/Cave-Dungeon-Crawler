using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IInteract
{
    Weapon pickupWeapon;

    [SerializeField] Weapon testMethod;

    private void Start()
    {
        setWeapon(testMethod);
    }
    public void setWeapon(Weapon weapon)
    {
        pickupWeapon = weapon;
        Weapon newWeapon = Instantiate(pickupWeapon, transform.position, Quaternion.identity);
        newWeapon.transform.parent = transform;
    }

    public void Interact()
    {
        Player player = FindObjectOfType<Player>();
        player.ChangeWeapon(pickupWeapon);
        Destroy(gameObject);
    }

    public void Display()
    {
        Debug.Log("You can see me");
    }
}
