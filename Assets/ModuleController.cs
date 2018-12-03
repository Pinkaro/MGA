using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModuleController : MonoBehaviour
{
    public bool moving;

    protected Vector3 dir;

    protected float movementSpeed = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (this.moving)
	    {
	        this.Move();
        }
    }

    protected abstract void Move();

    protected abstract void Action();
}
