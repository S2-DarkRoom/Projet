using UnityEngine;
using unityEngine.Network;

public class PlayerSetup : NetworkBehaviour
{ 
    [SerializeField]
    Behaviour[] componentsToDisable;

    private void Start()
    {
        if (!isPlayerController)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }

        else
        {
            Camera.main.gameObject.SetActive(false);
        }
    }
}
