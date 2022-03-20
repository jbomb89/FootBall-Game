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
    public void FixedUpdate()
    {

        




        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))

        {

            // curremtly Debug stuff to make the raycast seen
           
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

            if (hit.rigidbody != null && !hit.collider.gameObject.GetComponent<FixedJoint>())
            {
                Ball = hit.rigidbody;
                joint = Ball.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = player;
                held = true;
                Ball.gameObject.layer = 6;
            }
        }
    }

}
