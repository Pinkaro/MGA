using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameEndMenu : MenuController
{

    public StandaloneInputModule eventSystem;

    new public void Start()
    {
        base.Start();


        eventSystem.verticalAxis = "Vertical_" + currentPlayerId;
        eventSystem.horizontalAxis = "Horizontal_" + currentPlayerId;
        eventSystem.submitButton = "MenuSubmit_" + currentPlayerId;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
