using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip music;
    public AudioClip ambientSound;

    private AudioSource audioAmbi;
    private AudioSource audioMusic;

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check player's location. assgin different audio clip (y is below a certain value, then cave?)
        
    }
}
