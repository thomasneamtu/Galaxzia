using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : Character
{
    [SerializeField] GameObject turretPrefab;
    [SerializeField] private Transform turretWeaponTip;

    public void Update()
    {
        isTurretEnabled();
    }

    private void isTurretEnabled()
    {
        if (turretPrefab != null)
        {
            Invoke("PlayDeadEffect", 10f);
        }

    }

    public override void PlayDeadEffect()
    {
        base.PlayDeadEffect();
    }

    public override void StartAttack()
    {
        base.StartAttack();
        currentWeapon.StartShooting(turretWeaponTip);
    }
    public override void Attack()
    {
        currentWeapon.Shoot(turretWeaponTip);
    }

    public override void StopAttack()
    {
        base.StopAttack();
        currentWeapon.StopShooting();
    }
}
