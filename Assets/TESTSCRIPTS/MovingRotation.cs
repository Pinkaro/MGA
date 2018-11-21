using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRotation : MonoBehaviour
{
    private float rotationSpeed = 5.0f;
    private float translationSpeed = 0.1f;
    private Transform firepoint;

    void Awake()
    {
        firepoint = GameObject.Find("Firepoint").transform;
    }

	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKey("a"))
	    {
            transform.Rotate(Vector3.forward * -rotationSpeed);
	    }

	    if (Input.GetKey("d"))
	    {
	        transform.Rotate(Vector3.forward * rotationSpeed);
        }

	    //if (Input.GetKey("w"))
	    //{
	    //    firepoint = GameObject.Find("Firepoint").transform;
     //       transform.Translate((firepoint.position - transform.position) * translationSpeed);
	    //}

	    //if (Input.GetKey("s"))
	    //{
	    //    firepoint = GameObject.Find("Firepoint").transform;
     //       transform.Translate((firepoint.position - transform.position) * -translationSpeed);
     //   }
    }
}
