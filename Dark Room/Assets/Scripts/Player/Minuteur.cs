using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Minuteur : MonoBehaviour
{

    private float time = 3600.0f;


    void Update ()
    {
        time -= Time.deltaTime * 15; 

		if (time <= 0) 
		{
            //FIXME
			time = 0;
			SceneManager.LoadScene("Menu");
		}
	}
    void OnGUI()
    {
        TimeSpan t = TimeSpan.FromSeconds(time);
        //GUI.Box(new Rect(20, 20, 75, 20), "0 : " + ((time % 3600) / 60).ToString("00") + " : " + (time % 60).ToString("00"));
        GUI.Box(new Rect(20, 20, 75, 20), string.Format("{0:D2} : {1:D2} : {2:D2}",
                t.Hours,
                t.Minutes,
                t.Seconds));
    }
}
