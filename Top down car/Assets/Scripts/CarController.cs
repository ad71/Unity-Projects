using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float speed = 10f;
    public float torque = -500f;
    public float driftFactor = 1f;
    private Rigidbody2D rb;
    private bool movingForward;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 toAdd = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movingForward = true;
            rb.AddForce(this.transform.up * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movingForward = false;
            rb.AddForce(-this.transform.up * speed);
        }
        float vf = getVelocityTangent().magnitude;
        if (vf > 0.5f && movingForward) { 
            rb.angularVelocity = Input.GetAxis("Horizontal") * torque;
            toAdd = new Vector2(Input.GetAxis("Horizontal")/10, 0);
        } else if (vf > 0.5f && !movingForward)
        {
            rb.angularVelocity = -Input.GetAxis("Horizontal") * torque;
            toAdd = new Vector2(-Input.GetAxis("Horizontal") / 10, 0);
        }
                
        // rb.AddTorque(Input.GetAxis("Horizontal") * torque);

        rb.velocity = getVelocityTangent() + getVelocityNormal() * driftFactor + toAdd;
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
