using UnityEngine;
using System.Collections;

public class LuzFija : MonoBehaviour {

	//Establecemos que la variable positionZ sea -1
	public float positionZ = -1;
	//Nomramos un gameobject como target, para luego en Unity seleccionar el target al que queremos aplicarlo.
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Cada frame cambiamos la posicion del objeto que hemos referenciado en el target, la x y la y la que tiene, y la z, llamamos al valor posicionZ
		//Que es -1. Esto lo hacemos porque nuestro personaje tiene una luz, y esta luz al hacer un flip el personaje de izquierda a derecha, nos cambia
		//La posicion del eje Z y perdemos la luz. Esto es un parche para corregirlo.
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, positionZ);
	}
}
