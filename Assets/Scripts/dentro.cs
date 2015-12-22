using UnityEngine;
using System.Collections;

public class dentro : MonoBehaviour 
{
	seguimiento s;
	// Use this for initialization
	void Start () 
	{
		s=GetComponentInParent<seguimiento>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter2D(Collider2D objeto)
	{
		if(objeto.tag== "Player")
		{
			s.SetDentro(true);
		}

	}

	void OnTriggerExit2D(Collider2D objeto)
	{
		if(objeto.tag== "Player")
		{
			s.SetDentro(false);
		}
		
	}
}
