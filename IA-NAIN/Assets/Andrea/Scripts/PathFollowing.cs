using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour {

    public Grid grid;

    public float reachDistance;

    public Transform target; //target of this enemy
    public float speed;
    Vector3[] path;
    int targetIndex;

    Rigidbody enemyRigidbody;
    Vector3 movement;

    List<Nodo> pathToFollow;

    


    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {


       

        enemyRigidbody = GetComponent<Rigidbody>();

       Invoke("PathFollowingTo", 5);
	}

    void PathFollowingTo()
    {
        pathToFollow = grid.GetPath();
        pathToFollow.Reverse();

        Vector3 dest;
        Vector3 offset;
        bool withoutDestiny = true;


        if (pathToFollow != null){
            
            foreach(Nodo n in pathToFollow)
            {
                while (withoutDestiny)
                {
                    dest = n.worldPosition;
                    offset = dest - transform.position;
                   

                    

                    if (offset.magnitude > reachDistance)
                    {
                        offset = offset.normalized;
                        //Vector3.MoveTowards(transform.position, dest, 1f);
                        transform.Translate(offset * speed  , Space.World);

                        

                    }
                    else //si esta en el nodo que toca, break el while
                    {
                        //withoutDestiny = false;
                        break;
                    }
                }
               

       
            }
        }
    }


    void WalkToANode(Nodo n)
    {
        movement.Set(n.worldPosition.x, 2f, n.worldPosition.z);

        movement = movement.normalized * speed * Time.deltaTime;

        enemyRigidbody.MovePosition(transform.position + movement);
    }
	
	// Update is called once per frame
	void Update () {
/*
      pathToFollow = grid.GetPath();
      pathToFollow.Reverse();

      if (pathToFollow != null && pathToFollow.Count > 0)
        {

            Vector3 dest;
            Vector3 offset;
            bool withoutDestiny = true;
       
                foreach (Nodo n in pathToFollow)
                {
                    while (withoutDestiny)
                    {
                        dest = n.worldPosition;
                        offset = dest - transform.position;



                        if (offset.magnitude > reachDistance)
                        {
                            offset = offset.normalized;
                            transform.Translate(offset * speed * Time.deltaTime, Space.World);



                        }
                        else //si esta en el nodo que toca, break el while
                        {
                            //withoutDestiny = false;
                            break;
                        }
                    }



                }
            

        }*/

    }
}
