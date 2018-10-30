using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMarcos: MonoBehaviour {
	private Rigidbody rb;
	private float velocidad;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		velocidad = 0.5f;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)) {
			this.transform.Translate (Vector3.left * velocidad);
		} if (Input.GetKey (KeyCode.D)) {
			this.transform.Translate (Vector3.right * velocidad);
		} if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate (Vector3.forward * velocidad);
		} if (Input.GetKey (KeyCode.S)) {
			this.transform.Translate (Vector3.back * velocidad);
		} 
		
	}
}
