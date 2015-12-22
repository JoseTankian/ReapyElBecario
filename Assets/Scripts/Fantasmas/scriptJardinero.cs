using UnityEngine;
using System.Collections;

public class scriptJardinero : MonoBehaviour {

	//Invocamos los scripts ajeno a este que queremos utilizar
	MovimientoPersonaje Reapyscript;

	//Definimos el animator
	Animator animjardinero;

	//Variabl que localiza el punto al que el objeto sigue
	public Transform player;

	//Variables para la velocidad y comprobación del seguimiento
	public float speed = 1;
	public float lerpinicial = 0;
	private float posicion;
	private float distancia;
	public bool me_sigue = false;

	//Comprobamos el contacto con el jugador
	public bool dentro = false;

	//Enumeramos los diferentes estados que tendrá el personaje
	public enum Estados {quieto, siguiendo, regando_arbol, transcendiendo};
	public Estados estado; 

	//Definimos las variables que nos comprueban varias acciones
	bool regandofinal = false;
	public bool arbol_ya_regado = false;
	//Esta variable localizará el punto donde queremos que interactúe
	public Transform punto_arbol;

	public Rigidbody2D rigid_puntoB;

	
	// Update is called once per frame
	void Start(){

		//Invocamos al script que mueve al personaje
		GameObject Reapy = GameObject.Find ("PLAYER");
		Reapyscript = Reapy.GetComponent<MovimientoPersonaje> ();

		//Hacemos que la variable para la velocidad de seguimiento sea igual a un vector elegido
		posicion = lerpinicial;

		//Invocamos el Animator del jardinero
		animjardinero = GetComponent<Animator> ();
	}
	void Update () 
	{
		///Debug.Log (GameControl.fantasmaTeSigue);

		//Definimos los estados de este personaje
		switch (estado){
			
		case Estados.quieto:
			animjardinero.SetBool("siguiendo",false);
			break;

		case Estados.siguiendo:
			transform.localScale = player.transform.localScale;
			animjardinero.SetBool("siguiendo",true);
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
			break;

		case Estados.regando_arbol:

			transform.position = Vector3.Lerp (transform.position, punto_arbol.position, posicion);
			transform.localScale = punto_arbol.localScale;
			//Invoke ("empezandoaregar", 2);
			empezandoaregar();
			regandofinal = true;
			rigid_puntoB.isKinematic = false;
			break;

		case Estados.transcendiendo:


			break;
			
		default :

			break;
		}

		if (dentro) {
			
			if (Input.GetKey (KeyCode.S) && !GameControl.fantasmaTeSigue && !regandofinal && !GameControl.enMenu) {
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
	
	
	public void SetDentro(bool seg){
		dentro = seg;
	}

	public void regando(){
		if (!me_sigue) {
			estado = Estados.regando_arbol;
		}
	}

	public void empezandoaregar(){
		animjardinero.SetBool("regando", true);
	}

	public void arbol_regado(){
		arbol_ya_regado = true;
	}

	public void destroy(){
		GameControl.fantasmasSalvados = GameControl.fantasmasSalvados+1;
		Destroy (gameObject);

	}
}