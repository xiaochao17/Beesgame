using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject missileExplode;


    //private void Update()
    //{
    //    //Destroy(gameObject, 3f);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit");
        Destroy(gameObject);
        GameObject missile = Instantiate(missileExplode, transform.position, Quaternion.identity);
        Destroy(missile, 1f);
    }




}
