﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerosn : MonoBehaviour {

    Vector2 mouse;
    Vector2 smooth;
    public float sensitivity;
    public float smoothing;

    GameObject character;

	void Start ()
    {
        character = this.transform.parent.gameObject;
	}
	
	void Update ()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smooth.x = Mathf.Lerp(smooth.x, md.x, 1f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, md.y, 1f / smoothing);
        mouse += smooth;

        transform.localRotation = Quaternion.AngleAxis(-mouse.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouse.x, character.transform.up);
    }

}
