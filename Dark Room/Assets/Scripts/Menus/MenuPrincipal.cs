using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

	public void PlayMulti()
	{
		SceneManager.LoadScene("Multi");
	}

	public void PlayExplorer()
	{
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


