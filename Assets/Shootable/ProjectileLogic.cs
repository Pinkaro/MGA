using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{

    private Vector3 travelDirection;

    private float damage;

    private float speed;
	
	// Update is called once per frame
	void Update ()
	{
	    Rigidbody2D rigidBodyAmmunition = GetComponent<Rigidbody2D>();
	    rigidBodyAmmunition.AddForce(travelDirection * speed);

	    Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
	    bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

	    if (!onScreen)
	    {
            Destroy(this.gameObject);
	    }
    }

    public void Initiate(Vector3 travelDirection, float damage, float speed)
    {
        this.travelDirection = travelDirection;
        this.damage = damage;
        this.speed = speed;

        AvoidCollision("Ammunition");
    }

    private void AvoidCollision(string tag)
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        var objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (var o in objects)
        {
            CircleCollider2D otherCollider = o.GetComponent<CircleCollider2D>();

            Physics2D.IgnoreCollision(collider, otherCollider);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HealthManager hit = collision.gameObject.GetComponent<HealthManager>();

        hit.ApplyHealthEffect(-damage);

        Destroy(this.gameObject);
    }
}
