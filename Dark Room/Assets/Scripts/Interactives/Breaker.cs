using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    Animator anim;
    Animator animButton;
    public GameObject button;
    public bool opened = false;
    public bool pressed = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
        animButton = button.GetComponent<Animator>();
    }

    public bool CanOpen()
    {
        return !opened && FindObjectOfType<Inventory>().CheckForObject("Crowbar");
    }

    public void Activated()
    {
        opened = true;
        anim.SetBool("open", true);
    }

    public void ButtonPressed()
    {
        pressed = true;
        animButton.SetBool("pressed", true);
    }
}
