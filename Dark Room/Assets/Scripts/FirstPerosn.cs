using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerosn : MonoBehaviour {

    Vector2 mouse; /* créer un nouveau vecteur en dim 2 */ 
    Vector2 smooth;
    public float sensitivity; /* créer un floatant, une constante */ 
    public float smoothing;

    GameObject character; /*créer un objet "personnage", une entité dans les scenes */ 

	void Start () /* début, statut de base */
    {
        character = this.transform.parent.gameObject; /* Transform: permet de toucher a la postion, la rotation et l'echelle du gameObject, celui ci est toujours lié au Transform.
                                                         Le parent permet de créer une hierarchie */ 
	}
	
	void Update () /* "rafraichissement" apres chaque mouvement */ 
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing)); /* scale: multiplie les deux composents des deux vecteurs */ 

        smooth.x = Mathf.Lerp(smooth.x, md.x, 1f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, md.y, 1f / smoothing);
        mouse += smooth;

        transform.localRotation = Quaternion.AngleAxis(-mouse.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouse.x, character.transform.up);
    }

}
