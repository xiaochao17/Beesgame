using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{

    private GameObject player;

    private float cameraZoom;
    private float moveDistance;
    private float moveSpeed;
    private float elapsedTime;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Quaternion startAngle;


    private Camera mainCamera;
    private AudioSource characterConversation;

    public GameObject character;
    public AudioClip helloClip;
    public AudioClip goodbyeClip;
    public AudioClip playerClip;
    public float timeBetweenConversation = 0.0f;

    private void Start()
    {
        mainCamera = Camera.main;
        characterConversation = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<PlayerMovement>().enabled = false;
            startAngle = player.transform.rotation;
            startPoint = player.transform.position;
            moveDistance = character.transform.position.y - player.transform.position.y;
            endPoint = startPoint + new Vector2(0.0f, moveDistance);
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

            StartCoroutine("Conversation");
        }
    }

    IEnumerator Conversation()
    {
        characterConversation.clip = helloClip;
        characterConversation.Play();
        yield return new WaitForSeconds(characterConversation.clip.length + timeBetweenConversation);
        characterConversation.clip = playerClip;
        characterConversation.Play();
        yield return new WaitForSeconds(characterConversation.clip.length + timeBetweenConversation);
        characterConversation.clip = goodbyeClip;
        characterConversation.Play();
        yield return new WaitForSeconds(characterConversation.clip.length + timeBetweenConversation);

        player.GetComponent<PlayerMovement>().enabled = true;
        Destroy(gameObject);
    }


}
