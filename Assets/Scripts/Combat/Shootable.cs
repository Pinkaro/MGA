using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Shootable : MonoBehaviour
{
    public GameObject Ammunition;

    [Range(0.0f, 20.0f)]
    public float Firerate = 1.0f;

    [Range(0.0f, 1.0f)]
    public float Spread = 1.0f;

    [Range(1.0f, 20.0f)]
    public float Damage = 1.0f;

    [Range(1.0f, 20.0f)]
    public float Speed = 1.0f;

    private Transform firePoint;
    private float timeToFire;
    private string playerId;

	// Use this for initialization
	void Awake ()
	{
	    firePoint = gameObject.transform.Find("Firepoint");
	    ProjectileLogic projectileLogic = Ammunition.GetComponent<ProjectileLogic>();

        // to ensure ammunition flies faster than players
	    PlayerSpaceshipController shipController = GetComponent<PlayerSpaceshipController>();
	    Speed += shipController.AccelerationForce;
	    
	    playerId = shipController.Player;

	    if(firePoint == null) Debug.LogError("Firepoint was null. Is child missing or named wrong?");
        if(projectileLogic == null) Debug.LogError("Ammunition does not have ProjectileLogic component.");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Firerate == 0.0f) // Shoot on click
	    {
	        if (Input.GetAxis($"Fire1_{playerId}") > 0.0f)
	        {
	            Shoot();
	        }
        }
	    else
	    {
	        if ((Input.GetAxis($"Fire1_{playerId}") > 0.0f) && Time.time > timeToFire)
	        {
	            timeToFire = Time.time + 1 / Firerate;
                Shoot();
	        }
	    }
	}

    private void Shoot()
    {
        GameObject ammu = Instantiate(Ammunition, firePoint.position, firePoint.rotation);
        ProjectileLogic ammuLogic = ammu.GetComponent<ProjectileLogic>();
        ammuLogic.AvoidCollisionByGameObject(gameObject);

        float currentSpread = UnityEngine.Random.Range(-Spread, Spread);

        Vector3 travelDirection = (firePoint.position - transform.position);
        Vector3 travelDirectionSpread = new Vector3(travelDirection.x + currentSpread, travelDirection.y + currentSpread);

        ammuLogic.Initiate(travelDirectionSpread, Damage, Speed);
    }
}
