using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTentacleModule : ModuleController
{
    public Transform transformToRotate;
    public Transform rotateAround;
    public float rotationSpeed;
    public ParticleSystem TentacleSystem;

    protected override void Horizontal(float input)
    {
        Debug.Log("[SlowTentacleModule] Move");
        transformToRotate.RotateAround(rotateAround.position, Vector3.forward, -input * rotationSpeed);
    }

    protected override void Fire1Press()
    {
        Debug.Log("[SlowTentacleModule] Shoot");
        TentacleSystem.Play();
    }

    protected override void Fire1Release()
    {
        //Debug.Log("[SlowTentacleModule] Shoot stop");
        //TentacleSystem.Pause();
    }
}
