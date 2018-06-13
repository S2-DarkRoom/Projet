using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    public List<GameObject> buttons;
    public string victory;
    string result = "";
    Animator anim;


    public void OnButtonPushed(string order)
    {
        result += order;
        anim = buttons[Int32.Parse(order) - 1].GetComponent<Animator>();
        Debug.Log("push");
        anim.SetBool("push", true);
        FindObjectOfType<AudioManager>().Play("Shower");
    }

    public void ResetButton()
    {
        result = "";
    }

    public bool IsCodeOk()
    {
        return result == victory;
    }
}
