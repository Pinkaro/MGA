using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestModule : ModuleController {
    

    protected override void Horizontal(float input)
    {
        Vector3 dir = new Vector3();
        dir += new Vector3(input,0);
        transform.position += dir.normalized * movementSpeed * Time.deltaTime;
    }
}
