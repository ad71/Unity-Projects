using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class CarController : MonoBehaviour {

    private Rigidbody2D rb;
    public float brakeforce = 10f;
    public LayerMask layermask;
    // public Camera camera;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 10;
        //Vector3 screenPos = camera.ScreenToWorldPoint(mousePos);
        //RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

        //if(hit)
        //{
        //Debug.Log(hit.collider.name);
        //}
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D fronthit = Physics2D.Raycast(origin, this.transform.up, Mathf.Infinity, layermask);
        RaycastHit2D rightskewhit = Physics2D.Raycast(origin, 2*this.transform.up + this.transform.right, Mathf.Infinity, layermask);
        RaycastHit2D leftskewhit = Physics2D.Raycast(origin, 2 * this.transform.up - this.transform.right, Mathf.Infinity, layermask);
        RaycastHit2D lefthit = Physics2D.Raycast(origin, -this.transform.right, Mathf.Infinity, layermask);
        RaycastHit2D righthit = Physics2D.Raycast(origin, this.transform.right, Mathf.Infinity, layermask);

        if (fronthit)
        {
            // Debug.Log(fronthit.collider.name);
            // Debug.DrawLine(transform.position, fronthit.point, Color.red, 1);
            // Debug.Log(rightskewhit.collider.name);
            // Debug.DrawLine(transform.position, rightskewhit.point, Color.green, 1);
            // Debug.DrawLine(transform.position, leftskewhit.point, Color.green, 1);
            if (fronthit.distance > 12f && !Input.GetKey(KeyCode.UpArrow))
            {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.UP);
            }
            if (fronthit.distance < 12f)
            {
                // InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN);
                if (leftskewhit.distance < rightskewhit.distance && Vector2.Dot(this.transform.up, rb.velocity) > 0) InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
                if (leftskewhit.distance < rightskewhit.distance && Vector2.Dot(this.transform.up, rb.velocity) < 0) InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT);
                if (rightskewhit.distance < leftskewhit.distance && Vector2.Dot(this.transform.up, rb.velocity) > 0) InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT);
                if (rightskewhit.distance < leftskewhit.distance && Vector2.Dot(this.transform.up, rb.velocity) < 0) InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
            }
            if (fronthit.distance < 5f)
            {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN);
            }
            if (lefthit.distance < 2f)
            {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
            }
            if (righthit.distance < 2f)
            {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT);
            }
            if (rightskewhit.distance > leftskewhit.distance + 20f)
            {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
            }
            if (leftskewhit.distance > rightskewhit.distance + 20f)
            {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(-this.transform.up * brakeforce);
	}
}
