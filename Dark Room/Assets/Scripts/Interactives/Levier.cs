using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    bool ok = false;
    Shower shower;

    public void CheckIfCodeOk()
    {
        shower = FindObjectOfType<Shower>();
        ok = shower.IsCodeOk();
        shower.ResetButton();
    }
}
