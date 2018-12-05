using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    // Use this for initialization
	void Start ()
	{
	    PlayerGenerator playerGenerator = GetComponent<PlayerGenerator>();
        playerGenerator.LogControllerInfo();
        //playerGenerator.GeneratePlayers();


	}
	
	// Update is called once per frame
	void Update ()
	{

    }
}
