﻿using System.Collections;
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
    public Sprite[] listTutoInstructions = new Sprite[5];
    public Sprite first;
    public Sprite last;
    public Sprite bien;
    public GameObject manager;
    public GameObject UI;
    public Image instructions;
    

	void Start ()
    {
        instructions.sprite = first;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.SetActive(false);
            manager.SetActive(false);
        }

        if (instructions.sprite == first && Input.GetKeyDown(KeyCode.Space))
            SetNextTutorial(1);

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

        instructions.sprite = currentTuto.sprite;
    }

    public void CompletedAllTutorials()
    {
        instructions.sprite = last;
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
}
