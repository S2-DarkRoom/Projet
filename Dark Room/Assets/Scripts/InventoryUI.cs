using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;

    InventorySlot[] slots;
	void Start ()
    {
        inventory = Inventory.instance;
        UpdateUI();

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
