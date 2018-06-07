using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    public bool opened = false;

    public void TryOpen()
    {
        if (!opened)
            GetComponent<Animator>().SetBool("open", true);

        opened = true;
    }
}
