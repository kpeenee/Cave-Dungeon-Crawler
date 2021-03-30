using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] Weapon currentMain;
    [SerializeField] Weapon currentOff;
    [SerializeField] WeaponPickup createPickup;
    [SerializeField] Transform mainPoint;
    [SerializeField] Transform offPoint;

    [Header("Arms")]
    [SerializeField] Transform arms;
    private Animator armAnim;

    private void Awake()
    {
        armAnim = arms.GetComponent<Animator>();
        currentMain = Instantiate(currentMain, mainPoint.position, Quaternion.Euler(new Vector3(-72.5f, 0f, 0f)));
        currentMain.transform.parent = mainPoint.transform;

        currentOff = Instantiate(currentOff, offPoint.position, Quaternion.Euler(new Vector3(-72.5f, 0f, 0f)));
        currentOff.transform.parent = offPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentMain.Attack();
            armAnim.SetTrigger("attackR");
        }
        if (Input.GetMouseButtonDown(1))
        {
            currentOff.Attack();
            armAnim.SetTrigger("attackL");
        }
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        WeaponPickup oldWeapon = Instantiate(createPickup, transform.position + transform.forward * 2, Quaternion.identity);
        oldWeapon.setWeapon(currentMain);
        Destroy(currentMain.gameObject);

        currentMain = Instantiate(newWeapon, mainPoint.position, Quaternion.Euler(new Vector3(-72.5f, 0f, 0f)));
        currentMain.transform.parent = mainPoint.transform;
    }
}
