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

    

	//Añadido Marcos
	public GameObject bulletPrefab;
	public GameObject bulletSpawn;
	private float timeLeft=0f;
	private GameObject Player;

    //Sounds
    public AudioSource damageAudio;


    private void Awake()
    {
		Player=GameObject.FindGameObjectWithTag ("Player");
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
					if(timeLeft<=0){
						anim.SetTrigger("shoot");
						Debug.Log("DISPARA");
                        damageAudio.Play();
						this.Fire();
						timeLeft=4f;

					}
					else{
						
					}
	                    
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

			offset.y=0f;
             offset = offset.normalized;
			//Por Marcos para que no mire para abajo
			Vector3 objetivo=new Vector3(target.position.x,this.transform.position.y,target.position.z);
             
			transform.LookAt(/*target*/ objetivo);
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

        
		if(timeLeft>0f){timeLeft-=Time.deltaTime;}

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
				//Añadido por marcos para que el personaje reciba el ataque
				var distance = Mathf.Abs (Vector3.Distance (this.transform.position, Player.transform.position));
				Debug.Log(distance);
				if((Mathf.Abs (Vector3.Distance (this.transform.position, Player.transform.position)))<5.5f){
					anim.SetTrigger("punch");
					Player.GetComponent<PlayerMovement>().Attack();
				}
                


            }


        }

        Invoke("PathFollowingTo", 1);
        
        

    }

	//Mood marcos
	private void Fire(){
		var bullet=(GameObject) Instantiate(bulletPrefab,bulletSpawn.transform.position,bulletSpawn.transform.rotation);
		bullet.GetComponent<Rigidbody>().velocity=bullet.transform.forward*50;
		Destroy(bullet,2f);
	}
}
