﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public BoxCollider monColliderAsupprimer;

    public void DeleteCollider()
    {
        monColliderAsupprimer.enabled = false;
		FindObjectOfType<AudioManager>().Play("Porte");
    }
}
