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


	void Start()
	{
		ToPlayer = false;
		RotationTime = 0;
		TimeR = 4;
		detectedOneTime = false;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update()
	{
		realDistance=Mathf.Abs (Vector3.Distance (this.transform.position, player.transform.position));

		//define comportamiento del enemigo 
		if (ToPlayer) {
			transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));		
		}

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, visionRange)) {
			if (hit.transform.tag == "Player") {
				Debug.Log(hit.transform.name);

				positionPlayer = hit.transform;
				this.transform.LookAt (positionPlayer.position);
				ToPlayer = true;
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
					ToPlayer = false;
				}


			}
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
		this.transform.LookAt(target);
	}

}
