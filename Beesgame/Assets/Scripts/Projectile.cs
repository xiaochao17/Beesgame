using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject missileExplode;


    private void Awake()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject missile = Instantiate(missileExplode, transform.position, Quaternion.identity);
        Destroy(missile, 1f);
    }




}
