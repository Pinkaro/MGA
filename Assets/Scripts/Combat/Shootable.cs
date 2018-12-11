using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Shootable : MonoBehaviour
{
    public GameObject[] Ammunition;

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
    private System.Random rand;

	// Use this for initialization
	void Awake ()
	{
	    firePoint = gameObject.transform.Find("Firepoint");
	    rand = new System.Random();

        // to ensure ammunition flies faster than players
	    PlayerSpaceshipController shipController = GetComponent<PlayerSpaceshipController>();
	    if (shipController != null)
	    {
	        //Speed += shipController.AccelerationForce;
	        playerId = shipController.PlayerId;
        }
	    
	    if(firePoint == null) Debug.LogError("Firepoint was null. Is child missing or named wrong?");
        

	    ProjectileLogic projectileLogic = null;

        foreach (GameObject ammuType in Ammunition)
	    {
            projectileLogic = ammuType.GetComponent<ProjectileLogic>();

	        if (projectileLogic == null) Debug.LogError("Ammunition \"" + ammuType.name + "\" does not have ProjectileLogic component.");
        }
	}

    public void Shoot(float projectileSize = 5, float soundVolume = 0.1f)
    {
        if (Time.time > timeToFire)
        {
            if (Firerate > 0)
            {
                timeToFire = Time.time + 1 / Firerate;
            }

            int randomAmmo = rand.Next(0, Ammunition.Length);

            GameObject ammu = Instantiate(Ammunition[randomAmmo], firePoint.position, firePoint.rotation);
            ammu.transform.localScale = new Vector3(projectileSize,projectileSize,1);
            ammu.transform.Rotate(new Vector3(0,0,-90));

            ammu.GetComponent<AudioSource>().volume = soundVolume;

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
