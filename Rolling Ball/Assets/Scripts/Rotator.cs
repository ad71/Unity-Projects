using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        //We multiply by Time.deltaTime so that the rotation is smooth and framerate independent
	}

    //Since we are not updating physics, we will not use FixedUpdate()
}
