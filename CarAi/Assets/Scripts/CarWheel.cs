using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour {

    public WheelCollider target;
    private Vector3 wheelposition = new Vector3();
    private Quaternion wheelrotation = new Quaternion();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target.GetWorldPose(out wheelposition, out wheelrotation);
        this.transform.position = wheelposition;
        this.transform.rotation = wheelrotation;
	}
}
