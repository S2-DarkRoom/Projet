using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutCamera : MonoBehaviour
{
    float fadeTime = 5;
    public Texture fadeTexture;
    public bool fadeOut = false;
    private float tempTime;
    private float time = 0.0f;
    public GameObject tuto;

    public void Start()
    {
        fadeOut = true;
    }


    public void Update()
    {
        if (fadeOut)
        {
            if (time < fadeTime) time += Time.deltaTime;
            tempTime = Mathf.InverseLerp(0.0f, fadeTime, time);
        }

        if (tempTime >= 1.0f)
        {
            Debug.Log("Yeah");
            tuto.SetActive(true);
            enabled = false;
        }
            
    }
    
    public void OnGUI()
    {
        if (fadeOut)
        {
            Color thisColor = GUI.color;
            thisColor.a = 1f - tempTime;
            GUI.color = thisColor;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
    }
}
