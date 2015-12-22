using UnityEngine;
using System.Collections;

public class colaScale : MonoBehaviour {


	//Definimos la variable de la escala que queremos imitar
	public Transform Player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Player.localScale;
	}
}
