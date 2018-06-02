using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTutorial : Tutorial
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;
    public string obj;
    public GameObject particle;
    
    public void Start()
    {
        inventory = Inventory.instance;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void ActivateParticle()
    {
        particle.SetActive(true);
    }

    public override void CheckIfHappening()
    {
        if (inventory.CheckForObject(obj))
                TutorialManager.Instance.CompletedTutorial();
    }
}
