using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour {

    GameObject player;
    float speed = 6f;
    public bool ToPlayer, free;
    Animator theAnimator;
    float visionRange = 40f;
    private Transform positionPlayer;

    void Start()
    {
        theAnimator = GetComponent<Animator>();
        ToPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //define comportamiento del enemigo segun su tamaño
        if (ToPlayer)
        {
            if (Mathf.Abs(Vector3.Distance(this.transform.position, positionPlayer.position)) > 0 && Mathf.Abs(Vector3.Distance(this.transform.position, player.transform.position)) > 7)
            {
                transform.LookAt(positionPlayer);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else
            {
                theAnimator.SetBool("isWalking", false);
            }
        }
        if (free) { 
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.transform.position, out hit, visionRange))
            {
                if (hit.transform.tag == "Player")
                {
                    positionPlayer = hit.transform;
                    ToPlayer = true;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {//si come comida crece si te come gameover
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            positionPlayer.position = other.gameObject.transform.position;
            ToPlayer = true;
            free = true;
        }
        
    }
    public void Death()
    {
        theAnimator.SetTrigger("die");
    }
}
