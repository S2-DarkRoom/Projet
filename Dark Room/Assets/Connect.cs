using UnityEngine;
using UnityEngine.Networking;

public class Connect : MonoBehaviour
{
    NetworkManager nm;
    bool prev = true;

    void Start()
    {
        nm = gameObject.GetComponent<NetworkManager>();
    }

    void Update()
    {
        if (prev != nm.isNetworkActive)
        {
            prev = nm.isNetworkActive;

            if (prev)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
