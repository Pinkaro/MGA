using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModuleController : MonoBehaviour
{
    public string Player;

    protected float movementSpeed = 1.0f;
    
	// Update is called once per frame
	void Update () {
	    if (!string.IsNullOrWhiteSpace(Player))
	    {
	        if (Input.GetAxis($"Vertical_{Player}") != 0)
	        {
	            Vertical(Input.GetAxis($"Vertical_{Player}"));
	        }

	        if (Input.GetAxis($"Horizontal_{Player}") != 0)
	        {
	            Horizontal(Input.GetAxis($"Horizontal_{Player}"));
	        }

	        if (Input.GetAxis($"Accelerate_{Player}") > 0)
	        {
	            Accelerate(Input.GetAxis($"Accelerate_{Player}"));
	        }

	        if (Input.GetAxis($"Fire1_{Player}") > 0)
	        {
                Fire1Press();
	        }

	        if (Input.GetAxis($"Fire1_{Player}") == 0)
	        {
                Fire1Release();
	        }
	    }
	}
    protected virtual void Vertical(float input)
    {

    }

    protected virtual void Horizontal(float input)
    {

    }

    protected virtual void Accelerate(float input)
    {
        
    }

    protected virtual void Fire1Press()
    {
        
    }
    protected virtual void Fire1Release()
    {

    }
}
