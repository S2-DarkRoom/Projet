using UnityEngine;
using UnityEngine.Networking;

public class InventoryUI_multi : NetworkBehaviour
{

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
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.items.Count)
            {
                slots[i].AddItem(Inventory.items[i]);
            }
        }

    }
}
