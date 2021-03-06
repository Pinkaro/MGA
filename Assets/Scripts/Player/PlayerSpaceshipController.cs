﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PlayerSpaceshipController : MonoBehaviour, IKillable
{

    public string PlayerId;

    public Shootable shootable;

    public ParticleSystem DeathParticleSystem;
    public ParticleSystem TrailParticleSystem;
    public Color color;

    [Range(1.0f, 10.0f)] public float rotationSpeed = 5.0f;

    [Range(1.0f, 20.0f)] public float AccelerationForce = 10.0f;

    [Range(1.0f, 0.0f)] public float BrakeForce = 0.95f;

    [Range(1.0f, 0.0f)] public float SlowBrakeForce = 0.98f;

    [Range(1.0f, 0.0f)] public float BrakeThreshold = 0.7f;

    [Range(1.0f, 20.0f)] public float TurnModifier = 10.0f;

    private Rigidbody2D rb;
    [HideInInspector] public bool _canMove = true;

    [HideInInspector] public bool _isSlowed = false;

    public HealthManager HealthManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootable = GetComponent<Shootable>();
    }

    void FixedUpdate()
    {
        if (_canMove)
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
    }

    void Update()
    {
        if (_canMove)
        {
            if ((Input.GetAxis($"Fire1_{PlayerId}") > 0))
            {
                shootable.Shoot();
            }
        }
    }

    public void Die()
    {
        if (_canMove)
        {
            color = GetComponent<SpriteRenderer>().color;
            PlayerManager.instance.PlayerDeath(this);
            GetComponent<Collider2D>().enabled = false;
            Destroy(TrailParticleSystem);
            shootable.enabled = false;
            DeathParticleSystem?.Play();
            _canMove = false;
            StartCoroutine("DieDelay");
            StartCoroutine("ColorDecay");
        }
    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    IEnumerator ColorDecay()
    {
        var sprite = GetComponent<SpriteRenderer>();
        while (true)
        {
            var col = sprite.color;
            col.a -= 0.1f;
            sprite.color = col;
            transform.localScale *= 0.9f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Turn()
    {
        var rotation = rotationSpeed * -Input.GetAxisRaw($"Horizontal_{PlayerId}");
        var magnitude = rb.velocity.magnitude / TurnModifier;
        var speed = magnitude >= 1 ? magnitude : 1;
        rotation /= speed;
        transform.Rotate(Vector3.forward * (rotation));
    }

    private void Accelerate(float force)
    {
        //Debug.Log("Accelerate");
        var actualForce = AccelerationForce * force;
        if (_isSlowed) actualForce *= 0.5f;
        rb.AddRelativeForce(new Vector2(0, 1) * actualForce, ForceMode2D.Force);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SlowAmmu")
        {
            Debug.Log("SLOWED");
            _isSlowed = true;
            rb.velocity *= 0.5f;
        }
    }

    private void OnTriggerLeave2D(Collider2D other)
    {
        if (other.tag == "SlowAmmu")
        {
            _isSlowed = false;
        }
    }
}
