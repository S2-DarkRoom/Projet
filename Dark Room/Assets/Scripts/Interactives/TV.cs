using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    public bool pushed = false;
    public GameObject chair;
    public GameObject cam;
    public Material[] mats;
    public GameObject screen;
    private int i = 0;

    public void Push()
    {
        pushed = true;
        chair.SetActive(true);
    }

    public void Sit()
    {
        cam.SetActive(true);
    }

    public void ChangeScreen()
    {
        if (i == 0)
        {
            screen.GetComponent<VideoPlayer>().enabled = true;
            screen.GetComponent<Renderer>().material = mats[i];
        }

        i++;
    }
}
