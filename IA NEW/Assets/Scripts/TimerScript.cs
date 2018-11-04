using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float timer;
    public Text TimeText;
    // Use this for initialization
    void Start()
    {
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        int min = (int)timer / 60;
        TimeText.text = "Time: " + min.ToString("00") + ":" + seconds.ToString("00");
    }
}
