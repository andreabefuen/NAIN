using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowingEnemy : MonoBehaviour {

    public Transform target;
    public float speed;

    public Pathfinding pathfinding;


    Queue<Nodo> queuePath;
    Nodo newNodo;


    // Use this for initialization
    void Start () {
		
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
