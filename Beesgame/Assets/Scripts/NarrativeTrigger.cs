using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{

    private GameObject player;

    private float moveDistance;
    private float moveSpeed;
    private float startTime;
    private float elapsedTime;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Quaternion startAngle;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<PlayerMovement>().enabled = false;
            startAngle = player.transform.rotation;
            startPoint = player.transform.position;
            moveDistance = gameObject.transform.parent.transform.position.y - player.transform.position.y;
            endPoint = startPoint + new Vector2(0.0f, moveDistance);
            startTime = Time.time;
            StartCoroutine("movePlayer");
        }
    }

    IEnumerator movePlayer()
    {
        elapsedTime = 0.0f;
        while (elapsedTime < 1.0f)
        {
            player.transform.position = Vector2.Lerp(startPoint, endPoint, elapsedTime);
            player.transform.rotation = Quaternion.Lerp(startAngle, Quaternion.identity, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void Update()
    {
        if (elapsedTime >= 1)
        {
            Debug.Log("Hi");
        }
    }


}
