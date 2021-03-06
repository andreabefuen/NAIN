﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScriptMarcos: MonoBehaviour {

	GameObject player;
	float speed = 6f;
	public bool ToPlayer;
	private int RotationTime;
	private int TimeR;
	public float DistanceEP;

	void Start()
	{
		ToPlayer = false;
		RotationTime = 0;
		TimeR = 4;
	}

	// Update is called once per frame
	void Update()
	{
		//define comportamiento del enemigo segun su tamaño
		if (ToPlayer) {
			transform.LookAt (player.transform.position);
			if (Mathf.Abs (Vector3.Distance (this.transform.position, player.transform.position)) > DistanceEP) {
				transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
			}
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
	}

	private void OnTriggerEnter(Collider other)
	{//si come comida crece si te come gameover
		if (other.gameObject.tag == "Player")
		{
			player = other.gameObject;
			ToPlayer = true;
		}

	}

}

