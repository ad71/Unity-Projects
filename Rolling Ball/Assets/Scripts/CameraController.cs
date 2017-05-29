using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = this.transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame but runs after all items in Update have been processed
    //Thus, when we decide to move the camera, we know absolutely that the player has moved
	void LateUpdate () {
        this.transform.position = player.transform.position + offset;
	}
}
