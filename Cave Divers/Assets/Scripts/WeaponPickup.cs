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
    [SerializeField] TextMeshProUGUI speedText;

    private void Awake()
    {   
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(CheckWeapon());
    }
    public void SetWeapon(Weapon weapon)
    {
        pickupWeapon = Instantiate(weapon, transform.position, Quaternion.identity, transform);
        pickupWeapon.transform.localScale = weapon.transform.lossyScale;

        weaponsStats = pickupWeapon.GetStats();
        weaponTitle.text = weaponsStats.name;
        damageText.text = "Damage:    " + weaponsStats.damage.ToString();
        rangeText.text = "Range:     " + weaponsStats.range.ToString();
        speedText.text = "Speed:     " + weaponsStats.attackSpeed.ToString();
    }

    IEnumerator CheckWeapon()
    {
        yield return new WaitForSeconds(0.3f);
        if(pickupWeapon == null)
        {
            SetWeapon(defaultWeapon);
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
