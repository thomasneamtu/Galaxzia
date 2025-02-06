using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Charging Weapon")]
public class ChargeWeapon : ProjectileWeapon
{

    [SerializeField] private float chargingRequiredTime;
    private float chargingTimer;


    public override void Shoot(Transform weaponTip)
    {
        if (isShooting)
        {

            if (chargingTimer >= chargingRequiredTime)
            {
                //stop charging sound
                //play shot sound
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
        //audio source for charging sound
        isShooting = true;
        chargingTimer = 0;
    }   

    public override void StopShooting()
    {
        isShooting = false;
        chargingTimer = 0;
    }

}
