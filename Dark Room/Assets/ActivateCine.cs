using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCine : MonoBehaviour
{
    public GameObject cam2;
    bool entered = false;

    private void Start()
    {
        cam2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!entered)
            cam2.SetActive(true);
        entered = true;
    }
}
