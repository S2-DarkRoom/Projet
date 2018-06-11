using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PapersManager : MonoBehaviour                      
{
    bool FR;
    public Image sheet;

    public void Show(Paper paper)
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        sheet.sprite = FR ? paper.spriteFR : paper.spriteEN;
    }

    public void Update()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        if (Input.GetKeyDown(KeyCode.X))
        {
            FindObjectOfType<AudioManager>().Play("Paper");
            gameObject.SetActive(false);
        }  
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height * 0.95f, 200f, 200f), FR? "[X] Fermer": "[X] Close");
    }
}