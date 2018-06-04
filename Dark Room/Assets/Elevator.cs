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
        Debug.Log("Activated");
        anim.SetBool("open", true);
    }

    public void OnTriggerEnter(Collider other)
    {
        anim.SetBool("open", false);
    }
}
