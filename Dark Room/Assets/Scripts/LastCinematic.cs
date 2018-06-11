using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LastCinematic : MonoBehaviour
{
    private int i = 0;
    public Material[] mats;
    public GameObject screen;

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Outro");
    }

    public void ChangeScreen()
    {
        if (i == 0)
            screen.GetComponent<VideoPlayer>().enabled = true;

        else if (i == 1)
            screen.GetComponent<VideoPlayer>().enabled = false;

        if (i != 4)
            screen.GetComponent<Renderer>().material = mats[i];

        else if (i == 4)
            screen.GetComponent<VideoPlayer>().enabled = true;

        i++;
    }
}