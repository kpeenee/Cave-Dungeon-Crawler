using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponPickup : MonoBehaviour, IInteract
{
    Weapon pickupWeapon;

    [SerializeField] Weapon defaultWeapon;
    WeaponData weaponsStats;
    Animator anim;

    [SerializeField] TextMeshProUGUI weaponTitle;
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] TextMeshProUGUI rangeText;

    private void Awake()
    {   
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(CheckWeapon());
    }
    public void setWeapon(Weapon weapon)
    {
        pickupWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        pickupWeapon.transform.parent = transform;

        weaponsStats = pickupWeapon.GetStats();
        weaponTitle.text = weaponsStats.name;
        damageText.text = "Damage:    " + weaponsStats.damage.ToString();
        rangeText.text = "Range:     " + weaponsStats.range.ToString();
    }

    IEnumerator CheckWeapon()
    {
        yield return new WaitForSeconds(0.3f);
        if(pickupWeapon == null)
        {
            setWeapon(defaultWeapon);
        }
    }

    public void Interact()
    {
        PlayerWeaponManager player = FindObjectOfType<PlayerWeaponManager>();
        player.ChangeWeapon(pickupWeapon);
        Destroy(gameObject);
    }

    public void Display()
    {
        if (anim != null)
        {
            anim.SetBool("isLooking", true);
        }
    }

    public void UnDisplay()
    {
        if (anim != null)
        {
            anim.SetBool("isLooking", false);
        }
    }
}
