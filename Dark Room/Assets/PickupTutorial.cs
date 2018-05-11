using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTutorial : Tutorial
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;
    
    public void Start()
    {
        inventory = Inventory.instance;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    public override void CheckIfHappening()
    {
        if (inventory.CheckForObject("Flashlight"))
                TutorialManager.Instance.CompletedTutorial();
    }
}
