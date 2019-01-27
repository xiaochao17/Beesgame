using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BeeGun : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    
    [SerializeField]
    private GameObject bulletPrefab;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var position = transform.position;
            var direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition )- position).normalized;
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = position;
            Debug.Log(position);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
