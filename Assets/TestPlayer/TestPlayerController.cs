using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{

    public GameObject target;

    public float acceleration = 1.0f;

    public float startMovementSpeed = 1.0f;

    public float margin = 1.0f;

    public float movementSpeed = 1.0f;

    private Vector3 newPos;
    private float lastDif = 0;

    // Use this for initialization
    void Start()
    {
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Delta X: " + (newPos.x - transform.position.x));
        //Debug.Log("Delta Y: " + (newPos.y - transform.position.y));



        newPos = transform.position;

        //Debug.Log("Old pos: " + newPos.x);

        newPos += (target.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime;

        //movementSpeed += acceleration;

        //Debug.Log((lastDif - (target.transform.position - newPos).magnitude));
        //Debug.Log((target.transform.position - transform.position).magnitude);
        if ((target.transform.position - transform.position).magnitude < margin)// || (Mathf.Abs((lastDif - (target.transform.position - newPos).magnitude)) < margin))
        {
            //Debug.Log("Reset!");
            movementSpeed = startMovementSpeed;
        }
        else
        {
            transform.position = newPos;
        }

        lastDif = (target.transform.position - transform.position).magnitude;

        //Debug.Log("New pos: " + newPos.x);
    }
}
