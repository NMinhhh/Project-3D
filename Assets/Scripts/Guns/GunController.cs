using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform weaponHold;

    [SerializeField] private Gun startingGun;

    Gun currentGun;
    private void Start()
    {
        if(startingGun != null)
        {
            EquippedGun(startingGun);
        }
    }

    public void EquippedGun(Gun newGun)
    {
        if(currentGun != null)
        {
            Destroy(currentGun.gameObject);
        }
        currentGun = Instantiate(newGun, weaponHold.position, weaponHold.rotation) as Gun;
        currentGun.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if(currentGun != null)
        {
            currentGun.Shoot();
        }
    }
}
