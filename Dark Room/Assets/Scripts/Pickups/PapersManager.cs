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
        sheet.sprite = paper.sprite;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            FindObjectOfType<AudioManager>().Play("Paper");
            gameObject.SetActive(false);
        }  
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height * 0.9f, 200f, 200f), FR? "[X] Fermer": "[X] Close");
    }
}