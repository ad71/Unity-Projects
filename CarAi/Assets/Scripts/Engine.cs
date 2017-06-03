using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    public Transform path;
    public float maxSteerAngle = 45f;
    public float maxMotorTorque = 100f;
    public float maxBrakingTorque = 170f;
    public float currentSpeed;
    public float maxSpeed = 100f;
    public Vector3 centerOfMass;
    public bool isBraking = false;
    public Texture2D normal;
    public Texture2D braking;
    public Renderer carTextureRenderer;

    [Header("Colliders")]
    public WheelCollider wheelfl;
    public WheelCollider wheelfr;
    public WheelCollider wheelrl;
    public WheelCollider wheelrr;

    [Header("Sensors")]
    public float sensorLength = 3f;
    public Vector3 sensorPosition = new Vector3(0, 0.2f, 0.5f);
    public float sideSensorOffset = 0.2f;
    public float sensorSkewAngle = 30f;

    private List<Transform> nodes;
    private int current = 0;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
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
        Sense();
        ApplySteer();
        Drive();
        NextWaypoint();
        Brake();
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
        if (currentSpeed < maxSpeed && !isBraking)
        {
            wheelfl.motorTorque = maxMotorTorque;
            wheelfr.motorTorque = maxMotorTorque;
        } else
        {
            wheelfl.motorTorque = 0;
            wheelfr.motorTorque = 0;
        }
    }

    private void NextWaypoint()
    {
        if (Vector3.Distance(this.transform.position, nodes[current].position) < 3f)
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

    private void Brake()
    {
        if(isBraking)
        {
            carTextureRenderer.material.mainTexture = braking;
            wheelrl.brakeTorque = maxBrakingTorque;
            wheelrr.brakeTorque = maxBrakingTorque;
        } else
        {
            carTextureRenderer.material.mainTexture = normal;
            wheelrl.brakeTorque = 0;
            wheelrr.brakeTorque = 0;
        }
    }

    private void Sense()
    {
        RaycastHit hit;
        Vector3 origin = this.transform.position + sensorPosition;
        // Front center sensor
        if (Physics.Raycast(origin, this.transform.forward, out hit, sensorLength))
        {

        }
        Debug.DrawLine(origin, hit.point);

        // Front right sensor
        origin.x += sideSensorOffset;
        if (Physics.Raycast(origin, this.transform.forward, out hit, sensorLength))
        {

        }
        Debug.DrawLine(origin, hit.point);

        // Front right skew sensor
        if (Physics.Raycast(origin, Quaternion.AngleAxis(sensorSkewAngle, this.transform.up) * transform.forward, out hit, sensorLength))
        {

        }
        Debug.DrawLine(origin, hit.point);

        // Front left sensor
        origin.x -= 2 * sideSensorOffset;
        if (Physics.Raycast(origin, this.transform.forward, out hit, sensorLength))
        {

        }
        Debug.DrawLine(origin, hit.point);

        // Front right skew sensor
        if (Physics.Raycast(origin, Quaternion.AngleAxis(-sensorSkewAngle, this.transform.up) * transform.forward, out hit, sensorLength))
        {

        }
        Debug.DrawLine(origin, hit.point);
    }
}
