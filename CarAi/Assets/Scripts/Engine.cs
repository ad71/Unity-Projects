using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelfl;
    public WheelCollider wheelfr;
    public float mmt = 100f;
    public float currentSpeed;
    public float maxSpeed = 100f;

    private List<Transform> nodes;
    private int current = 0;
	// Use this for initialization
	void Start () {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i = 0; i < pathTransforms.Length; ++i)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
        ApplySteer();
        Drive();
        NextWaypoint();
	}

    private void ApplySteer()
    {
        Vector3 relative = this.transform.InverseTransformPoint(nodes[current].position);
        // relative /= relative.magnitude; // can be done by relative.Normalize() probably :/
        float steer = (relative.x / relative.magnitude) * maxSteerAngle;
        wheelfl.steerAngle = steer;
        wheelfr.steerAngle = steer;
    }

    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * wheelfl.radius * wheelfl.rpm * 60 / 1000;
        if (currentSpeed < maxSpeed)
        {
            wheelfl.motorTorque = mmt;
            wheelfr.motorTorque = mmt;
        } else
        {
            wheelfl.motorTorque = 0;
            wheelfr.motorTorque = 0;
        }
    }

    private void NextWaypoint()
    {
        if (Vector3.Distance(this.transform.position, nodes[current].position) < 5f)
        {
            if (current == nodes.Count - 1)
            {
                current = 0;
            } else
            {
                current++;
            }
        }
    }
}
