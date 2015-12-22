using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu_principal : MonoBehaviour
{
	private AsyncOperation ao;

	public string LevelToLoad;

	public GameObject progressbar;
	public GameObject text;
	public GameObject progressback;

	bool cargando_nivel = false;

//	public int loadProgress = 0;

//	public Text textocarga;



    // Use this for initialization
    void Start()
    {
		UnityEngine.EventSystems.EventSystem.current.sendNavigationEvents = true;

		if (progressbar != null && text != null) {
			progressbar.SetActive (false);
			progressback.SetActive (false);
			text.SetActive (false);
			cargando_nivel = false;
		}

    }

    // Update is called once per frame
	public void jugar_nivel_1()
	{
		//StartCoroutine (DisplayLoadingLevel (LevelToLoad));

		ao = Application.LoadLevelAsync("Nivel_1");
		progressbar.SetActive (true);
		text.SetActive (true);
		progressback.SetActive (true);
		cargando_nivel = true;
		UnityEngine.EventSystems.EventSystem.current.sendNavigationEvents = false;

	}


	void Update(){

		if(cargando_nivel){

			progressbar.transform.localScale = new Vector3 (ao.progress*40, progressbar.transform.localScale.y, progressbar.transform.localScale.z);
//			textocarga.text = cargando.ToString();
		}


	}

	public void intro()
	{
		Application.LoadLevel("menu_principal");

	}

    public void jugar1()
    {
        Application.LoadLevel("explicacion");

    }

    public void jugar()
    {
        Application.LoadLevel("juegoo");

    }

    public void creditos()
    {
        Application.LoadLevel("creditos");
    }

    public void salir()
    {
        Application.Quit();
    }

    public void volver()
    {
        Application.LoadLevel("menu_principal");
    }



	/*

	IEnumerator DisplayLoadingLevel (string level){

		progressbar.SetActive (true);
		text.SetActive (true);

		progressbar.transform.localScale = new Vector3 (loadProgress, progressbar.transform.y, progressbar.transform.z);

		AsyncOperation async = Application.LoadLevelAsync("Nivel_1");

		while (!async.isDone) {

			loadProgress = async.progress;
			progressbar.transform.localScale = new Vector3 (async.progress, progressbar.transform.y, progressbar.transform.z);


			yield return null;
		}
	}

	*/


}





