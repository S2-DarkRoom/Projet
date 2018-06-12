using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public bool opened = false;
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        opened = true;
        anim.SetBool("open", true);
    }
}
