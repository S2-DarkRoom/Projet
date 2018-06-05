using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControls : MonoBehaviour
{
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Activated()
    {
        anim.SetBool("low", true);
        GetComponentInParent<Elevator>().GoDown();
    }
}
