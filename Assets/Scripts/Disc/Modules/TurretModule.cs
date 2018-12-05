using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretModule : ModuleController
{

    public Shootable shootable;
    public Transform transformToRotate;
    public Transform rotateAround;
    public float rotationSpeed;
    private float currentRotation;
    public float maximumRotation;

    void Start()
    {
        if (shootable == null)
        {
            shootable = GetComponent<Shootable>();
        }

        if (transformToRotate == null)
        {
            transformToRotate = transform;
        }
    }


    protected override void Horizontal(float input)
    {
        Debug.Log("[TurretModule] Move");
        var rota = currentRotation + (-input * rotationSpeed);
        if (rota < maximumRotation && rota > -maximumRotation)
        {
            currentRotation += -input * rotationSpeed;
            transformToRotate.RotateAround(rotateAround.position, Vector3.forward, -input * rotationSpeed);
        }
    }

    protected override void Fire1Press()
    {
        Debug.Log("[TurretModule] Shoot");
        shootable.Shoot();
    }
}
