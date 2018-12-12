using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{

    public string[] TagsIgnoreCollision;

    private float damage;

    public Renderer ToDisableOnDestroy;

	// Update is called once per frame
	void Update ()
	{
	    Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
	    bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

	    if (!onScreen)
	    {
            DestroyProjectile();
	    }
    }

    public void Initiate(Vector3 travelDirection, float damage, float speed)
    {
        this.damage = damage;

        foreach (string tag in TagsIgnoreCollision)
        {
            AvoidCollisionByTag(tag);
        }

        AudioSource ammuAudio = GetComponent<AudioSource>();
        ammuAudio.Play();

        Rigidbody2D rigidBodyAmmunition = GetComponent<Rigidbody2D>();
        rigidBodyAmmunition.AddForce(travelDirection * speed, ForceMode2D.Impulse);
    }

    private void AvoidCollisionByTag(string tag)
    {
        Collider2D collider = GetComponent<Collider2D>();
        var objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (var o in objects)
        {
            Collider2D otherCollider = o.GetComponent<Collider2D>();

            Physics2D.IgnoreCollision(collider, otherCollider);
        }
    }

    public void AvoidCollisionByGameObject(GameObject gameObject)
    {
        Collider2D collider = GetComponent<Collider2D>();
        Collider2D otherCollider = gameObject.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(collider, otherCollider);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HealthManager hit = collision.gameObject.GetComponent<HealthManager>();

        hit?.ApplyHealthEffect(-damage);

        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if(ToDisableOnDestroy != null)
            ToDisableOnDestroy.enabled = false;

        if (audioSource != null)
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        else
            Destroy(gameObject);
    }
}
