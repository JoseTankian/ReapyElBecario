using UnityEngine;
using System.Collections;

public class cadenaScript : MonoBehaviour {
	
	//Definimos los puntos que tenemos como extremos de la cadena
	public GameObject punto_A;
	public GameObject punto_B;
	Animator anim_chain;

	
	public GameObject gordo_object;
	public GameObject jardinero_object;
	public GameObject psicologo_object;
	public GameObject gimnasta_object;
	public GameObject player;

	scriptGordo gordo_script;
	scriptGimnasta gimnasta_script;
	scriptPsicologo psicologo_script;
	scriptJardinero jardinero_script;
	MovimientoPersonaje reapy_script;

	Rigidbody2D rigid_puntoB;

	//Buscamos la localización del jugador
//	public Transform player;

	//Definimos la junta del eslabon que queremos partir
	public HingeJoint2D eslabon;


	// Use this for initialization
	void Start () {
		anim_chain = GetComponent<Animator> ();

		rigid_puntoB = punto_B.GetComponent<Rigidbody2D>();

		GameObject gordito = gordo_object;
		gordo_script = gordito.GetComponent <scriptGordo> ();

		GameObject psicolog = psicologo_object;
		psicologo_script = psicolog.GetComponent <scriptPsicologo> ();

		GameObject gimn = gimnasta_object;
		gimnasta_script = gimn.GetComponent <scriptGimnasta> ();

		GameObject jardi = jardinero_object;
		jardinero_script = jardi.GetComponent <scriptJardinero> ();

		GameObject reapy = player;
		reapy_script = player.GetComponent <MovimientoPersonaje> ();
	}


	// Update is called once per frame
	void Update () {

		punto_A.transform.position = player.transform.position;
		//La cadena siempre sigue al jugador
	//	punto_A.transform.position = player.position;
		if (gordo_script.me_sigue) {
			punto_B.transform.position = gordo_object.transform.position;
			nuevo_eslabon ();
			rigid_puntoB.isKinematic = true;
		} 


		if (jardinero_script.me_sigue) {
			punto_B.transform.position = jardinero_object.transform.position;
			nuevo_eslabon ();
			rigid_puntoB.isKinematic = true;
		} 


		if (gimnasta_script.me_sigue) {
			punto_B.transform.position = gimnasta_object.transform.position;
			nuevo_eslabon ();
			rigid_puntoB.isKinematic = true;
		} 


		if (psicologo_script.me_sigue) {
			punto_B.transform.position = psicologo_object.transform.position;
			nuevo_eslabon ();
			rigid_puntoB.isKinematic = true;

		} 

	}

	//Nueva cadena
	public void nuevo_eslabon(){
		eslabon.enabled = true;
		anim_chain.SetBool ("Aparece", true);
	}

	//El eslabón se suelta
	public void eslabon_roto(){
		eslabon.enabled = false;
		anim_chain.SetBool ("Aparece", false);
	}




	public void destruir_cadena(){
		Destroy (gameObject);
	}
}
