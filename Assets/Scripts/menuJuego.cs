using UnityEngine;
using System.Collections;

public class menuJuego : MonoBehaviour {

	//Variable animator del menú
	Animator anim;

	private int paginaScroll = 0;
	private bool menu_in = false;

	// Use this for initialization
	void Start () {
	
		//definimos el animator dentro del objeto
		anim = GetComponent<Animator> ();
		GameControl.enMenu = false;

	}
	
	// Update is called once per frame
	void Update () {

		paginaScroll = 0;

		if (menu_in) {
			anim.SetBool("Menu_In", true);
		} else {
			anim.SetBool("Menu_In", false);
		}

		//Al pulsar la tecla D, accionamos el menú
		if (Input.GetButtonDown ("Menu") && GameControl.fantasmasSalvados<4) {
			menu_in = !menu_in;
			GameControl.enMenu = !GameControl.enMenu;
		}

		if (GameControl.fantasmasSalvados >= 4) {
			GameControl.enMenu = false;
			menu_in = false;
		}

		if(Input.GetAxisRaw("Horizontal")<0 && GameControl.enMenu){
			paginaScroll = paginaScroll-1;
		}
		
		if(Input.GetAxisRaw("Horizontal")>0 && GameControl.enMenu){
			paginaScroll = paginaScroll+1;
		}

		anim.SetInteger("pagina", paginaScroll);

	}

	public void salirMenu(){
		GameControl.enMenu = false;
		menu_in = false;
	}

	public void reiniciar()
	{
		if (GameControl.enMenu) {
			GameControl.enMenu = false;
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
