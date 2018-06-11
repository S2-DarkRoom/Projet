using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LastCinematic : MonoBehaviour
{
    private int i = 0;
    public Material[] mats;
    public GameObject screen;
    public Image UI;
    public Sprite n1EN, n2EN, n2FR, n1FR;
    private bool FR;

    public void Play()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        UI.enabled = false;
        FindObjectOfType<AudioManager>().Play("Outro");
    }

    public void ChangeScreen()
    {
        switch (i)
        {
            case (0):
                screen.GetComponent<VideoPlayer>().enabled = true;
                screen.GetComponent<Renderer>().material = mats[i];
                break;
            case (1):
                screen.GetComponent<VideoPlayer>().enabled = false;
                screen.GetComponent<Renderer>().material = mats[i];
                break;
            case (2):
                UI.enabled = true;
                UI.sprite = FR ? n1FR : n1EN;
                break;
            case (3):
                
            case (4):
                UI.enabled = false;
                screen.GetComponent<VideoPlayer>().enabled = true;
                break;
        }

        i++;
    }
}