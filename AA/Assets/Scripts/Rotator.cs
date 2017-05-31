using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed = 100f;

    private void Update()
    {
        this.transform.Rotate(0f, 0f, speed * Time.deltaTime);
        // We multiply this by Time.deltaTime because we are using the Update methid and we want it to be framerate independent
    }
}
