using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugPretendDeath : MonoBehaviour
{
    public Animator bugAnimator;
    private AudioSource bugAudio;
    private Rigidbody2D bugRB2D;

    private void Start()
    {
        bugAnimator = gameObject.GetComponent<Animator>();
        bugAudio = gameObject.GetComponent<AudioSource>();
        bugRB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bugAnimator.SetBool("isHit", true);
            bugAudio.Stop();
            bugRB2D.bodyType = RigidbodyType2D.Static;
            StartCoroutine("PretendDeath");
        }
    }

    IEnumerator PretendDeath()
    {
        yield return new WaitForSeconds(3);
        bugRB2D.bodyType = RigidbodyType2D.Dynamic;
        bugAnimator.SetBool("isHit", false);
        bugAudio.Play();
    }
}
