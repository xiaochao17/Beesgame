using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

    [SerializeField] GameObject spiderProjectile;
    [SerializeField] float missileSpeed;
    GameObject missile;
    [SerializeField] Transform playerPosition;
    Vector2 directionToPlayer;
    bool changeFace = false;
    float angel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        directionToPlayer = playerPosition.position - gameObject.transform.position;
        Fire();

        if (directionToPlayer.x>0f && !changeFace ){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            changeFace = true;
        }
        if (directionToPlayer.x < 0f && changeFace)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            changeFace = false;
        }
    }

    void Fire()
    {
        // TODO: can be changed to a set of key code
        if (Vector3.Magnitude(directionToPlayer) < 10f && directionToPlayer.y < 0f && missile == null)
        {
            missile = Instantiate(spiderProjectile) as GameObject;
            missile.transform.position = gameObject.transform.position;
            //Debug.Log(Vector2.Angle(Vector2.right, directionToPlayer.normalized));
            missile.transform.eulerAngles = Vector3.forward * (Vector2.SignedAngle(Vector2.right, directionToPlayer.normalized) + 180);
            missile.GetComponent<Rigidbody2D>().velocity = directionToPlayer.normalized * missileSpeed;

        }
    }
}
