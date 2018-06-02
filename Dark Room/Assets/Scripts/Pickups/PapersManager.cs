using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PapersManager : MonoBehaviour
{
    bool FR;

    public void Show(Paper paper)
    {
        GetComponentInChildren<Image>().sprite = paper.sprite;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = false;
    }

    public void Update()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
            GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = true;
            gameObject.SetActive(false);
        }
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 0.95f, 200f, 200f), FR? "[X] Fermer" : "[X] Close");
    }
}
