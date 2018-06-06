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
        time -= Time.deltaTime; 
		if (time <= 0) 
		{
			time = 0;
			SceneManager.LoadScene("Menu");
		}
	}
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 75, 20), "0 : " + ((time / 60) % 60 - 1).ToString("0") + " : " + (time % 60).ToString("0"));
    }
}
