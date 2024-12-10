using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{
    [SerializeField] private int healthPointsToAdd;
    protected override void PickMeUp(Player playerInTrigger)
    {
        playerInTrigger.healthValue.IncreaseHealth(Random.Range(1, 4));
        Destroy(gameObject);
    }
}