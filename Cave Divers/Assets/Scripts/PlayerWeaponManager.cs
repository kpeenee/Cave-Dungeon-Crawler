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
    private bool switchRight = true;
    private float mainAttackInterval = 0.0f;
    private float offAttackInterval = 0.0f;

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
            if (mainAttackInterval <= 0)
            {
                currentMain.Attack();
                armAnim.SetTrigger("attackR");
                WeaponData data = currentMain.GetStats();
                mainAttackInterval = data.attackSpeed;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(offAttackInterval <= 0)
            {
                currentOff.Attack();
                armAnim.SetTrigger("attackL");
                WeaponData data = currentOff.GetStats();
                offAttackInterval = data.attackSpeed;
            }
        }
        mainAttackInterval -= Time.deltaTime;
        offAttackInterval -= Time.deltaTime;
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        if (switchRight == true)
        {
            WeaponPickup oldWeapon = Instantiate(createPickup, transform.position + transform.forward * 2, Quaternion.identity);
            oldWeapon.setWeapon(currentMain);
            Destroy(currentMain.gameObject);

            currentMain = Instantiate(newWeapon, mainPoint.position, Quaternion.Euler(new Vector3(-72.5f, 0f, 0f)));
            currentMain.transform.parent = mainPoint.transform;
            switchRight = !switchRight;
        }
        else
        {
            WeaponPickup oldWeapon = Instantiate(createPickup, transform.position + transform.forward * 2, Quaternion.identity);
            oldWeapon.setWeapon(currentOff);
            Destroy(currentOff.gameObject);

            currentOff = Instantiate(newWeapon, offPoint.position, Quaternion.Euler(new Vector3(-72.5f, 0f, 0f)));
            currentOff.transform.parent = offPoint.transform;
            switchRight = !switchRight;
        }
    }
}
