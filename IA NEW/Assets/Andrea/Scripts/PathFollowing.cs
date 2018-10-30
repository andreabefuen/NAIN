using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour {

   // public Grid grid;
    Pathfinding pathfinding;

    public float reachDistance;

    public Transform target; //target of this enemy
    public float speed;
    Vector3[] path;
    int targetIndex;

    Rigidbody enemyRigidbody;
    Vector3 movement;

    List<Nodo> pathToFollow;

    Queue<Nodo> queuePath;
    Nodo newNodo;
    bool reachDestination;




    private void Awake()
    {
        
    }

    
    // Use this for initialization
    void Start () {


       

        enemyRigidbody = GetComponent<Rigidbody>();

        pathfinding = GetComponent<Pathfinding>();

        queuePath = new Queue<Nodo>();

       Invoke("PathFollowingTo", 5);
	}

    void PathFollowingTo()
    {

        //Debug.Log("Se inicia");


        pathToFollow = pathfinding.pathPublic;
        //pathToFollow.Reverse();

        queuePath.Clear();


        foreach(Nodo n in pathToFollow)
        {
            queuePath.Enqueue(n);
        }

        WalkToANode(queuePath.Dequeue());

    }


    bool WalkToANode(Nodo n)
    {

        Vector3 dest;
        Vector3 offset;
        

        dest = n.worldPosition;
        offset = dest - transform.position;

       // Debug.Log("magnitud :" + offset.magnitude);

        if(offset.magnitude > reachDistance)
        {
            // movement.Set(n.worldPosition.x, 2f, n.worldPosition.z);
            //
            // movement = movement.normalized * speed * Time.deltaTime;
            //
            // enemyRigidbody.MovePosition(transform.position + movement);

            offset = offset.normalized;
            //Vector3.MoveTowards(transform.position, dest, 1f);
            transform.Translate(offset * speed * Time.deltaTime, Space.World);

            return false;

            
        }
        else
        {
            return true;
        }

        
    }
	
	// Update is called once per frame
	void Update () {

        
        

        if(queuePath.Count > 0)
        {
            newNodo = queuePath.Peek();
            
           // Debug.Log("Elemento en cola: " + queuePath.Count);

            if (WalkToANode(newNodo))
            {
                queuePath.Dequeue();
            }
        }
        
        Invoke("PathFollowingTo", 1);
        
        

    }
}
