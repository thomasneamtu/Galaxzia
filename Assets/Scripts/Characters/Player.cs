
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Transform playerWeaponTip;

    protected override void Start()
    {
        base.Start();
    }

    public override void StartAttack()
    {
        base.StartAttack();
        currentWeapon.StartShooting(playerWeaponTip);
    }

    public override void StopAttack()
    {
        base.StopAttack();
        currentWeapon.StopShooting();
    }


    public override void Attack()
    {
        currentWeapon.Shoot(playerWeaponTip);
    }

    private void Update()
    {
        Attack();
    }
}