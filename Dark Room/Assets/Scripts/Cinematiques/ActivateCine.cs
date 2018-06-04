using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCine : MonoBehaviour
{
    public GameObject cam;
    bool entered = false;
    public int number;

    private void Start()
    {
        cam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!entered)
            cam.SetActive(true);
        entered = true;

        /*if (number == 2)
         * Jouer musique chambre 2
         else
            Jouer musique chambre 3
            */
    }
}
