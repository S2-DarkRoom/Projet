using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float distance;
    RaycastHit hit;

    float displayTime = 2;
    bool displayMessage = false;
    string message = "";
    bool lockedMessage = false;

    public GameObject flashlight;
    bool code = false;
    public GameObject UIcode;
    bool FR;
    public GameObject paper;

    void Update ()
    {
        FR = FindObjectOfType<SettingsManager>().FR; //Get language

        Debug.DrawRay(this.transform.position, this.transform.forward * distance, Color.magenta);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance))
        {
            if (hit.collider.tag == "pickup")
            {
                displayMessage = true;
                message = FR ? "[E] Ramasser": "[E] Pick Up";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Pickups item = hit.collider.GetComponent<Pickups>();
                    if (item.name == "Flashlight")
                    {
                        FindObjectOfType<AudioManager>().Play("Flashlight");
                        flashlight.GetComponent<Flashlight>().Enabled();
                    }

                    else if (item.name.Substring(0, 4) == "Door" || item.name == "Chest")
                        FindObjectOfType<AudioManager>().Play("Key");

                    else if (item.name == "Crowbar")
                        FindObjectOfType<AudioManager>().Play("Crowbar");

                    else if (item.name == "Battery")
                        FindObjectOfType<AudioManager>().Play("Battery");

                    else if (item.name == "Bone")
                        FindObjectOfType<AudioManager>().Play("Flashlight");

                    else if (item.name == "Sheet")
                    {
                        FindObjectOfType<AudioManager>().Play("Paper");
                        paper.SetActive(true);
                        paper.GetComponent<PapersManager>().Show(item.GetComponent<Paper>());
                    }

                    Inventory.instance.Add(item);
                    displayMessage = false;

                    Destroy(hit.collider.gameObject);
                }
            }

            else if (hit.collider.tag == "button")
            {
                displayMessage = true;
                message = FR ? "[E] Appuyer" : "[E] Press";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Hit E");
                    string button = hit.collider.GetComponent<ButtonPush>().order;
                    FindObjectOfType<Shower>().OnButtonPushed(button);
                }
            }

            else if (hit.collider.tag == "interactif")
            {
                displayMessage = true;
                switch(hit.collider.GetComponent<Interactible>().name)
                {
                    case ("Levier"):
                    case("BreakerButton"):
                        message = FR ? "[E] Activer" : "[E] Activate";
                        break;
                    case ("BreakerDoor"):
                        message = FR ? "[E] Forcer l'ouverture" : "[E] Force opening";
                        break;
                    default:
                        message = FR ? "[E] Interagir" : "[E] Interact";
                        break;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (hit.collider.GetComponent<Interactible>().name)
                    {
                        case ("Levier"):
                            hit.collider.GetComponentInParent<Levier>().Activated();
                            break;
                        case ("BreakerDoor"):
                            hit.collider.GetComponentInParent<Breaker>().Activated();
                            break;
                        case ("BreakerButton"):
                            hit.collider.GetComponentInParent<Breaker>().ButtonPressed();
                            break;
                        default:
                            break;
                    }
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

                else if (code)
                {
                    code = false;
                    displayMessage = false;
                    hit.collider.GetComponent<CodeUI>().Called();
                }

                else if (door.open == false)
                {
                    if (UIcode.activeSelf == false)
                        displayMessage = true;

                    message = FR ? "[E] Ouvrir" : "[E] Open";

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        door.TryOpen(true);
                        door.open = true;
                        displayMessage = false;
                    }

                    else if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (door.name.Substring(0, 4) == "Door")
                        {
                            if (door.TryOpen(false) == false)
                            {
                                displayMessage = true;
                                message = FR ? "[E] Verrouillé" : "[E] Locked";
                                lockedMessage = true;
                            }

                            else
                            {
                                door.open = true;
                                displayMessage = false;
                            }
                        }

                        else if (door.name == "Chest")
                        {
                            displayMessage = false;
                            code = true;
                        }
                    }
                }

                /* A UPDATE : POSSIBILITE DE FERMER PORTE */
                else if (name.Substring(0, 4) == "Door")
                {
                    displayMessage = true;
                    message = FR ? "[E] Fermer" : "[E] Close";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        door.Close();
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
