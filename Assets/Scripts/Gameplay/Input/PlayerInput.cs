using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Character player;
    
    //DEBUG ONLY
    public Vector2 direction;
    public Vector3 mousePosition;
    public Vector3 lookDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        player.Move(direction);

        mousePosition = Input.mousePosition;
        mousePosition.z = 10; //Offsetting the cameras Z value to compensate for the -10 Z value from the camera
                              //mousePosition.z = -Camera.main.transform.position.z; is the same as above, more professional 

        lookDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        // direction  =        final position             -              starting position

        player.Look(lookDirection);

        if (Input.GetMouseButtonDown(0))
        {
            player.StartAttack();
            //start shooting
        }

        if (Input.GetMouseButton(0))
        {
            player.Attack();
        }

        if (Input.GetMouseButtonUp(0))
        {
            player.StopAttack();
            //stop shooting
        }
    }
}
