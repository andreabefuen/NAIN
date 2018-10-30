using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchIlluminationScriptJose : MonoBehaviour {

	GameObject player;
	GameObject dirLight;
	GameObject enemy;
	float speed = -1f;
	float switchDist;
	bool Pressed;
	bool LightOn;
	float time;

	// Use this for initialization
	void Start () {
		Pressed = false;
		dirLight = GameObject.Find ("Directional Light");
		enemy = GameObject.Find ("Enemy");
		switchDist = this.transform.position.x - this.transform.localScale.x + 0.3f;
		time = 0;
		LightOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Pressed) {
			if (Mathf.Abs(Vector3.Distance(this.transform.position, player.transform.position)) > 2 && time == 0)
			{
				
				if (this.transform.position.x >= switchDist) {
					LightOn = true;

					transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
				}
			}
			if (time <= 5 && LightOn) {
				if (this.transform.position.x <= switchDist) {
					dirLight.GetComponent<Light> ().intensity -= 0.1f;
					time += Time.deltaTime;
					enemy.GetComponent<EnemyMovementJose> ().ToPlayer = false;
					Debug.Log (time + ", " + Time.deltaTime);
				}
			}
			else {
				LightOn = false;
				if (dirLight.GetComponent<Light> ().intensity <= 1) {
					dirLight.GetComponent<Light> ().intensity += 0.1f;
				}

				if (this.transform.position.x <= switchDist + this.transform.localScale.x - 0.3f) {
					transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
				} 
				else {
					time = 0;
					enemy.GetComponent<EnemyMovementJose> ().ToPlayer = true;
					Pressed = false;
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
