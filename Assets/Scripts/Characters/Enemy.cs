using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float distanceToStop = 2f;
    [SerializeField] private float attackCoolDown = 3f;
    [SerializeField] private Transform enemyWeaponTip;
    private float attackTimer;
    private Player target;


    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<Player>();
    }
    
        
    
    protected void Update()
    {
        if (target == null) return;

        Vector2 destination = target.transform.position;
        Vector2 currentPosition = transform.position;
        Vector2 direction = destination - currentPosition;
        if(Vector2.Distance(destination, currentPosition) > distanceToStop)
        {
            Move(direction.normalized);
        }
        else
        {
            Attack();
        }

        Look(direction.normalized);
    }

    public override void Attack()
    {

        if (attackTimer >= attackCoolDown)
        {
            currentWeapon.StartShooting(enemyWeaponTip);
            attackTimer = 0;
        }
        else
        {
            attackTimer += Time.deltaTime;
        }

    }
    public override void PlayDeadEffect()
    {
        GameManager.instance.RemoveEnemyFromList(this);
        base.PlayDeadEffect();
    }
}    

