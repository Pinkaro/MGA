using UnityEngine;

public class TouretteMovementModule : ModuleController
{
    
    public Transform transformToRotate;
    public Transform rotateAround;
    public float rotationSpeed;

    void Start()
    {
        if (transformToRotate == null)
        {
            transformToRotate = transform;
        }
    }


    protected override void Horizontal(float input)
    {
        Debug.Log("[TouretteModule] Move");
        transformToRotate.RotateAround(rotateAround.position, Vector3.forward, -input * rotationSpeed);
    }
}