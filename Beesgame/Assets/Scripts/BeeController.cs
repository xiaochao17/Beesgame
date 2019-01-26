using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BeeController : MonoBehaviour
{
    [SerializeField]
    private float moveForceMagnitude;
    [SerializeField]
    private Transform spriteContainerTransform;
    
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");

        if (Math.Abs(hAxis) > Mathf.Epsilon)
        {
            var localScale = spriteContainerTransform.localScale;
            localScale.x = hAxis > 0 ? 1 : -1;
            spriteContainerTransform.localScale = localScale;
        }

        var direction = new Vector2(hAxis, vAxis).normalized;
        _rigidbody.AddForce(direction * moveForceMagnitude);
    }
}
