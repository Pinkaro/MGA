using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

public class PlayerSpaceshipController : MonoBehaviour
{
    
    public string PlayerId;

    public Shootable shootable;

    public GameObject PlayerInDiscPrefab;

    [Range(1.0f, 10.0f)]
    public float rotationSpeed = 5.0f;

    [Range(1.0f, 20.0f)]
    public float AccelerationForce = 10.0f;

    [Range(1.0f, 0.0f)]
    public float BrakeForce = 0.95f;

    [Range(1.0f, 0.0f)]
    public float SlowBrakeForce = 0.98f;

    [Range(1.0f, 0.0f)]
    public float BrakeThreshold = 0.7f;

    [Range(1.0f, 20.0f)]
    public float TurnModifier = 10.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootable = GetComponent<Shootable>();
    }

    void FixedUpdate ()
    {
	    if (Input.GetAxis($"Horizontal_{PlayerId}") != 0)
	    {
	        Turn();
	    }

	    if (Input.GetAxis($"Accelerate_{PlayerId}") > 0)
	    {
	        Accelerate(Input.GetAxisRaw($"Accelerate_{PlayerId}"));
        }
	    else
	    {
	        Brake(SlowBrakeForce);
	    }

	    if (Input.GetButton($"Brake_{PlayerId}"))
	    {
	        Brake(BrakeForce);
	    }
    }

    void Update()
    {
        if ((Input.GetAxis($"Fire1_{PlayerId}") > 0))
        {
            shootable.Shoot();
        }
    }

    void OnDestroy()
    {
        PlayerGenerator.instance.SpawnPlayerInDisc(PlayerId, GetComponent<SpriteRenderer>().color);
    }

    private void Turn()
    {
        var rotation = rotationSpeed * -Input.GetAxisRaw($"Horizontal_{PlayerId}");
        var magnitude = rb.velocity.magnitude/TurnModifier;
        var speed = magnitude >= 1 ? magnitude : 1;
        rotation /= speed;
        transform.Rotate(Vector3.forward * (rotation));
    }

    private void Accelerate(float force)
    {
        //Debug.Log("Accelerate");
        rb.AddRelativeForce(new Vector2(0, 1) * AccelerationForce * force, ForceMode2D.Force);
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
