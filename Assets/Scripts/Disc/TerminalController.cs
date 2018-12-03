using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : MonoBehaviour
{

    public GameObject Module;

    private ModuleController moduleController;

    private IEnumerator coroutine;

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
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (Input.GetKey(KeyCode.Escape)&&this.registeredModule)
	    {
	        this._controller.clearModule();
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
            this.registeredModule = _controller.RegisterModule(this.Module);
            coroutine = HandleTurretControls();
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("untriggered");
        if (this._controller != null)
        {
            this.registeredModule = false;
            _controller.clearModule();
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator HandleTurretControls()
    {
        while (true)
        {
            Debug.Log("staying triggered");
            //listen for exit key 
            yield return new WaitForSeconds(0.5f);
        }
        //as long as in there controls are used for turrent
    }

}        //one key to leave (steht oben press xy to leave)

