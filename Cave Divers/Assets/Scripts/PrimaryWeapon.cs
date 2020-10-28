using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeapon : Weapon
{

    public override void Attack()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, data.range))
        {
            Debug.Log("something has been hit");
        }
    }
}
