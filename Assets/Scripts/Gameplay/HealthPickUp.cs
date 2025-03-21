using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{
    [SerializeField] private GameObject healthGlow; 
    [SerializeField] private int healthPointsToAdd;
    protected override void PickMeUp(Player playerInTrigger)
    {   
        playerInTrigger.healthValue.IncreaseHealth(Random.Range(25, 50));
        Instantiate(healthGlow, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}