using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomber : Enemy
{
    private float myDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody && collision.rigidbody.CompareTag("Player"))
        {
            collision.rigidbody.GetComponent<Character>().healthValue.DecreaseHealth(25f);
            PlayDeadEffect();
        }
       
    }

}
