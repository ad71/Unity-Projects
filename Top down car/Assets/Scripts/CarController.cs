using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float speed = 10f;
    public float torque = -0.0000005f;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(this.transform.up * speed);
        else if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(-this.transform.up * speed);

        rb.AddTorque(Input.GetAxis("Horizontal") * torque);
	}
}
