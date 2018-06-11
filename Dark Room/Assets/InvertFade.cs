using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertFade : MonoBehaviour
{
    float fadeTime = 5f;
    public Texture fadeTexture;
    public bool fadeOut = false;
    private float tempTime;
    private float time = 0.0f;
    public string cam;

    public void InvertFading()
    {
        fadeTime = 6f;
        fadeOut = true;
    }

    public void Update()
    {
        if (fadeOut)
        {
            if (time < fadeTime) time += Time.deltaTime;
            tempTime = Mathf.InverseLerp(0.0f, fadeTime, time);
        }
    }

    public void OnGUI()
    {
        if (fadeOut)
        {
            Color thisColor = GUI.color;
            thisColor.a = tempTime;
            GUI.color = thisColor;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
    }
}

