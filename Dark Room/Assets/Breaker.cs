using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Activated()
    {
        anim.SetBool("open", true);
        Debug.Log("opening");
    }
}
