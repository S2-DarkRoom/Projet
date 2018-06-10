using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Minuteur : MonoBehaviour
{
    public bool end = false;
    public GameObject mainCam, endCam;
    public GameObject UIend;

    private float time = 3600.0f;

    void Update ()
    {
        time -= Time.deltaTime * 200; 

		if (time <= 0) 
		{
            end = true;
            EndGame();
		}
	}

    public void EndGame()
    {
        mainCam.SetActive(false);
        endCam.SetActive(true);
    }

    void OnGUI()
    {
        if (!end)
        {
            TimeSpan t = TimeSpan.FromSeconds(time);
            GUI.Box(new Rect(20, 20, 75, 20), string.Format("{0:D2} : {1:D2} : {2:D2}",
                    t.Hours,
                    t.Minutes,
                    t.Seconds));
        }

        else
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(20, 20, 75, 20), "00 : 00 : 00");
        }
    }
}
