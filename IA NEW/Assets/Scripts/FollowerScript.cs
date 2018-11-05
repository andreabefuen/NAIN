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
                theAnimator.SetBool("isWalking", true);

                transform.LookAt(positionPlayer);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else
            {
                theAnimator.SetBool("isWalking", false);
            }
        }
        if (free) {
            RaycastHit[] hit;
            hit = Physics.RaycastAll(transform.position, player.transform.position, Mathf.Infinity);
           
            if (hit.Length >= 1)
            {
                   if (hit[0].transform.tag == "Player")
                    {
                        Debug.Log("Player hit");

                        positionPlayer = hit[0].transform;
                    }
            }
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {//si come comida crece si te come gameover
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            positionPlayer = player.transform;
            ToPlayer = true;
            free = true;
        }
        
    }
    public void Death()
    {
        theAnimator.SetTrigger("die");
    }
}
