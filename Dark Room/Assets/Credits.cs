using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Button()
    {
        SceneManager.LoadScene("Menu");
    }
}
