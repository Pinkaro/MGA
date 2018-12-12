using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    public bool SpawnMock = false;
    // Use this for initialization
	void Start ()
	{
	    if (SpawnMock)
	    {
	        PlayerManager.instance.GenerateMockPlayer();
        }
	    else
	    {
	        PlayerManager.instance.LogControllerInfo();
	        PlayerManager.instance.GeneratePlayers();
        }

	    //Debug.Log("IF YOU READ THIS: I TURNED ON MOCK GENERATION INSTEAD OF NORMAL AND PROBABLY FORGOT TO REMOVE IT AGAIN. SAY HI TO ME!\n-Alex");

        //
    }
}
