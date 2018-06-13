﻿using System.Collections;
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
        FindObjectOfType<AudioManager>().
    }

    public void GoDown()
    {
        anim.SetBool("down", true);
    }
}
