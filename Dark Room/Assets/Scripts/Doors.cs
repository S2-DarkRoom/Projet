﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

    new public string name = "New Item";
    public bool open = false;
    public bool locked = true;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Close()
    {
        _animator.SetBool("open", false);
    }

    public bool TryOpen()
    {
        if (locked == true)
        {
            for (int i = 0; i < Inventory.items.Count; i++)
            {
                if (Inventory.items[i].name == this.name)
                {
                    _animator.SetBool("open", true);
                    if (name != "Interactible")
                        FindObjectOfType<AudioManager> ().Play ("Porte");
                    return true;
                }
            } 
            return false;
        }

        _animator.SetBool("open", true);
        if (name != "Interactible")
		    FindObjectOfType<AudioManager> ().Play ("Porte");
        return true;
    }
}
