using UnityEngine;
using System.Collections;

public class arbol_jardinero : MonoBehaviour {

	scriptJardinero jardinero;
	scriptGimnasta gimnasta;

	Animator animArbol;

	public bool arbol_crecido = false;
	public bool arbol_gimnasta = false;

	public GameObject rama;
	SpriteRenderer rama_renderer;

	// Use this for initialization

	void Start () {
		animArbol = GetComponent<Animator>();
		rama_renderer = rama.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (arbol_crecido) {

		}

	}

	void OnTriggerStay2D(Collider2D objeto){

		if (objeto.transform.tag == "Jardinero") {
			jardinero = objeto.GetComponent<scriptJardinero>();
			jardinero.regando();
			Invoke ("arbol_creciendo", 8);
			//animArbol.SetBool("creciendo", true);
		}

		if (objeto.transform.tag == "Gimnasta" && arbol_crecido) {
			gimnasta = objeto.GetComponent<scriptGimnasta>();
			gimnasta.haciendoPirueta();
//			animArbol.SetBool("moviendose", true);
		}


	}
	

	public void arbol_creciendo(){
		animArbol.SetBool("creciendo", true);
		arbol_crecido = true;
	}

	public void superponer_rama(){
		rama_renderer.enabled = true;
	}

}
