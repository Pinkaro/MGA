using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : MonoBehaviour
{

    public GameObject Module;

    private ModuleController moduleController;
    
    private GameObject player;

    private bool registeredModule;

    private PlayerInDiscController _controller;

    // Use this for initialization
    void Start ()
	{
	    if (this.Module != null)
	    {
	        this.moduleController = this.Module.GetComponent<ModuleController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRiGgEREd!!!!!!!!!!!!");
        player = other.gameObject;
        if (this.player != null)
        {
            _controller = this.player.GetComponent<PlayerInDiscController>();
        }
        if (this._controller != null)
        {
            this.registeredModule = _controller.RegisterModule(moduleController);
        }
    }
}

