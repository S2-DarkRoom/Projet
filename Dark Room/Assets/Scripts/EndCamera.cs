using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCamera : MonoBehaviour
{
    private bool min = false;
    private float time = 2.0f;
    public GameObject UI;

	void Start ()
    {
        min = FindObjectOfType<Minuteur>().end;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;

        if (min)
            FindObjectOfType<AudioManager>().Play("TimeOut");
        else
            FindObjectOfType<AudioManager>().Play("WrongKey");
    }

    public void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
            UI.SetActive(true);
    }
}
