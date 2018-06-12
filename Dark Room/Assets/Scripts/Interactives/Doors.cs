using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

    new public string name = "New Item";
    public bool open = false;
    public bool locked = true;

    private Animator _animator;

    private void Start()
    {
        if (name == "DoorElevator")
            _animator = GetComponentInParent<Animator>();
        else
            _animator = GetComponent<Animator>();
    }

    public void Close()
    {
        _animator.SetBool("open", false);
    }

    public bool TryOpen(bool force)
    {
        if (locked)
        {
            if (force)
            {
                _animator.SetBool("open", true);
                if (name == "DoorElevator")
                    FindObjectOfType<Elevator>().Activate();

                else if (name.Substring(0, 4) == "Door" || name == "Secret") //cas des portes 
                    FindObjectOfType<AudioManager>().Play("Porte");


                return true;
            }

            else
            {
                if (name == "DoorElevator" && FindObjectOfType<Breaker>().pressed)
                {
                    _animator.SetBool("open", true);
                    FindObjectOfType<AudioManager>().Play("Porte");
                    FindObjectOfType<Elevator>().Activate();
                    return true;
                }

                else
                {
                    for (int i = 0; i < Inventory.items.Count; i++)
                    {
                        Debug.Log(Inventory.items[i].name);
                        Debug.Log(this.name);
                        if (Inventory.items[i].name == this.name)
                        {
                            _animator.SetBool("open", true);

                            if (name.Substring(0, 4) == "Door") //cas des portes 
                                FindObjectOfType<AudioManager>().Play("Porte");

                            else if (name == "Cabinet")
                                GetComponent<Cabinet>().Open();

                            return true;
                        }
                    }
                }
            }
            
            return false;
        }

        _animator.SetBool("open", true);
        if (name.Substring(0, 4) == "Door")
            FindObjectOfType<AudioManager> ().Play ("Porte");
        return true;
    }
}
