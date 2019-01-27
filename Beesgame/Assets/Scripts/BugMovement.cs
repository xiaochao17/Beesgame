using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D bugRB2D;
    private Collider2D bugCollider;
    private Vector2 bugDirection;

    public float bugSpeed = 1.0f;
    private void Start()
    {
        bugDirection = new Vector2 (1.0f, 0.0f);
    }

    private void Update()
    {
        transform.Translate(bugDirection * bugSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BugStop"))
        {
            bugDirection *= -1;
            var localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
    }


}
