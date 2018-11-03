using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour {

    GameObject player;
    float speed = 6f;
    public bool ToPlayer;
    Animator theAnimator;
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
            if (Mathf.Abs(Vector3.Distance(this.transform.position, player.transform.position)) > 7)
            {
                theAnimator.SetBool("isWalking",true);
                transform.LookAt(player.transform.position);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else
            {
                theAnimator.SetBool("isWalking", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {//si come comida crece si te come gameover
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            ToPlayer = true;
        }
        
    }
    public void Death()
    {
        theAnimator.SetTrigger("die");
    }
}
