using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Inside the tools menu I changed the line delete tool to ctrl + y!

public class Player : MonoBehaviour

{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask dirtTileMask;
    [SerializeField] private LayerMask mushroomMask;
    [SerializeField] private LayerMask Everything;


    public Coin coinScript;
    public Mushroom mushroomScript;
    public GameObject mushroomObject;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;

    



    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();

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
        /*the below code uses a spherical area to check for transforms.
        We can use the ground check transform (the empty game object) for the position and 0.1 for the radius
        since unity engine collider isn't compatible with bool, we use Length to check the number of items in the array - we don't need more info*/

        rigidbodyComponent.linearVelocity = new Vector3(horizontalInput * 2, rigidbodyComponent.linearVelocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, dirtTileMask | mushroomMask ).Length == 0)
        {
            jumpKeyWasPressed = false;
        }
        


        if (jumpKeyWasPressed)
        {
            //f for float needs to be added when using decimals!
            rigidbodyComponent.AddForce(Vector3.up * 6.5f, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        if(mushroomScript.powerupsCollected > 0)
        {
            rigidbodyComponent.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
           mushroomScript.powerupsCollected--;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinScript.coinsCollected++;
        }

        if (other.gameObject.CompareTag("Mushroom"))
        {
            mushroomObject.SetActive(false);
            mushroomScript.powerupsCollected++;

            Invoke("spawnMushroom", 1.5f);
            

        }

    }
    void spawnMushroom()
    {
        mushroomObject.SetActive(true);
    }


}
