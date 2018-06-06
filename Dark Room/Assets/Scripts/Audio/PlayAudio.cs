using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    void Play()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    void Stop() 
    {
        AudioSource audio = null;
        audio.Stop();
    }
}
