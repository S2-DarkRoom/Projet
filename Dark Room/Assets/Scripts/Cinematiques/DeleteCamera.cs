using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteCamera : MonoBehaviour
{
    public GameObject player, crosshair;
    public new string name;
    bool FR;
    public AudioSource m_MyAudioSource;
    public GameObject subtitles;
    public GameObject door;

    void Start()
    {
        player.SetActive(false);
        crosshair.SetActive(false);

        if (name == "End")
        {
            m_MyAudioSource.Stop();
            FindObjectOfType<AudioManager>().Stop("R2");
            FindObjectOfType<AudioManager>().Stop("R3");
        }

        if (name == "Last")
            door.GetComponent<Transform>().localRotation = Quaternion.Euler(-90f, 0, 0);
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
        GUI.Label(new Rect(Screen.width * 0.03f, Screen.height * 0.97f, 200f, 200f), FR ? "[X] Passer cinématique" : "[X] Skip Cutscene");
    }

    public void LastCam()
    {
        SceneManager.LoadScene("EndCredits");
    }

    void Delete()
    {
        if (name == "Intro")
        {
            m_MyAudioSource.Play(); 
        }

        else if (name == "Room2")
        {
            m_MyAudioSource.Stop();
            FindObjectOfType<AudioManager>().Play("R2");
        }

        else if (name == "Room3")
        {
            m_MyAudioSource.Stop();
            FindObjectOfType<AudioManager>().Stop("R2"); 
            FindObjectOfType<AudioManager>().Play("R3");
        }

        if (name == "Intro")
            subtitles.SetActive(false);

        player.SetActive(true);
        crosshair.SetActive(true);
        Destroy(gameObject);
	}
}
