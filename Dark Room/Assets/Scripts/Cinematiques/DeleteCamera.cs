using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject manager;
    public GameObject UI;
    public new string name;
    bool FR;

    void Start()
    {
        manager.SetActive(false);
        player.SetActive(false);
        UI.SetActive(false);
    }

    void PlayerOff()
    {
        player.SetActive(false);
    }

    void Update()
    {
        FR = FindObjectOfType<SettingsManager>().FR;

        if (Input.GetKeyDown(KeyCode.X))
            Delete();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.03f, Screen.height * 0.97f, 200f, 200f), FR ? "[X] Passer cinématique" : "[X] Pass kinematic");
    }

    void Delete()
    {
        if (name == "Intro")
        {
            manager.SetActive(true);
            UI.SetActive(true);
        }

        player.SetActive(true);
        Destroy(gameObject);
	}
}
