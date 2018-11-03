using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour {

   // public Grid grid;
    Pathfinding pathfinding;

    public float reachDistance;

    public bool isShooter;
    public  float shootDistance;

    public Transform target; //target of this enemy
    public float speed;
    Vector3[] path;
    int targetIndex;

    Rigidbody enemyRigidbody;
    Vector3 movement;

    List<Nodo> pathToFollow;

    Queue<Nodo> queuePath;
    Nodo newNodo;

    Animator anim;

    
    bool reachDestination = false;

    float initialSpeed;



    private void Awake()
    {
        
    }

    
    // Use this for initialization
    void Start () {

       

        anim = GetComponent<Animator>();
        //
        // anim.SetBool("isWatching", true);
        // anim.SetBool("isFar", true);
        //
     
        enemyRigidbody = GetComponent<Rigidbody>();

        pathfinding = GetComponent<Pathfinding>();

        queuePath = new Queue<Nodo>();

        initialSpeed = speed;

       Invoke("PathFollowingTo", 5);
	}

    void PathFollowingTo()
    {

        //Debug.Log("Se inicia");


        pathToFollow = pathfinding.pathPublic;
        //pathToFollow.Reverse();

        queuePath.Clear();
        reachDestination = false;


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

            if(isShooter)
            {
                Vector3 dstToPlayer;
                Vector3 aux;

                dstToPlayer = target.position;
                aux = dstToPlayer - transform.position;

                if(aux.magnitude <= shootDistance)
                {
                    anim.SetBool("isWatching", true);
                    anim.SetBool("isFar", false);
                    anim.SetTrigger("shoot");
                    Debug.Log("DISPARA");
                    speed = 0;
                }
                else
                {
                    anim.SetBool("isWatching", true);
                    anim.SetBool("isFar", true);
                    speed = initialSpeed;
                }
              

                
            }
            else
            {
                anim.SetBool("isWatching", true);
                anim.SetBool("isFar", true);
                speed = initialSpeed;
            }

             offset = offset.normalized;

             
             transform.LookAt(target);
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
        else
        {
            //Debug.Log("hA LLEGADO");
            reachDestination = true;
            anim.SetBool("isWatching", true);
            anim.SetBool("isFar", false);
            if (!isShooter)
            {
                anim.SetTrigger("punch");

            }


        }

        Invoke("PathFollowingTo", 1);
        
        

    }
}
