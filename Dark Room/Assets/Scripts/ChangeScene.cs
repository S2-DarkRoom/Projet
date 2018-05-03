using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    /*
	void Start ()
    {
        
        Scene sc = SceneManager.GetActiveScene();

        if (sc.name == "TitleGame")
        {
            StartCoroutine(Wait());
            SceneManager.LoadScene("TitleCredit");
        }
            
        else if (sc.name == "TitleCredit")
        {
            StartCoroutine(Wait());
            SceneManager.LoadScene("Menu");
        }
            
        else if (sc.name == "Menu")
            SceneManager.LoadScene("Game");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(20);
    }
    */
    
	void Update () 
	{
        Scene sc = SceneManager.GetActiveScene();

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
            if (sc.name == "TitleGame")
                SceneManager.LoadScene("TitleCredit");
            else if (sc.name == "TitleCredit")
                    SceneManager.LoadScene("Menu");
            else if (sc.name == "Menu")
                SceneManager.LoadScene("Game");
        }
	}
    


}
