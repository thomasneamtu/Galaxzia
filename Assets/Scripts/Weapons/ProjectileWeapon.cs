using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Projectile Weapon")]
public abstract class ProjectileWeapon : Weapon

{
    [SerializeField] protected Bullet projectilePrefab;
    private float shootDelay;



    public override void StartShooting(Transform weaponTip)
    {
        isShooting = true;
        shootDelay += 1 / fireRate;
    }

    public override void Reload()
    {
       
    }

    public override void Shoot(Transform weaponTip)
    {
        if (isShooting)
        {
            if (shootDelay >= 1 / fireRate)
            {
                Bullet bulletClone = GameObject.Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
                bulletClone.InitializeBullet(damage);
                shootDelay = 0;
            }
            else
            {
                shootDelay += Time.deltaTime;
            }
        }
    }

    public override void StopShooting()
    {
       isShooting = false;
        shootDelay = -1 / fireRate;
    }


}
