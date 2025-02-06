using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretInput : MonoBehaviour
{
    [SerializeField] private Character turret;

    public Vector3 mousePosition;
    public Vector3 lookDirection;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
        mousePosition = Input.mousePosition;
        mousePosition.z = 0; 

        lookDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        

        turret.Look(lookDirection);

        if (Input.GetMouseButtonDown(0))
        {
            turret.StartAttack();
           
        }

        if (Input.GetMouseButton(0))
        {
            turret.Attack();
        }

        if (Input.GetMouseButtonUp(0))
        {
            turret.StopAttack();
            
        }
    }
}
