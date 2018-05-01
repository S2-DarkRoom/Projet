using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour {

    private bool Ison;
    public GameObject lightobj;

    public float maxnrj;
    private float currentnrj;
    private float usednrj;

    private int batteries = 3;
    private GameObject batteryPickedUp;

	// Use this for initialization
	void Start () {
        maxnrj = 10 * batteries;
        currentnrj = maxnrj;
	}
	
	// Update is called once per frame
	void Update () {
        maxnrj = 10 * batteries;
        currentnrj = maxnrj;

        if (Input.GetKeyDown("f"))
            Ison = !Ison;

        if (Ison)
        {
            lightobj.SetActive(true);

            if (currentnrj <= 0)
            {
                lightobj.SetActive(false);
                batteries = 0;
            }
            if (currentnrj > 0)
            {
                lightobj.SetActive(true);
                currentnrj -= 0.5f * Time.deltaTime;
                usednrj += 10f * Time.deltaTime;
            }

            if (usednrj > 50)
            {
                batteries -= 1;
                usednrj = 0;
            }
        }
        else
            lightobj.SetActive(false);

        /* pour la batterie
         * public void OnTriggerEnter(Collider other)
         * {
         *      if (other.tag = "Battery")
         *      {
         *          batteryPickedUp = other.gameObjetc;.
         *          batteries++;
         *          Destroy(batteryPickedUp);
         *      }
         * }
         * */


    }
}
