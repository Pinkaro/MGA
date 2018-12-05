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
        Debug.Log("[TouretteModule] Start Charge");
        if (charging == false)
        {
            charging = true;
            StartCoroutine("Charge");
        }
    }

    protected override void Fire1Release()
    {
        
        charging = false;
        if (chargeSize > chargeThreshold)
        {
            //Debug.Log($"[TouretteModule] Release Charge: Size {chargeSize}");
            shootable.Shoot(chargeSize);
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
                Debug.Log($"[TouretteModule] Current Charge Size {chargeSize}");
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
