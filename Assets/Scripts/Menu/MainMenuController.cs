using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void ShowCredits()
    {
        Debug.Log("Credits");
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void ShowMenu()
    {
        Debug.Log("Menu");
        menu.SetActive(true);
    }
}
