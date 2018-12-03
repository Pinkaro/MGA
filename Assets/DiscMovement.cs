using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMovement : MonoBehaviour
{

    public float movementSpeed = 1.0f;

    private Vector3 dir;

    private bool remoteControl;

    private GameObject module;

    private ModuleController moduleController;

    // Use this for initialization
    void Start()
    {

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
    void Update()
    {
        if (!this.remoteControl)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                dir += Vector3.up;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                dir += Vector3.down;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dir += Vector3.left;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                dir += Vector3.right;
            }

            if (dir != Vector3.zero)
            {
                transform.position += dir.normalized * movementSpeed * Time.deltaTime;
                dir = Vector3.zero;
            }
        }
    }

    private void FixedUpdate()//todo put into better function
    {
        
        if(this.remoteControl)
        {
            this.moduleController.moving = true;
        }
    }
}
