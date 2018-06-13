using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animator anim;
    public GameObject elevator;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Activate()
    {
        anim.SetBool("open", true);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        anim.SetBool("open", false);
        FindObjectOfType<AudioManager>().Play("CloseElevator");
    }

    public void GoDown()
    {
        FindObjectOfType<AudioManager>().Stop("R2");
        FindObjectOfType<AudioManager>().Stop("R3");
        FindObjectOfType<AudioManager>().Play("Last");

        anim.SetBool("down", true);
        FindObjectOfType<AudioManager>().Play("DownElevator");
    }
}
