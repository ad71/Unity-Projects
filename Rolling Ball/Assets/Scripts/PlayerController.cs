using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    private Rigidbody rb;
    public float speed;

    //Unity equivalent of Processing's void setup()
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //Update is called for calculating stuff before rendering the frame
    void Update()
    {

    }

    //FixedUpdate is called before performing any Physics calculation
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
            other.gameObject.SetActive(false);
    }
}
