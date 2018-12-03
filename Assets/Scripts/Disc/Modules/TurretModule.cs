using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretModule : ModuleController
{

    public Shootable shootable;
    public Transform rotateAround;
    public float rotationSpeed;

    void Start()
    {
        shootable = GetComponent<Shootable>();
    }


    protected override void Horizontal(float input)
    {
        Debug.Log("[TurretModule] Move");
        transform.RotateAround(rotateAround.position, Vector3.forward, -input*rotationSpeed);
    }

    protected override void Fire1()
    {
        Debug.Log("[TurretModule] Shoot");
        shootable.Shoot();
    }
}
