﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    public float distance;
    RaycastHit hit;
    float displayTime = 2;
    bool displayMessage = false;
    string message = "";
    bool lockedMessage = false;

    void Update ()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distance, Color.magenta);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance))
        {
            if (hit.collider.tag == "pickup")
            {
                displayMessage = true;
                message = "[E] Ramasser";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Pickups item = hit.collider.GetComponent<Pickups>();
                    Inventory.instance.Add(item);
                    displayMessage = false;
                    Destroy(hit.collider.gameObject);
                }
            }

            else if (hit.collider.tag == "doors")
            {
                Doors door = hit.collider.GetComponent<Doors>();

                if (lockedMessage)
                {
                    displayTime -= Time.deltaTime;

                    if (displayTime <= 0.0)
                    {
                        lockedMessage = false;
                        displayMessage = false;
                        displayTime = 2;
                    }
                }

                else if (door.open == false)
                {
                    displayMessage = true;
                    message = "[E] Ouvrir";

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (door.TryOpen() == false)
                        {
                            displayMessage = true;
                            message = "Locked";
                            lockedMessage = true;
                        }

                        else
                        {
                            door.open = true;
                            displayMessage = false;
                        }
                    }
                }
            }
            
            else
            {
                displayMessage = false;
                lockedMessage = false;
            }
            
        }
    }

    void OnGUI()
    {
        if (displayMessage)
        {
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 50, 200f, 200f), message);
        }
    }
}
