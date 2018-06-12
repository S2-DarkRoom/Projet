using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public bool pushed = false;
    public GameObject chair;
    public GameObject cam;

    public void Push()
    {
        pushed = true;
        chair.SetActive(true);
    }

    public void Sit()
    {
        cam.SetActive(true);
    }
}
