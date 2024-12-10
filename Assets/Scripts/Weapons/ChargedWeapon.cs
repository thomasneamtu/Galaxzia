using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Charging Weapon")]
public class ChargeWeapon : ProjectileWeapon
{

    [SerializeField] private float chargingRequiredTime;
    private float chargingTimer;


    public override void Reload()
    {
        
    }

    public override void Shoot(Transform weaponTip)
    {
        if (isShooting)
        {

            if (chargingTimer > chargingRequiredTime)
            {
                Bullet bulletClone = GameObject.Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
                bulletClone.InitializeBullet(damage);
                StopShooting();
            }
            else
            {
                chargingTimer += Time.deltaTime;
            }
        }
    }

    public override void StartShooting(Transform weaponTip)
    {
        isShooting = true;
        chargingTimer = 0;
    }

    public override void StopShooting()
    {
        isShooting = false;
        chargingTimer = 0;
    }

}
