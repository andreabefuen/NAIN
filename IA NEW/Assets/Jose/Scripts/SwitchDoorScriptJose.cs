using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoorScriptJose : MonoBehaviour {
	
	GameObject player;
	GameObject door;
	float speed = -1f;
	float doorSpeed = 2.5f;
	float switchDist;
	float doorDist;
	bool Pressed;

	// Use this for initialization
	void Start () {
		Pressed = false;
		door = GameObject.Find ("Door");
		switchDist = this.transform.position.x - this.transform.localScale.x + 0.3f;
		doorDist = door.transform.position.z + door.transform.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (Pressed) {
			if (Mathf.Abs(Vector3.Distance(this.transform.position, player.transform.position)) > 2)
			{
				
				if (this.transform.position.x >= switchDist) {
					transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));

				}
			}

			if(this.transform.position.x <= switchDist){
				if(door.transform.position.z <= doorDist){
					door.transform.Translate(new Vector3 (0, 0, doorSpeed * Time.deltaTime));
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
		{
			player = other.gameObject;
			Pressed = true;
		}

	}


}
