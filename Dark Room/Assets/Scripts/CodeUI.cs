using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUI : MonoBehaviour
{
    public GameObject UI;
    public GameObject UIwrong;
    public GameObject UIenter;
    public string code;
    string entered = "";
    int curr;
    public Transform digitsParent;
    private Animator _animator;
    bool enter = true;
    bool displayMessage = false;

    DigitSlot[] slots;

    private void Start()
    {
        UI.SetActive(false);
        slots = digitsParent.GetComponentsInChildren<DigitSlot>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Quitter l'interface
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.SetActive(false);
            displayMessage = false;
            Reset();
        }

        //Valider le code
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (enter)
            {
                if (entered == code)
                {
                    _animator.SetBool("open", true);
                    displayMessage = false;
                    UI.SetActive(false);
                    GetComponent<Chest>().DeleteCollider();
                    GetComponent<Doors>().open = true;
                    this.enabled = false;
                }

                else
                {
                    enter = false;
                    WrongCode();
                }
            }

            else
            {
                enter = true;
                UIwrong.SetActive(false);
                UIenter.SetActive(true);
                Reset();
            }
        }

        else if (entered.Length != code.Length)
        {
            //Le joueur rentre un nouveau chiffre
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad9))
            { 

                if (Input.GetKeyDown(KeyCode.Keypad0))
                    curr = 0;
                else if (Input.GetKeyDown(KeyCode.Keypad1))
                    curr = 1;
                else if (Input.GetKeyDown(KeyCode.Keypad2))
                    curr = 2;
                else if (Input.GetKeyDown(KeyCode.Keypad3))
                    curr = 3;
                else if (Input.GetKeyDown(KeyCode.Keypad4))
                    curr = 4;
                else if (Input.GetKeyDown(KeyCode.Keypad5))
                    curr = 5;
                else if (Input.GetKeyDown(KeyCode.Keypad6))
                    curr = 6;
                else if (Input.GetKeyDown(KeyCode.Keypad7))
                    curr = 7;
                else if (Input.GetKeyDown(KeyCode.Keypad8))
                    curr = 8;
                else if (Input.GetKeyDown(KeyCode.Keypad9))
                    curr = 9;

                entered += curr;

                slots[entered.Length - 1].AddDigit(curr);
            }
        }
        
        //Le joueur veut supprimer le dernier chiffre
        if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
        {
            //FIXME
        }
    }

    public void WrongCode()
    {
        UIenter.SetActive(false);
        UIwrong.SetActive(true);

        enter = false;
    }

    void OnGUI()
    {
        if (displayMessage)
        {
            string message;

            if (enter)
                message = "[A] Validate";
            else
                message = "[A] Try Again";

            GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 200, 250f, 250f), message);
        }
    }

    void Reset()
    {
        //FIXME
    }

    //Appel du script
    public void Called()
    {
        UI.SetActive(true);
        UIwrong.SetActive(false);
        displayMessage = true;
    }
}
