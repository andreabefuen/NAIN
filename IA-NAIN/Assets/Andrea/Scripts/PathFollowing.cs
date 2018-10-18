using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour {

    private Grid grid;

    public Transform target; //target of this enemy
    public float speed;
    Vector3[] path;
    int targetIndex;


    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    // Use this for initialization
    void Start () {

       
        List<Nodo> pathToFollow = grid.GetPath();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
