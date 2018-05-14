using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {

    void Play()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
