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
	    if (shipController != null)
	    {
	        Speed += shipController.AccelerationForce;
	        playerId = shipController.Player;
        }
	    
	    
	    

	    if(firePoint == null) Debug.LogError("Firepoint was null. Is child missing or named wrong?");
        if(projectileLogic == null) Debug.LogError("Ammunition does not have ProjectileLogic component.");
	}

    public void Shoot()
    {
        if (Time.time > timeToFire)
        {
            if (Firerate > 0)
            {
                timeToFire = Time.time + 1 / Firerate;
            }
            GameObject ammu = Instantiate(Ammunition, firePoint.position, firePoint.rotation);
            ProjectileLogic ammuLogic = ammu.GetComponent<ProjectileLogic>();
            ammuLogic.AvoidCollisionByGameObject(gameObject);

            float currentSpread = UnityEngine.Random.Range(-Spread, Spread);

            Vector3 travelDirection = (firePoint.position - transform.position);
            Vector3 travelDirectionSpread =
                new Vector3(travelDirection.x + currentSpread, travelDirection.y + currentSpread);

            ammuLogic.Initiate(travelDirectionSpread, Damage, Speed);
        }
    }
}
