using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    private Rigidbody2D rb;
    public float torque;
    public float x;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // rb.AddTorque(torque);
        rb.AddForce(new Vector2(x, 0));
	}
}
