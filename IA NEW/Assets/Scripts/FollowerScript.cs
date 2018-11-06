using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour {

    GameObject player;
    float speed = 8f;
    public bool ToPlayer, free;
    Animator theAnimator;
    float visionRange = 40f;
    private Vector3 positionPlayer;

    void Start()
    {
        theAnimator = GetComponent<Animator>();
        ToPlayer = false;
        free = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ToPlayer)
        {
            if (Mathf.Abs(Vector3.Distance(this.transform.position, positionPlayer)) > 0.1 && Mathf.Abs(Vector3.Distance(this.transform.position, player.transform.position)) > 7)
            {
                theAnimator.SetBool("isWalking", true);

                transform.LookAt(positionPlayer);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else
            {
                ToPlayer = false;
                theAnimator.SetBool("isWalking", false);
            }
        }
       if (free) {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, player.transform.position, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    positionPlayer = hit.transform.position;
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
            positionPlayer = player.transform.position;
            ToPlayer = true;
            free = true;
        }
        
    }
    public void Death()
    {
        theAnimator.SetTrigger("die");
    }
}
