﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseKeyUI : MonoBehaviour
{
    public Sprite backFR, backEN;
    public Image back;
    public GameObject UI;
    private bool FR, n, red, blue;
    private bool zero = false, one = false, two = false;
    public bool on;
    public GameObject panelGauche, panelDroite;
    public GameObject choose1, choose2;
    private string choice = "";
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            on = false;
            UI.SetActive(false);

            if (choice == "B")
                Success();

            else if (choice == "R")
                Fail();
        }


        else if (on && two)
        {
            choose2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                panelGauche.SetActive(true);
                panelDroite.SetActive(false);
                choice = "B";
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                panelGauche.SetActive(false);
                panelDroite.SetActive(true);
                choice = "R";
            }
        }
    }

    public void Activate()
    {
        red = FindObjectOfType<Inventory>().CheckForObject("KeyRed");
        blue = FindObjectOfType<Inventory>().CheckForObject("KeyBlue");
        if (red && blue)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = false;
            on = true;
            UI.SetActive(true);
            two = true;
        }
            
        else if (red)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = false;
            on = true;
            UI.SetActive(true);
            one = true;
            choice = "R";
            choose1.SetActive(true);
        }

        else if (blue)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = false;
            on = true;
            UI.SetActive(true);
            one = true;
            choice = "B";
            choose1.SetActive(true);
        }
            
        else
        {
            zero = true;
        } 
    }

    public void ChangeLang()
    {
        back.sprite = FR ? backFR : backEN;
    }

    public void Success()
    {
        anim.SetBool("open", true);
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponentInChildren<FirstPerson>().enabled = true;
        on = false;
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

        if (zero)
        {
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2, 200f, 200f), FR ? "Verrouillée" : "Locked");
        }
    }
}
