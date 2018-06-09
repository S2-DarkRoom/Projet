using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControls : MonoBehaviour
{
    Animator anim;
    public bool low = false;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Activated()
    {
        low = true;
        anim.SetBool("low", true);
        GetComponentInParent<Elevator>().GoDown();
    }
}
