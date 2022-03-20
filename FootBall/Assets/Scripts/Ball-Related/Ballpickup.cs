using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ballpickup : MonoBehaviour
{
    public Rigidbody player;
    private Rigidbody Ball;
    private FixedJoint joint;
    private FootBall footBall;
    RaycastHit hit;
    bool held;
    public void Awake()
    {
        footBall = new FootBall();

    }
    private void OnEnable()
    {
        footBall.Enable();
    }
    private void OnDisable()
    {
        footBall.Disable();
    }
    public void Update()
    {



       


        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))

        {
           
            footBall.Player.PickUp.performed += Pickup;
        }

        
    }
    public void Pickup(InputAction.CallbackContext context)
    {

        print("pressed");
        if (hit.distance <= 1 && !held)
        {
            // The input stuff to pickup the ball **IS SUBJECT TO CHANGE**
            print("HIT");
            Ball = hit.rigidbody;
            Ball.AddForce(1, 100, 1);
            if (hit.rigidbody != null && !hit.collider.gameObject.GetComponent<FixedJoint>())
            {

              
                joint = Ball.gameObject.AddComponent<FixedJoint>();
                Ball.isKinematic = true;
                Ball.position = player.position;
                joint.connectedBody = player;
                held = true;
                Ball.gameObject.layer = 6;
                Ball.isKinematic = false;
                
            }
        }
    }

}
