using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public BoxCollider monColliderAsupprimer;
    public GameObject UICode;

    public void DeleteCollider()
    {
        Debug.Log("Del");
        monColliderAsupprimer.enabled = false;
        FindObjectOfType<AudioManager>().Play("Chest");
    }
}
