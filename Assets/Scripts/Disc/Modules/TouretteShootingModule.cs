using UnityEngine;

public class TouretteShootingModule : ModuleController
{
    public Shootable shootable;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void Fire1Press()
    {
        Debug.Log("[TouretteModule] Shoot");
        shootable.Shoot();
    }
}
