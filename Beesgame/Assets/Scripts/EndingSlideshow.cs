using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingSlideshow : MonoBehaviour
{
    private const float FadeDuration = 0.25f;
    private readonly float[] _slideDurations = { 2f, 2f };
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
