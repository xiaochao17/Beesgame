using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    private float _duration = 10f;

    void Update()
    {
        _duration -= Time.deltaTime;
        if (_duration < 0)
        {
            Destroy(gameObject);
        }
    }
}
