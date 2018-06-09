using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public List<Tutorial> tutos = new List<Tutorial>();
    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TutorialManager>();
            if (instance == null)
                Debug.Log("No TutorialManager");
            return instance;
        }
    }
    private Tutorial currentTuto;

    //Gestion de l'UI
    public Sprite[] listTutoInstructionsFR = new Sprite[4];
    public Sprite[] listTutoInstructionsEN = new Sprite[4];

    public Sprite firstFR;
    public Sprite firstEN;
    public Sprite lastFR;
    public Sprite lastEN;
    public Sprite goodEN;
    public Sprite goodFR;

    public GameObject manager;
    public GameObject UI;
    public Image instructions;
    bool showText = true;
    bool FR;
    bool completed = false;
    

	void Start ()
    {
        FR = FindObjectOfType<SettingsManager>().FR;
        instructions.sprite = FR ? firstFR : firstEN;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            UI.SetActive(false);
            manager.SetActive(false);
        }

        if ((instructions.sprite == firstFR || instructions.sprite == firstEN) && Input.GetKeyDown(KeyCode.X))
        {
            showText = false;
            SetNextTutorial(1);
        }

        if ((instructions.sprite == lastFR || instructions.sprite == lastEN) && Input.GetKeyDown(KeyCode.X))
        {
            showText = false;
            UI.SetActive(false);
            manager.SetActive(false);
        }

        if (currentTuto)
            currentTuto.CheckIfHappening();
    }

    public void CompletedTutorial()
    {
        SetNextTutorial(currentTuto.order + 1);
    }

    public void SetNextTutorial(int currentOrder)
    {
        currentTuto = GetTutorialByOrder(currentOrder);
        if (!currentTuto)
        {
            CompletedAllTutorials();
            return;
        }

        instructions.sprite = FR ? currentTuto.spriteFR : currentTuto.spriteEN;
        if (currentTuto.GetComponent<PickupTutorial>() != null)
            currentTuto.GetComponent<PickupTutorial>().ActivateParticle();
    }

    public void CompletedAllTutorials()
    {
        instructions.sprite = FR? lastFR : lastEN;
        completed = true;
    }

    public Tutorial GetTutorialByOrder(int order)
    {
        for (int i = 0; i < tutos.Count; i++)
        {
            if (tutos[i].order == order)
                return tutos[i];
        }

        return null;
    }

    void OnGUI()
    {
        if (instructions.sprite == lastFR || instructions.sprite == lastEN)
            GUI.Label(new Rect(Screen.height * 0.05f, Screen.width * 0.1f, 200f, 200f), FR? "[X] Quitter" : "[X] Exit");
            

        if (!completed && (showText || currentTuto.order % 2 == 0))
            GUI.Label(new Rect(Screen.height * 0.05f, Screen.width * 0.1f, 200f, 200f), FR? "[X] Suivant" : "[X] Next");
    }
}
