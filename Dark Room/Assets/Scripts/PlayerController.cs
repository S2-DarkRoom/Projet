using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed; /* créer un attribut vitesse, variable */ 

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked; /* determine si le curseur doit apparaitre, et ou (au centre, a gauche...), ici il est bloqué */ 
	}
	
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed; /* Input permet d'acceder au mode inputManager, ou l'on regle les différent réglage secondaire, comme les touche du mouvement */ 
        float moveVertical = Input.GetAxis("Vertical") * speed;

        moveHorizontal *= Time.deltaTime; /* permet d'exprimé le mouvement en seconde et non en image */ 
        moveVertical *= Time.deltaTime;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); /* créer le vecteur representatn le mouvement */ 

        transform.Translate(movement); /* applique le mouvement */ 

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None; /* si on appui sur espace le curseur disparait */ 
    }
}
