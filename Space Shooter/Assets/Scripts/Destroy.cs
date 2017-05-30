using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
            return;
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        //All destroy calls are stacked and executed at the end of each frame together, so the order of destruction doesn't matter
    }
}
