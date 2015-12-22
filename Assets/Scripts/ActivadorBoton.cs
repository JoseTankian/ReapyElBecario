using UnityEngine;
using System.Collections;

public class ActivadorBoton : MonoBehaviour 
{
	//Variable booleana que indica que el boton esta desactivado inicialmente
	public bool botonpulsado = false;
	//Se nombra la animacion del boton
	Animator boton;
	// Use this for initialization

	void Start () 
	{
		boton = GetComponent<Animator>(); //Se llama la animacion del boton.
	}
	
	// Update is called once per frame
	void Update () 
	{
				
	}
		
	//Es una funcion para que cuando entre un objeto con el tag GordoFisica en el trigger del boton, active la animacion del boton.
	//Y cambie a estar el boton pulsado
	void OnTriggerStay2D(Collider2D objeto)
	{
		if (objeto.transform.tag == "GordoFisica")
		{
			boton.SetBool("gordo",true);
			botonpulsado  = true;
		//	Debug.Log ("El botonFunciona!!!!!");
		}
	}

	//Es una funcion para que cuando salga un objeto con el tag GordoFisica del trigger del boton, se desactive la animacion,
	//y el boton vuelva a no estar pulsado.
	void OnTriggerExit2D(Collider2D objeto) 
	{
		if (objeto.transform.tag == "GordoFisica" )
		{
			boton.SetBool("gordo",false);
			botonpulsado  = false;
		}
	}
	
}
