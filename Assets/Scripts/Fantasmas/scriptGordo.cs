using UnityEngine;
using System.Collections;

public class scriptGordo : MonoBehaviour {

	//Invocamos los scripts ajeno a este que queremos utilizar
	MovimientoPersonaje Reapyscript;
	scriptPsicologo psicologo;
	manzana_Gordo manzanita;

	Animator animgordo;
	public Transform player;
	public float speed = 1;
	public float lerpinicial = 0;
	private float posicion;
	private float distancia;
	public bool me_sigue = false;

	public bool dentro = false;
	// Use this for initialization
	public enum Estados {quieto, siguiendo, huyendo_boton, escuchando, llorando, comiendo};
	public Estados estado; 
	public Transform punto_manzana;
	public Transform punto_origen;
	public bool gordorayado = false;
	public bool gordollora = false;
	public bool gordocomiendo = false;

	public GameObject manzana;
//	public Transform psicologo_pos;

	public float tiempo_regreso = 3;
	//public float tiempo_llanto = 0;
	//public float llanto_final = 2;


	public float correccion_tamaño = 0.4f;

	public Rigidbody2D rigid_puntoB;



	// Update is called once per frame
	void Start(){
		//		Bocadillo.SetActive(false);
		GameObject Reapy = GameObject.Find ("PLAYER");
		GameObject Psico = GameObject.Find ("Psicólogo");
		GameObject Manzana = manzana;


		Reapyscript = Reapy.GetComponent<MovimientoPersonaje> ();
		psicologo = Psico.GetComponent<scriptPsicologo>();
		manzanita = Manzana.GetComponent<manzana_Gordo>();

		posicion = lerpinicial;
		animgordo = GetComponent<Animator> ();}

	void UnFantasmaMas(){
		GameControl.fantasmaTeSigue = true;

		
		me_sigue = true;
	}

	void Update () 
	{


		if (psicologo.psicologoHabla && !gordollora) {
			GameControl.tiempo_llanto = GameControl.tiempo_llanto + 0.1f;
		} else {
			if(!gordollora){
			GameControl.tiempo_llanto = 0;
			}
		}

		if (GameControl.tiempo_llanto > GameControl.llanto_final) {
			gordoLlorando();
		}
		//Debug.Log (GameControl.fantasmaTeSigue);
		switch (estado){
			
		case Estados.quieto:
			animgordo.SetBool("siguiendo",false);

			break;
			
		case Estados.siguiendo:

			animgordo.SetBool("siguiendo",true);
			transform.localScale = player.transform.localScale*correccion_tamaño;
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
			break;

		case Estados.escuchando:
			//animgordo.SetBool("siguiendo", false);
			if (!psicologo.psicologoHabla) {
				Invoke ("regresoPosicion", tiempo_regreso);
			}

			if(gordollora){
				estado = Estados.llorando;
			}
			
			break;

		case Estados.huyendo_boton:
			transform.localScale = punto_origen.transform.localScale*correccion_tamaño;
			transform.position = Vector3.Lerp (transform.position, punto_origen.position, posicion);
			Invoke ("QuietoAgain", 2);

			break;

		case Estados.llorando:
			gordollora = true;

			break;
			
		case Estados.comiendo:
			gordocomiendo = true;
			transform.position = Vector3.Lerp (transform.position, punto_manzana.position, posicion);
			transform.localScale = punto_manzana.transform.localScale*correccion_tamaño;
			rigid_puntoB.isKinematic = false;

			Invoke ("gordoempiezacomer",3);


			
			break;
			
		default :
			//Debug.Log ("...");
			break;
		}


		if (psicologo.psicologoHabla) {
			estado = Estados.escuchando;
		}


		if (dentro) {

			if (Input.GetKey (KeyCode.S) && !GameControl.fantasmaTeSigue && !gordocomiendo && !GameControl.enMenu) {

				UnFantasmaMas ();

			} else if (Input.GetKey (KeyCode.A) && me_sigue && !GameControl.enMenu) {
				Reapyscript.CortandoAlma();
				UnFantasmaMenos ();
				me_sigue = false;
				
				if(psicologo.psicologoHabla){
					estado = Estados.escuchando;

					if(gordollora){
						animgordo.SetBool("llorando", true);
						estado = Estados.quieto;
					}
					
				} else {
					estado = Estados.quieto;
					posicion = lerpinicial;
					Invoke ("regresoPosicion", tiempo_regreso);
				}
				
			} 

		}


		if (me_sigue) {
			
			estado = Estados.siguiendo;
			
		} else if (!me_sigue) {
			
			
		}
		
		/*
			if(Input.GetKey(KeyCode.A))
			{
				me_sigue = !me_sigue;
			}
			*/

	}
	

	
	void UnFantasmaMenos(){
		GameControl.fantasmaTeSigue = false;
	}

	void QuietoAgain(){
		if (!me_sigue) {
			estado = Estados.quieto;
			me_sigue = false;
		}
	}
	
	
	public void SetDentro(bool seg){
		dentro = seg;
	}
	
	public void regando(){
		if (!me_sigue) {
			
			estado = Estados.huyendo_boton;
		}
	}


	public void gordoLlorando(){
		gordollora = true;
		animgordo.SetBool("llorando", true);
	}
	
	public void destroy(){		
		GameControl.fantasmasSalvados = GameControl.fantasmasSalvados+1;
		Destroy (gameObject);

	}

	public void regresoPosicion(){
		if (!me_sigue && !psicologo.psicologoHabla) {
			estado = Estados.huyendo_boton;
		}
	}

	public void gordoCome(){
		if (!me_sigue && manzanita.manzana_caida && gordollora) {
			estado = Estados.comiendo;
		}
	}

	public void gordoempiezacomer(){
		animgordo.SetBool("comiendo",true);

	}

	public void destroy_manzana(){
		Destroy(manzana);

	}


}
