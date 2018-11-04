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
	private PathFollowing pathInit;
	private Pathfinding pathSearch;

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
		pathInit = this.GetComponent<PathFollowing> ();
		pathSearch= this.GetComponent<Pathfinding> ();
	}

	void Update ()
	{
		realDistance=Mathf.Abs (Vector3.Distance (this.transform.position, playerReal.transform.position));
		//Debug.Log(realDistance);
		if(realDistance<15f){
			pursuit=true;
			positionPlayer=playerReal.transform;
		}
		if(pursuit){

			pathSearch.enabled=true;
			pathInit.enabled=true;
			pathSearch.target=positionPlayer;
			pathInit.target=positionPlayer;
			if (Mathf.Abs (Vector3.Distance (this.transform.position, positionPlayer.position)) > distanceEP) {
				
			} else {
				
				if (shootTime <= 0) {
					Shoot ();
				} else {
					shootTime -= Time.deltaTime;
				}

			}
		}


		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, visionRange)) {
			if (hit.transform.tag == "Player") {
				positionPlayer = hit.transform;
				pursuit = true;
				RotationTime = 0;
			}
			else{

				if (RotationTime<(TimeR*60)){
					RotationTime += 1;
				}
				else{
					pursuit = false;
					pathSearch.enabled=false;
					pathInit.enabled=false;
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
	public void SetPursuit(bool pur, Transform detec){
		pursuit = pur;
		Vector3 target = new Vector3(detec.position.x,this.transform.position.y,detec.position.z);
		Debug.Log("Antes del detec: "+detec);
		positionPlayer = detec;
		//Debug.Log("Después del detec: "+positionPlayer.position);
		this.transform.LookAt(target);

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
