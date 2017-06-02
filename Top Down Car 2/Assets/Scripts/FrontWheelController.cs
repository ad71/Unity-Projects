using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheelController : MonoBehaviour {

    private Rigidbody2D rb;
    private HingeJoint2D hj;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        hj = GetComponent<HingeJoint2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        JointAngleLimits2D anglesx = new JointAngleLimits2D
        {
            min = -30,
            max = 30
        };
        hj.limits = anglesx;
        if (Input.GetKey(KeyCode.RightArrow))
        {

            hj.useMotor = true;
            JointMotor2D motor = new JointMotor2D
            {
                motorSpeed = 100,
                maxMotorTorque = 10000
            };
            hj.motor = motor;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            hj.useMotor = true;
            JointMotor2D motor = new JointMotor2D
            {
                motorSpeed = -100,
                maxMotorTorque = 10000
            };
            hj.motor = motor;
        } 
        else
        {
            JointAngleLimits2D angles = new JointAngleLimits2D
            {
                min = 0,
                max = 0
            };
            hj.limits = angles;
        }
	}
}
