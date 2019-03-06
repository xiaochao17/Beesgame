using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeJitterer : MonoBehaviour
{
    [SerializeField]
    private float xAmplitude1;
    [SerializeField]
    private float xFrequency1;
    [SerializeField]
    private float xAmplitude2;
    [SerializeField]
    private float xFrequency2;
    [SerializeField]
    private float yAmplitude1;
    [SerializeField]
    private float yFrequency1;
    [SerializeField]
    private float yAmplitude2;
    [SerializeField]
    private float yFrequency2;
    
    private Transform _transform;

    void Start()
    {
        _transform = transform;
    }

    void FixedUpdate()
    {
        var localPosition = _transform.localPosition;
        localPosition.x = xAmplitude1 * Mathf.Sin(Time.time * 2 * Mathf.PI * xFrequency1) *
                          xAmplitude2 * Mathf.Sin(Time.time * 2 * Mathf.PI * xFrequency2);
        localPosition.y = yAmplitude1 * Mathf.Cos(Time.time * 2 * Mathf.PI * yFrequency1) *
                          yAmplitude2 * Mathf.Cos(Time.time * 2 * Mathf.PI * yFrequency2);
        _transform.localPosition = localPosition;
    }
}
