using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animator anim;

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
    }

    public void GoDown()
    {
        anim.SetBool("down", true);
    }

    public void Arrived()
    {
        anim.SetBool("open", true);
    }
}
