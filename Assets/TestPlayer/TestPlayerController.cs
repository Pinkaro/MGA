using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{

    public GameObject target;

    public float acceleration = 0.0f;

    public float startMovementSpeed = 1.0f;

    public float margin = 1.0f;

    float movementSpeed = 1.0f;

    private Vector3 newPos;

    // Use this for initialization
    void Start()
    {
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (((newPos.x - transform.position.x) > margin) || ((newPos.y - transform.position.y) > margin))
        {
            movementSpeed = startMovementSpeed;
        }



        newPos = transform.position;

        movementSpeed += acceleration;

        newPos.x += ((transform.position.x - target.transform.position.x) / Mathf.Abs(transform.position.x - target.transform.position.x)) * movementSpeed * Time.deltaTime;

        newPos.y += ((transform.position.y - target.transform.position.y) / Mathf.Abs(transform.position.y - target.transform.position.y)) * movementSpeed * Time.deltaTime;

    }
}
