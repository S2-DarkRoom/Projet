using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class InventorySlot_multi : NetworkBehaviour {

    public Image icon;
    Pickups item;

    public void AddItem(Pickups newitem)
    {
        item = newitem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }
}
