using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int order;
    public Sprite sprite;

    void Awake()
    {
        TutorialManager.Instance.tutos.Add(this);
    }

    public virtual void CheckIfHappening() { }
}
