using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Inventory : NetworkBehaviour
{
    #region Singleton
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public static List<Pickups> items = new List<Pickups>();

    public void Add(Pickups item)
    {
        items.Add(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }

}
