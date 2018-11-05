using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public GameObject CompletePanel;
    public float dist = 30;
    GameObject[] Hostages = new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        Hostages = GameObject.FindGameObjectsWithTag("Follower");

        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    if (Mathf.Abs(Vector3.Distance(this.transform.position, hos.transform.position)) <= dist)
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
