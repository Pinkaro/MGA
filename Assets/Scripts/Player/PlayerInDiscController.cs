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

    private List<SpriteRenderer> _previousModulColors;

    [HideInInspector]
    public bool _canMove = true;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _previousModulColors = new List<SpriteRenderer>();
    }

    public bool RegisterModule(ModuleController module, IEnumerable<SpriteRenderer> toDye)
    {
        this.remoteControl = true;
        if (module != null)
        {
            module.Player = PlayerId;
            moduleController = module;
            Color playerColor = GetComponent<SpriteRenderer>().color;
            _previousModulColors.Clear();

            foreach (SpriteRenderer spriteRender in toDye)
            {
                _previousModulColors.Add(spriteRender);
                spriteRender.color = playerColor;
            }

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

        foreach (SpriteRenderer spriteRenderer in _previousModulColors)
        {
            spriteRenderer.color = Color.white;
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
                clearModule();
            }
        }
    }
}
