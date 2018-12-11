using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject menu;
    public GameObject credits;

    public void Start()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        Debug.Log("Credits da");
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void HideCredits()
    {
        Debug.Log("Credits weg");
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void ShowMenu()
    {
        Debug.Log("Menu");
        menu.SetActive(true);
    }
}
