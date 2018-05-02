using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCode : MonoBehaviour {

    public int codeLock;
    public InputField input;

    public void GetInput(string codeUser)
    {
        input.text = "";
    }
}
