using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Image back, oui, non;
    public Sprite ouiFR, nonFR, backFR, ouiEN, nonEN, backEN;
    public GameObject Poui, Pnon;
    private bool again = true;
    private bool FR, n;

    public void Start()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        n = FR;
    }

    public void Update()
    {
        FR = FindObjectOfType<SettingsManager>().FR;

        if (n != FR)
            ChangeLanguage();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Poui.SetActive(true);
            Pnon.SetActive(false);
            again = true;
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Poui.SetActive(false);
            Pnon.SetActive(true);
            again = false;
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (again)
                SceneManager.LoadScene("Game");
            else
                SceneManager.LoadScene("Menu");
        }
    }

    public void ChangeLanguage()
    {
        n = FR;
        if (FR)
        {
            back.sprite = backFR;
            oui.sprite = ouiFR;
            non.sprite = nonFR;
        }

        else
        {
            back.sprite = backEN;
            oui.sprite = ouiEN;
            non.sprite = nonEN;
        }
    }
}
