using System.Collections;
using UnityEngine;

public class TouretteShootingModule : ModuleController
{
    public Shootable shootable;
    private bool charging = false;
    private float chargeSize = 0;
    public float chargeIncreasePerSecond = 5;
    public float maximumCharge = 25;
    public float chargeThreshold = 3;
    
    protected override void Fire1Press()
    {
        if (charging == false)
        {
            Debug.Log("[TouretteModule] Start Charge");
            charging = true;
            StartCoroutine("Charge");
        }
    }

    protected override void Fire1Release()
    {
        
        charging = false;
        if (chargeSize > chargeThreshold)
        {
            Debug.Log($"[TouretteModule] Release Charge: Size {chargeSize}");
            shootable.Shoot(chargeSize, (chargeSize/maximumCharge)/ (maximumCharge/chargeSize));
        }
        chargeSize = 0;
    }

    IEnumerator Charge()
    {
        while (charging)
        {
            if (maximumCharge > chargeSize)
            {
                chargeSize += chargeIncreasePerSecond / 10;
                //Debug.Log($"[TouretteModule] Current Charge Size {chargeSize}");
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
