using UnityEngine;
using System.Collections;

public class menuFinNivel : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		GameControl.fantasmasSalvados = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.fantasmasSalvados >= 4) {
			GameControl.enMenu = true;
			anim.SetBool("fin_juego", true);
			if(Input.GetButtonDown("Submit")){
				Application.LoadLevel("menu_principal");
			}
		}
	}
}
