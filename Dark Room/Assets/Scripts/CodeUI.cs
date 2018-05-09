using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeUI : MonoBehaviour {

    public GameObject UI;
    public string code;
    string entered = "";

    private void Start()
    {
        UI.SetActive(false);
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
    }

    public void Called()
    {
        Debug.Log("Called");
        UI.SetActive(true);
    }
}
