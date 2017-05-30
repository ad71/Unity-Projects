using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float speed = 1500;
    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;
    private float movement = 0;
    private void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed;
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
    }
}
