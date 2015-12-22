using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	private Vector3 mousePosition;

	// Velocidad a la que sigue al raton
	public float moveSpeed = 0.1f;
	

	void Update () {
		if (Input.GetMouseButton(1)) {
			//Obtenemos las coordenadas del raton
			mousePosition = Input.mousePosition;
			//transformamos las coordenadas a la posicion respecto a la camara
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			//Movemos el objeto a la posición del raton
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

		}
		
	}
}
