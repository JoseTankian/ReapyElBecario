using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textosCOmputer : MonoBehaviour {

	public Text panel_texto;
	public int pagina = 0;
	[Multiline]
	public string[] paginas;
	private bool ordenador_col = false;
	
	// Update is called once per frame
	void Update () {
		panel_texto.text = paginas[pagina];
	}
	
	//Esta funcion detecta si el personaje está en el rango de acción del ordenador
	void OnTriggerStay (Collider col) {
		if (col.transform.tag == "Player") {
			ordenador_col = true;
		}
	}	
	//Esta detecta si sale
	void OnTriggerExit (Collider col) {
		if (col.transform.tag == "Player") {
			ordenador_col = false;
		}
	}	
	//con esta función le decimos 
	void OnGUI(){
		if (ordenador_col){
			if(Event.current.type == EventType.keyDown && Event.current.keyCode == KeyCode.X && pagina < paginas.Length-1){
				pagina = pagina+1;
			} else if (Event.current.type == EventType.keyDown && Event.current.keyCode == KeyCode.Z && pagina > 0){				
				pagina = pagina-1;
			}
		}
	}

}