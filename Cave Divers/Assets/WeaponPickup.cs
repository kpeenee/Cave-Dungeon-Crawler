using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    PrimaryWeapon pickupWeapon;
    MeshFilter mesh;
    Material material;

    [SerializeField] PrimaryWeapon testMethod;

    private void Start()
    {
        mesh = transform.GetChild(0).GetComponent<MeshFilter>();
        material = transform.GetChild(0).GetComponent<Renderer>().material;
        setWeapon(testMethod);
    }
    public void setWeapon(PrimaryWeapon weapon)
    {
        pickupWeapon = weapon;
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        mesh.mesh = pickupWeapon.GetComponent<MeshFilter>().sharedMesh;
        material = pickupWeapon.GetComponent<Renderer>().sharedMaterial;
        transform.GetChild(0).localScale = pickupWeapon.transform.localScale;
    }
}
