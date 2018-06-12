using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public bool opened = false;
    public Collider col;

    public void TryOpen()
    {
        if (!opened)
            GetComponent<Animator>().SetBool("open", true);

        opened = true;
    }

    public void Open()
    {
        col.enabled = false;
    }
}
