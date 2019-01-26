using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Use this for initialization
    private Rigidbody2D playerRB2D;
    private float forceAmount = 1.0f;
    public float jumpForceModifier = 10.0f;
    public float moveForceModfier = 5.0f;
    public float tilt = 1.0f;


    void Start()
    {
        playerRB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        playerRB2D.rotation = playerRB2D.velocity.x * -tilt;

        // change give it a little bit rotation

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 horizontalMovement = new Vector2(moveHorizontal, 0.0f);

        if (Input.GetButton("Jump"))
        {
            playerRB2D.AddForce(forceAmount * jumpForceModifier * Vector3.up);
        }


        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        playerRB2D.AddForce(horizontalMovement * moveForceModfier * forceAmount);
    }
}
