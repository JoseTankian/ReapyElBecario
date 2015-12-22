using UnityEngine;
using System.Collections;

public class manzana_Gordo : MonoBehaviour {

	
	public GameObject gimnasta;

	scriptGordo gordito;
	scriptGimnasta gimnastaScript;

	Rigidbody2D manzana_rigid;
	Animator manzanim;
	
//	Animator animArbol;
	
	public bool manzana_caida = false;
	
	// Use this for initialization
	
	void Start () {
		manzana_rigid = GetComponent<Rigidbody2D> ();
		GameObject gim = gimnasta;
		gimnastaScript = gim.GetComponent <scriptGimnasta> ();
		manzanim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (gimnastaScript.manzana_cae) {
			manzana_rigid.isKinematic = false;
			manzanim.SetBool("cayendo", true);
			manzana_caida = true;
		}
		
	}
	
	void OnTriggerStay2D(Collider2D col){
		
		if (col.transform.tag == "GordoFisica") {
		//	Debug.Log ("MANZANAAAA");
			gordito = col.GetComponent<scriptGordo>();
			gordito.gordoCome();

		}
		
		
	}
	

}
