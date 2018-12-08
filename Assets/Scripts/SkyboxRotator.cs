using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{

    public float rotationSpeed;

	// Update is called once per frame
	void Update () {
	    RenderSettings.skybox.SetFloat("_Rotation", Time.time*rotationSpeed);
    }

    void OnDisable()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }
}
