using UnityEngine;
using UnityEngine.Networking;

public class InventoryUI_multi : NetworkBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;

    InventorySlot[] slots;
	void Start ()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI()
    {
       int i = 0, j = 0;

       while (i < slots.Length)
       {
            if (j < Inventory.items.Count)
            {

                if (Inventory.items[j].name == "Battery")
                    i--;
                    

                else
                    slots[i].AddItem(Inventory.items[j]);
            }

            j++;
            i++;
        }

    }
}
