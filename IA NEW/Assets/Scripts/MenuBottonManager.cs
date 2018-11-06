using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottonManager : MonoBehaviour
{


    private string FirstLevel = "MainScene";

    private string SecondLevel = "Level02";
    private string ThirdLevel = "Level03";

    private string Menu = "Menu";

    public GameObject pausePanel;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene(FirstLevel);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        
    }

    public void OnSecondLevel()
    {
        SceneManager.LoadScene(SecondLevel);
    }

    public void OnThirdLevel()
    {
        SceneManager.LoadScene(ThirdLevel);
    }

    public void OnMenu() {
        SceneManager.LoadScene(Menu);
    }

    public void OnBack()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);

    }

}
