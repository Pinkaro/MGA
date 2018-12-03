using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    public GameObject Playerblueprint;
    public int WidthDivisor;
    public int HeightDivisor;

    private Vector3 spawnpoint1;
    private Vector3 spawnpoint2;
    private Vector3 spawnpoint3;
    private Vector3 spawnpoint4;


	// Use this for initialization
	void Start ()
	{
	    string[] controllers = Input.GetJoystickNames();

        Debug.Log("Controllers detected: " + controllers.Length);

	    foreach (string controller in controllers)
	    {
            Debug.Log(controller);
	    }

	    Camera mainCam = Camera.main;

	    Vector3 cameraMiddle = mainCam.ScreenToWorldPoint(new Vector2(mainCam.pixelWidth / 2, mainCam.pixelHeight / 2));
	    cameraMiddle.z = 0.0f;

	    int partWidthIndention = mainCam.pixelWidth / WidthDivisor;
	    int partHeightIndention = mainCam.pixelHeight / HeightDivisor;

	    Vector3 bottomLeft = new Vector3(partWidthIndention, partHeightIndention, 0.0f);
        Vector3 bottomRight = new Vector3(mainCam.pixelWidth - partWidthIndention, partHeightIndention, 0.0f);
	    Vector3 topLeft = new Vector3(partWidthIndention, mainCam.pixelHeight - partHeightIndention, 0.0f);
	    Vector3 topRight = new Vector3(mainCam.pixelWidth - partWidthIndention, mainCam.pixelHeight - partHeightIndention, 0.0f);

        spawnpoint1 = mainCam.ScreenToWorldPoint(bottomLeft);
	    spawnpoint1.z = 0.0f;

	    spawnpoint2 = mainCam.ScreenToWorldPoint(bottomRight);
	    spawnpoint2.z = 0.0f;

	    spawnpoint3 = mainCam.ScreenToWorldPoint(topLeft);
	    spawnpoint3.z = 0.0f;

	    spawnpoint4 = mainCam.ScreenToWorldPoint(topRight);
	    spawnpoint4.z = 0.0f;

	    GameObject player1 = Instantiate(Playerblueprint, spawnpoint1, Quaternion.identity);
	    player1.transform.up = cameraMiddle - spawnpoint1;

	    GameObject player2 = Instantiate(Playerblueprint, spawnpoint2, Quaternion.identity);
	    player2.transform.up = cameraMiddle - spawnpoint2;

	    GameObject player3 = Instantiate(Playerblueprint, spawnpoint3, Quaternion.identity);
	    player3.transform.up = cameraMiddle - spawnpoint3;

	    GameObject player4 = Instantiate(Playerblueprint, spawnpoint4, Quaternion.identity);
	    player4.transform.up = cameraMiddle - spawnpoint4;
    }
	
	// Update is called once per frame
	void Update ()
	{

    }
}
