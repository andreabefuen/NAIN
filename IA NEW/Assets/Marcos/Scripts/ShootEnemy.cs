using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour 
{
	public float betweenShotsTime=5f;
	public float distanceEP=20;
	public float visionRange=100f;
	//public GameObject Light;
	private float realDistance;
	private Transform positionPlayer;
	private float speed=6f;
	private bool pursuit = false;
	private GameObject playerReal;
	private float shootTime;

	void Awake ()
	{
		shootTime = betweenShotsTime;
		playerReal = GameObject.FindGameObjectWithTag ("Player");
		//Light.active = false;
		positionPlayer= transform;
		pursuit = false;
	}

	void Update ()
	{
		realDistance=Mathf.Abs (Vector3.Distance (this.transform.position, playerReal.transform.position));
		//Debug.Log(realDistance);
		transform.LookAt (positionPlayer);
		if (Mathf.Abs (Vector3.Distance (this.transform.position, positionPlayer.position)) > distanceEP) {
			transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
		} else {
			if (shootTime <= 0) {
				Shoot ();
			} else {
				shootTime -= Time.deltaTime;
			}

		}
		/*Light.active = false;
		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}*/
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, visionRange)) {
			if (hit.transform.name == "Player") {
				positionPlayer = hit.transform;
				//Debug.Log (positionPlayer);
				this.transform.LookAt(positionPlayer.position);
				pursuit = true;
			}
		}
		
	}

	public float VisionRangeGet (){
		return visionRange;
	}
	public bool GetPursuit(){
		return pursuit;
	}

	public float GetRealDist(){
		return realDistance;
	}



	void Shoot ()
	{
		shootTime = betweenShotsTime;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 100f)) {
			Debug.Log (hit.transform.name);
		}
	}

}
