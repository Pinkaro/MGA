using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeamMemberController : MonoBehaviour {

    public float movementSpeed = 1.0f;

    private Vector3 dir;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector3.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir += Vector3.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir += Vector3.right;
        }

        if (dir != Vector3.zero) {
            transform.position += dir.normalized * movementSpeed * Time.deltaTime;
            dir = Vector3.zero;
        }

	}
}
