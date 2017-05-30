using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The line below is going to force Unity to require a riidbody2d on the car controller
// [RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour {

    public float speed = 1500;
    public float rotationspeed = 15f;
    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;
    public Rigidbody2D rb;
    private float movement = 0;
    private float tilt = 0;
    private void Update()
    {
        // rb = GetComponent<Rigidbody2D>();
        // GetAxis smoothens user input which feels a bit 'nice' but not very respondent
        movement = -Input.GetAxisRaw("Vertical") * speed;
        tilt = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if(movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        } else
        {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D
            {
                motorSpeed = this.movement,
                maxMotorTorque = backWheel.motor.maxMotorTorque
            };

            backWheel.motor = motor;
            frontWheel.motor = motor;
        }
        rb.AddTorque(-tilt * rotationspeed * Time.fixedDeltaTime);
        // Maybe fixedDeltaTime adds framerate independence
    }
}
