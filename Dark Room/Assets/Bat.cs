using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public GameObject bat;

    public void Launch()
    {
        FindObjectOfType<AudioManager>().Play("Bat");
    }

    public void End()
    {
        Destroy(bat);
    }
}
