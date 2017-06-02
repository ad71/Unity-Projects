using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWheelController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 10f;
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
            rb.AddForce(-this.transform.up * speed);
        }
	}
}
