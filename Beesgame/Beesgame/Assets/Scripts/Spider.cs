using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

    [SerializeField] GameObject spiderProjectile;
    [SerializeField] float missileSpeed;
    GameObject missile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
	}

    void Fire()
    {
        // TODO: can be changed to a set of key code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            missile = Instantiate(spiderProjectile,
                                            gameObject.transform.position,
                                         Quaternion.identity) as GameObject;
            //TODO: Chnage speed and direction (get player position)
            missile.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, missileSpeed);

        }


    }
}
