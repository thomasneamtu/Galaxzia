using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NukePickUp : PickUp
{
    [SerializeField] private GameObject nukeEffect;
    [SerializeField] private GameObject nukeposition;
    protected override void PickMeUp(Player playerInTrigger)
    {       
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy")) Destroy(go);
        Instantiate(nukeEffect, Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
    }
}
