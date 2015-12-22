using UnityEngine;
using System.Collections;

public class ActivadorBlabla : MonoBehaviour {

	public GameObject particulasblabla;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	//Es una funcion para que cuando entre un objeto con el tag GordoFisica en el trigger del psicologo, empiece a generar particulas.
	void OnTriggerEnter2D(Collider2D objeto)
	{
		if (objeto.transform.tag == "GordoFisica")
		{

			Instantiate(particulasblabla, transform.position, transform.rotation);

		}
	}
	
	//Funcion para que cuando salga pare de generar particulas.
	void OnTriggerExit2D(Collider2D objeto) 
	{
		if (objeto.transform.tag == "GordoFisica" )
		{
			
		}
	}
}
