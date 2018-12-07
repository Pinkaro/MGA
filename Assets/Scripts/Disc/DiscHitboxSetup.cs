using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscHitboxSetup : MonoBehaviour
{

    public int smothness = 8;
    private readonly float sizeMultiplier = 0.1f;

    void Start()
    {

        EdgeCollider2D collider = GetComponent<EdgeCollider2D>();

        List<Vector2> points = new List<Vector2>();

        Vector2 point;

        float angle;

        for (float i = 0; i <= smothness; i++)
        {
            angle = 2.0f * Mathf.PI / (float)smothness * i;
            //Debug.Log("Winkel: " + (angle * 180.0f / Mathf.PI));

            point = new Vector2(Mathf.Cos(angle) * sizeMultiplier, Mathf.Sin(angle) * sizeMultiplier);

            points.Add(point);
        }

        collider.points = points.ToArray();

        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<BoxCollider2D>();
        }
    }

}
