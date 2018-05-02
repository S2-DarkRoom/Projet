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
                    if (name == "Door1" || name == "Door2" || name == "Door3" || name == "DoorToilet3" || name == "DoorToilet2" || name == "DoorToilet1" || name == "DoorSecret")
                        FindObjectOfType<AudioManager>().Play("Porte");
                    else if (name == "Chest")
                    {
						FindObjectOfType<AudioManager>().Play("Porte");
                        this.GetComponent<Chest>().DeleteCollider();
                    }

                    return true;
                }
            } 
            return false;
        }

        _animator.SetBool("open", true);
        if (name == "Door1" || name == "Door2" || name == "Door3" || name == "DoorToilet3" || name == "DoorToilet2" || name == "DoorToilet1" || name == "DoorSecret")
            FindObjectOfType<AudioManager> ().Play ("Porte");
        return true;
    }
}
