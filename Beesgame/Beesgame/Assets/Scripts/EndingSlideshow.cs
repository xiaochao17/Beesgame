using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingSlideshow : MonoBehaviour
{
    private const float FadeDuration = 0.4f;
    private readonly float[] _slideDurations =
    {
        3f, // friends 
        5f, // rain starts
        1f, // lightning
        4f, // rain again
        5f, // hive falls
        4f, // hive fall close up
        5f, // oh no
        4f, // top down broken
        4f, // tap
        4f, // friends
        1f, // blackout
        4f, // credits
    };
    private Image[] _images;
    
    void Start()
    {
        _images = GetComponentsInChildren<Image>();
        for (var i = 0; i < _images.Length; i++)
        {
            _images[i].canvasRenderer.SetColor(Color.clear);
        }
        StartCoroutine(StartSlideshow());
    }

    IEnumerator StartSlideshow()
    {


        for (var i = 0; i < _images.Length; i++)
        {
            print(_images[i].canvasRenderer.GetColor());
            _images[i].CrossFadeColor(Color.white, FadeDuration, false, true);
            yield return new WaitForSeconds(_slideDurations[i]);
        } 
    }
}
