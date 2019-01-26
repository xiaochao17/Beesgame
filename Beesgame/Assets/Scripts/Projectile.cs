using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject missileExplode; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Forest_Ground"){
            Destroy(gameObject);
            GameObject missile = Instantiate(missileExplode, transform.position, Quaternion.identity);
            Destroy(missile, 1f);
        }

    }
}
