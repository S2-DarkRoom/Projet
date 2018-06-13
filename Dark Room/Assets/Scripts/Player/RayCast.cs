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
                message = FR ? "[E] Ramasser" : "[E] Pick Up";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Pickups item = hit.collider.GetComponent<Pickups>();
                    if (item.name == "Flashlight")
                    {
                        FindObjectOfType<AudioManager>().Play("Flashlight");
                        flashlight.GetComponent<Flashlight>().Enabled();
                    }

                    else if (item.name.Substring(0, 3) == "Doo" || item.name == "Chest" || item.name.Substring(0, 3) == "Key")
                        FindObjectOfType<AudioManager>().Play("Key");

                    else if (item.name == "Crowbar")
                        FindObjectOfType<AudioManager>().Play("Crowbar");

                    else if (item.name == "Battery")
                    {
                        FindObjectOfType<AudioManager>().Play("Battery");
                        FindObjectOfType<Flashlight>().AddBattery();
                    }

                    else if (item.name == "Hammer")
                        FindObjectOfType<AudioManager>().Play("Hammer");

                    else if (item.name == "Knife")
                        FindObjectOfType<AudioManager>().Play("Knife");

                    else if (item.name == "Sheet" || item.name == "Bone" || item.name == "Rib")
                    {
                        switch (item.name)
                        {
                            case ("Sheet"):
                                FindObjectOfType<AudioManager>().Play("Paper");
                                break;
                            case ("Bone"):
                            case ("Rib"):
                                FindObjectOfType<AudioManager>().Play("Flashlight");
                                break;
                        }

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
                switch (hit.collider.GetComponent<Interactible>().name)
                {
                    case ("Levier"):
                    case ("BreakerButton"):
                        message = FR ? "[E] Activer" : "[E] Activate";
                        break;
                    case ("Door3"):
                        message = (!hit.collider.GetComponent<ChooseKeyUI>().opened && !hit.collider.GetComponent<ChooseKeyUI>().on) ? FR ? "[E] Ouvrir" : "[E] Open" : "";
                        break;
                    case ("GlassEmpty"):
                        message = hit.collider.GetComponent<Glass>().CanPour() ? FR ? "Verser l'eau" : "Pour the water" : "";
                        break;
                    case ("Glass"):
                        message = FR ? "Prendre" : "Take";
                        break;
                    case ("Cardboard"):
                        message = hit.collider.GetComponentInParent<Cardboard>().CanOpen() ? FR ? "[E] Ouvrir" : "[E] Open" : "";
                        break;
                    case ("Fire"):
                        message = FindObjectOfType<Glass>().onyou ? FR ? "[E] Eteindre" : "[E] Estinguish" : "";
                        break;
                    case ("Fridge"):
                        message = !hit.collider.GetComponentInParent<Fridge>().opened ? FR ? "[E] Ouvrir" : "[E] Open" : "";
                        break;
                    case ("Seat"):
                        message = FR ? "[E] S'asseoir" : "[E] Sit";
                        break;
                    case ("Screen"):
                        message = !hit.collider.GetComponentInParent<TV>().pushed ? FR ? "[E] Appuyer" : "[E] Press" : "";
                        break;
                    case ("Mirror"):
                        message = hit.collider.GetComponentInParent<BreakMirror>().Check(false) ? FR ? "[E] Casser" : "[E] Break" : "";
                        break;
                    case ("ElevatorControls"):
                        message = !hit.collider.GetComponentInParent<ElevatorControls>().low ? FR ? "[E] Baisser" : "[E] Lower" : "";
                        break;
                    case ("Cabinet"):
                        message = !hit.collider.GetComponentInParent<Cabinet>().opened ? FR ? "[E] Ouvrir" : "[E] Open" : "";
                        break;
                    case ("BreakerDoor"):
                        message = hit.collider.GetComponentInParent<Breaker>().CanOpen() ? FR ? "[E] Forcer l'ouverture" : "[E] Force opening" : "";
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
                        case ("Glass"):
                            if (!hit.collider.GetComponent<Glass>().onyou)
                                hit.collider.GetComponent<Glass>().Take();
                            break;
                        case ("GlassEmpty"):
                            if (hit.collider.GetComponent<Glass>().CanPour())
                                 hit.collider.GetComponent<Glass>().PourMe();
                            break;
                        case ("Fridge"):
                            hit.collider.GetComponentInParent<Fridge>().Open();
                            break;
                        case ("Seat"):
                            FindObjectOfType<TV>().Sit();
                            break;
                        case ("Door3"):
                            hit.collider.GetComponent<ChooseKeyUI>().Activate();
                            break;
                        case ("Fire"):
                            FindObjectOfType<Glass>().FireDown();
                            break;
                        case ("Cardboard"):
                            if (hit.collider.GetComponentInParent<Cardboard>().CanOpen())
                                hit.collider.GetComponentInParent<Cardboard>().Open();
                            break;
                        case ("Screen"):
                            hit.collider.GetComponentInParent<TV>().Push();
                            break;
                        case ("Cabinet"):
                            hit.collider.GetComponentInParent<Cabinet>().TryOpen();
                            break;
                        case ("Mirror"):
                            hit.collider.GetComponentInParent<BreakMirror>().Check(true);
                            break;
                        case ("BreakerDoor"):
                            if (hit.collider.GetComponentInParent<Breaker>().CanOpen())
                                hit.collider.GetComponentInParent<Breaker>().Activated();
                            break;
                        case ("BreakerButton"):
                            hit.collider.GetComponentInParent<Breaker>().ButtonPressed();
                            break;
                        case ("ElevatorControls"):
                            hit.collider.GetComponentInParent<ElevatorControls>().Activated();
                            break;
                        default:
                            break;
                    }
                }

                else if (Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    if (hit.collider.GetComponent<Interactible>().name == "Door3")
                        hit.collider.GetComponent<ChooseKeyUI>().Success();
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
                        if (door.name.Substring(0, 4) == "Door" || door.name == "Cabinet")
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
