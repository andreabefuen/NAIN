using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour 
{
	public float betweenShotsTime=5f;
	public float distanceEP=20;
	public float visionRange=100f;
	public float speed=6f;
	//public GameObject Light;

	private int RotationTime;
	private int TimeR;
	private bool detectedOneTime;
	private float realDistance;
	private Transform positionPlayer;

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


		RotationTime = 0;
		TimeR = 4;
		detectedOneTime = false;
	}

	void Update ()
	{
		realDistance=Mathf.Abs (Vector3.Distance (this.transform.position, playerReal.transform.position));
		//Debug.Log(realDistance);
		if(pursuit){
			if (Mathf.Abs (Vector3.Distance (this.transform.position, positionPlayer.position)) > distanceEP) {
				transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
			} else {
				if (shootTime <= 0) {
					Shoot ();
				} else {
					shootTime -= Time.deltaTime;
				}

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
				RotationTime = 0;
				detectedOneTime = true;
			}
			else{

				if (RotationTime<(TimeR*60)){
					RotationTime += 1;
					if(detectedOneTime){
						this.transform.LookAt(positionPlayer.position);	
					}
				}
				else{
					pursuit = false;
				}


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
