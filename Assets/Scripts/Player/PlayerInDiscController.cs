using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInDiscController : MonoBehaviour
{
    [HideInInspector]
    public string PlayerId;

    private Rigidbody2D rb;

    [Range(1.0f, 20.0f)]
    public float MovementSpeed = 5.0f;

    private Vector3 dir;

    public bool remoteControl;

    private ModuleController moduleController;

    [HideInInspector]
    public bool _canMove = true;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool RegisterModule(ModuleController module)
    {
        this.remoteControl = true;
        if (module != null)
        {
            module.Player = PlayerId;
            module.colorRenderer.color = spriteRenderer.color;
            moduleController = module;
            return true;
        }
        this.remoteControl = false;
        return false;
    }

    public void ClearModule()
    {
        if (moduleController != null)
        {
            moduleController.Player = string.Empty;
            moduleController.colorRenderer.color = Color.white;
        }

        this.remoteControl = false;
        this.moduleController = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_canMove)
        {
            if (!this.remoteControl)
            {
                rb.velocity =
                    MovementSpeed * new Vector2(Input.GetAxis($"Horizontal_{PlayerId}"),
                        -Input.GetAxis($"Vertical_{PlayerId}")).normalized;

                if (Input.GetAxis($"Accelerate_{PlayerId}") > 0)
                {

                }

                if (Input.GetAxis($"Fire1_{PlayerId}") > 0)
                {

                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            if (Input.GetButton($"Brake_{PlayerId}"))
            {
                ClearModule();
            }
        }
    }
}
