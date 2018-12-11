using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorModule : ModuleController
{
    public Transform transformToRotate;
    public Transform rotateAround;
    public float rotationSpeed;

    private bool firing;

    void Start()
    {
        if (transformToRotate == null)
        {
            transformToRotate = transform;
        }
    }

    protected override void Horizontal(float input)
    {
        transformToRotate.RotateAround(rotateAround.position, Vector3.forward, -input * rotationSpeed);
    }

    protected override void Fire1Press()
    {
        if (firing == false)
        {
            firing = true;
            StartCoroutine("Charge");
        }
    }

    protected override void Fire1Release()
    {

        firing = false;

    }

    IEnumerator Charge()
    {
        while (firing)
        {

            yield return new WaitForSeconds(0.1f);
        }
    }
}
