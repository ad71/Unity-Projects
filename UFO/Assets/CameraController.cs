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
	
	// Update is called once per frame
	void LateUpdate () {
        //LateUpdate runs every frame but only after all items have been processed in Update
        transform.position = player.transform.position + offset;
	}
}