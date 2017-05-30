using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//System.Serializable is declared so that the boundary class appears in the editor. Without this, Unity has no idea about th class
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary b;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // FixedUpdate is called once per frame. This will be called by Unity before every Physics step
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, b.xMin, b.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, b.zMin, b.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
