using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptAlex : MonoBehaviour {

    GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 35, Player.transform.position.z - 17);  ; 
	}
}
