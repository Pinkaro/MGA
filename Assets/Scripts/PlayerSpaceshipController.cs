using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceshipController : MonoBehaviour
{

    public string Player;

    private float rotationSpeed = 5.0f;
    private float translationSpeed = 0.1f;
    private float AccelerationForce = 20f;
    private float BrakeForce = 0.95f;
    private float SlowBrakeForce = 0.98f;
    private float BrakeThreshold = 0.7f;
    private float TurnModifier = 10;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        string[] controllers = Input.GetJoystickNames();

        Debug.Log("Controllers detected: " + controllers.Length);

        foreach (string controller in controllers)
        {
            Debug.Log(controller);
        }
    }

    void FixedUpdate () {
	    if (Input.GetAxis("Horizontal_" + Player) != 0)
	    {
	        Turn();
	    }

	    if (Input.GetAxis("Accelerate_" + Player) > 0)
	    {
	        Accelerate();
        }
	    else
	    {
	        Brake(SlowBrakeForce);
	    }

	    if (Input.GetButton("Brake_" + Player))
	    {
	        Brake(BrakeForce);
	    }
    }

    private void Turn()
    {
        var rotation = rotationSpeed * -Input.GetAxisRaw("Horizontal_" + Player);
        var magnitude = rb.velocity.magnitude/TurnModifier;
        var speed = magnitude >= 1 ? magnitude : 1;
        rotation /= speed;
        transform.Rotate(Vector3.forward * (rotation));
    }

    private void Accelerate()
    {
        //Debug.Log("Accelerate");
        rb.AddRelativeForce(new Vector2(0, AccelerationForce), ForceMode2D.Force);
    }

    private void Brake(float brakeForce)
    {
        //Debug.Log("Brake");
        if (rb.velocity.magnitude > BrakeThreshold)
        {
            rb.velocity *= brakeForce;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }
}
