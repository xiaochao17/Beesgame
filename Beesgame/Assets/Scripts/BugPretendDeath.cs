using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugPretendDeath : MonoBehaviour
{
    public Animator bugAnimator;

    private void Start()
    {
        bugAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hello");
            bugAnimator.SetBool("isHit", true);
            StartCoroutine("PretendDeath");
        }
    }

    IEnumerator PretendDeath()
    {
        yield return new WaitForSeconds(3);
        bugAnimator.SetBool("isHit", false);
    }
}
