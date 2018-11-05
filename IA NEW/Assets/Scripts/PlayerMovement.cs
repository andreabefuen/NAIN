using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	private Rigidbody rb;
	private float velocidad,timer, energy;
    bool[] directions;
    bool run;
    public bool Dash;
    Animator theAnimator;
    public Image Fill;
    public Slider EnergySlider;
    public GameObject GameOverPanel, PausePanel;

    public AudioSource audioMorir;
    public AudioSource audioJuego;
    public AudioClip audioGameOver;

    // Use this for initialization
    void Awake () {
        Time.timeScale = 1;
        theAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody> ();
		velocidad = 10f;
        directions = new bool[4];
		run = false;
        Dash = false;
        energy = 100;
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


        if (run && !Dash)
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
        else
        {
            theAnimator.SetBool("isWalking", false);

        }
        if (energy< 100)
        {
            energy += Time.deltaTime * 10;
        }
        Fill.color = Color.Lerp(Color.red, Color.green, energy / 100);
        EnergySlider.value = energy;

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
        {   if (energy > 50 && !Dash)
            {
                energy -= 50;
                theAnimator.SetTrigger("dash");
                timer = 0;
                Dash = true;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void Death()
    {
        theAnimator.SetTrigger("die");
        GameOverPanel.SetActive(true);
        audioJuego.Stop();
        audioMorir.Play();
       

        //Para que de tiempo a que la animación se vea
        Invoke("DeathTime", 1f);
        
    }
    public void Attack()
    {
        if (!Dash)
        {
            Death();
        }
    }
    public void Press()
    {
        Debug.Log("Press");
        theAnimator.SetTrigger("pressButton");

    }
    void PauseGame()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    void DeathTime()
    {


        Time.timeScale = 0;

    }
}
