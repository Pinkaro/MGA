using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInDiscController : MonoBehaviour
{
    public string Player;

    private Rigidbody2D rb;
    [Range(1.0f, 20.0f)]
    public float MovementSpeed = 1.0f;

    private Vector3 dir;

    private bool remoteControl;

    private GameObject module;

    private ModuleController moduleController;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool RegisterModule(GameObject module)
    {
        this.remoteControl = true;
        this.module = module;
        this.moduleController = this.module.GetComponent<ModuleController>();
        if (this.moduleController != null)
        {
            return true;
        }
        this.remoteControl = false;
        this.module = null;
        return false;
    }

    public void clearModule()
    {
        this.remoteControl = false;
        if (this.moduleController != null)
        {
            this.moduleController.moving = false;
        }
        this.module = null;
        this.moduleController = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!this.remoteControl)
        {
            rb.velocity = 
                MovementSpeed * new Vector2(Input.GetAxis($"Horizontal_{Player}"), -Input.GetAxis($"Vertical_{Player}")).normalized;


            if (Input.GetAxis($"Accelerate_{Player}") > 0)
            {
                
            }

            if (Input.GetButton($"Brake_{Player}"))
            {
                
            }

            if (Input.GetButton($"Fire1_{Player}"))
            {
                
            }
        }
        if (this.remoteControl)
        {
            this.moduleController.moving = true;
        }
    }
}
