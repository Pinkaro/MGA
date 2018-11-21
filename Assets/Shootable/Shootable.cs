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

	// Use this for initialization
	void Awake ()
	{
	    firePoint = GameObject.Find("Firepoint").transform;
	    ProjectileLogic projectileLogic = Ammunition.GetComponent<ProjectileLogic>();


	    if(firePoint == null) Debug.LogError("Firepoint was null. Is child missing or named wrong?");
        if(projectileLogic == null) Debug.LogError("Ammunition does not have ProjectileLogic component.");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Firerate == 0.0f) // Shoot on click
	    {
	        if (Input.GetMouseButton(0))
	        {
	            Shoot();
	        }
        }
	    else
	    {
	        if (Input.GetMouseButton(0) && Time.time > timeToFire)
	        {
	            timeToFire = Time.time + 1 / Firerate;
                Shoot();
	        }
	    }
	}

    private void Shoot()
    {
        GameObject ammu = Instantiate(Ammunition, firePoint.position, firePoint.rotation);

        float currentSpread = UnityEngine.Random.Range(-Spread, Spread);

        Vector3 travelDirection = (firePoint.position - transform.position);
        Vector3 travelDirectionSpread = new Vector3(travelDirection.x + currentSpread, travelDirection.y + currentSpread);

        ammu.GetComponent<ProjectileLogic>().Initiate(travelDirectionSpread, Damage, Speed);
    }
}
