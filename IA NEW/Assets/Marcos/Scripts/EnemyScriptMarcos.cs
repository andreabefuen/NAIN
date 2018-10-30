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


	void Start()
	{
		ToPlayer = false;
		RotationTime = 0;
		TimeR = 4;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update()
	{
		realDistance=Mathf.Abs (Vector3.Distance (this.transform.position, player.transform.position));


		//define comportamiento del enemigo segun su tamaño
		if (ToPlayer) {
			transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
		
		} else if (RotationTime < (TimeR*60)) {
			transform.Rotate (new Vector3 (0, 20 * Time.deltaTime));
			RotationTime += 1;
		} else {
			transform.Rotate (new Vector3 (0, -20 * Time.deltaTime));
			RotationTime += 1;
			if (RotationTime > (TimeR*120)) {
				RotationTime = 0;
			}
		}

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, visionRange)) {
			if (hit.transform.name == "Player") {
				positionPlayer = hit.transform;
				//Debug.Log (positionPlayer);
				this.transform.LookAt (positionPlayer.position);
				ToPlayer = true;
			}
		}




	}

	/*private void OnTriggerEnter(Collider other)
	{//si come comida crece si te come gameover
		if (other.gameObject.tag == "Player")
		{
			player = other.gameObject;
			ToPlayer = true;
		}

	}*/

	public float VisionRangeGet (){
		return visionRange;
	}
	public bool GetPursuit(){
		return ToPlayer;
	}

	public float GetRealDist(){
		return realDistance;
	}

}
