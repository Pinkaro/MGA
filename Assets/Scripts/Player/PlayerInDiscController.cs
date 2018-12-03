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

    public bool remoteControl;

    private ModuleController moduleController;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool RegisterModule(ModuleController module)
    {
        this.remoteControl = true;
        if (module != null)
        {
            module.Player = Player;
            moduleController = module;
            return true;
        }
        this.remoteControl = false;
        return false;
    }

    public void clearModule()
    {
        if (moduleController != null)
        {
            moduleController.Player = string.Empty;
        }

        this.remoteControl = false;
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

            if (Input.GetAxis($"Fire1_{Player}") > 0)
            {

            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        if (Input.GetButton($"Brake_{Player}"))
        {
            clearModule();
        }
    }
}
