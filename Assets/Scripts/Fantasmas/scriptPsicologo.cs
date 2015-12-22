using UnityEngine;
using System.Collections;

public class scriptPsicologo : MonoBehaviour {

	Animator animpsicologo;
	public Transform player;
	public float speed = 1;
	public float lerpinicial = 0;
	private float posicion;
	private float distancia;
	public bool me_sigue = false;
	public bool dentro = false;
	public enum Estados {quieto, siguiendo, hablando, feliz, transcendiendo};
	public Estados estado; 

	public bool psicologoHabla = false;
	
	public bool muerteSeAleja = true;

	public bool psicologoYGordoJuntos = false;

	public bool psicologoDeshaogado = false;

	public float correccion_tamaño = 5f;

	MovimientoPersonaje Reapyscript;

	public ParticleSystem blablas;
	public float blablas_emision = 1.5f;




	// Update is called once per frame
	void Start(){
		//		Bocadillo.SetActive(false);
		posicion = lerpinicial;
		animpsicologo = GetComponent<Animator> ();

		GameObject Reapy = GameObject.Find ("PLAYER");
		Reapyscript = Reapy.GetComponent<MovimientoPersonaje> ();
	}
	void Update () 
	{
		if (GameControl.tiempo_llanto > GameControl.llanto_final) {
			transcendiendo();
		}

		if (psicologoHabla) {
			blablas.emissionRate = blablas_emision;
		} else {
			blablas.emissionRate = 0;
		}

		//Debug.Log (GameControl.fantasmaTeSigue);
		switch (estado){
			
		case Estados.quieto:
			animpsicologo.SetBool("siguiendo",false);
			animpsicologo.SetBool("hablando", false);
			psicologoHabla = false;
			break;
			
		case Estados.siguiendo:
			transform.localScale = player.transform.localScale * correccion_tamaño;
			animpsicologo.SetBool("siguiendo",true);
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
			break;
			
		case Estados.hablando:
			animpsicologo.SetBool("hablando", true);
			me_sigue = false;
			psicologoHabla = true;

			//Esto deberá invocarse desde dentro de la animación
			//Invoke ("psicologoFeliz", 10);
			break;
			
		case Estados.feliz:
			animpsicologo.SetBool("feliz", true);
			break;
			
		case Estados.transcendiendo:
			break;
			
		default :
			//Debug.Log ("...");
			break;
		}

		if (muerteSeAleja && psicologoYGordoJuntos) {
			estado = Estados.hablando;
		} else {
			estado = Estados.quieto;
		}

		if (dentro) {
			
			if (Input.GetKey (KeyCode.S) && !GameControl.fantasmaTeSigue && !psicologoDeshaogado && !GameControl.enMenu) {
				//me_sigue = true;
				UnFantasmaMas ();
				
				//	Debug.Log ("Funciona");
			} else if (Input.GetKey (KeyCode.A) && me_sigue && !GameControl.enMenu) {

				Reapyscript.CortandoAlma();
				me_sigue = false;
				estado = Estados.quieto;
				UnFantasmaMenos ();
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
	
	void UnFantasmaMas(){
		GameControl.fantasmaTeSigue = true;
		me_sigue = true;
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

	void psicologoFeliz(){
		Debug.Log ("El psicolo ya se ha deshagado");
		estado = Estados.feliz;
		psicologoDeshaogado = true;
	}
	
	public void SetDentro(bool seg){
		dentro = seg;
	}

	public void transcendiendo(){
		estado = Estados.transcendiendo;
		animpsicologo.SetBool("transcendiendo",true);
	}
	
	public void destroy(){
		GameControl.fantasmasSalvados = GameControl.fantasmasSalvados+1;
		Destroy (gameObject);

	}
	

}