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

    private DiscMovement movement;

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
	        this.movement.clearModule();
	    }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRiGgEREd!!!!!!!!!!!!");
        player = other.gameObject;
        if (this.player != null)
        {
            movement = this.player.GetComponent<DiscMovement>();
        }
        if (this.movement != null)
        {
            this.registeredModule = movement.RegisterModule(this.Module);
            coroutine = HandleTurretControls();
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("untriggered");
        if (this.movement != null)
        {
            this.registeredModule = false;
            movement.clearModule();
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

