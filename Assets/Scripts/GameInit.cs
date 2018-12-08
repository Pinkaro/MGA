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
	    PlayerManager.instance.GeneratePlayers();
    }
}
