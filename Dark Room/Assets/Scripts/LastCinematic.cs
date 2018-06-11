using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LastCinematic : MonoBehaviour
{
    private int i = 0, j = 0;
    public Material[] mats;
    public GameObject screen;
    public Image UI;
    public Sprite n1EN, n2EN, n2FR, n1FR;
    private bool FR;

    public void Start()
    {
        UI.enabled = false;
    }

    public void Play()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        FindObjectOfType<AudioManager>().Play("Outro");
    }

    public void SetUI()
    {
        if (j == 1)
            UI.sprite = FR ? n2FR : n2EN;

        if (j == 0)
            UI.sprite = FR ? n1FR : n1EN;

        UI.enabled = true;
        j++;
    }

    public void CloseUI()
    {
        UI.enabled = false;
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
            case (3):
            case (4):
                screen.GetComponent<Renderer>().material = mats[i];
                break;
            case (5):
                screen.GetComponent<VideoPlayer>().enabled = true;
                break;
        }

        i++;
    }
}