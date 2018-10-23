using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAlex : MonoBehaviour {
	private Rigidbody rb;
	private float velocidad;
    float hori;
    float vert;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		velocidad = 10f;
		
	}
	
	// Update is called once per frame
	void Update () {
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if(hori > 0.9 && vert == 0 )
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (hori > 0.9 && vert > 0.9)
        {
            transform.eulerAngles = new Vector3(00, 45, 0);
        }
        else if (hori == 0 && vert > 0.9)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (hori < -0.9 && vert > 0.9)
        {
            transform.eulerAngles = new Vector3(0, 315, 0);
        }
        else if (hori < -0.9 && vert == 0)
        {
            transform.eulerAngles = new Vector3(0, 270, 0);

        }
        else if (hori < -0.9 && vert < -0.9)
        {
            transform.eulerAngles = new Vector3(0, 235, 0);

        }
        else if (hori == 0 && vert < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if (hori > 0 && vert < 0)
        {
            transform.eulerAngles = new Vector3(0, 135, 0);

        }
        if (Mathf.Abs(hori) > 0.9 || Mathf.Abs(vert) > 0.9)
        {
            transform.Translate(0, 0, velocidad * Time.deltaTime);

        }


    }
}
