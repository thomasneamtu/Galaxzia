using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Semi-Auto Weapon")]
public class SemiAuto : ProjectileWeapon
// Start is called before the first frame update

{
    public override void Reload()
    {
        
    }

    public override void Shoot(Transform weaponTip)
    {
        Bullet bulletClone = GameObject.Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
        bulletClone.InitializeBullet(damage);
    }

    public override void StartShooting(Transform weaponTip)
    {
        isShooting = true;
        Shoot(weaponTip);
        StopShooting();
    }

    public override void StopShooting()
    {
       isShooting = false;
    }

}

