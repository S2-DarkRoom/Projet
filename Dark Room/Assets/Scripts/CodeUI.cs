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
                this.enabled = false;
            }

            else
            {
                return;
            }
        }

        if ()
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            Debug.Log("Entered a digit");

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
