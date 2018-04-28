using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCamera : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            Delete();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.01f, Screen.height * 0.99f, 200f, 200f), "[X] Pass cinematique");
    }

    void Delete ()
    {
        player.SetActive(true);
        Destroy(gameObject);
	}
}
