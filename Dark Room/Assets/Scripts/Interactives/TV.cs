using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public bool pushed = false;
    public GameObject chair;

    public void Push()
    {
        pushed = true;
        chair.SetActive(true);
    }
}
