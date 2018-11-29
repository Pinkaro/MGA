using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    public GameObject Playerblueprint;

    private Vector3 spawnpoint0;
    private Vector3 spawnpoint1;
    private Vector3 spawnpoint2;
    private Vector3 spawnpoint3;

	// Use this for initialization
	void Start ()
	{
	    string[] controllers = Input.GetJoystickNames();

        Debug.Log("Controllers detected: " + controllers.Length);

	    foreach (string controller in controllers)
	    {
            Debug.Log(controller);
	    }

	    Vector2 cameraMiddle = Camera.main.ScreenToWorldPoint(new Vector2(0.5f, 0.5f));

	    spawnpoint0 = Camera.main.ScreenToWorldPoint(new Vector2(0.1f, 0.9f)); // top right

	    GameObject player = Instantiate(Playerblueprint, spawnpoint0, Quaternion.identity);
	    player.transform.right = cameraMiddle;

	}
	
	// Update is called once per frame
	void Update ()
	{

    }
}
