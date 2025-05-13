using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Inside the tools menu I changed the line delete tool to ctrl + y!

public class Player : MonoBehaviour

{
    private bool jumpKeyWasPressed;
    private float horizontalInput;

    void Start()
    {

    }


    void Update()
    //update is called once per frame
    // anything with a key code/press should be here and not fixed update!
    //good workflow : check for key press in update, then apply the forces in fixed update
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;

        }
        horizontalInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
        //physics stuff here :]
    {
        if (jumpKeyWasPressed)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        GetComponent<Rigidbody>().linearVelocity = new Vector3(horizontalInput, GetComponent<Rigidbody>().linearVelocity.y, 0);
    }


}