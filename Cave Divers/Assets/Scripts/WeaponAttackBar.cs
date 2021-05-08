using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAttackBar : MonoBehaviour
{
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetWeaponValues(float speed)
    {
        slider.maxValue = speed;
        slider.value = speed;
    }

    public void UpdateValue(float timeBTWAttack)
    {
        slider.value = slider.maxValue - timeBTWAttack;
    }
}
