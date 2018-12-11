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

    private Sprite initialSprite;

    public Sprite ActivationSprite;

    private int collisionCounter;

    void Start()
    {
        initialSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionCounter++;

        if (string.IsNullOrWhiteSpace(moduleController.Player))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ActivationSprite;

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

    private void OnTriggerExit2D(Collider2D other)
    {
        collisionCounter--;

        if (collisionCounter == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = initialSprite;
        }
    }
}

