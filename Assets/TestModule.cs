using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModule : ModuleController {
    protected override void Action()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector3.up;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir += Vector3.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir += Vector3.right;
        }

        if (dir != Vector3.zero)
        {
            transform.position += dir.normalized * movementSpeed * Time.deltaTime;
            dir = Vector3.zero;
        }
    }
}
