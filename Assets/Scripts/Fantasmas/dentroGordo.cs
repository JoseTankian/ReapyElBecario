using UnityEngine;
using System.Collections;

public class dentroGordo : MonoBehaviour {

	scriptGordo g;
	// Use this for initialization
	void Start () 
	{
		g=GetComponentInParent<scriptGordo>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerStay2D(Collider2D objeto)
	{
		if(objeto.tag== "Player")
		{
			g.SetDentro(true);

		}

		if (objeto.tag == "Psicologo") {

				g.gordorayado = true;

		}
		
	}

	void OnTriggerExit2D(Collider2D objeto)
	{
		if(objeto.tag== "Player")
		{
			g.SetDentro(false);
		}

		if (objeto.tag == "Psicologo") {
			g.gordorayado = false;
		}
		
	}
}
