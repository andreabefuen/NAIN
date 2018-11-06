using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public GameObject CompletePanel;
    public float dist = 30;
    GameObject[] Hostages;
    // Start is called before the first frame update
    void Start()
    {
        Hostages = GameObject.FindGameObjectsWithTag("Follower");
        Debug.Log(Hostages.Length);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Hostages.Length > 0)
            {
                int count = 0;
                foreach (GameObject hos in Hostages)
                {
                    if (hos.GetComponent<FollowerScript>().ToPlayer)
                    {
                        count++;
                    }
                }
                if (Hostages.Length <= count)
                {
                    CompletePanel.SetActive(true);
                    Time.timeScale = 0;
                }
            }
            else
            {
                CompletePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
