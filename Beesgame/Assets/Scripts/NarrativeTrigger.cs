using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 


public class NarrativeTrigger : MonoBehaviour
{

    private GameObject player;

    private float cameraCurrentZoom;
    private float moveDistance;
    private float moveSpeed;
    private float elapsedTime;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Quaternion startAngle;

    private AudioSource characterConversation;

    public CinemachineVirtualCamera vcam;
    public GameObject character;
    public AudioClip helloClip;
    public AudioClip goodbyeClip;
    public AudioClip playerClip;
    public GameObject homeImg;
    public float timeBetweenConversation = 0.0f;

    private bool isAlreadyPlaying = false;

    private void Start()
    {

        characterConversation = gameObject.GetComponent<AudioSource>();
        cameraCurrentZoom = vcam.m_Lens.OrthographicSize;
        homeImg.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isAlreadyPlaying)
        {
            isAlreadyPlaying = true;
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
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(cameraCurrentZoom, cameraCurrentZoom / 2.0f, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StartCoroutine("Conversation");
        
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

        StartCoroutine("CharacterLeave");
    }

    IEnumerator CharacterLeave()
    {
        float t = 0.0f;
        while (t <= 3.0f)
        {
            t += Time.fixedDeltaTime; // Goes from 0 to 1, incrementing by step each time
            character.transform.position += Vector3.left * 5.0f * Time.fixedDeltaTime; // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();      
        }
        Destroy(character);

        homeImg.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(homeImg);
        StartCoroutine("ZoomOut");
    }


    IEnumerator ZoomOut()
    {
        elapsedTime = 0.0f;
        while (elapsedTime < 1.0f)
        {
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(cameraCurrentZoom / 2.0f, cameraCurrentZoom, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
