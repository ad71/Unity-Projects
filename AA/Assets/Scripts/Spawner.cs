using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject pin;

    private void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            SpawnPin();
        }
    }

    void SpawnPin()
    {
        Instantiate(pin, this.transform.position, this.transform.rotation);
    }
}
