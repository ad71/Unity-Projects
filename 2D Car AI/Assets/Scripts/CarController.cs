using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        RaycastHit2D hit = Physics2D.Raycast(origin, rb.velocity, Mathf.Infinity, layermask);

        if (hit)
        {
            Debug.Log(hit.collider.name);
            Debug.DrawLine(transform.position, hit.point, Color.red, 1);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(-this.transform.up * brakeforce);
	}
}
