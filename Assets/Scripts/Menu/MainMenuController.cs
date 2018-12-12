using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MenuController
{

    public GameObject menu;
    public GameObject credits;

    public void Start()
    {
        credits.GetComponent<Canvas>().enabled = false;
        menu.GetComponent<Canvas>().enabled = true;
    }

    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        Debug.Log("Credits da");
        credits.GetComponent<Canvas>().enabled = true;
        menu.GetComponent<Canvas>().enabled = false;
    }

    public void HideCredits()
    {
        Debug.Log("Credits weg");
        credits.GetComponent<Canvas>().enabled = false;
        menu.GetComponent<Canvas>().enabled = true;
    }

    public void ShowMenu()
    {
        Debug.Log("Menu");
        menu.GetComponent<Canvas>().enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
