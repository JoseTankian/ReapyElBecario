using UnityEngine;
using System.Collections;

public class scriptGimnasta : MonoBehaviour {

	//Invocamos los scripts ajeno a este que queremos utilizar
	MovimientoPersonaje Reapyscript;

	Animator animgimnasta;
	public Transform player;
	public float speed = 1;
	public float lerpinicial = 0;
	private float posicion;
	private float distancia;
	public bool me_sigue = false;
	public bool dentro = false;

	public enum Estados {quieto, siguiendo, pirueta, transcendiendo};
	public Estados estado; 

	public Transform punto_arbol;
	public bool gimnasta_volteando = false;

	public bool manzana_cae = false;

	public Rigidbody2D rigid_puntoB;

	
	// Update is called once per frame
	void Start(){
		//		Bocadillo.SetActive(false);
		GameObject Reapy = GameObject.Find ("PLAYER");
		Reapyscript = Reapy.GetComponent<MovimientoPersonaje> ();
		posicion = lerpinicial;
		animgimnasta = GetComponent<Animator> ();
	}
	void Update () 
	{
		//Debug.Log (GameControl.fantasmaTeSigue);
		switch (estado){
			
		case Estados.quieto:
			animgimnasta.SetBool("siguiendo",false);
			break;
			
		case Estados.siguiendo:
			transform.localScale = player.transform.localScale;
			animgimnasta.SetBool("siguiendo",true);
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
			break;
			
		case Estados.pirueta:
			transform.localScale = punto_arbol.localScale;
			gimnasta_volteando = true;
			animgimnasta.SetBool("pirueta", true);
		//	Debug.Log ("HACIENDO PIRUETA");
			transform.position = Vector3.Lerp (transform.position, punto_arbol.position, posicion);
			rigid_puntoB.isKinematic = false;
			break;
			
		case Estados.transcendiendo:
			
			
			break;
			
		default :
			//Debug.Log ("...");
			break;
		}
		
		if (dentro) {
			
			if (Input.GetKey (KeyCode.S) && !GameControl.fantasmaTeSigue && !gimnasta_volteando && !GameControl.enMenu) {
				//me_sigue = true;
				UnFantasmaMas ();
				
				//	Debug.Log ("Funciona");
			} else if (Input.GetKey (KeyCode.A) && me_sigue && !GameControl.enMenu) {
				//me_sigue = false;
				Reapyscript.CortandoAlma();
				posicion = lerpinicial;
				UnFantasmaMenos ();
				
			} else if (Input.GetKey (KeyCode.D)) {
				//Bocadillo.SetActive(true);
				//dialogo.text ="ejemplo";
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
		estado = Estados.quieto;
		me_sigue = false;
	}
	
	
	public void SetDentro(bool seg) {
		dentro = seg;
	}
	
	public void haciendoPirueta() {
		if (!me_sigue) {
			estado = Estados.pirueta;
		//	animgimnasta.SetBool("pirueta", true);
		}
	}
	
	public void transcendiendo(){
		estado = Estados.transcendiendo;
		animgimnasta.SetBool("transcendiendo",true);
	}

	public void manzana_cayendo(){
		manzana_cae = true;
	}
	
	public void destroy(){
		GameControl.fantasmasSalvados = GameControl.fantasmasSalvados+1;
		Destroy (gameObject);
	}
}