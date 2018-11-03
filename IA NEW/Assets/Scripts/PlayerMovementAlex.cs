using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAlex : MonoBehaviour {
	private Rigidbody rb;
	private float velocidad,timer;
    bool[] directions;
    bool run;
    public bool Dash;
    Animator theAnimator;

    // Use this for initialization
    void Awake () {
        theAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody> ();
		velocidad = 10f;
        directions = new bool[4];
		run = false;
        Dash = false;
	}
	
	// Update is called once per frame
	void Update () {
        KeysPress();
        
      

        if (directions[0] && !directions[1] && !directions[2] && !directions[3])
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        else if (!directions[0] && directions[1] && !directions[2] && !directions[3])
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (!directions[0] && !directions[1] && directions[2] && !directions[3])
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (!directions[0] && !directions[1] && !directions[2] && directions[3])
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (directions[0] && directions[1] && !directions[2] && !directions[3])
        {
            transform.eulerAngles = new Vector3(0, 315, 0);
        }
        else if (!directions[0] && directions[1] && directions[2] && !directions[3])
        {
            transform.eulerAngles = new Vector3(0, 45, 0);
        }
        else if (!directions[0] && !directions[1] && directions[2] && directions[3])
        {
            transform.eulerAngles = new Vector3(0, 135, 0);
        }
        else if (directions[0] && !directions[1] && !directions[2] && directions[3])
        {
            transform.eulerAngles = new Vector3(0, 225, 0);
        }


        if (run)
        {
            theAnimator.SetBool("isWalking", true);
            transform.Translate(0, 0, velocidad * Time.deltaTime);
        }
        else if(Dash)
        {
            timer += Time.deltaTime;
            transform.Translate(0, 0, (velocidad*2) * Time.deltaTime);
            if(timer >= 1)
            {
                Dash = false;
            }

        }


    }
    void KeysPress()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            directions[0] = true;
        }
        else
        {
            directions[0] = false;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            directions[1] = true;
        }
        else
        {
            directions[1] = false;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            directions[2] = true;
        }
        else
        {
            directions[2] = false;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            directions[3] = true;
        }
        else
        {
            directions[3] = false;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            run = true;
        }
        else
        {
            run = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            theAnimator.SetTrigger("dash");
            timer = 0;
            Dash = true;
        }
    }
    public void Death()
    {
        theAnimator.SetTrigger("die");
    }


}
