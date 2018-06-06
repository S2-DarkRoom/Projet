using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLanguage : MonoBehaviour
{
    public Image enterCode;
    public Image wrongCode;
    public Sprite enterFR;
    public Sprite enterEN;
    public Sprite wrongFR;
    public Sprite wrongEN;
    bool FR, n;

    public void Start()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
    }

    public void Update()
    {
        n = FindObjectOfType<SettingsManager>().FR;

        if (n != FR)
        {
            FR = n;
            enterCode.sprite = n ? enterFR : enterEN;
            wrongCode.sprite = n ? wrongFR : wrongEN;
        }
    }
}
