using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCinematic : MonoBehaviour
{
    public void Play()
    {
        GetComponent<Animator>().SetBool("play", true);
    }
}
