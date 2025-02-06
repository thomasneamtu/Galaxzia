using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPickUp : PickUp
{
    [SerializeField] private GameObject turretPrefab;


    protected override void PickMeUp(Player playerInTrigger)
    {
        Instantiate(turretPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
