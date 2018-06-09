using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardboard : MonoBehaviour
{
    public bool opened = false;
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        anim.SetBool("open", true);
        opened = true;
    }

    public bool CanOpen()
    {
        return !opened && FindObjectOfType<Inventory>().CheckForObject("Knife");
    }
}
