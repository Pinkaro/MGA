using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLogic : MonoBehaviour
{
    public Transform PullTowards;
    public string[] AvoidTagCollision;

    [Range(0.0f, 10.0f)]
    public float PullForce;

    private Collider2D thisCollider;
    private GameObject objectToPull;
    private bool pullableObjectEntered = false;
    private Vector3 pullDirection;
    private Rigidbody2D otherRb;

    void Awake ()
    {
        thisCollider = GetComponent<Collider2D>();

        foreach (string tag in AvoidTagCollision)
        {
            AvoidCollisionByTag(tag);
        }
    }

    void Update()
    {
        if (pullableObjectEntered)
        {
            otherRb = objectToPull.GetComponent<Rigidbody2D>();
            pullDirection = PullTowards.position - objectToPull.transform.position;

            otherRb.AddForce(pullDirection * PullForce);
        }
    }

    private void AvoidCollisionByTag(string tag)
    {
        var objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (var o in objects)
        {
            Collider2D otherCollider = o.GetComponent<Collider2D>();

            Physics2D.IgnoreCollision(thisCollider, otherCollider);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[TRACTOR BEAM] PULL");
        pullableObjectEntered = true;
        objectToPull = collision.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        pullableObjectEntered = false;
    }
}
