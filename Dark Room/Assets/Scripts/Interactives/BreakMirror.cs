using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMirror : MonoBehaviour
{
    public GameObject brokenMirror;
    public GameObject intactMirror;
    public float magnitude;
    public float radius;
    public float power;
    public float upwards;
    public float time = 3f;
    Collider[] colliders;

    public bool broken = false;

    public void Update()
    {
        if (broken)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                Destroy(brokenMirror);
            }
        }
    }

    public bool Check(bool br)
    {
        if (!broken && br && FindObjectOfType<Inventory>().CheckForObject("Hammer"))
            Break();

        return !broken && FindObjectOfType<Inventory>().CheckForObject("Hammer");
    }

    public void Break()
    {
        broken = true;
        FindObjectOfType<AudioManager>().Play("Mirror");
        Destroy(intactMirror);
        brokenMirror.SetActive(true);
        Vector3 explPos = transform.position;
        colliders = Physics.OverlapSphere(explPos, radius);

        foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<Rigidbody>())
                hit.GetComponent<Rigidbody>().AddExplosionForce(power, explPos, radius, upwards);
        }
    }

}
