
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : Character
{
    private float timeAlive;
    private float timeUntilDestruction = 5f;
    [SerializeField] GameObject turretPrefab;
    [SerializeField] private Transform turretWeaponTip;

    public void Update()
    {
        
    }

    private void TurretTimer()
    {
        if (timeAlive > timeUntilDestruction)
        {
            PlayDeadEffect();
        }
        else
        {
            timeAlive += Time.deltaTime;
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
