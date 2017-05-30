using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float lifetime;
	// Use this for initialization
	void Start () {
        // lifetime indicates the time to wait before destroying the object
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
