using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWheelController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 100f;
    public float drift = 0.1f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(this.transform.up * speed);
        } else if(Input.GetKey(KeyCode.DownArrow))
        {
            // rb.AddForce(-this.transform.up * speed);
            rb.velocity = new Vector2(0, 0);
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
