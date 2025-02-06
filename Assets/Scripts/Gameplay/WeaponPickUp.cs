using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickUp
{
    
    protected override void PickMeUp(Player playerInTrigger)
    {
        
        Destroy(gameObject);
    }
}
