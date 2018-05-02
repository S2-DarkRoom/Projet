using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCine : MonoBehaviour
{
    public GameObject cam;
    bool entered = false;

    private void Start()
    {
        cam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!entered)
            cam.SetActive(true);
        entered = true;
    }
}
