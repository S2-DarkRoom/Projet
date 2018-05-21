using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    bool ok = false;
    public GameObject trueLED, falseLED;
    public Material[] green;
    public Material[] red;
    public Material[] greenglass;
    public Material[] redglass;
    Shower shower;
    Animator anim;
    bool set = false;
    float time = -100000f;

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

        else if (time > -10000f)
        {
            if (ok)
                Green(false);

            else
                Red(false);

            time = -10000f;
        }
    }
    public void Activated()
    {
        anim = this.GetComponent<Animator>();
        anim.SetBool("active", true);
    }

    public void CheckIfCodeOk()
    {
        anim.SetBool("active", false);
        shower = FindObjectOfType<Shower>();
        ok = shower.IsCodeOk();
        time = 2f;

        if (ok)
            Green(true);
        else
            Red(true);

        shower.ResetButton();
    }

    public void Green(bool light)
    {
        if (light)
            trueLED.GetComponent<Renderer>().materials = green;
        else
            trueLED.GetComponent<Renderer>().materials = greenglass;
    }

    public void Red(bool light)
    {   
        if (light)
            falseLED.GetComponent<Renderer>().materials = red;
        else
            falseLED.GetComponent<Renderer>().materials = redglass;
    }


}
