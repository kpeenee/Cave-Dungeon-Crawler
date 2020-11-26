using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponPickup : MonoBehaviour, IInteract
{
    Weapon pickupWeapon;

    [SerializeField] Weapon testMethod;
    WeaponData weaponsStats;
    Animator anim;

    [SerializeField] TextMeshProUGUI weaponTitle;
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] TextMeshProUGUI rangeText;

    private void Start()
    {
        setWeapon(testMethod);
        weaponsStats = pickupWeapon.GetStats();
        anim = GetComponent<Animator>();
        weaponTitle.text = weaponsStats.name;
        damageText.text = "Damage:    " + weaponsStats.damage.ToString();
        rangeText.text = "Range:     999";
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
        anim.SetBool("isLooking", true);
    }

    public void UnDisplay()
    {
        anim.SetBool("isLooking", false);
    }
}
