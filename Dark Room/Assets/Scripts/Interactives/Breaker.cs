using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    Animator anim;
    Animator animButton;
    public GameObject button;

    public void Start()
    {
        anim = GetComponent<Animator>();
        animButton = button.GetComponent<Animator>();
    }

    public void Activated()
    {
        anim.SetBool("open", true);
        Debug.Log("opening");
    }

    public void ButtonPressed()
    {
        animButton.SetBool("pressed", true);
    }
}
