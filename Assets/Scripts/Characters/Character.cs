using UnityEngine;

public class Character : MonoBehaviour
{
  
    public Health healthValue;
    public Weapon currentWeapon;

    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float health = 10f;
    [SerializeField] public GameObject dieEffect;

    protected virtual void Start()
    {
        healthValue = new Health(health);
        healthValue.OnDied.AddListener(PlayDeadEffect);
    }
    public virtual void Move(Vector2 direction)
    {
        myRigidbody.AddForce(direction * Time.deltaTime * movementSpeed, ForceMode2D.Impulse);
    }

    public virtual void Look(Vector2 direction)
    {
        float angle; // = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; more complicated option
        angle = Vector2.SignedAngle(Vector2.up, direction); // SignedAngle gives you a full 360, Angle gives 180
        myRigidbody.SetRotation(angle);
    }

    public virtual void PlayDeadEffect()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public virtual void Attack() //part that insantiates the bullet
    {

    }


    public void Interact()
    {
        
    }

    public virtual void StartAttack()
    {
       
    }
    
    public virtual void StopAttack()
    {

    }
}
