using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUI : MonoBehaviour {

    public GameObject UI;
    public string code;
    string entered = "";
    int curr;
    public Transform digitsParent;

    DigitSlot[] slots;

    private void Start()
    {
        UI.SetActive(false);
        slots = digitsParent.GetComponentsInChildren<DigitSlot>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Tried quit code");
            UI.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown("enter"))
        {
            if (entered == code)
            {
                UI.SetActive(false);
                GetComponent<Chest>().DeleteCollider();
                GetComponent<Doors>().open = true;
            }

            else
            {
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            Debug.Log("Entered a digit");

            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                entered += "0";
                curr = 0;
            }

            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Entered 1");
                entered += "1";
                curr = 1;
            }

            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                entered += "2";
                curr = 2;
            }

            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                entered += "3";
                curr = 3;
            }

            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                entered += "4";
                curr = 4;
            }

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                entered += "5";
                curr = 5;
            }

            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                entered += "6";
                curr = 6;
            }

            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                entered += "7";
                curr = 7;
            }

            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                entered += "8";
                curr = 8;
            }

            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                entered += "9";
                curr = 9;
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if (i < entered.Length)
                {
                    slots[i].AddDigit(curr);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
        {

        }
    }

    public void Called()
    {
        Debug.Log("Called");
        UI.SetActive(true);
    }
}
