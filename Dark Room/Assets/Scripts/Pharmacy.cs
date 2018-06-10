using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pharmacy : MonoBehaviour
{
    public GameObject bat1, bat2;

    public void Opened()
    {
        bat1.SetActive(true);
        bat2.SetActive(true);
    }
}
