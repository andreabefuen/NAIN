using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptMarcos : MonoBehaviour {

	GameObject player;
	float speed = 6f;
	public bool ToPlayer;
	public float visionRange=20f;

	private int RotationTime;
	private int TimeR;
	private float realDistance;
	private Transform positionPlayer;
	private bool detectedOneTime;
	private PathFollowing pathInit;
	private Pathfinding pathSearch;
    //private SwitchIlluminationScriptJose IlumJose;


	void Start()
	{
		ToPlayer = false;
		RotationTime = 0;
		TimeR = 10;
		detectedOneTime = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		pathInit = this.GetComponent<PathFollowing> ();
		pathSearch= this.GetComponent<Pathfinding> ();
        //IlumJose = GameObject.Find("SwitchIllumination").GetComponent<SwitchIlluminationScriptJose> ();
	}

	// Update is called once per frame
	void Update()
	{
		realDistance=Mathf.Abs (Vector3.Distance (this.transform.position, player.transform.position));
		if (realDistance<15f){
			ToPlayer=true;
			positionPlayer=player.transform;
		}
        //define comportamiento del enemigo 
        if (ToPlayer)
        {
            //Debug.Log(positionPlayer.position);
            pathSearch.enabled = true;
            pathInit.enabled = true;
            pathSearch.target = positionPlayer;
            pathInit.target = positionPlayer;

        }
        else {
            pathSearch.enabled = false;
            pathInit.enabled = false;
        }

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, visionRange)) {
			if (hit.transform.tag == "Player") {
				positionPlayer = hit.transform;
				ToPlayer = true;
				RotationTime = 0;
			}

			else{

				if (RotationTime<(TimeR*60)){
					RotationTime += 1;

				}
				else{
					ToPlayer = false;
					pathSearch.enabled=false;
					pathInit.enabled=false;

				}
			}
//
//
		}




	}

	public float VisionRangeGet (){
		return visionRange;
	}
	public bool GetPursuit(){
		return ToPlayer;
	}

	public float GetRealDist(){
		return realDistance;
	}

	public void SetPursuit(bool pur,Transform detec){
		ToPlayer = pur;	
		Vector3 target = new Vector3(detec.position.x,this.transform.position.y,detec.position.z);
		Debug.Log("Antes del detec: "+detec.position);
		positionPlayer = detec;
		//Debug.Log("Después del detec: "+positionPlayer.position);
		//this.transform.LookAt(target);
	}

}
