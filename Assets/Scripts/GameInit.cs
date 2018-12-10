using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    // Use this for initialization
	void Start ()
	{
        PlayerManager.instance.LogControllerInfo();
	    //PlayerManager.instance.GeneratePlayers();

	    Debug.Log(
	        "IF YOU READ THIS: I TURNED ON MOCK GENERATION INSTEAD OF NORMAL AND PROBABLY FORGOT TO REMOVE IT AGAIN. SAY HI TO ME!\n-Alex");

        PlayerManager.instance.GenerateMockPlayer();
    }
}
