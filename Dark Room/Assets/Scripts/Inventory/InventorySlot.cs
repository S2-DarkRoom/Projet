using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    Pickups item;

    public void AddItem(Pickups newitem)
    {
        item = newitem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }
}
