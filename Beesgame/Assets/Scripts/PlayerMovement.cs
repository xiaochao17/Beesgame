using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    // Use this for initialization
    private Rigidbody2D playerRB2D;
    public float forceAmount = 1.0f;
    public float dashForceModifier = 5.0f;
    public float tilt = 1.0f;
    public float tiltThreshold;


    void Start()
    {
        playerRB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerRB2D.rotation = playerRB2D.velocity.x * -tilt;

        // change give it a little bit rotation

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        playerRB2D.AddForce(forceAmount * movement);

        if (Input.GetButtonDown("Jump"))
        {
            playerRB2D.AddForce(forceAmount * dashForceModifier * new Vector2(movement.x, 0), ForceMode2D.Impulse);
        }

        if (Mathf.Abs(moveHorizontal) > Mathf.Epsilon && playerRB2D.rotation * Mathf.Sign(transform.localScale.x) > tiltThreshold)
        {
            var localScale = transform.localScale;
            localScale.x = moveHorizontal > 0 ? 1 : -1;
            transform.localScale = localScale;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "friend")
        {
            SceneManager.LoadScene(2);
        }
    }
}
