using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Sprite loading;
    public Image background;
    public GameObject menu;

    public void Play()
    {
        Cursor.visible = false;
        //background.color = Color.white;
        menu.SetActive(false);
        background.sprite = loading;
        
        SceneManager.LoadScene("Game");
    }

	public void PlayMulti()
	{
        menu.SetActive(false);
        background.sprite = loading;
        Cursor.visible = false;

        SceneManager.LoadScene("Multi");
	}

	public void PlayExplorer()
	{
        menu.SetActive(false);
        background.sprite = loading;
        background.color = Color.white;
        Cursor.visible = false;


        SceneManager.LoadScene("Game 1");
	}

    public void Exit()
    {
        Application.Quit();
    }

    public void exitOptions()
    {
        SceneManager.LoadScene("Menu");
    }
}


