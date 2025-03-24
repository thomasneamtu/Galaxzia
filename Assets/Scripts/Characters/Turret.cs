
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : Character
{
    [SerializeField] private float timeAlive;
    [SerializeField] private float timeUntilDestruction = 5f;
    [SerializeField] GameObject turretPrefab;
    [SerializeField] private Transform turretWeaponTip;

    public void Update()
    {
        TurretTimer();
    }

    private void TurretTimer()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive >= timeUntilDestruction)
        {
            PlayDeadEffect();
            Debug.Log("Turret Expired");
            timeAlive = 0;
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
