using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public GameObject water, glass;
    public GameObject glassInHand;
    public bool onyou = false;
    public GameObject fire;

    public void Take()
    {
        glassInHand.SetActive(true);
        glass.GetComponent<MeshRenderer>().enabled = false;
        water.GetComponent<MeshRenderer>().enabled = false;
        onyou = true;
    }

    public void PourMe()
    {
        water.SetActive(true);
        GetComponent<Interactible>().name = "Glass";
    }

    public bool CanPour()
    {
        return FindObjectOfType<Inventory>().CheckForObject("Bottle");
    }

    public void FireDown()
    {
        fire.SetActive(false);
        glassInHand.SetActive(false);
    }
}
