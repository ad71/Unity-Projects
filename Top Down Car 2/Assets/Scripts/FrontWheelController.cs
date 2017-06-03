using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheelController : MonoBehaviour {

    private Rigidbody2D rb;
    private HingeJoint2D hj;
    public float drift = 0.7f;
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
                motorSpeed = 40,
                maxMotorTorque = 100
            };
            hj.motor = motor;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            hj.useMotor = true;
            JointMotor2D motor = new JointMotor2D
            {
                motorSpeed = -40,
                maxMotorTorque = 100
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
        rb.velocity = getVelocityTangent() + getVelocityNormal() * drift;
	}

    Vector2 getVelocityTangent()
    {
        return transform.up * Vector2.Dot(rb.velocity, transform.up);
    }

    Vector2 getVelocityNormal()
    {
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }
}
