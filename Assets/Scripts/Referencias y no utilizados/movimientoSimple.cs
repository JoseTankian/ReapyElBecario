using UnityEngine;
using System.Collections;

//Script de movimiento hecho por aniceto. Usamos este o el otro al final?
public class movimientoSimple : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(2,3);

	private float forceX;
	//float forceY;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		var absVelX = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);

		if (Input.GetKey ("right")) {
			//mirarderecha = true;
			if (absVelX < maxVelocity.x)
				forceX = speed;
			this.transform.localScale = new Vector3 (1, 1, 1);
			//anim.SetBool("andar",true); 
			
		}else if (Input.GetKey ("left")) {
			//mirarderecha = false;
			if (absVelX < maxVelocity.x)
				forceX = -speed;
			this.transform.localScale = new Vector3 (-1, 1, 1);
			//anim.SetBool("andar",true); 
			
		}

	}


}
