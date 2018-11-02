using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMarcos: MonoBehaviour {
	private Rigidbody rb;
    private Animator anim;
	private float velocidad;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
        anim = GetComponent<Animator>();
		velocidad = 0.5f;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)) {
            anim.SetBool("isWalking", true);
			this.transform.Translate (Vector3.left * velocidad);
		} else if (Input.GetKey (KeyCode.D)) {
            anim.SetBool("isWalking", true);
            this.transform.Translate (Vector3.right * velocidad);
		} else if (Input.GetKey (KeyCode.W)) {
            anim.SetBool("isWalking", true);
            this.transform.Translate (Vector3.forward * velocidad);
		}else  if (Input.GetKey (KeyCode.S)) {
            anim.SetBool("isWalking", true);
            this.transform.Translate (Vector3.back * velocidad);
		}
        else
        {
            anim.SetBool("isWalking", false);
        }
		
	}
}
