using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
	// Use this for initialization
	void Start () {
        SpawnWaves();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void SpawnWaves()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, spawnValues.z);
        Quaternion spawnRotation = new Quaternion();
        Instantiate(hazard, spawnPosition, spawnRotation);
    }
}
