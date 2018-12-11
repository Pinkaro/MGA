using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableWallModule : ModuleController {

    public Transform transformToRotate;
    public Transform rotateAround;
    public float rotationSpeed;
    public GameObject wall;

    private bool _isActive;
    private bool _wasReleased;
    private GameObject _createdWall;

    void Start()
    {

        if (transformToRotate == null)
        {
            transformToRotate = transform;
        }

        wall.SetActive(false);
    }

    protected override void Fire1Press()
    {
        if (_wasReleased)
        {
            if (_isActive)
            {
                RemoveWall();
            }
            else
            {
                CreateWall();
            }

            _wasReleased = false;
        }
    }
    protected override void Fire1Release()
    {
        _wasReleased = true;
    }

    protected override void Horizontal(float input)
    {
        Debug.Log("[MoveableWallModule] Move");
        transformToRotate.RotateAround(rotateAround.position, Vector3.forward, -input * rotationSpeed);
    }


    private void RemoveWall()
    {
        _createdWall.SetActive(false);
        Destroy(_createdWall);
        _isActive = false;
    }

    private void CreateWall()
    {
        _createdWall = Instantiate(wall,transform);
        _createdWall.SetActive(true);
        _createdWall.transform.SetParent(null);
        _isActive = true;
    }
}
