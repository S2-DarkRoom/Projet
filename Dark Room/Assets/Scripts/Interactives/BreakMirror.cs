using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMirror : MonoBehaviour
{
    public Transform brokenMirror;
    public GameObject intactMirror;
    public float magnitude;
    public float radius;
    public float power;
    public float upwards;

    public bool broken = false;

    public bool Check(bool br)
    {
        if (!broken && br && FindObjectOfType<Inventory>().CheckForObject("Hammer"))
            Break();

        //return FindObjectOfType<Inventory>().CheckForObject("Hammer");
        return !broken;
    }

    public void Break()
    {
        broken = true;
        Destroy(intactMirror);
        Instantiate(brokenMirror, transform.position, transform.rotation);
        brokenMirror.localScale = transform.localScale;
        Vector3 explPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explPos, radius);

        foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<Rigidbody>())
                hit.GetComponent<Rigidbody>().AddExplosionForce(power, explPos, radius, upwards);
        }
    }

}
