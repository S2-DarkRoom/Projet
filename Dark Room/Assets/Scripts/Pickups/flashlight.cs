using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    private bool Ison;
    public GameObject lightobj;

    private bool lightInHand = false;
    private float time;
    public bool FR;

    /*
    private float maxnrj;
    private float currentnrj;
    private float usednrj;
    private int batteries = 1;
    private GameObject batteryPickedUp;
    */

    //InventorySlot[] slots;

    void Start ()
    {
        time = 30f;
        gameObject.SetActive(false);
        lightobj.SetActive(false);

        /*
        maxnrj = 50 * batteries;
        currentnrj = maxnrj;
        this.gameObject.SetActive(false);
        lightobj.SetActive(false);
        */
    }

    public void Enabled()
    {
        Debug.Log("yea");
        gameObject.SetActive(true);
        enabled = true;
        lightInHand = true;
    }

    void Update()
    {
        FR = FR = FindObjectOfType<SettingsManager>().FR;
        /*
        maxnrj = 50 * batteries;
        currentnrj = maxnrj;
        */

        if (lightInHand)
        {
            if (Input.GetKeyDown("f"))
            {
                FindObjectOfType<AudioManager>().Play("On");
                Ison = !Ison;
            }

            if (Ison)
            {
                time -= Time.deltaTime;

                lightobj.SetActive(true);

                if (time <= 0)
                {
                    Ison = !Ison;
                    time = 0;
                }

                /*
                if (currentnrj > 0)
                {
                    lightobj.SetActive(true);
                    currentnrj -= 0.5f * Time.deltaTime;
                    usednrj += 10f * Time.deltaTime;
                }
                */

                /*
                if (usednrj > 50)
                {
                    batteries -= 1;
                    usednrj = 0;
                }
                */
            }

            else
                lightobj.SetActive(false);
        }
    }


    public void AddBattery()
    {
        time += 30f;
    }

    public void OnGUI()
    {
        GUI.color = new Color(1, 0.5f, 0.5f) ;
        GUI.Button(new Rect(Screen.width * 0.90f, Screen.height * 0.95f, 100, 20), FR? time.ToString("0") + "s restantes" : time.ToString("0") + "s left");
    }
}
