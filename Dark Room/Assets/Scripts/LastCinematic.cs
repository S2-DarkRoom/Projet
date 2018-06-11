using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCinematic : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Animator>().SetBool("play", true);
    }

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Outro");
    }
}
