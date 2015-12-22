using UnityEngine;
using System.Collections;

public class MovimientoPersonaje : MonoBehaviour 
{
	//Nombramos la variable FuerzaSalto como valor tipo float
	public float fuerzaSalto;
	//Nombramos la variable velocidad como valor tipo float y le asignamos 10
	public float velocidad = 10f;
	//Nombramos la variable rg como un Rigidbody2D que luego necesitaremos.
//	private int numsaltos=0;

	Animator anim;
	Rigidbody2D rg;

	//Para luego meterle la animacion
	//private Animator anim;

	//creamos dos vectores, uno para la mira derecha y otro para la izq
	private Vector3 miraDerecha;
	private Vector3 miraIzquierda;

	public GameObject cadena;
	cadenaScript cadena_script;


	void Start () 
	{

		GameObject cadenilla = cadena;
		cadena_script = cadenilla.GetComponent <cadenaScript> ();

		//A las variables le asignamos un vector y le asignamos los valores de posicion del eje x y y. Para que miren a izquierda y derecha
		miraDerecha = new Vector3(1f,1f,transform.position.z); 
		miraIzquierda = new Vector3(-1f,1f,transform.position.z); 
		rg= GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		/*
		anim = GetComponent<Animator>();
		//invertimos una de las escalas
		miraIzquierda = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z); 
		//escala por defecto
		miraDerecha = transform.localScale; 
		 */
	}
	
	void Update () 
	{
		//Controles Salto Esto no se usa al final.
		//Para que salte nuestro personaje tenemos que pulsar Espacio
		/*
		if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			//Tenemos un contador numsaltos que es 1, porque se ejecuta
			 //* una vez hemos pulsado espacio, por lo tanto siempre tendremos el contador en 1
			 //* *
			numsaltos=1;
			if(numsaltos==1)
			{
				salto();
				GetComponent<Rigidbody2D>().AddForce (new Vector2(fuerzaSalto,fuerzaSalto));
				//Personaje.rg.AddForce(new Vector3 (0,10,0)), ForceMode.VelocityChange);
			}
		}
		*/

		//Controles Izquierda Derecha
		//Cuando pasemos por teclado la tecla izquierda y derecha de las flechas, ejecutara la funcion MovimientoIzq y drch.
		if(Input.GetKey(KeyCode.LeftArrow) && !GameControl.enMenu && GameControl.fantasmasSalvados<4)
		{
			MovimientoIzq();

		}
		
		if(Input.GetKey(KeyCode.RightArrow) && !GameControl.enMenu && GameControl.fantasmasSalvados<4){
			MovimientoDrch();

		}


		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
		//&& GameControl.enMenu && GameControl.fantasmasSalvados<4) {
			anim.SetBool("andando",false);
		}

		//Para insertar la animacion de caminar
		//anim.SetFloat("caminando", Mathf.Abs(velocidad.x));

		Vector2 velocidad = GetComponent<Rigidbody2D>().velocity;
		Debug.DrawLine(transform.position, new Vector3(transform.position.x+ velocidad.x,
		                                               transform.position.y + velocidad.y, transform.position.z));
	}


	void salto()
	{
		//Aplicamos una fuerza en el salto en el eje Y
		rg.AddForce(new Vector2 (0, fuerzaSalto));
	}

	void MovimientoIzq()
	{
		//Le pasamos los valores de la variable miraIzquierda de posicion.
		transform.localScale=miraIzquierda;	
		/*De esta forma la velocidad siempre sera constante, el rg.velocity.y es 
		 * para q caiga a la vez que salta
		*/
		rg.velocity  = new Vector2 (-velocidad, 0);
			anim.SetBool("andando",true);
	}
	void MovimientoDrch()
	{
		//Le pasamos los valores de la variable miraIzquierda de posicion.
		transform.localScale=miraDerecha;	
		/*De esta forma la velocidad siempre sera constante, el rg.velocity.y es 
		 * para q caiga a la vez que salta
		*/
		rg.velocity  = new Vector2(velocidad,0);
			anim.SetBool("andando",true);
	}

	public void CortandoAlma()
	{
		anim.SetBool("cortando",true);
	}

	public void AlmaCortada(){
		anim.SetBool ("cortando", false);
	}

	public void cortar_cadena(){
		cadena_script.eslabon_roto ();
	}
}
