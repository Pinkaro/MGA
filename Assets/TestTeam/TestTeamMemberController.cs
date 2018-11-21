using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeamMemberController : MonoBehaviour {

    public float movementSpeed = 1.0f;

    private Vector3 newPos;

    // Use this for initialization
    void Start () {
        newPos = transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        newPos = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos.y += movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPos.y -= movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPos.x -= movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPos.x += movementSpeed * Time.deltaTime;
        }

        transform.position = newPos;

	}
}
