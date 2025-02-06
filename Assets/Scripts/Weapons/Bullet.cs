using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private float bulletSpeed;
    private float myDamage;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.velocity = transform.up * bulletSpeed;
        bullet = GameObject.FindWithTag("Bullet");
    }

    public virtual void InitializeBullet(float damageParam)
    {
        myDamage = damageParam;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            collision.rigidbody.GetComponent<Character>().healthValue.DecreaseHealth(myDamage);
        }
        else
        {
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

   
}
