using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseKeyUI : MonoBehaviour
{
    public Sprite backFR, backEN;
    public Image back;
    public GameObject UI;
    private bool FR, n;
    public bool on;

    public void Start()
    {
        UI.SetActive(false);
        on = false;
        FR = FindObjectOfType<SettingsManager>().FR;
        n = FR;
    }

    public void Update()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        if (n != FR)
            ChangeLang();
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            on = false;
            UI.SetActive(false);
        }
    }

    public void Activate()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = false;
        on = true;
        UI.SetActive(true);
    }

    public void ChangeLang()
    {
        back.sprite = FR ? backFR : backEN;
    }

    public void Success()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = true;
        on = false;
        GetComponent<Doors>().TryOpen(true);
    }

    public void Fail()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = true;
        on = false;
        FindObjectOfType<Minuteur>().EndGame();
    }

    public void OnGUI()
    {
        if (on)
        {
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height * 0.92f, 200f, 200f), FR ? "[A] Valider" : "[A] Validate");
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height * 0.95f, 200f, 200f), FR ? "[X] Fermer" : "[X] Close");
        }
    }
}
