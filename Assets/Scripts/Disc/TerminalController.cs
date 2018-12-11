using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    public List<SpriteRenderer> spritesToDye;

    public ModuleController moduleController;
    
    private GameObject player;

    private bool registeredModule;

    private PlayerInDiscController _controller;

    // Use this for initialization
    void Start ()
	{
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (string.IsNullOrWhiteSpace(moduleController.Player))
        {
            player = other.gameObject;
            if (this.player != null)
            {
                _controller = this.player.GetComponent<PlayerInDiscController>();
            }
            if (this._controller != null)
            {
                this.registeredModule = _controller.RegisterModule(this, spritesToDye);
            }
        }
    }
}

