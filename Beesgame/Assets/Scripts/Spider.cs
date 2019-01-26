using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

    [SerializeField] GameObject spiderProjectile;
    [SerializeField] float missileSpeed;
    GameObject missile;
    [SerializeField] Transform playerPosition;
    Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Fire();
	}

    void Fire()
    {
        // TODO: can be changed to a set of key code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 player = playerPosition.position;
            print(player);
            //direction = (playerPosition.position - gameObject.transform.position).normalized;
            //missile = Instantiate(spiderProjectile,
            //                                gameObject.transform.position,
            //                             Quaternion.identity) as GameObject;
            ////TODO: Chnage speed and direction (get player position)
            //missile.GetComponent<Rigidbody2D>().velocity = direction*missileSpeed;

        }


    }
}
