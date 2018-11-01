using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottonManager : MonoBehaviour
{

    public string FirstLevel;


    public void OnStartButton()
    {
        SceneManager.LoadScene(FirstLevel);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

}
