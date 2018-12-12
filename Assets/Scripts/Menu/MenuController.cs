using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    protected static string currentPlayerId;


    public void Start()
    {
        Debug.Log("Finding input");

        string[] controllerNames = Input.GetJoystickNames();
        
        for (int i = 0; i < controllerNames.Length; i++)
        {
            if (string.IsNullOrEmpty(controllerNames[i]))
                continue;
            
            currentPlayerId = PlayerManager.GeneratePlayerId(i + 1, controllerNames[i]); // so we map it to the correct joyNum in InputManager
            Debug.Log(currentPlayerId);
            break;
        }
    }

}
