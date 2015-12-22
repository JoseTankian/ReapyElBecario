using UnityEngine;
using System.Collections;

public class dentroGimnasta : MonoBehaviour {

	scriptGimnasta gim;
	// Use this for initialization
	void Start () 
	{
		gim = GetComponentInParent<scriptGimnasta>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D objeto)
	{
		if(objeto.tag == "Player")
		{
			gim.SetDentro(true);
		}
		
	}
	
	void OnTriggerExit2D(Collider2D objeto)
	{
		if(objeto.tag == "Player")
		{
			gim.SetDentro(false);
		}
		
	}
}
