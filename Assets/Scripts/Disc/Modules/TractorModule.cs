  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorModule : ModuleController
{
    public Transform transformToRotate;
    public Transform rotateAround;
    public float rotationSpeed;

    public Transform Firepoint;

    public GameObject BeamBlueprint;

    public ParticleSystem TractorBeamBlueprint;

    private GameObject currentBeam;
    private ParticleSystem TractorBeam;

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
        if (currentBeam == null)
        {
            currentBeam = Instantiate(BeamBlueprint, Firepoint);
            currentBeam.transform.right = Firepoint.position - transform.position;

            TractorBeam = Instantiate(TractorBeamBlueprint, this.Firepoint);
        }
    }

    protected override void Fire1Release()
    {
        Destroy(currentBeam);
        currentBeam = null;
        Destroy(TractorBeam);
        TractorBeam = null;
    }
}
